﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UtilsNS;
using Path = System.IO.Path;
using Newtonsoft.Json;

namespace scripthea.viewer
{    
    public class ImageInfo
    {
        public enum ImageGenerator { FromFile, Crayion, StableDiffusion, DeepAI }
        public ImageInfo()
        {

        }
        public ImageInfo(string fullfilename, ImageGenerator imageGenerator, bool keepName) 
        {
            if (!File.Exists(fullfilename)) return;
            string suggestedName = ""; bool bb;
            switch (imageGenerator) 
            {
                case ImageGenerator.StableDiffusion:
                    bb = FromSDFile(fullfilename, out suggestedName); if (!bb) return;
                    break;
                case ImageGenerator.Crayion:
                    if (!FromCraiyonFile(fullfilename, out suggestedName)) return;
                    break;
                case ImageGenerator.DeepAI:
                    if (!FromDeepAIFile(fullfilename, out suggestedName)) return;
                    break;
            }
            if (keepName || suggestedName.Equals("")) return;
            try
            {
                File.Move(fullfilename, suggestedName); // Rename the oldFileName into newFileName
                filename = Path.GetFileName(suggestedName);
            }
            catch (System.IO.IOException IOe) { Utils.TimedMessageBox("Error: (" + System.IO.Path.GetFileName(fullfilename) + ") " + IOe.Message);  }

        }
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
            if (ls.Count < 4) return false;
            if (!Utils.isNumeric(ls[0]) || !Utils.isNumeric(ls[1])) return false;
            suggestedName =  System.IO.Path.ChangeExtension("SD-" + ls[1], ls[3]);
            suggestedName = Utils.AvoidOverwrite(System.IO.Path.Combine(Path.GetDirectoryName(fullfilename),suggestedName));
            
