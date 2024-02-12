using Project1WpfMVVM.Services;
using Project1WpfMVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Project1WpfMVVM.Models
{
    public class Author
    {
        public string authorName { get; set; } = string.Empty;
        public string birthDate { get; set; } = DateTime.Now.ToString("d");
        public string email { get; set; } = string.Empty;
        public string education { get; set; } = string.Empty;

        [JsonIgnore]
        public ICommand? DeleteAuthorCommand { get; set; }

        [JsonIgnore]
        public ICommand? EditAuthorCommand { get; set; }

        [JsonIgnore]
        public ICommand? AddAuthorCommand { get; set; }
    }
}