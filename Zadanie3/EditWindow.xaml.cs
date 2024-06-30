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
using System.Windows.Shapes;

namespace Zadanie3
{
    public partial class EditWindow : Window
    {
        public EditWindow(MediaItem item)
        {
            InitializeComponent();
            DataContext = item;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
