﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using scripthea.viewer;
using UtilsNS;
using Path = System.IO.Path;
using System.Drawing;
using Brushes = System.Windows.Media.Brushes;
using System.Drawing.Imaging;

namespace scripthea.external
{
    /// <summary>
    /// Interaction logic for CraiyonImportUC.xaml
    /// </summary>
    public partial class ImportUtilUC : UserControl
    {
        DataTable dTable; 
        public ImportUtilUC()
        {
            InitializeComponent();
        }
        public void Init()
        {
            dTable = new DataTable();
            dTable.Columns.Add(new DataColumn("on", typeof(bool)));
            dTable.Columns.Add(new DataColumn("file", typeof(string)));

            tcMain.SelectedIndex = 1;
        }
        public void BindData()
        {
            Binding binding = new Binding("."); //ItemsSource="{Binding Path=., Mode=TwoWay}"  SourceUpdated="OnTargetUpdated"
            binding.BindsDirectlyToSource = true;           
            binding.Mode = BindingMode.TwoWay; 
            binding.Source = dTable;
            //binding.NotifyOnSourceUpdated = true;
            dGrid.SetBinding(DataGrid.ItemsSourceProperty, binding);
        }
        private void OnTargetUpdated(Object sender, DataTransferEventArgs args)
        {

        }
        private string _imageFolder;
        public string imageFolder
        {
            get
            {
                if (Directory.Exists(tbImageDepot.Text)) _imageFolder = tbImageDepot.Text;
                else _imageFolder = ImgUtils.defaultImageDepot;
                return _imageFolder.EndsWith("\\") ? _imageFolder : _imageFolder + "\\";
            }
            set
            {
                _imageFolder = value; tbImageDepot.Text = value;
            }
        }
        public event Utils.LogHandler OnLog;
        protected void Log(string txt, SolidColorBrush clr = null)
        {
            if (OnLog != null) OnLog(txt, clr);
            else Utils.TimedMessageBox(txt);
        }
        public void btnNewFolder_Click(object sender, RoutedEventArgs e)
        {
            if (!Utils.isNull(sender))
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = imageFolder;
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    tbImageDepot.Text = dialog.FileName; 
                }
            }
            LoadImages(imageFolder);
        }
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        public void LoadImages(string path)
        {
            if (!Utils.comparePaths(imageFolder, path)) depotFolder = null; // new folder
            if (!Directory.Exists(path))
            {
                Log("Err: Directory <" + imageFolder + "> does not exist. "); return;
            }
            else imageFolder = path;
            List<string> orgFiles = new List<string>();            
            if (Utils.isNull(depotFolder))
            {               
                if (ImgUtils.checkImageDepot(path, true) > -1) depotFolder = new DepotFolder(path, ImageInfo.ImageGenerator.FromDescFile);
                else orgFiles = new List<string>(Directory.GetFiles(imageFolder, "*.png"));
            }
            if (!Utils.isNull(depotFolder)) orgFiles = depotFolder.Extras();     
            if (orgFiles.Count.Equals(0)) { Log("No image files to consider in " + path); return; }
            switch (tcMain.SelectedIndex)
            {
                case 0: //tiList - redundant
                    lstFiles.Items.Clear(); 
                    foreach (string ss in orgFiles)
                    {
                        CheckBox chk = new CheckBox(); chk.Content = System.IO.Path.GetFileName(ss); chk.IsChecked = true;
                        lstFiles.Items.Add(chk);
                    }
                    btnConvertFolder.IsEnabled = lstFiles.Items.Count > 0;
                    break;
                case 1: //tiGrid
                    dTable.Rows.Clear();
                    foreach (string ss in orgFiles)
                        dTable.Rows.Add(true, System.IO.Path.GetFileName(ss));
                    BindData();
                    //dGrid.ItemsSource = dTable.DefaultView;
                    if (dTable.Rows.Count > 0) dGrid.SelectedIndex = 0;
                    btnConvertFolder.IsEnabled = dTable.Rows.Count > 0;
                    break;
                default:
                    Log("Error: intrernal error 23");
                    break;
            }
            checkBoxes.Clear();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                CheckBox chk = DataGridHelper.GetCellByIndices(dGrid, i, 0).FindVisualChild<CheckBox>();
                chk.Name = "chkList" + i.ToString();
                chk.Tag = i;
                //chk.Checked += new RoutedEventHandler(CheckUncheck); chk.Unchecked += new RoutedEventHandler(CheckUncheck);
                checkBoxes.Add(chk);
            }
            GetChecked();
        }
       
        private List<string> GetChecked(bool print = true)
        {
            int sr = lastSelectedRow; bool cc = false; //dGrid.SelectedIndex
            if (Utils.InRange(sr, 0, dTable.Rows.Count - 1))
            {
                CheckBox chk = DataGridHelper.GetCellByIndices(dGrid, sr, 0).FindVisualChild<CheckBox>();
                cc = chk.IsChecked.Value; 
                dTable.Rows[sr]["on"] = chk.IsChecked.Value;
            }            
            List<string> ls = new List<string>();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dTable.Rows[i]["on"]))
                    ls.Add(Convert.ToString(dTable.Rows[i]["file"]));
            }
            if (print)
                lbChecked.Content = ls.Count.ToString() + " out of " + dTable.Rows.Count.ToString(); //+ (cc ? " X": " O"); //"+ sr.ToString() +"
            return ls;
        }

        private List<string> SplitFilename(string fn, char sep) // pattern <txt><sep><txt><sep><cue><ext>
        {
            var ls = new List<string>();
            string[] spl = fn.Split(sep);
            if (spl.Length < 3) return ls;
            ls.Add(spl[0]); 
            ls.Add(spl[1]+Utils.randomString(9-spl[1].Length,true));
            string ext = System.IO.Path.GetExtension(fn);
            string fnn = System.IO.Path.ChangeExtension(fn, null); // no ext            
            ls.Add(fnn.Substring(spl[0].Length + spl[1].Length + 2)); // cue
            ls.Add(ext);
            return ls;
        }  
        private bool DecodeFilename(string filename, out string newFile, out string cue)
        {
            newFile = ""; cue = ""; List<string> ls; 
            if (filename.StartsWith("craiyon"))
            {
                ls = SplitFilename(filename, '_');
                if ((ls.Count < 4) || !ls[0].Equals("craiyon")) return false;
                if (!Utils.isNumeric(ls[1])) return false;
                newFile = System.IO.Path.ChangeExtension("c-" + ls[1], ls[3]);
                cue = ls[2];
            }
            else // Stable Diffusion
            {
                Utils.TimedMessageBox("Error: no implementation");
            }
            return true;
        }
        public bool converting = false; DepotFolder depotFolder =null;
        private void btnConvertFolder_Click(object sender, RoutedEventArgs e)
        {       
            if (dTable.Rows.Count == 0) return; int k = 0; converting = true;
            image.Source = new BitmapImage(new Uri(Path.Combine(Utils.configPath, "file_not_found.jpg"))); image.UpdateLayout();
            
            if (Utils.isNull(depotFolder))
                depotFolder = new DepotFolder(imageFolder, ImageInfo.ImageGenerator.StableDiffusion);
            try
            {
                GetChecked();
                List<string> unchk = new List<string>();                 
                foreach (DataRow row in dTable.Rows)
                {
                    string efn = Convert.ToString(row["file"]);
                    if (!Convert.ToBoolean(row["on"]))
                    {
                        unchk.Add(efn); continue;
                    }
                    ImageInfo ii = new ImageInfo(Path.Combine(imageFolder, efn), ImageInfo.ImageGenerator.StableDiffusion, chkKeepNames.IsChecked.Value);
                    if (!ii.IsAvailable()) continue;
                    depotFolder.infos.Add(ii);                   
                    k++;
                }
                depotFolder.Save();
                if (chkDeleteUnchecked.IsChecked.Value)
                {
                    foreach(string fn in unchk)
                    {
                        File.Delete(Path.Combine(imageFolder, fn));
                    }
                }
            }
            finally
            {
                LoadImages(imageFolder);
                Log("Done! Image depot of " + k.ToString() + " images was created.", Brushes.DarkGreen); 
                converting = false;
            }            
        }
        private void dGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var col = e.Column as DataGridTextColumn; if (Utils.isNull(col)) return;
            switch (e.Column.Header.ToString())
            {                
                case ("on"):
                    col.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                    break;
                case ("file"):
                    var style = new Style(typeof(TextBlock));
                    style.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
                    style.Setters.Add(new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center));                   
                    col.ElementStyle = style;
                    col.IsReadOnly = true;
                    col.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
            }
        }
        int lastSelectedRow = -1;
        private void dGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (converting) return;
            DataRowView dataRow = (DataRowView)dGrid.SelectedItem;
            if (Utils.isNull(dataRow)) return;
            dGrid.Dispatcher.InvokeAsync(() =>
            {
                dGrid.UpdateLayout();
                dGrid.ScrollIntoView(dGrid.SelectedItem, null);
            });
            string fn = System.IO.Path.Combine(imageFolder,System.IO.Path.ChangeExtension(Convert.ToString(dataRow.Row.ItemArray[1]), ".png"));
            if (File.Exists(fn)) image.Source = ImgUtils.UnhookedImageLoad(fn, ImageFormat.Png);
            else Log("Error: file not found-> " + fn);
            if (!Utils.isNull(e)) e.Handled = true;
            // int sr = dGrid.SelectedIndex; 
            // TextBlock textBlock = DataGridHelper.GetCellByIndices(dGrid, sr, 1).FindVisualChild<TextBlock>();
            GetChecked();
            lastSelectedRow = dGrid.SelectedIndex;
        }

        private void textBlock_KeyDown(object sender, KeyEventArgs e)
        {
            int sr = dGrid.SelectedIndex; 
            if (e.Key.Equals(Key.Space) && Utils.InRange(sr, 0, checkBoxes.Count - 1))
            {
                var chk = DataGridHelper.GetCellByIndices(dGrid, sr, 0).FindVisualChild<CheckBox>();
                chk.IsChecked = !chk.IsChecked.Value;   
            }                
        }  

        private void tbImageDepot_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ImgUtils.checkImageDepot(tbImageDepot.Text,false) > 0) tbImageDepot.Foreground = Brushes.Black;
            else tbImageDepot.Foreground = Brushes.Red;
        }

        private void chkDeleteUnchecked_Checked(object sender, RoutedEventArgs e)
        {
            chkDeleteUnchecked.Foreground = Brushes.Red;
        }

        private void chkDeleteUnchecked_Unchecked(object sender, RoutedEventArgs e)
        {
            chkDeleteUnchecked.Foreground = Brushes.Black;
        }

        private readonly string[] miTitles = { "Check All", "Uncheck All", "Invert Checking" };
        private void imgMenu_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {            
            cmCue.Items.Clear();
            for (int i = 0; i < 3; i++)
            {
                MenuItem mi = new MenuItem() { Name = "mi" + i.ToString(), Header = miTitles[i] };
                if (i == 2) mi.FontWeight = FontWeights.Bold;
                mi.Click += mi_Click;
                cmCue.Items.Add(mi);
            }
        }
        private void mi_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem; string header = Convert.ToString(mi.Header);
            foreach (DataRow dr in dTable.Rows)
            {
                switch (header)
                {
                    case "Check All":
                        dr["on"] = true;
                        break;
                    case "Uncheck All":
                        dr["on"] = false;
                        break;
                    case "Invert Checking":
                        dr["on"] = !Convert.ToBoolean(dr["on"]);
                        break;
                }
            }
            GetChecked();
        }
        private void imgMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                foreach (DataRow dr in dTable.Rows) 
                    dr["on"] = !Convert.ToBoolean(dr["on"]);
            }
            GetChecked();
        }

        private void MCheckUncheck(object sender, MouseButtonEventArgs e)
        {
            GetChecked();
        }
    }
}
