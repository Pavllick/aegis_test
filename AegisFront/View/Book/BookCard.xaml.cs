using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using AegisLibraryService.Model;

namespace AegisFront.View.Book {
    /// <summary>
    /// Interaction logic for BookCard.xaml
    /// </summary>
    public partial class BookCard : UserControl, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;
        public string BookTitle {
            get => _title;
            set {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _note;
        public string Note {
            get => _note;
            set {
                _note = value;
                OnPropertyChanged();
            }
        }

        private DateTime _release_date;
        public DateTime ReleaseDate {
            get => _release_date;
            set {
                _release_date = value;
                OnPropertyChanged();
            }
        }

        public BookCard(BookType book) {
            InitializeComponent();
            this.DataContext = this;

            BookTitle = book.Title;
            Note = book.Note;
            ReleaseDate = book.ReleaseDate;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
