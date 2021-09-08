using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Display1.Model
{
   public class List : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(params string[] nazwyWlasciwosci)
        {
            if (PropertyChanged != null)
            {
                foreach (string nazwaWlasciwosci in nazwyWlasciwosci) PropertyChanged(this, new PropertyChangedEventArgs(nazwaWlasciwosci));
            }
        }
        #endregion //PropertyChanged

        private DateTime dataDokumentu;
        public DateTime DataDokumentu
        {
            get { return dataDokumentu; }
            set
            {
                dataDokumentu = value;
                OnPropertyChanged(nameof(DataDokumentu));
            }
        }

        private string numerDokumentu;
        public string NumerDokumentu
        {
            get { return numerDokumentu; }
            set
            {
                numerDokumentu = value;
                OnPropertyChanged(nameof(NumerDokumentu));
            }
        }

        private int pCN_NAZWA;
        public int PCN_NAZWA
        {
            get { return pCN_NAZWA; }
            set
            {
                pCN_NAZWA = value;
                OnPropertyChanged(nameof(PCN_NAZWA));
            }
        }

        private decimal pCN_WAGA_BRUTTO;
        public decimal PCN_WAGA_BRUTTO
        {
            get { return pCN_WAGA_BRUTTO; }
            set
            {
                pCN_WAGA_BRUTTO = value;
                OnPropertyChanged(nameof(PCN_WAGA_BRUTTO));
            }
        }

        private decimal pCN_WAGA_NETTO;
        public decimal PCN_WAGA_NETTO
        {
            get { return pCN_WAGA_NETTO; }
            set
            {
                pCN_WAGA_NETTO = value;
                OnPropertyChanged(nameof(PCN_WAGA_NETTO));
            }
        }
        private decimal pCN_WARTOSC;
        public decimal PCN_WARTOSC
        {
            get { return pCN_WARTOSC; }
            set
            {
                pCN_WARTOSC = value;
                OnPropertyChanged(nameof(PCN_WARTOSC));
            }
        }

        private decimal pCN_M2;
        public decimal PCN_M2
        {
            get { return pCN_M2; }
            set
            {
                pCN_M2 = value;
                OnPropertyChanged(nameof(PCN_M2));
            }
        }


    }
}
