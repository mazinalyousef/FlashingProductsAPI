using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ProductCreateDto
    {
        
        public string Title { get; set; }

        public string TitleEN { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? StartDate { get; set; }

        public Int64? Durationseconds { get; set; }

        public decimal? Price { get; set; }
    }
}
