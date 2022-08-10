using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
#nullable disable
    public class Settings
    {
        public bool DescriptionTags { get; set; }
        public string[] Url { get; set; }
        public int UpdateTime { get; set; }
    }
}
