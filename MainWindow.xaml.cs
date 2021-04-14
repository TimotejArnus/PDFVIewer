using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using PDFViewer.Classes;
using System.Management;
using IronPdf;
using System.ServiceProcess;
using System.Windows.Controls;


namespace PDFViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ServiceSetup();
            SetPrinterCobmoBox();
        }

        private void BtnFilePath_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF-File | *.pdf";
            dialog.ShowDialog();

            if (!String.IsNullOrEmpty(dialog.FileName))
            {
                SetFileInfo(dialog.FileName);
            }
        }

        private void TbFileFullPath_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TbFileFullPath.Text))
            {
                if (new FileInfo(TbFileFullPath.Text).Exists)
                {
                    SetFileInfo(TbFileFullPath.Text);
                    return;
                }
            }

            TbFileName.Text = "";
            TbFileSize.Text = "";
        }

        private void BtnPrint_OnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TbFileFullPath.Text))
            {
                new Logger("File path is empty", RtbErrorLogger);
                return;
            }

            if (!new FileInfo(TbFileFullPath.Text).Exists)
            {
                new Logger("File ( " + TbFileFullPath.Text + " ) does not exist", RtbErrorLogger);
                return;
            }

            if (String.IsNullOrEmpty(cbPrinterName.Text))
            {
                // If no printer is selected, we check if there is a default printer
                if (PrinterInfo.PrintersList.Find(p => p.IsDefault == "True") != null) 
                {
                    MessageBoxResult Result = MessageBox.Show("Do you want to use default printer ?",
                        "Printer is not selected! ", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (Result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            PdfDocument pdf = PdfDocument.FromFile(TbFileFullPath.Text);
                            pdf.Print();
                        }
                        catch (Exception exception)
                        {
                            new Logger(exception.Message, RtbErrorLogger);
                        }
                    }
                }

                new Logger("No printer is selected", RtbErrorLogger);
                return;
            }

            try
            {
                PdfDocument pdf = PdfDocument.FromFile(TbFileFullPath.Text);
                pdf.Print(cbPrinterName.Text);
            }
            catch (Exception exception)
            {
                new Logger(exception.Message, RtbErrorLogger);
            }
        }

        private void BtnPreview_OnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TbFileFullPath.Text))
            {
                new Logger("File path is empty", RtbErrorLogger);
                return;
            }

            if (!new FileInfo(TbFileFullPath.Text).Exists)
            {
                new Logger("File ( " + TbFileFullPath.Text + " ) does not exist", RtbErrorLogger);
                return;
            }

            PreviewPDFWindow window = new PreviewPDFWindow(TbFileFullPath.Text);
            window.Show();
        }

        private void SetFileInfo(string path)
        {
            try
            {
                FileInfo info = new FileInfo(path);

                if (info.Exists)
                {
                    TbFileFullPath.Text = path;
                    TbFileName.Text = info.Name;
                    TbFileSize.Text = info.Length / 1024 + " KB"; // Convert bytes to KB 
                }
                else
                {
                    new Logger("File ( " + path  + " ) does not exist", RtbErrorLogger);
                }

            }
            catch (Exception e)
            {
                new Logger(e.Message, RtbErrorLogger);
            }
        }
        private void SetPrinterCobmoBox()
        {
            FindPrinters();

            cbPrinterName.Items.Clear();

            foreach (var printer in PrinterInfo.PrintersList)
            {
                cbPrinterName.Items.Add(printer.Name);
            }
            
        }

        private void FindPrinters()
        {
            var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
            var printers = printerQuery.Get();

            try
            {
                if (printers.Count == 0)
                {
                    Logger log = new Logger("Can not find any printer", RtbErrorLogger);
                    return;
                }
            }
            catch (Exception e)
            {
                new Logger(e.Message, RtbErrorLogger);
                return;
            }

            PrinterInfo.PrintersList.Clear();  // Printers wont be duplicated  

            foreach (var printer in printers)
            {   // all the printers are saved in static list in class printers 
                
                new PrinterInfo(printer.GetPropertyValue("Name").ToString(), printer.GetPropertyValue("Status").ToString(),
                    printer.GetPropertyValue("Default").ToString(), printer.GetPropertyValue("Network").ToString());
            }
        }

        //need to run programa as a Admin
        private void ServiceSetup()
        {   
            try
            {
                ServiceController service = new ServiceController("Spooler");   // starts print Spooler

                if (service.Status == ServiceControllerStatus.Stopped)
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(300000);
                    
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
            }
            catch (Exception e)
            {
                new Logger(e.Message, RtbErrorLogger);
            }
        }
    }
}