            return sd;
        }
        public bool FromCraiyonFile(string fullfilename, out string suggestedName) // true if it's there and it's sd image 
        {
            suggestedName = "";
            if (File.Exists(fullfilename)) return false;
            return true;
        }
        public bool FromDeepAIFile(string fullfilename, out string suggestedName) // true if it's there and it's sd image 
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
        public DepotFolder(string _folder, ImageInfo.ImageGenerator _imageGenerator = ImageInfo.ImageGenerator.FromFile) 
        {
            if (!Directory.Exists(_folder)) return;
            header = new Dictionary<string, string>(); infos = new List<ImageInfo>();

            if (_imageGenerator == ImageInfo.ImageGenerator.FromFile) // read type from file
            {
                string desc = Path.Combine(_folder, ImgUtils.descriptionFile);
                if (File.Exists(desc))
                {
                    List<string> body = Utils.readList(desc);
                    if (body.Count == 0) return;
                    if (body[0].StartsWith("#"))
                    {
                        header = JsonConvert.DeserializeObject<Dictionary<string, string>>(body[0].Substring(1));
                        body.RemoveAt(0);
                        foreach (ImageInfo.ImageGenerator ig in Enum.GetValues(typeof(ImageInfo.ImageGenerator)))
                        {
                            if (ig.Equals(header["ImageGenerator"])) imageGenerator = ig;
                        }
                    }
                    foreach (string ss in body)
                        infos.Add(new ImageInfo(ss));
                }
            }
            else
            {
                imageGenerator = _imageGenerator; header.Add("ImageGenerator", imageGenerator.ToString());
                header.Add("version", "1.4"); header.Add("application", "Scripthea " + Utils.getAppFileVersion);
            }
            folder = _folder;
        }
        public bool IsEnabled
        {
            get { return !(Utils.isNull(header) || Utils.isNull(infos)); }
        }
        public Dictionary<string, string> header;
        public List<ImageInfo> infos;
        public List<string> allImages()
        {
            List<string> pngs = new List<string>(Directory.GetFiles(folder, "*.png"));
            List<string> jpgs = new List<string>(Directory.GetFiles(folder, "*.jpg"));
            pngs.AddRange(jpgs);
            for (int i = 0; i < pngs.Count; i++)
                pngs[i] = Path.GetFileName(pngs[i]);
           return new List<string>(pngs);
        }
        public bool fileMatch(List<string> imgs, out int idxFile, out int idxII) // found match within imgs and infos[*].filename
        {
            bool found = false; idxFile = -1; idxII = -1;
            for (int i = 0; i < imgs.Count; i++)
            {            
                for (int j = 0; j <  infos.Count; j++)
                {
                    found = infos[j].filename.Equals(imgs[i], StringComparison.InvariantCultureIgnoreCase);
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
        public string folder { get; private set; }
        public ImageInfo.ImageGenerator imageGenerator { get; private set; }
        public bool Validate(bool correct) // true if no mismatched entries; if correct and mismatched then they are deleted 
        {
            List<string> allImgs = allImages(); bool ok = true;             
            /*int idxFile; int idxII; bool fnd;
            do { fnd = fileMatch(allImgs, out idxFile, out idxII); } while (fnd);*/
            foreach (string img in allImgs)
            {
                bool found = false; int j = -1;
                for (int i = 0; i < infos.Count; i++)
                {
                    found = infos[i].filename.Equals(img, StringComparison.OrdinalIgnoreCase);
                    if (found) { j = i; break; } 
                }
                if (found && correct) infos.RemoveAt(j);
            }
            return ok;
        }
        public void Append(ImageInfo ii)
        {
            using (StreamWriter w = File.AppendText(Path.Combine(folder, ImgUtils.descriptionFile)))
            {
                w.WriteLine(ii.To_String());
            }
            infos.Add(ii);
        }
        public void Save()
        {
            List<string> ls = new List<string>();
            ls.Add("#"+ JsonConvert.SerializeObject(header));
            foreach (ImageInfo ii in infos)
                ls.Add(ii.To_String());
            Utils.DelayExec(200, 
                new Action(() => { Utils.writeList(Path.Combine(folder, ImgUtils.descriptionFile), ls); }));            
        }
        public List<Tuple<int, string, string>> Export2Viewer()
        {
            List<Tuple<int, string, string>> lst = new List<Tuple<int, string, string>>();
            for (int i = 0; i < infos.Count; i++)
                lst.Add(new Tuple<int, string, string>(i+1, infos[i].filename, infos[i].prompt));
            return lst;
        }
    }

    interface iPicList
    {
        void Init(ref Options _opts);
        void Finish();
        string imageFolder { get; }
        void Clear();
        void FeedList(List<Tuple<int, string, string>> theList, string imageDepot);  // index, filename, prompt     
        int selectedIndex { get; set; } // one based index
        int Count { get; }
        List<Tuple<int, string, string>> items { get; }
    }
    /// <summary>
    /// Interaction logic for ViewerUC.xaml
    /// </summary>
    public partial class ViewerUC : UserControl
    {       
        public ViewerUC()
        {
            InitializeComponent();
            views = new List<iPicList>();
            views.Add(tableViewUC); tableViewUC.SelectEvent += new TableViewUC.PicViewerHandler(picViewerUC.loadPic); 
            views.Add(gridViewUC);  gridViewUC.SelectEvent += new GridViewUC.PicViewerHandler(picViewerUC.loadPic); 
        }
        iPicList activeView { get { return views[tabCtrlViews.SelectedIndex]; } }
        Options opts;
        public void Init(ref Options _opts)
        {
            opts = _opts;
            chkAutoRefresh.IsChecked = opts.Autorefresh; imageFolder = opts.ImageDepotFolder; 
            colListWidth.Width = new GridLength(opts.ViewColWidth);
            foreach (iPicList ipl in views)
                ipl.Init(ref opts);            
        }
        public void Finish()
        {
            opts.ViewColWidth = Convert.ToInt32(colListWidth.Width.Value);
            opts.Autorefresh = chkAutoRefresh.IsChecked.Value;
            foreach (iPicList ipl in views)
                ipl.Finish();
        }
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
        private List<Tuple<int, string, string>> DecompImageDepot(string imageDepot, bool checkFileAndOut)
        {
            if (ImgUtils.checkImageDepot(imageDepot, true) < 1) return null;
            List<Tuple<int, string, string>> lt = new List<Tuple<int, string, string>>();
            List<string> ls = new List<string>(File.ReadAllLines(imageDepot + "description.txt")); int k = 1;
            foreach (string ss in ls)
            {               
                string[] sa = ss.Split('=');
                if (sa.Length != 2) { Log("Err: wrong line format <" + ss + ">. "); return null; }
                if (checkFileAndOut)
                    if (!File.Exists(imageDepot + sa[0])) continue;
                lt.Add(new Tuple<int, string, string>(k, sa[0], sa[1])); k++;
            }
            return lt;
        }
        private void btnFindUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int k = sender.Equals(btnFindUp) ? -1 : 1;
            if (activeView.selectedIndex.Equals(-1)) activeView.selectedIndex = 1;
            int idx = activeView.selectedIndex + k -1;
            List<Tuple<int, string, string>> items = activeView.items;
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
        private bool checkImageDepot(string folder)
        {
            bool bb = ImgUtils.checkImageDepot(tbImageDepot.Text) > 0;
            if (bb) lbDepotInfo.Content = "";
            else lbDepotInfo.Content = "This is not an image depot.";
            return bb;
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        { 
            if (!checkImageDepot(tbImageDepot.Text))                 
            {                
                if (sender.Equals(btnRefresh)) Clear();
                return; 
            }
            DepotFolder df = new DepotFolder(imageFolder);
            if (!df.IsEnabled) { Log("Error: Image depot folder is not formated as it should be."); return; }
            List<Tuple<int, string, string>> decompImageDepot = df.Export2Viewer(); // DecompImageDepot(imageFolder, true);
            if (!Utils.isNull(decompImageDepot))
            {
                activeView.FeedList(decompImageDepot, imageFolder); 
            }
            if (!Utils.isNull(e)) e.Handled = true;
        }
        private void tbImageDepot_TextChanged(object sender, TextChangedEventArgs e)
        {           
            if (checkImageDepot(tbImageDepot.Text))
            {
                tbImageDepot.Foreground = Brushes.Black; 
                opts.ImageDepotFolder = tbImageDepot.Text; Log("@WorkDir");
                if (chkAutoRefresh.IsChecked.Value) btnRefresh_Click(sender, e);
            }
            else { tbImageDepot.Foreground = Brushes.Red; }     
        }
        private void chkAutoRefresh_Checked(object sender, RoutedEventArgs e)
        {
            if (chkAutoRefresh.IsChecked.Value)
            { colRefresh.Width = new GridLength(0); btnRefresh.Visibility = Visibility.Collapsed; btnRefresh_Click(sender, e); }
            else { colRefresh.Width = new GridLength(70); btnRefresh.Visibility = Visibility.Visible; }
        }
        private void tabCtrlViews_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chkAutoRefresh.IsChecked.Value && showing) btnRefresh_Click(sender, e); 
            if (!Utils.isNull(e)) e.Handled = true;
        }
    }
}
