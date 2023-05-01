using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
   public class CustomeFeild
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public virtual ICollection<CustomeFeildValue> CustomeFeildValues { get; set; }
    }
}
