using System.Net;
using System.Windows;

namespace DNS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            string hostname = "www.google.com", message = "IP адреса для домена " + hostname + "\n";
            IPHostEntry entry = Dns.GetHostEntry(hostname);

            foreach (IPAddress a in entry.AddressList)
                message += "  --> "+ a.ToString() + "\n";

            message += "\nАльтернативное имя домена: ";
            foreach (string aliasName in entry.Aliases)
                message += aliasName + "\n";

            message += "\nРеальное название хоста: " + entry.HostName;
            MessageBox.Show(message);
        }
    }
}