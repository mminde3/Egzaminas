using Microsoft.AspNetCore.Mvc;
using Pastomatas.Data;
using Pastomatas.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pastomatas.Controllers
{
    public class PostPackageController : Controller
    {
        public readonly DataContext _context;

        public PostPackageController(DataContext context)
        {
            _context = context;
        }

        public IActionResult PackageIndex()
        {
            var packages = new ViewPackageIndex()
            {
                Packages = _context.PostPackages.OrderByDescending(s => s.Weight).ToList(),
                Terminals = _context.PostTerminals.ToList()
            };
            return View(packages);
        }
        
        public IActionResult PackageFilter(ViewPackageIndex choise)
        {
            var packages = new ViewPackageIndex()
            {
                Packages = _context.PostPackages
                    .Where(f => f.TerminalId == choise.TerminalId || choise.TerminalId == 0)
                    .OrderByDescending(s => s.Weight).ToList(),
                Terminals = _context.PostTerminals.ToList()
            };
            return View("PackageIndex", packages);
        }

        public IActionResult PackageAdd()
        {
            var packageTerminals = new PackageWithTerminals()
            {
                Terminals = _context.PostTerminals.ToList()
            };
            return View(packageTerminals);
        }

        [HttpPost]
        public IActionResult PackageAdd(PackageWithTerminals postPakage)
        {
            _context.PostPackages.Add(postPakage.Package);
            _context.SaveChanges();
            return RedirectToAction("PackageIndex");
        }

        public IActionResult PackageEdit(int id)
        {
            var packageWithTerminals = new PackageWithTerminals()
            {
                Package = _context.PostPackages.FirstOrDefault(B => B.PackageId == id),
                Terminals = _context.PostTerminals.ToList()
            };
            return View(packageWithTerminals);
        }

        [HttpPost]
        public IActionResult PackageEdit(PackageWithTerminals pack)
        {
            _context.Update(pack.Package);
            _context.SaveChanges();
            return RedirectToAction("PackageIndex");
        }

        public IActionResult PackageRemove(int id)
        {
            var package = _context.PostPackages.FirstOrDefault(B => B.PackageId == id);
            _context.Remove(package);
            _context.SaveChanges();
            return RedirectToAction("PackageIndex");
        }
    }
}
