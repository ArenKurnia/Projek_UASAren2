using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projek_UTSAren.Data;
using Projek_UTSAren.Helper;
using Projek_UTSAren.Models;
using Projek_UTSAren.Services;
using Projek_UTSAren.Services.AlumniService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Controllers
{
    public class AlumniController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAlumniService _alumniService;
        public AlumniController(AppDbContext context, IAlumniService alumni)
        {
            _context = context;
            _alumniService = alumni;
        }
        public IActionResult Index()
        {
            var data = _context.Tb_Alumni.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Alumni parameter)
        {
            if (ModelState.IsValid)
            {
                _alumniService.CreateAlumni(parameter);

                return RedirectToAction("Index");
            }
            return View(parameter);
        }
        public async Task<IActionResult> Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ubah = await _context.Tb_Alumni.FindAsync(id);
            if (ubah == null)
            {
                return NotFound();
            }
            return View(ubah);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Alumni ubah)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ubah);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    return NotFound(0);
                }
                return RedirectToAction("Index", "Alumni");
            }
            return View(ubah);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var cari = _context.Tb_Alumni.Where(x => x.NIM == id).FirstOrDefault();
            if (cari == null)
            {
                return NotFound();
            }
            _context.Tb_Alumni.Remove(cari);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public IActionResult Detail(string id)
        {
            Alumni cari = _alumniService.AmbilAlumniBerdasarkanId(id);

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }
    }
}
