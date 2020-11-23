using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfLMI
{
    public class Abiturient : INotifyPropertyChanged
    {
        private string zno;
        private string study;
        private string school;
        public Abiturient(string zno = "", string study = "", string school = "")
        {
            this.zno = zno;
            this.study = study;
            this.school = school;
        }
        public Abiturient(Abiturient abiturient)
        {
            this.zno = abiturient.zno;
            this.study = abiturient.study;
            this.school = abiturient.school;
        }
        public Abiturient(string study, string school)
        {
            this.zno = "";
            this.study = study;
            this.school = school;
        }
        public Abiturient(string school)
        {
            this.zno = "";
            this.study = "";
            this.school = school;
        }
        public string Zno
        {
            get { return zno; }
            set
            {
                zno = value;
                OnPropertyChanged("Zno");
            }
        }
        public string Study
        {
            get { return study; }
            set
            {
                study = value;
                OnPropertyChanged("Study");
            }
        }
        public string School
        {
            get { return school; }
            set
            {
                school = value;
                OnPropertyChanged("School");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}