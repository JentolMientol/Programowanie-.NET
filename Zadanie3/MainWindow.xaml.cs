using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;

namespace Zadanie3
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private MediaItem wybranyElement;
        public ObservableCollection<MediaItem> MediaItems { get; set; } = new ObservableCollection<MediaItem>();
        public MediaItem WybranyElement
        {
            get => wybranyElement;
            set
            {
                wybranyElement = value;
                OnPropertyChanged(nameof(WybranyElement));
                OnPropertyChanged(nameof(ElementCzyWybrany));
            }
        }
        public bool ElementCzyWybrany => WybranyElement != null;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void DodajElement_Click(object sender, RoutedEventArgs e)
        {
            var nowyElement = new MediaItem();
            var edytujOkno = new EditWindow(nowyElement);
            if (edytujOkno.ShowDialog() == true)
            {
                MediaItems.Add(nowyElement);
            }
        }

        private void EdytujElement_Click(object sender, RoutedEventArgs e)
        {
            if (WybranyElement != null)
            {
                var edytujOkno = new EditWindow(WybranyElement);
                edytujOkno.ShowDialog();
            }
        }

        private void UsunElement_Click(object sender, RoutedEventArgs e)
        {
            if (WybranyElement != null)
            {
                MediaItems.Remove(WybranyElement);
            }
        }

        private void ImportujElementy_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var json = File.ReadAllText(openFileDialog.FileName);
                var items = JsonSerializer.Deserialize<ObservableCollection<MediaItem>>(json);
                foreach (var item in items)
                {
                    MediaItems.Add(item);
                }
            }
        }

        private void EksportujElementy_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                var json = JsonSerializer.Serialize(MediaItems);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}