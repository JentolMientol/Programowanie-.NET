using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PNET_24_ININ4_hybryda_PR2_2_kalkulator;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    LogikaKalkulatora logika { get; } = new();
    public MainWindow()
    {
        DataContext = logika;
        InitializeComponent();
    }

    private void Cyfra(object sender, RoutedEventArgs e)
    {
        string cyfra = (sender as Button).Content.ToString();
        logika.WprowadźCyfrę(cyfra);
    }

    private void Znak(object sender, RoutedEventArgs e)
        => logika.ZmieńZnak();

    private void Przecinek(object sender, RoutedEventArgs e)
        => logika.ZacznijUłamek();

    private void KasujZnak(object sender, RoutedEventArgs e)
        => logika.KasujZnak();

    private void KasujLiczbę(object sender, RoutedEventArgs e)
        => logika.KasujLiczbę();

    private void KasujWszystko(object sender, RoutedEventArgs e)
        => logika.KasujWszystko();

    private void WprowadźDziałanieDwuargumentowe(object sender, RoutedEventArgs e)
    {
        string działanie = (sender as Button).Content.ToString();
        logika.WprowadźDziałanieDwuargumentowe(działanie);
    }

    private void WprowadźDziałanieJednoargumentowe(object sender, RoutedEventArgs e)
    {
        string działanie = (sender as Button).Content.ToString();
        logika.WykonajDziałanieJednoargumentowe(działanie);
    }

    private void WykonajDziałanie(object sender, RoutedEventArgs e)
        => logika.WykonajDziałanie();
}
