using System.Windows;
using System;
using System.Collections.Generic;

using AegisFront.AegisLibraryServiceReference;
using AegisLibraryService.Model;
using System.Linq;
using AegisFront.View.Book;
using System.Threading.Tasks;

namespace AegisFront {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly LibraryServiceClient _library_service;

        public MainWindow() {
            _library_service = new LibraryServiceClient();

            this.Initialized += MainWindow_Initialized;
            InitializeComponent();
        }

        private async void MainWindow_Initialized(object sender, EventArgs e) {
            await RefreshBooksList();
        }

        private async Task RefreshBooksList() {
            var books = await _library_service.GetAllBooksAsync();
            BooksListView.ItemsSource = books.Select(b => new BookCard(b));
        }

        private async void AddBookBtn_Click(object sender, RoutedEventArgs e) {
            var dialog = new CreateBookWindow();
            dialog.Owner = this;
            dialog.ShowDialog();

            if(dialog.DialogResult == true) {
                await RefreshBooksList();
            }
        }
    }
}
