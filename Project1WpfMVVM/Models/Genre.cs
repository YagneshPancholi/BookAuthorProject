using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project1WpfMVVM.Models
{
    public class Genre
    {
        public string genreName { get; set; } = string.Empty;

        public ICommand AddGenreCommand { get; set; }
        public ICommand DeleteGenreCommand { get; set; }
    }
}