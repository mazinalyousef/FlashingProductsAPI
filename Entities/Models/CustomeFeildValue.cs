using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CustomeFeildValue
    {
        public int Id { get; set; }
        public string key { get; set; }
        public string value { get; set; }


        [ForeignKey(nameof(CustomeFeild))]
        public int CustomeFeildId { get; set; }
    }
}
