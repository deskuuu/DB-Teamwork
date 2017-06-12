using BookStore.Data;
using BookStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Client
{
    public partial class MainWindow : Window
    {
        IList productsInCart;
        decimal priceOfAllProducts = 0;

        public MainWindow()
        {
            InitializeComponent();
            SearchByBox.Items.Add("Books");
            SearchByBox.Items.Add("Authors");
            SearchByBox.Items.Add("Genres");
            SearchByBox.Items.Add("Categories");
            SearchByBox.Items.Add("Series");
            SearchByBox.SelectedIndex = 0;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var searchItem = SearchByBox.SelectedValue.ToString();
            var searchText = searchBox.Text;

            switch (searchItem)
            {
                case "Books":
                    using (var dbContext = new BookStoreContext())
                    {
                        var query =
                            from book in dbContext.Books
                            join author in dbContext.Authors on book.AuthorRefId equals author.Id
                            join genre in dbContext.Genres on book.GenreRefId equals genre.Id
                            join category in dbContext.Categories on book.CategoryRefId equals category.Id
                            join serie in dbContext.Series on book.SerieRefId equals serie.Id
                            where book.Name.Contains(searchText)
                            select new
                            {
                                Id = book.Id,
                                Book__Name = book.Name,
                                Genre__Name = genre.Name,
                                Price = book.Price,
                                Category = category.Name,
                                Serie = serie.Name,
                                Author__First__Name = author.Firstname,
                                Author__Last__Name = author.Lastname
                            };

                        DataGrid1.ItemsSource = query.ToList();
                    }
                    break;

                case "Authors":
                    using (var dbContext = new BookStoreContext())
                    {
                        var query =
                            from book in dbContext.Books
                            join author in dbContext.Authors on book.AuthorRefId equals author.Id
                            join genre in dbContext.Genres on book.GenreRefId equals genre.Id
                            join category in dbContext.Categories on book.CategoryRefId equals category.Id
                            join serie in dbContext.Series on book.SerieRefId equals serie.Id
                            where author.Firstname.Contains(searchText) || author.Lastname.Contains(searchText)
                            select new
                            {
                                Id = book.Id,
                                Book__Name = book.Name,
                                Genre__Name = genre.Name,
                                Price = book.Price,
                                Category = category.Name,
                                Serie = serie.Name,
                                Author__First__Name = author.Firstname,
                                Author__Last__Name = author.Lastname
                            };

                        DataGrid1.ItemsSource = query.ToList();
                    }
                    break;

                case "Genres":
                    using (var dbContext = new BookStoreContext())
                    {
                        var query =
                            from book in dbContext.Books
                            join author in dbContext.Authors on book.AuthorRefId equals author.Id
                            join genre in dbContext.Genres on book.GenreRefId equals genre.Id
                            join category in dbContext.Categories on book.CategoryRefId equals category.Id
                            join serie in dbContext.Series on book.SerieRefId equals serie.Id
                            where genre.Name.Contains(searchText)
                            select new
                            {
                                Id = book.Id,
                                Book__Name = book.Name,
                                Genre__Name = genre.Name,
                                Price = book.Price,
                                Category = category.Name,
                                Serie = serie.Name,
                                Author__First__Name = author.Firstname,
                                Author__Last__Name = author.Lastname
                            };

                        DataGrid1.ItemsSource = query.ToList();
                    }
                    break;

                case "Categories":
                    using (var dbContext = new BookStoreContext())
                    {
                        var query =
                            from book in dbContext.Books
                            join author in dbContext.Authors on book.AuthorRefId equals author.Id
                            join genre in dbContext.Genres on book.GenreRefId equals genre.Id
                            join category in dbContext.Categories on book.CategoryRefId equals category.Id
                            join serie in dbContext.Series on book.SerieRefId equals serie.Id
                            where category.Name.Contains(searchText)
                            select new
                            {
                                Id = book.Id,
                                Book__Name = book.Name,
                                Genre__Name = genre.Name,
                                Price = book.Price,
                                Category = category.Name,
                                Serie = serie.Name,
                                Author__First__Name = author.Firstname,
                                Author__Last__Name = author.Lastname
                            };

                        DataGrid1.ItemsSource = query.ToList();
                    }
                    break;

                case "Series":
                    using (var dbContext = new BookStoreContext())
                    {
                        var query =
                            from book in dbContext.Books
                            join author in dbContext.Authors on book.AuthorRefId equals author.Id
                            join genre in dbContext.Genres on book.GenreRefId equals genre.Id
                            join category in dbContext.Categories on book.CategoryRefId equals category.Id
                            join serie in dbContext.Series on book.SerieRefId equals serie.Id
                            where serie.Name.Contains(searchText)
                            select new
                            {
                                Id = book.Id,
                                Book__Name = book.Name,
                                Genre__Name = genre.Name,
                                Price = book.Price,
                                Category = category.Name,
                                Serie = serie.Name,
                                Author__First__Name = author.Firstname,
                                Author__Last__Name = author.Lastname
                            };

                        DataGrid1.ItemsSource = query.ToList();
                    }
                    break;

                default:
                    break;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (productsInCart == null)
            {
                productsInCart = new List<int>();
            }

            foreach (dynamic item in DataGrid1.SelectedItems)
            {
                productsInCart.Add(item.Id);
                priceOfAllProducts += (decimal)item.Price;
                totalPrice.Content = priceOfAllProducts;
            }

            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string pathToJsonFile = string.Empty;

            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "json files (*.json)|*.json" // Filter files by extension
            };
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                pathToJsonFile = dlg.FileName;
            }

            List<Book> books = new List<Book>();
            using (StreamReader r = new StreamReader(pathToJsonFile))
            {
                string json = r.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            Book tempBook = new Book();
            Author tempAuthor = new Author();
            Genre tempGenre = new Genre();
            Category tempCategory = new Category();
            Series tempSeries = new Series();

            foreach (var book in books)
            {
                tempAuthor.Firstname = book.Author.Firstname;
                tempAuthor.Lastname = book.Author.Lastname;
                tempGenre.Name = book.Genre.Name;
                tempCategory.Name = book.Category.Name;
                tempSeries.Name = book.Serie.Name;
                tempBook.Name = book.Name;
                tempBook.Price = book.Price;
                tempBook.Serie = book.Serie;
                tempBook.Category = tempBook.Category;

                
                    using (var dbContext = new BookStoreContext())
                    {
                        dbContext.Series.Add(tempSeries);
                        dbContext.Categories.Add(tempCategory);
                        dbContext.Genres.Add(tempGenre);
                        dbContext.Authors.Add(tempAuthor);
                        dbContext.Books.Add(tempBook);
                    try
                    {
                        dbContext.SaveChanges();
                    }
                    catch (DbEntityValidationException ea)
                    {
                        foreach (var eve in ea.EntityValidationErrors)
                        {
                            searchBox.Text = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                searchBox.Text += string.Format("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                    }
                }

                
                

            }


        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
