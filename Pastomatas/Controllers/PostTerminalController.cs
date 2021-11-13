using Microsoft.AspNetCore.Mvc;
using Pastomatas.Data;
using Pastomatas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pastomatas.Controllers
{
    public class PostTerminalController : Controller
    {
        public readonly DataContext _context;

        public PostTerminalController(DataContext context)
        {
            _context = context;
        }

        public IActionResult TerminalIndex()
        {
            var terminals = _context.PostTerminals.OrderBy(s => s.Code).ToList();
            return View(terminals);
        }

        public IActionResult TerminalAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TerminalAdd(PostTerminalModel newTerminal)
        {
            _context.PostTerminals.Add(newTerminal);
            _context.SaveChanges();
            return RedirectToAction("TerminalIndex");
        }

        public IActionResult TerminalEdit(int id)
        {
            var terminal = _context.PostTerminals.FirstOrDefault(B => B.TerminalId == id);
            return View(terminal);
        }

        [HttpPost]
        public IActionResult TerminalEdit(PostTerminalModel terminal)
        {
            _context.Update(terminal);
            _context.SaveChanges();
            return RedirectToAction("TerminalIndex");
        }

        public IActionResult TerminalRemove(int id)
        {
            var terminal = _context.PostTerminals.FirstOrDefault(B => B.TerminalId == id);
            _context.Remove(terminal);
            _context.SaveChanges();
            return RedirectToAction("TerminalIndex");
        }
    }
}
