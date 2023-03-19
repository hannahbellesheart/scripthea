﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using scripthea.master;
using UtilsNS;
using Path = System.IO.Path;
using Newtonsoft.Json;

namespace scripthea.viewer 
{
    public class ImageInfo
    {
        public enum ImageGenerator { StableDiffusion, Crayion, FromDescFile}       
        public ImageInfo()
        {

        }
        public ImageInfo(string fullfilename, ImageGenerator imageGenerator, bool keepName) 
        {
            filename = "";
            if (!File.Exists(fullfilename)) return;
            string suggestedName = ""; bool bb;
            switch (imageGenerator) 
            {
                case ImageGenerator.StableDiffusion:
                    bb = FromSDFile(fullfilename, out suggestedName); 
                    if (!bb) 
                    {
                        FromSDFile(fullfilename, out suggestedName); return; // when it is not SD file
                    }                       
                    break;
                case ImageGenerator.Crayion:
                    if (!FromCraiyonFile(fullfilename, out suggestedName)) return;
                    break;
            }
            if (keepName) { filename = Path.GetFileName(fullfilename); return; } 
            try
            {
                if (!fullfilename.Equals(suggestedName, StringComparison.InvariantCultureIgnoreCase))
                {
                    File.Move(fullfilename, suggestedName); // Rename the oldFileName into newFileName                    
                }             
                filename = Path.GetFileName(suggestedName);       
            }
            catch (System.IO.IOException IOe) { Utils.TimedMessageBox("Error: (" + System.IO.Path.GetFileName(fullfilename) + ") " + IOe.Message);  }
        }
        public bool IsAvailable() { return !filename.Equals(""); } // file hasn't been assinged
        private List<string> SplitFilename(string fn, char sep) // pattern <txt><sep><txt><sep><cue><ext>
        {
            var ls = new List<string>();
            string[] spl = fn.Split(sep);
            if (spl.Length < 3) return ls;
            ls.Add(spl[0]);
            ls.Add(spl[1] + Utils.randomString(9 - spl[1].Length, true));
            string ext = System.IO.Path.GetExtension(fn);
            string fnn = System.IO.Path.ChangeExtension(fn, null); // no ext            
            ls.Add(fnn.Substring(spl[0].Length + spl[1].Length + 2)); // cue
            ls.Add(ext);
            return ls;
        }

        public ImageInfo(string json)
        {
            FromString(json);
        }
        public ImageInfo(Dictionary<string, string> dict)
        {
            FromDictionary(dict);
        }
        public string prompt { get; set; }        
        public int steps { get; set; }
        public string sampler { get; set; }
        public int scale { get; set; }
        public long seed { get; set; }
        public string size { get; set; }
        public string ModelHash { get; set; }
        public string filename { get; set; } // without folder
        public string MD5Checksum { get; set; } 
        public string history { get; set; } // stages of variations, '|' separated -> for future use

