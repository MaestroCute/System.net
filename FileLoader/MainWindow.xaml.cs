using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace FileLoader
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

        private async void LoadFile_OnClick(object sender, RoutedEventArgs e)
        {
            content.Text = await GetFileStringTask(link.Text);
        }

        private Task<string> GetFileStringTask(string _link)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(link.Text);
            StreamReader sr = new StreamReader(stream);
            return Task.Run(() => sr.ReadToEndAsync());
            //stream.Close();
        }
    }
}