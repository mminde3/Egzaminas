using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pastomatas.Models
{
    public class PostTerminalModel
    {
        [Key]
        public int TerminalId { get; set; }

        [Column(TypeName = "varchar(55)")]
        public string Town { get; set; }

        public int Capacity { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Code { get; set; }

        public ICollection<PostPackageModel> Package { get; set; }
    }
}
