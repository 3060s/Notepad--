using System.Windows;
using System.IO;

namespace Notepad__
{
    public partial class MainWindow : Window
    {
        private string filename = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            savedbox.Visibility = Visibility.Hidden;
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog opendlg = new Microsoft.Win32.OpenFileDialog();
            opendlg.Filter = "(*.txt, *.ini, *.cfg, *.xml, *.yml, *.json)|*.txt;*.ini;*.cfg;*.xml;*.yml;*.json";
            Nullable<bool> result = opendlg.ShowDialog();

            if (result == true)
            {
                this.filename = opendlg.FileName;
                textbox.Content = filename;

                FileContent.Text = File.ReadAllText(filename);
            }
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.filename))
            {
                SaveAsFile(sender, e);
            }

            else
            {
                string filecontent = FileContent.Text;
                File.WriteAllText(filename, filecontent);
                savedbox.Visibility = Visibility.Visible;
            }
        }

        private void SaveAsFile(object sender, RoutedEventArgs e)
        {
            string filecontent = FileContent.Text;

            Microsoft.Win32.SaveFileDialog savedlg = new Microsoft.Win32.SaveFileDialog();
            savedlg.FileName = "Document";
            savedlg.DefaultExt = ".txt";
            savedlg.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = savedlg.ShowDialog();

            if (result == true)
            {
                this.filename = savedlg.FileName;
                File.WriteAllText(filename, filecontent);
                savedbox.Visibility = Visibility.Visible;
            }
        }
    }
}