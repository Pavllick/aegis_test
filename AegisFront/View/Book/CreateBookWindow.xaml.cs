using AegisFront.AegisLibraryServiceReference;
using AegisLibraryService.Model;
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
using System.Windows.Shapes;

namespace AegisFront.View.Book {
    /// <summary>
    /// Interaction logic for CreateBookWindow.xaml
    /// </summary>
    public partial class CreateBookWindow : Window, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly LibraryServiceClient _library_service;

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

        private string _description;
        public string Description {
            get => _description;
            set {
                _description = value;
                OnPropertyChanged();
            }
        }

        public CreateBookWindow() {
            _library_service = new LibraryServiceClient();

            InitializeComponent();
            this.DataContext = this;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e) {
            await _library_service.AddBookAsync(new BookType() {
                Title = BookTitle,
                ReleaseDate = DateTime.Now,
                Description = Description,
            });

            this.DialogResult = true;
        }
    }
}
