using Microsoft.Reporting.WinForms;
using System;
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

namespace DemoWPFReport
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonF_Click(object sender, RoutedEventArgs e)
        {

            ReportDataSource rds = new ReportDataSource("InvoiceDataSet");
            rds.Value = Connection.getDataSet(1).Tables[0];

            ReportDataSource rds2 = new ReportDataSource("ProductsDataSet");
            rds2.Value = Connection.getDataSet(1).Tables[1];

            reportViewer1.LocalReport.ReportPath = "../../InvoiceReport.rdlc";
            reportViewer1.LocalReport.Refresh();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(rds2);

            
            reportViewer1.RefreshReport();
        }
    }
}
