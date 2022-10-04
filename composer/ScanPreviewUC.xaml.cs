﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using UtilsNS;

namespace scripthea.composer
{
    /// <summary>
    /// Interaction logic for ScanPreviewUC.xaml
    /// </summary>
    public partial class ScanPreviewUC : UserControl
    {
        public ScanPreviewUC()
        {
            InitializeComponent();
        }
        public delegate void LogHandler(string txt, SolidColorBrush clr = null);
        public event LogHandler OnLog;
        protected void Log(string txt, SolidColorBrush clr = null)
        {
            if (OnLog != null) OnLog(txt, clr);
            else Utils.TimedMessageBox(txt);
        }

        DataTable dTable;
        public void LoadPrompts(List<string> prompts)
        {
            if (prompts.Count == 0)
            {
                Log("Error: no prompts in the list"); return;
            }
            dTable = new DataTable();
            dTable.Columns.Add(new DataColumn("#", typeof(int)));
            dTable.Columns.Add(new DataColumn("On", typeof(bool)));
            dTable.Columns.Add(new DataColumn("Prompt", typeof(string)));
            for (int i = 0; i < prompts.Count; i++)
                dTable.Rows.Add(i + 1, true, prompts[i]);
            dGrid.ItemsSource = dTable.DefaultView; lbCheckCount.Content = "Checked: " + prompts.Count.ToString();
            if (!this.IsVisible) return;
            Utils.DoEvents(); 
            for (int i = 0; i < prompts.Count; i++)
            {
                CheckBox chk = DataGridHelper.GetCellByIndices(dGrid, i, 1).FindVisualChild<CheckBox>();
                if (Utils.isNull(chk)) continue;
                chk.Checked += new RoutedEventHandler(chkTable_Checked); chk.Unchecked += new RoutedEventHandler(chkTable_Checked);
            }                            
            if (dTable.Rows.Count > 0) dGrid.SelectedIndex = 0;
        }
        private bool _scanning = false;
        public bool scanning
        {
            get
            {
                return _scanning;
            }
            set
            {
                if (value)
                {
                    btnScanChecked.Content = "Cancel Scan";
                    btnQuerySelected.IsEnabled = false; btnClose.IsEnabled = false;
                    btnScanChecked.Background = Brushes.Coral;
                }
                else
                {
                    btnScanChecked.IsEnabled = true; btnScanChecked.Content = "Scan All Checked";
                    btnQuerySelected.IsEnabled = true; btnClose.IsEnabled = true;
                    btnScanChecked.Background = Brushes.MintCream;
                }
                _scanning = value;
            }
        }
        private void chkTable_Checked(object sender, RoutedEventArgs e)
        {
            lbCheckCount.Content = "Checked: " + checkedPrompts().Count.ToString();
        }        
        private void dGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var col = e.Column as DataGridTextColumn; if (Utils.isNull(col)) return;
            switch (e.Column.Header.ToString())
            {
                case ("#"):
                case ("On"):
                    col.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                    break;
                case ("Prompt"):
                    var style = new Style(typeof(TextBlock));
                    style.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
                    style.Setters.Add(new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center));
                    col.ElementStyle = style;
                    col.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
            }
        }
        private string _selectedPrompt = "";
        public string selectedPrompt
        {
            get { return _selectedPrompt; }
            set { _selectedPrompt = value; btnQuerySelected.IsEnabled = !value.Equals(""); }
        }
        private void dGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (converting) return;
            DataRowView dataRow = null; ;
            try
            {
               dataRow = (DataRowView)dGrid.SelectedItem;
            }
            catch(System.InvalidCastException ex) { selectedPrompt = ""; }
            if (Utils.isNull(dataRow)) return;
            selectedPrompt = Convert.ToString(dataRow.Row.ItemArray[2]);
        }
        public List<string> checkedPrompts()
        {
            List<string> ls = new List<string>();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                CheckBox chk = DataGridHelper.GetCellByIndices(dGrid, i, 1).FindVisualChild<CheckBox>();
                if (Utils.isNull(chk)) continue;
                if (chk.IsChecked.Value)
                    ls.Add(Convert.ToString(dTable.Rows[i]["Prompt"]));
            }
            return ls;
        }
        public void selectByPropmt(string pr)
        {
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                TextBlock tb = DataGridHelper.GetCellByIndices(dGrid, i, 2).FindVisualChild<TextBlock>();
                if (Utils.isNull(tb)) continue; //if (chk.IsChecked.Value) ls.Add(Convert.ToString(dTable.Rows[i]["Prompt"]));
                if (tb.Text.Equals(pr))
                {
                    dGrid.SelectedIndex = i; dGrid.Focus();
                    btnQuerySelected.IsEnabled = !scanning; return;
                }
            }
        }
    }
}
