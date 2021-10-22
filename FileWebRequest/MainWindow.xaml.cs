using System.IO;
using System.Net;
using System.Windows;

namespace FileWebRequest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            string filename = txb_fileuri.Text;
            System.Net.FileWebRequest request = 
                (System.Net.FileWebRequest)WebRequest.Create(filename);

            using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                txb_fileContent.Text = sr.ReadToEnd();
            }
        }
        
        private void writeFile_Click(object sender, RoutedEventArgs e)
        {
            WebRequest request = WebRequest.Create(txb_fileuri.Text);
            request.Method = "PUT";
            using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(txb_writefile.Text);
            }
        }


    }
}