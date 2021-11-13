using Pastomatas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pastomatas.Dto
{
    public class PackageWithTerminals
    {
        public PostPackageModel Package { get; set; }
        public List<PostTerminalModel> Terminals { get; set; }
    }
}
