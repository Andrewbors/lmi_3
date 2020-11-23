using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WpfLMI
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Abiturient selectedAbiturient;
        public ObservableCollection<Abiturient> Abiturient { get; set; }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Abiturient abiturient = new Abiturient();
                      Abiturient.Insert(0, abiturient);
                      SelectedAbiturient = abiturient;
                  }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Abiturient abiturient = obj as Abiturient;
                      if (abiturient != null)
                      {
                          Abiturient.Remove(abiturient);
                      }
                  },
                 (obj) => Abiturient.Count > 0));
            }
        }

        public Abiturient SelectedAbiturient
        {
            get { return selectedAbiturient; }
            set
            {
                selectedAbiturient = value;
                OnPropertyChanged("SelectedAbiturient");
            }
        }

        public ApplicationViewModel()
        {
            Abiturient = new ObservableCollection<Abiturient>
            {
                new Abiturient { Zno="152", Study="10.2", School="4 school"},
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}