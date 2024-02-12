using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project1WpfMVVM.Models
{
    public class Book
    {
        public string bookName { get; set; }
        public decimal price { get; set; }

        public string PriceStr
        {
            get
            {
                if(price == 0)
                {
                    return "Free";
                }
                return price.ToString();
            }
            set
            {
                if (decimal.TryParse(value, out decimal convertedPrice))
                {
                    price = convertedPrice;
                }
                else
                {
                    MessageBox.Show("Price Formate Is Invalid,Only Numbers Allowed");
                    price = (decimal)-1.00;
                }
            }
        }

        public List<string> authorNames { get; set; }

        [JsonIgnore]
        public string AuthorNamesStr
        {
            get
            {
                return string.Join(", ", authorNames);
            }
            set
            {
                if (authorNames != null && value != string.Empty)
                {
                    authorNames.Clear();
                    authorNames.AddRange(value.Split(", "));
                }
                else
                {
                    authorNames = new List<string>();
                }
            }
        }

        public List<string> genreNames { get; set; }

        [JsonIgnore]
        public string GenreNamesStr
        {
            get
            {
                return string.Join(", ", genreNames);
            }
            set
            {
                if (genreNames != null)
                {
                    genreNames.Clear();
                    genreNames.AddRange(value.Split(", "));
                }
                else
                {
                    genreNames = new List<string>();
                }
            }
        }

        public List<string> publisherNames { get; set; }

        [JsonIgnore]
        public string PublisherNamesStr
        {
            get
            {
                return string.Join(", ", publisherNames);
            }
            set
            {
                if (publisherNames != null)
                {
                    publisherNames.Clear();
                    publisherNames.AddRange(value.Split(", "));
                }
                else
                {
                    publisherNames = new List<string>();
                }
            }
        }

        [JsonIgnore]
        public ICommand EditBookCommand { get; set; }

        [JsonIgnore]
        public ICommand DeleteBookCommand { get; set; }

        [JsonIgnore]
        public ICommand AddBookCommand { get; set; }
    }
}