        public bool IsEnabled() { return !filename.Equals(""); }
        public bool IsModified(string folder) // check if recorded MD5 is egual to MD5 of the image file
        {
            string ffn = Path.Combine(folder, filename);
            if (!File.Exists(ffn)) return false;
            return MD5Checksum.Equals(ffn);
        }
        public int Width()
        {
            string[] sa = size.Split('x');
            if (sa.Length != 2) return -1;
            return Convert.ToInt32(sa[0]);
        }
        public int Height()
        {
            string[] sa = size.Split('x');
            if (sa.Length != 2) return -1;
            return Convert.ToInt32(sa[1]);
        }
        public void historyAdd(string txt)
        {
            string tx = txt.Replace('|', '_');
            if (history.Equals("")) history = tx;
            else history += '|' + tx;
        }
        public List<string> historyLog()
        {
            return new List<string>(history.Split('|'));
        }
        public bool FromSDFile(string fullfilename, out string suggestedName) // true if it's there and it's sd image 
        {
            suggestedName = ""; // with folder
            if (!File.Exists(fullfilename)) return false;
            filename = Path.GetFileName(fullfilename);
            MD5Checksum = Utils.GetMD5Checksum(fullfilename);
            history = "";

            Dictionary<string, string> meta;
            bool sd = ImgUtils.GetMetaDataItems(fullfilename, out meta);
            if (sd) sd &= FromDictionary(meta);
            if (!sd) { filename = ""; return false; }

            // suggest a name
            List<string> ls = SplitFilename(filename, '-'); 
            if (ls.Count >= 4) 
            {
                if (Utils.isNumeric(ls[0]) && Utils.isNumeric(ls[1])) // check pattern
                    suggestedName = System.IO.Path.ChangeExtension("SD-" + ls[1], ls[3]);                 
            }
            bool sf = false;  
            if (suggestedName == "")
            {
                sf = filename.StartsWith("SD-"); // file is there (previous import)
                suggestedName = sf ? filename : "SD-" + filename; 
            }
            suggestedName = System.IO.Path.Combine(Path.GetDirectoryName(fullfilename), suggestedName); // complete with folder
            if (sd && !sf) // pattern or not, meta data is there
                suggestedName = Utils.AvoidOverwrite(suggestedName);            
            return sd;
        }
        public bool FromCraiyonFile(string fullfilename, out string suggestedName) // true if it's there and it's sd image 
        {
            suggestedName = "";
            if (File.Exists(fullfilename)) return false;
            return true;
        }
        public bool FromString(string json)
        {
            ImageInfo ii = JsonConvert.DeserializeObject<ImageInfo>(json);
            prompt = ii.prompt; steps = ii.steps; sampler = ii.sampler; scale = ii.scale; seed = ii.seed; size = ii.size; ModelHash = ii.ModelHash;
            filename = ii.filename; MD5Checksum = ii.MD5Checksum; history = ii.history;
            return true;
        }
        public string To_String()
        {
            return JsonConvert.SerializeObject(this);
        }
        public bool FromDictionary(Dictionary<string,string> dict) 
        {
            if (dict.ContainsKey("prompt")) prompt = dict["prompt"];
            if (dict.ContainsKey("steps")) steps = Convert.ToInt32(dict["steps"]);
            if (dict.ContainsKey("sampler")) sampler = dict["sampler"];
            if (dict.ContainsKey("scale")) scale = Convert.ToInt32(dict["scale"]);
            if (dict.ContainsKey("seed")) seed = Convert.ToInt64(dict["seed"]);
            if (dict.ContainsKey("size")) size = dict["size"];
            if (dict.ContainsKey("ModelHash")) ModelHash = dict["ModelHash"];
            if (dict.ContainsKey("filename")) filename = dict["filename"];
            if (dict.ContainsKey("MD5Checksum")) MD5Checksum = dict["MD5Checksum"];             
            if (dict.ContainsKey("history")) history = dict["history"];
            else history = "";
            return true;
        }
        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("prompt", prompt); dict.Add("steps", steps.ToString()); dict.Add("sampler",sampler); dict.Add("scale", scale.ToString()); 
            dict.Add("seed", seed.ToString()); dict.Add("size", size); dict.Add("ModelHash", ModelHash); dict.Add("filename", filename); 
            dict.Add("MD5Checksum", MD5Checksum); dict.Add("history", history); 
            return dict;
        }
        // clone 1. target.FromString(source.To_String())
        //       2. target.FromDictionary(Source.ToDictionary())
    }
    public class DepotFolder
    {
        public DepotFolder(string _folder, ImageInfo.ImageGenerator _imageGenerator = ImageInfo.ImageGenerator.FromDescFile, bool _IsReadOnly = false) 
        {
            if (!Directory.Exists(_folder)) return; isReadOnly = _IsReadOnly;
            header = new Dictionary<string, string>(); items = new List<ImageInfo>();

            if (_imageGenerator == ImageInfo.ImageGenerator.FromDescFile) // read type from file
            {
                string desc = Path.Combine(_folder, ImgUtils.descriptionFile);
                if (File.Exists(desc))
                {
                    List<string> body = Utils.readList(desc,false);
                    if (body.Count == 0) return;
                    if (body[0].StartsWith("#"))
                    {
                        header = JsonConvert.DeserializeObject<Dictionary<string, string>>(body[0].Substring(1));
                        body.RemoveAt(0);
                        if (header.ContainsKey("ImageGenerator"))
                            foreach (ImageInfo.ImageGenerator ig in Enum.GetValues(typeof(ImageInfo.ImageGenerator)))
                            {
                                if (ig.Equals(header["ImageGenerator"])) imageGenerator = ig;
                            }
                    }
                    foreach (string ss in body)
                        items.Add(new ImageInfo(ss));
                }
            }
            else
            {
                imageGenerator = _imageGenerator; header.Add("ImageGenerator", imageGenerator.ToString());
                header.Add("webui", "AUTOMATIC1111"); header.Add("application", "Scripthea " + Utils.getAppFileVersion);
            }
            path = _folder;
        }
        public bool isEnabled
        {
            get { return !Utils.isNull(header) && !Utils.isNull(items); }
        }
        public bool isReadOnly { get; private set; }
        public Dictionary<string, string> header;
        public List<ImageInfo> items;
        public bool RemoveAt(int idx, bool inclFile)
        {
            if (!isEnabled) return false;
            if (!Utils.InRange(idx, 0, items.Count - 1)) return false; 
            if (inclFile)
            {
                string fn = Path.Combine(path, items[idx].filename);
                if (!File.Exists(fn)) return false;
                File.Delete(fn);
            }
            items.RemoveAt(idx);
            return true;
        }
        public DepotFolder VirtualClone(string targetPath, List<Tuple<int,string,string>> filter = null) // int -> index; string -> filename (may differ); string -> prompt (for consistency)
        {
            if (!Directory.Exists(targetPath)) return null;
            DepotFolder dp = new DepotFolder(targetPath, imageGenerator, isReadOnly);
            if (Utils.isNull(filter)) dp.items.AddRange(items);
            else
            {
                foreach (var itm in filter)
                {
                    ImageInfo ii = items[itm.Item1 - 1];
                    if (ii.prompt != itm.Item3) { Utils.TimedMessageBox("Error: broken filter"); break; }
                    ii.filename = itm.Item2; 
                    dp.items.Add(ii);
                }
            } 
            return dp;
        }
        public List<string> allImages() // in this folder 
        {
            List<string> pngs = new List<string>(Directory.GetFiles(path, "*.png"));
            List<string> jpgs = new List<string>(Directory.GetFiles(path, "*.jpg"));
            pngs.AddRange(jpgs);
            for (int i = 0; i < pngs.Count; i++)
                pngs[i] = Path.GetFileName(pngs[i]);
           return new List<string>(pngs);
        }
        public bool fileMatch(List<string> imgs, out int idxFile, out int idxII) // found match within imgs and items[*].filename
        {
            bool found = false; idxFile = -1; idxII = -1;
            for (int i = 0; i < imgs.Count; i++)
            {            
                for (int j = 0; j <  items.Count; j++)
                {
                    found = items[j].filename.Equals(imgs[i], StringComparison.InvariantCultureIgnoreCase);
                    if (found) { idxFile = i; idxII = j; break; }
                }
                if (found) break;
            }
            return found;
        }
        public List<string> Extras()
        {
            List<string> imgs = allImages();
            int idxFile; int idxII; bool fnd;
            do
            { 
                fnd = fileMatch(imgs, out idxFile, out idxII); 
                if (fnd) imgs.RemoveAt(idxFile);
            } while (fnd);
            return new List<string>(imgs);
        } 
        public string path { get; private set; }
        public ImageInfo.ImageGenerator imageGenerator { get; private set; }
        public bool Validate(bool? correctEntry) // argument: if correctEntry is null ask user
               // return true: if no mismatched entries (OK depot) OR if correctEntry and file is missing then entries are deleted
               // return false: there were missing files with not-corrected entries (unfinished business)
        {
            List<string> allImgs = allImages(); // from the folder
            bool ok = true;
            /*int idxFile; int idxII; bool fnd;
            do { fnd = fileMatch(allImgs, out idxFile, out idxII); } while (fnd);*/
            int i = 0; int itemsCount = items.Count; 
            while (i < items.Count)
            {
                bool found = false; 
                foreach (string img in allImgs)
                {
                    found = items[i].filename.Equals(img, StringComparison.InvariantCultureIgnoreCase);
                    if (found) break;  
                }
                if (!found)
                {
                    if (correctEntry == null)
                    {
                        //Configure the message box
                        var messageBoxText =
                            "Image depot entry <"+ items[i].filename+ "> has no corresponding image file.\rClick \"Yes\" to correct entry list, \"No\" to skip this correction, or \"Cancel\" to exit validation.";
                        // Display message box
                        var messageBoxResult = MessageBox.Show(messageBoxText, "Image Depot Validation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                        // Process message box results
                        switch (messageBoxResult)
                        {
                            case MessageBoxResult.Yes: // correct entry list
                                items.RemoveAt(i); found = true; continue;                                
                            case MessageBoxResult.No: // skip this correction
                                break;
                            case MessageBoxResult.Cancel: // exit validation
                                return false;                                
                        }
                    }
                    else
                    {
                        if (Convert.ToBoolean(correctEntry)) { items.RemoveAt(i); continue; }
                    }                    
                }
                i++; ok &= found;
            }
            if (itemsCount != items.Count)
            {
                Save(true); Utils.TimedMessageBox((itemsCount - items.Count).ToString()+" image depot entries have been removed", "Warining", 3000);
            }
            return ok;
        }
        public void Append(ImageInfo ii)
        {
            if (isReadOnly) return;
            using (StreamWriter w = File.AppendText(Path.Combine(path, ImgUtils.descriptionFile)))
            {
                w.WriteLine(ii.To_String());
            }
            items.Add(ii);
        }
        public void Save(bool forced = false)
        {
            if (!forced)
                if (isReadOnly) return;
            List<string> ls = new List<string>();
            ls.Add("#"+ JsonConvert.SerializeObject(header));
            foreach (ImageInfo ii in items)
                ls.Add(ii.To_String());
            //Utils.DelayExec(20, new Action(() => {  }));       
            Utils.writeList(Path.Combine(path, ImgUtils.descriptionFile), ls);
            Utils.Sleep(200);
        }
        public List<Tuple<int, string, string>> Export2Viewer()
        {
            List<Tuple<int, string, string>> lst = new List<Tuple<int, string, string>>();
            for (int i = 0; i < items.Count; i++)
                lst.Add(new Tuple<int, string, string>(i+1, items[i].filename, items[i].prompt));
            return lst;
        }
    }
    interface iPicList
    {
        void Init(ref Options _opts, bool _checkable);
        void Finish();
        bool IsAvailable { get; }
        DepotFolder iDepot { get; set; }
        string loadedDepot { get; set; }
        bool FeedList(string imageFolder); // the way to load the list
        bool FeedList(ref DepotFolder _iDepot); // external iDepot; regular use
        void UpdateVis(); // update visual from iDepot
        void SynchroChecked(List<Tuple<int, string, string>> chks);
        void SetChecked(bool? check); // if null invert; returns checked
        void Clear(bool inclDepotItems = false);
        int selectedIndex { get; set; } // one based index in no-checkable mode
        int Count { get; }
        List<Tuple<int, string, string>> GetItems(bool check, bool uncheck); // idx, filename, prompt
    }
    /// <summary>
    /// Interaction logic for ViewerUC.xaml
    /// </summary>
    public partial class ViewerUC : UserControl, iFocusControl
    {       
        public ViewerUC()
        {
            InitializeComponent();
            views = new List<iPicList>(); 
            views.Add(tableViewUC); tableViewUC.SelectEvent += new TableViewUC.PicViewerHandler(picViewerUC.loadPic); 
            views.Add(gridViewUC);  gridViewUC.SelectEvent += new GridViewUC.PicViewerHandler(picViewerUC.loadPic); 
        }
        private DepotFolder iDepot;
        iPicList activeView { get { return views[tabCtrlViews.SelectedIndex]; } }
        private DispatcherTimer timer;
        private Options opts;
        public void Init(ref Options _opts) // ■▬►
        {
            opts = _opts;
            chkAutoRefresh.IsChecked = opts.Autorefresh; imageFolder = opts.ImageDepotFolder; 
            colListWidth.Width = new GridLength(opts.ViewColWidth);
            foreach (iPicList ipl in views)
                ipl.Init(ref opts, false);            
        }
        public void Finish()
        {
            opts.ViewColWidth = Convert.ToInt32(colListWidth.Width.Value);
            opts.Autorefresh = chkAutoRefresh.IsChecked.Value;
            foreach (iPicList ipl in views)
                ipl.Finish();
        }
        public UserControl parrent { get { return this; } }
        public GroupBox groupFolder { get { return gbFolder; } }
        public TextBox textFolder { get { return tbImageDepot; } }

        private string _imageFolder;
        public string imageFolder
        {
            get
            {
                if (Directory.Exists(tbImageDepot.Text)) _imageFolder = tbImageDepot.Text;
                else _imageFolder = ImgUtils.defaultImageDepot;
                return _imageFolder.EndsWith("\\") ? _imageFolder: _imageFolder + "\\";
            }
            set
            {
                _imageFolder = value;  tbImageDepot.Text = value;
            }
        }
        
        public event Utils.LogHandler OnLog;
        protected void Log(string txt, SolidColorBrush clr = null)
        {
            if (OnLog != null) OnLog(txt, clr);
        }
        public int RemoveSelected(bool inclFile = false)
        {
            string ss = inclFile ? "and file" : ""; bool anim = animation; animation = false;
            Log("Deleting image #" + activeView.selectedIndex.ToString()+ " entry "+ ss, Brushes.Tomato);
            if (iDepot == null) { Log("no active image depot found"); return -1; }
            if (!iDepot.isEnabled) { Log("current image depot - not active"); return -1; }
            int idx = activeView.selectedIndex - 1;
            if (!Utils.InRange(idx, 0, iDepot.items.Count - 1)) { Log("index out of limits"); return -1; }                           
            if (iDepot.RemoveAt(idx, inclFile)) iDepot.Save();
            else { Log("Unsuccessful delete operation"); return -1; }
            btnRefresh_Click(null, null);
            if (!iDepot.isEnabled) { Log("current image depot - not active"); return -1; }
            activeView.selectedIndex = Utils.EnsureRange(idx + 1, 1, iDepot.items.Count);
            if (anim) animation = true;
            //if (tabCtrlViews.SelectedIndex == 0) 
            return idx;
        } 
        public void Clear() 
        {
            activeView.Clear(); picViewerUC.Clear();
        }
        private bool updating = false; private bool showing = false;
        public void ShowImageDepot(string imageDepot)
        {
            if (updating) return;
            updating = true;
            tbImageDepot.Text = imageDepot; 
            tbImageDepot_TextChanged(null, null);
            updating = false; showing = true;
        }
        List<iPicList> views;
        
        private void btnFindUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tabCtrlViews.SelectedIndex.Equals(0)) tableViewUC.SortTableByIndex();
            int k = sender.Equals(btnFindUp) ? -1 : 1;
            if (activeView.selectedIndex.Equals(-1)) activeView.selectedIndex = 1;
            int idx = activeView.selectedIndex + k - 1;
            List<Tuple<int, string, string>> items = activeView.GetItems(true,true);
            while (idx > -1 && idx < items.Count)
            {
                string prompt = Convert.ToString(items[idx].Item3);
                if ((prompt.IndexOf(tbFind.Text) > -1) || tbFind.Text.Equals(""))
                {
                    activeView.selectedIndex = idx+1; break;
                }
                idx += k;
            }
        }
        private int checkImageDepot(string folder)
        {
            int cnt = ImgUtils.checkImageDepot(tbImageDepot.Text);
            if (cnt > 0) { lbDepotInfo.Content = cnt.ToString() + " images"; lbDepotInfo.Foreground = Brushes.Blue; }
            else { lbDepotInfo.Content = "This is not an image depot."; lbDepotInfo.Foreground = Brushes.Tomato; }
            return cnt;
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e) 
        { 
            if (checkImageDepot(tbImageDepot.Text) == 0)                 
            {                
                if ((sender == btnRefresh) || (sender == tbImageDepot)) Clear();
                return; 
            }
            iDepot = new DepotFolder(imageFolder);
            if (!iDepot.isEnabled) { Log("Error: This is not an image depot."); return; }
            List<Tuple<int, string, string>> decompImageDepot = iDepot.Export2Viewer(); 
            if (!Utils.isNull(decompImageDepot))
            {
                showing = false;
                activeView.FeedList(ref iDepot); picViewerUC.iDepot = iDepot;
                showing = true;
            }
            animation = false; btnPlay.IsEnabled = decompImageDepot.Count > 0; 
            if (!Utils.isNull(e)) e.Handled = true;
        }
        private void tbImageDepot_TextChanged(object sender, TextChangedEventArgs e)
        {           
            if (checkImageDepot(tbImageDepot.Text) > 0)
            {
                tbImageDepot.Foreground = Brushes.Black; 
                //opts.ImageDepotFolder = tbImageDepot.Text; Log("@WorkDir");
            }
            else 
            { 
                tbImageDepot.Foreground = Brushes.Red;                
            }     
            if (chkAutoRefresh.IsChecked.Value) btnRefresh_Click(sender, e);
        }
        private void chkAutoRefresh_Checked(object sender, RoutedEventArgs e)
        {
            if (chkAutoRefresh.IsChecked.Value) { colRefresh.Width = new GridLength(0); btnRefresh.Visibility = Visibility.Collapsed; btnRefresh_Click(sender, e); }
            else { colRefresh.Width = new GridLength(70); btnRefresh.Visibility = Visibility.Visible; }
        }
        private void tabCtrlViews_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            animation = false;
            if (chkAutoRefresh.IsChecked.Value && showing) btnRefresh_Click(sender, e);           
            if (!Utils.isNull(e)) e.Handled = true;
        }        
        public bool animation
        {
            get { return btnStop.Visibility.Equals(Visibility.Visible); }
            set 
            {
                if (value.Equals(animation)) return;
                bool vl = value;
                if (activeView.iDepot == null) vl = false;
                if (vl) { btnStop.Visibility = Visibility.Visible; btnPlay.Visibility = Visibility.Collapsed; }
                else { btnStop.Visibility = Visibility.Collapsed; btnPlay.Visibility = Visibility.Visible; }
                if (vl)
                {
                    if (timer == null) timer = new DispatcherTimer(TimeSpan.FromSeconds(numDly.Value), DispatcherPriority.Normal, OnTimerTick, Dispatcher);
                    timer?.Start();
                }
                else
                {
                    timer?.Stop();
                }
            }
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            if (activeView.iDepot == null) return;
            int cnt = activeView.iDepot.items.Count;
            if (activeView.selectedIndex.Equals(cnt)) animation = false;
            if (Utils.InRange(activeView.selectedIndex, 1,cnt-1)) activeView.selectedIndex += 1;
        }
        private void numDly_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (timer == null) return;
            timer.Interval = TimeSpan.FromSeconds(numDly.Value);
        }
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            animation = sender.Equals(btnPlay); 
        }        
        private void ucViewer_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Delete) && !tbImageDepot.IsFocused && !numDlyIsFocused) 
            Utils.DelayExec(100, () => { RemoveSelected(); } );
        }
        private bool numDlyIsFocused = false;
        private void numDly_GotFocus(object sender, RoutedEventArgs e)
        {
            numDlyIsFocused = true;
        }
        private void numDly_LostFocus(object sender, RoutedEventArgs e)
        {
            numDlyIsFocused = false;
        }
    }
}
