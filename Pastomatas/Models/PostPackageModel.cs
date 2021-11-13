using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pastomatas.Models
{
    public class PostPackageModel
    {
        [Key]
        public int PackageId { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string ReceiverName { get; set; }

        [Column(TypeName = "decimal(6,3)")]
        public decimal Weight { get; set; }

        public uint Phone { get; set; }

        [Column(TypeName = "text")]
        public string Text { get; set; }

        [ForeignKey("PostTerminalModel")]
        public int TerminalId { get; set; }

        public PostTerminalModel TerminalModel { get; set; }
    }
}