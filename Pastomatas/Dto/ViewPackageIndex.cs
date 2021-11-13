using Pastomatas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pastomatas.Dto
{
    public class ViewPackageIndex
    {
        public List<PostPackageModel> Packages { get; set; }
        public List<PostTerminalModel> Terminals { get; set; }
        public int TerminalId { get; set; }
    }
}
