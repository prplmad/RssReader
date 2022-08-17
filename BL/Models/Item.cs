using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Item
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public Item(string title, DateTime date, string description, string url)
        {
            this.Title = title;
            this.Date = date;
            this.Description = description;
            this.Url = url;
        }
    }
}
