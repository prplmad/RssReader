using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Item
    {
        public String Title { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public String Url { get; set; }

        public Item(string title, DateTime date, string description, string url)
        {
            this.Title = title;
            this.Date = date;
            this.Description = description;
            this.Url = url;
        }
    }
}
