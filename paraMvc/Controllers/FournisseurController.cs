using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using paraMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using paraMvc.Data;
using Microsoft.EntityFrameworkCore;
using paraMvc.Data.Services;
using System.Numerics;

namespace paraMvc.Controllers
{
    public class FournisseurController : Controller
    {
        private readonly IFournisseurService _service;

       
        public FournisseurController (IFournisseurService service)
        {
            _service = service;
        }
        public async Task< IActionResult> Index()
        {
            var allFournisseurs = await _service.GetAllAsync();
            return View(allFournisseurs);
        }
        //Get : Fourisseur/Create

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Telephone")] Fournisseur fourisseur)
        {
            if (!ModelState.IsValid)
            {
                return View(fourisseur);
            }
           await _service.AddAsync(fourisseur);
            return RedirectToAction(nameof(Index));
        }

        //Get :
        //    [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var fourisseurDetails =await _service.GetByIdAsync(id);

            if (fourisseurDetails == null) return View("NoteFound");
            return View(fourisseurDetails );
        }

        public async Task<IActionResult> Edit(int id)
        {
            var fourisseurDetails = await _service.GetByIdAsync(id);

            if (fourisseurDetails == null) return View("NoteFound");
            return View(fourisseurDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Telephone")] Fournisseur fourisseur)
        {

            if (!ModelState.IsValid)
            {
                return View(fourisseur);
            }
           await _service.UpdateAsync(id,fourisseur);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var fourisseurDetails = await _service.GetByIdAsync(id);

            if (fourisseurDetails == null) return View("NoteFound");
            return View(fourisseurDetails);
         }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fourisseurDetails = await _service.GetByIdAsync(id);

            if (fourisseurDetails == null) return View("NoteFound");
          
            await _service.DeleteAsync(id);

          
            return RedirectToAction(nameof(Index));
        }
    }
}
