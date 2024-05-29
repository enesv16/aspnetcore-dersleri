using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace efcoreApp.Controllers
{

    public class OgretmenController : Controller
    {
        private readonly DataContext _context;

        public OgretmenController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ogretmenler = await _context.Ogretmenler.ToListAsync();
            return View(ogretmenler);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model)
        {
            if (model.BaslamaTarihi == DateTime.MinValue)
            {
                model.BaslamaTarihi = DateTime.Now;
            }

            _context.Ogretmenler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            return View(ogretmen);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ogretmen model)
        {
            if (id!= model.OgretmenId)
            {
                return NotFound("Öğretmen bulunamadı");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Ogretmenler.Any(m => m.OgretmenId == model.OgretmenId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest("Geçersiz istek: id parametresi eksik.");
            }
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            return View(ogretmen);  
        }


        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen == null)
            {
                return NotFound("Öğretmen bulunamadı");
            }
            _context.Ogretmenler.Remove(ogretmen);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }
}