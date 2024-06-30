using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MediaItem : INotifyPropertyChanged
    {
        private string tytul;
        private string autor;
        private string wydawca;
        private string nosnik;
        private DateTime dataWydania;

        public string Tytul
        {
            get => tytul;
            set
            {
                tytul = value;
                OnPropertyChanged(nameof(Tytul));
            }
        }

        public string Autor
        {
            get => autor;
            set
            {
                autor = value;
                OnPropertyChanged(nameof(Autor));
            }
        }

        public string Wydawca
        {
            get => wydawca;
            set
            {
                wydawca = value;
                OnPropertyChanged(nameof(Wydawca));
            }
        }

        public string Nosnik
        {
            get => nosnik;
            set
            {
                nosnik = value;
                OnPropertyChanged(nameof(Nosnik));
            }
        }

        public DateTime DataWydania
        {
            get => dataWydania;
            set
            {
                dataWydania = value;
                OnPropertyChanged(nameof(DataWydania));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}