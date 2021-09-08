using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Display1.Model
{
    public class Downloading : INotifyPropertyChanged
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

        private string trN_KrajPrzezWys;
        public string TrN_KrajPrzezWys
        {
            get { return trN_KrajPrzezWys; }
            set
            {
                trN_KrajPrzezWys = value;
                OnPropertyChanged(nameof(TrN_KrajPrzezWys));
            }
        }
    }
}
