using System;
using System.Collections.Generic;
using System.Text;

namespace PDFViewer.Classes
{
    class PrinterInfo
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string IsDefault { get; set; }
        public string IsNetworkPrinter { get; set; }

        public static List<PrinterInfo> PrintersList = new List<PrinterInfo>();

        public PrinterInfo(string Name, string Status, string IsDefault, string IsNetworkPrinter)
        {
            this.Name = Name;
            this.Status = Status;
            this.IsDefault = IsDefault;
            this.IsNetworkPrinter = IsNetworkPrinter;

            PrintersList.Add(this);
        }
    }
}
