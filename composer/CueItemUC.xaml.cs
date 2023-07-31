﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using UtilsNS;

namespace scripthea.composer
{
    /// <summary>
    /// Interaction logic for OneSeedUC.xaml
    /// </summary>
    public partial class CueItemUC : UserControl
    {
        public CueItemUC()
        {
            InitializeComponent();
        }
        public CueItemUC(string text, bool _radioChecked = false)
        {
            InitializeComponent(); radioChecked = _radioChecked;
            tbCue.Text = text.Trim().Trim('\"').Trim();
        }
        public CueItemUC(List<string> text, bool _radioChecked = false)
        {
            InitializeComponent(); radioChecked = _radioChecked;
            tbCue.Text = ""; 
            foreach (string line in text) tbCue.Text += line + "\r";
            tbCue.Text = tbCue.Text.Trim().Trim('\"');
        }
        public event Utils.LogHandler OnLog;
        protected void Log(string txt, SolidColorBrush clr = null)
        {
            if (OnLog != null) OnLog(txt, clr);
        }
        public bool radioMode
        {
            get { return rbChecked.Visibility.Equals(Visibility.Visible); }
            set
            {
                if (value)
                {
                    rbChecked.Visibility = Visibility.Visible;
                    checkBox.Visibility = Visibility.Collapsed;
                }
                else
                {
                    rbChecked.Visibility = Visibility.Collapsed;
                    checkBox.Visibility = Visibility.Visible;
                }
            }
        }
        public bool radioChecked
        {
            get { return rbChecked.IsChecked.Value; }
            set { rbChecked.IsChecked = value; }
        }
        public bool boxChecked
        {
            get { return checkBox.IsChecked.Value; }
            set { checkBox.IsChecked = value; }
        }
        public string cueText
        {
            get { return tbCue.Text.Trim().Trim('\"').Trim(); }
            set { tbCue.Text = value.Trim().Trim('\"').Trim(); }
        }
        public bool empty
        {
            get { return cueText.Trim().Equals(""); }
        }
        public string cueTextAsString(bool noComment)
        {
            return Utils.flattenTextBox(tbCue, noComment).Trim().Trim('\"').Trim();
        }
        public List<string> cueTextAsList(bool noComment)
        {
            List<string> ls = new List<string>();
            cueText = cueText.Trim(); tbCue.UpdateLayout();
            int lineCount = tbCue.LineCount; string st = "";
            for (int line = 0; line < lineCount; line++)
            {                
                string ss = tbCue.GetLineText(line);
                bool bb = ss.EndsWith("\r\n");
                if (noComment) ss = Utils.skimRem(ss);
                if (ss.Trim().Equals("")) continue;
                if (bb || (line == lineCount - 1))
                {
                    ls.Add((st + " " + ss).Replace("  ", " ").Trim()); st = ""; 
                }                                 
                else 
                    st += " " + ss;                 
            }
            return ls;
        }
    }
}

