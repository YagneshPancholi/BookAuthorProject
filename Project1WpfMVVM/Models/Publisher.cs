using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project1WpfMVVM.Models
{
    public class Publisher
    {
        public string publisherName { get; set; } = string.Empty;

        public ICommand AddPublisherCommand { get; set; }
        public ICommand DeletePublisherCommand { get; set; }
    }
}