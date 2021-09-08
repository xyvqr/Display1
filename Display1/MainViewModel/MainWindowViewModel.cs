using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Display1.Model;
using System.Windows.Input;

namespace Display1.MainViewModel
{
   public class MainWindowViewModel : INotifyPropertyChanged
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
        private BindingList<Model.List> lista_list;
        public BindingList<Model.List> Lista_list
        {
            get
            {
                return lista_list;
            }
            set
            {
                if (lista_list != value)
                {
                    lista_list = value;
                    OnPropertyChanged(nameof(Lista_list));
                }
            }

        }

        private BindingList<Model.Sum> lista_sum;
        public BindingList<Model.Sum> Lista_sum
        {
            get
            {
                return lista_sum;
            }
            set
            {
                if (lista_sum != value)
                {
                    lista_sum = value;
                    OnPropertyChanged(nameof(Lista_sum));
                }
            }

        }

        private BindingList<Model.Downloading> lista_downloading;
        public BindingList<Model.Downloading> Lista_downloading
        {
            get
            {
                return lista_downloading;
            }
            set
            {
                if(lista_downloading != value)
                {
                    lista_downloading = value;
                    OnPropertyChanged(nameof(Lista_downloading));
                }
            }
        }
        private Model.List wybraneZlecenie;
        public Model.List WybraneZlecenie
        {
            get
            {
                return wybraneZlecenie;
            }
            set
            {
                if (wybraneZlecenie != value)
                {
                    wybraneZlecenie = value;
                    OnPropertyChanged(nameof(WybraneZlecenie));
                }
            }
        }
        private Model.Downloading wybraneDownloading;
        public Model.Downloading WybraneDownloading
        {
            get
            {
                return wybraneDownloading;
            }
            set
            {
                if (wybraneDownloading != value)
                {
                    wybraneDownloading = value;
                    OnPropertyChanged(nameof(WybraneDownloading));
                }
                if(wybraneDownloading != null)
                {
                    lista_list = Baza.SQL_SelectList(DataOd.Date.ToString("yyyy-MM-dd"), DataDo.Date.ToString("yyyy-MM-dd"), WybraneDownloading.TrN_KrajPrzezWys);
                    lista_sum = Baza.SQL_SelectSum(DataOd.Date.ToString("yyyy-MM-dd"), DataDo.Date.ToString("yyyy-MM-dd"), WybraneDownloading.TrN_KrajPrzezWys);
                    OnPropertyChanged(nameof(Lista_list),nameof(Lista_sum));
                }
            }
        }
        private Model.Sum wybraneSum;
        public Model.Sum WybraneSum
        {
            get
            {
                return wybraneSum;
            }
            set
            {
                if (wybraneSum != value)
                {
                    wybraneSum = value;
                    OnPropertyChanged(nameof(WybraneSum));
                }
                //if (wybraneSum != null)
                //{
                    
                //    OnPropertyChanged(nameof(Lista_sum));
                //}
            }
        }
        private DateTime dataOd;
        public DateTime DataOd
        {
            get
            {
                return dataOd;
            }
            set
            {
                if (dataOd != value)
                {
                    dataOd = value;
                    OnPropertyChanged(nameof(DataOd));
                }
            }
        }
        private DateTime dataDo;
        public DateTime DataDo
        {
            get
            {
                return dataDo;
            }
            set
            {
                if (dataDo != value)
                {
                    dataDo = value;
                    OnPropertyChanged(nameof(DataDo));
                }
                if(dataDo != null)
                {
                    lista_downloading = Baza.SQL_SelectDownloading(DataOd.Date.ToString("yyyy-MM-dd"), DataDo.Date.ToString("yyyy-MM-dd"));
                    OnPropertyChanged(nameof(Lista_downloading));
                }
            }
        }
        public MainWindowViewModel()
        {
            //lista_list = Baza.SQL_SelectList();
            //lista_sum = Baza.SQL_SelectSum();
            
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;


        }
       
    }
}
