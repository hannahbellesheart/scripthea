﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UtilsNS;
using Path = System.IO.Path;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace scripthea
{
    public class Options
    {
        public Options()
        {
            if (general == null) general = new General();
            if (layout == null) layout = new Layout();
            if (composer == null) composer = new Composer();
            if (viewer == null) viewer = new Viewer();
            if (iDutilities == null) iDutilities = new IDutilities();
        }
        public General general; 
        public class General
        {
            public bool debug;
            public bool UpdateCheck;
            public int LastUpdateCheck;
            public string NewVersion;
        }
        public Layout layout; 
        public class Layout
        {
            public int Left;
            public int Top;
            public int Height;
            public int Width;
            public bool Maximazed;
            public int LogColWidth;
            public bool LogColWaveSplit;
        }
        public Composer composer;
        public class Composer
        {
            public int QueryRowHeight;
            public int QueryColWidth;
            public int ViewColWidth;
            // query single
            public bool SingleAuto;
            public bool OneLineCue;
            // query 
            public string ImageDepotFolder;        
            public string API;
            // modifiers
            public string ModifPrefix;
            public bool AddEmptyModif;
            public bool ConfirmGoogling;
            public int ModifSample;
        }
        public Viewer viewer;
        public class Viewer
        {
            public bool Autorefresh;
            public int ThumbZoom;
            public bool ThumbCue;
            public bool ThumbFilename;
            public bool RemoveImages;
        }

        public IDutilities iDutilities; // Image Depot utilities
        public class IDutilities
        {
            public bool MasterValidationAsk;
            public int MasterWidth;
            public int ImportWidth;
            public int ExportWidth;
        }
     }

    /// <summary>
    /// Interaction logic, load & save for GeneralOptions genOptions
    /// </summary>
    public partial class PreferencesWindow : Window
    {
        public bool keepOpen = true;
        /// <summary>
        /// dialog box constructor; reads from file or creates new options object
        /// </summary>
        public PreferencesWindow()
        {
            InitializeComponent();         
        }
        Options opts;
        public void Init(ref Options _opts)
        {
            opts = _opts; 
        } 
        public string configFilename = Path.Combine(Utils.configPath, "Scripthea.cfg");  
        /// <summary>
        /// the point of the dialog, readable everywhere
        /// </summary>
        public event Utils.LogHandler OnLog;
        protected void Log(string txt, SolidColorBrush clr = null)
        {
            if (OnLog != null) OnLog(txt, clr);
            else Utils.TimedMessageBox(txt, "Warning", 3500);
        }
        public void opts2visuals()
        {
            if (!opts.general.NewVersion.Equals("")) lbNewVer.Content = "New version: " + opts.general.NewVersion;
            chkUpdates.IsChecked = opts.general.UpdateCheck;
            chkConfirmGoogling.IsChecked = opts.composer.ConfirmGoogling;
            chkViewerRemoveImages.IsChecked = opts.viewer.RemoveImages;
            chkValidationAsk.IsChecked = opts.iDutilities.MasterValidationAsk;
        }
        public void visuals2opts()
        {
            opts.general.UpdateCheck = chkUpdates.IsChecked.Value;
            opts.composer.ConfirmGoogling = chkConfirmGoogling.IsChecked.Value;
            opts.viewer.RemoveImages = chkViewerRemoveImages.IsChecked.Value;
            opts.iDutilities.MasterValidationAsk = chkValidationAsk.IsChecked.Value;
        }
        public void ShowWindow(int tabIdx)
        {
            tabControl.SelectedIndex = Utils.EnsureRange(tabIdx, 0, 2) + 1;
            opts2visuals();
            ShowDialog();
        }
        /// <summary>
        /// Accepting and saving the changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, RoutedEventArgs e) // visual to internal 
        {
            visuals2opts(); Hide();
        }

        /// <summary>
        /// Cancel without modifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
        private void wndSDOptions_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = keepOpen; Hide();
        }
    }
}
