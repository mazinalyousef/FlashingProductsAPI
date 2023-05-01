using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
   public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Product title is required feild....")]
        public string Title { get; set; }

        public string TitleEN { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? StartDate { get; set; }

        /// <summary>
        /// the duration that the product will show in seconds...
        /// </summary>
        public Int64? Durationseconds { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }


        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }

        public virtual Category category { get; set; }

        public virtual ICollection<CustomeFeild> CustomeFeilds { get; set; }

    }
}
