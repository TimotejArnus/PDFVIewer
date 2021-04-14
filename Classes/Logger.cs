using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PDFViewer.Classes
{
    class Logger
    { 
        public DateTime Time { get; set; }
        public string Err { get; set; }

        public Logger(string Err, RichTextBox rtb)
        {
            Time = DateTime.Now;
            this.Err = Err;

            rtb.Visibility = Visibility.Visible;
            rtb.AppendText("[ " + this.Time + " ] " + this.Err + '\n' );
            
        }
    }
}
