using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNET_24_ININ4_hybryda_PR2_2_kalkulator;
internal class LogikaKalkulatora : INotifyPropertyChanged
{
    private double? lewyOperand = null, prawyOperand = null;
    private string? operacja = null;
    private string wyświetlanaLiczba = "0";
    private bool flagaDziałania;

    public string WyświetlaneDziałanie
    {
        get
        {
            if (lewyOperand == null)
                return "";
            else if (operacja == null)
                return $"{lewyOperand}";
            else if (prawyOperand == null)
                return $"{lewyOperand} {operacja}";
            else
                return $"{lewyOperand} {operacja} {prawyOperand} =";
        }
    }
    public string WyświetlanaLiczba
    {
        get => wyświetlanaLiczba;
        set
        {
            wyświetlanaLiczba = value;
            PropertyChanged?.Invoke(this, new(nameof(WyświetlanaLiczba)));
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    internal void KasujLiczbę()
    {
        if (flagaDziałania)
            KasujWszystko();
        WyświetlanaLiczba = "0";
    }

    internal void KasujWszystko()
    {
        flagaDziałania = false;
        KasujLiczbę();
        lewyOperand = prawyOperand = null;
        operacja = null;
        PropertyChanged?.Invoke(this, new(nameof(WyświetlaneDziałanie)));
    }

    internal void KasujZnak()
    {
        if (flagaDziałania)
            KasujWszystko();
        if (WyświetlanaLiczba.Length == 1 || WyświetlanaLiczba == "-0,")
            WyświetlanaLiczba = "0";
        else
            WyświetlanaLiczba = WyświetlanaLiczba.Substring(0, WyświetlanaLiczba.Length - 1);
    }

    internal void WprowadźCyfrę(string? cyfra)
    {
        if (flagaDziałania)
            KasujWszystko();
        if (WyświetlanaLiczba == "0")
            WyświetlanaLiczba = cyfra;
        else
            WyświetlanaLiczba += cyfra;
    }

    internal void WprowadźDziałanieDwuargumentowe(string? działanie)
    {
        if (flagaDziałania)
        {
            prawyOperand = null;
            flagaDziałania = false;
        }
        else if (operacja == null)
            lewyOperand = Convert.ToDouble(WyświetlanaLiczba);
        else
        {
            WykonajDziałanie();
            prawyOperand = null;
            flagaDziałania = false;
        }
        operacja = działanie;
        PropertyChanged?.Invoke(this, new(nameof(WyświetlaneDziałanie)));
        wyświetlanaLiczba = "0";
    }

    internal void WykonajDziałanie()
    {
        if (prawyOperand == null)
            prawyOperand = Convert.ToDouble(WyświetlanaLiczba);
        PropertyChanged?.Invoke(this, new(nameof(WyświetlaneDziałanie)));

        double wynik = 0;
        switch (operacja)
        {
            case "+":
                wynik = (double)(lewyOperand + prawyOperand);
                break;
            case "-":
                wynik = (double)(lewyOperand - prawyOperand);
                break;
            case "×":
                wynik = (double)(lewyOperand * prawyOperand);
                break;
            case "/":
                wynik = (double)(lewyOperand / prawyOperand);
                break;
            case "x²":
                wynik = Math.Pow((double)lewyOperand, (double)prawyOperand);
                break;
            case "%":
                wynik = (double)(lewyOperand % prawyOperand);
                break;
            case "+%":
                wynik = (double)(lewyOperand * (1 + prawyOperand / 100));
                break;
            case "-%":
                wynik = (double)(lewyOperand * (1 - prawyOperand / 100));
                break;
        }

        WyświetlanaLiczba = $"{wynik}";
        lewyOperand = wynik;
        flagaDziałania = true;
    }

    internal void ZacznijUłamek()
    {
        if (flagaDziałania)
            KasujWszystko();
        if (WyświetlanaLiczba.Contains(','))
            return;
        else
            WyświetlanaLiczba += ",";
    }

    internal void ZmieńZnak()
    {
        if (flagaDziałania)
            KasujWszystko();
        if (WyświetlanaLiczba == "0")
            return;
        else if (WyświetlanaLiczba[0] == '-')
            WyświetlanaLiczba = WyświetlanaLiczba.Substring(1);
        else
            WyświetlanaLiczba = "-" + WyświetlanaLiczba;
    }

    internal void WykonajDziałanieJednoargumentowe(string działanie)
    {
        double operand = Convert.ToDouble(WyświetlanaLiczba);
        double wynik = 0;

        switch (działanie)
        {
            case "√x":
                wynik = Math.Sqrt(operand);
                break;
            case "1/x":
                wynik = 1 / operand;
                break;
            case "x!":
                wynik = Factorial(operand);
                break;
            case "log10":
                wynik = Math.Log10(operand);
                break;
            case "floor":
                wynik = Math.Floor(operand);
                break;
            case "ceiling":
                wynik = Math.Ceiling(operand);
                break;
        }

        WyświetlanaLiczba = $"{wynik}";
        flagaDziałania = true;
    }

    private double Factorial(double n)
    {
        if (n < 0)
            throw new ArgumentException("Negative numbers are not allowed.");
        if (n == 0 || n == 1)
            return 1;
        double result = 1;
        for (int i = 2; i <= (int)n; i++)
            result *= i;
        return result;
    }
}