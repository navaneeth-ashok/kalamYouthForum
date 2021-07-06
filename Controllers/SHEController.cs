﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KalamYouthForumWebApp.Data;
using KalamYouthForumWebApp.Models;
using KalamYouthForumWebApp.Models.ViewModels;

namespace KalamYouthForumWebApp.Controllers
{
    public class SHEController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SHEController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SHE
        public async Task<IActionResult> Index()
        {
            //var SHEs = await _context.sheModels.ToListAsync();
            //List<SHEChapter> sheChapters = new List<SHEChapter>();
            //foreach(var she in SHEs)
            //{
            //    ChapterModel SelectedChapter = _context.chapterModels.Include(c => c.SHEModels).Where(b => b.SHEModels;

            //    var model = new SHEChapter
            //    {
            //        Chapter = SelectedChapter,
            //        SHEModel = she
            //    };
            //    sheChapters.Add(model);
            //}
            ////return View(await _context.sheModels.ToListAsync());
            //return View(sheChapters);
            var chapters = await _context.chapterModels.ToListAsync();
            var shes = await _context.sheModels.ToListAsync();
            List<SHEChapter> sheChapters = new List<SHEChapter>();
            foreach (var she in shes)
            {
                SHEModel sheModel = _context.sheModels.Include(c => c.ChapterModels).Where(a => a.SHEId == she.SHEId).FirstOrDefault();
                ChapterModel chapterModel = _context.chapterModels.Include(c => c.SHEModels).Where(a => a.ChapterID == she.ChapterModels.First().ChapterID).FirstOrDefault();
                var model = new SHEChapter
                {
                    Chapter = chapterModel,
                    SHEModel = she
                };
                sheChapters.Add(model);
            }

            //List<SHEChapter> sheChapters = new List<SHEChapter>();
            //foreach (var chapter in chapters)
            //{
            //    foreach(var she in chapter.SHEModels)
            //    {
            //        var model = new SHEChapter
            //        {
            //            Chapter = chapter,
            //            SHEModel = she
            //        };
            //        sheChapters.Add(model);
            //    }
            //}
            return View(sheChapters);
        }

        public void AssociateSHEToChapter(int chapterID, int sheID)
        {
            // Adding SHE to Chapter
            ChapterModel SelectedChapter = _context.chapterModels.Include(c => c.SHEModels).Where(a => a.ChapterID == chapterID).FirstOrDefault();
            SHEModel sheModel = _context.sheModels.Find(sheID);
            SelectedChapter.SHEModels.Add(sheModel);

            _context.SaveChanges();
        }

        // GET: SHE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sHEModel = await _context.sheModels
                .FirstOrDefaultAsync(m => m.SHEId == id);
            if (sHEModel == null)
            {
                return NotFound();
            }

            return View(sHEModel);
        }

        // GET: SHE/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Create(int chapterID)
        {
            ViewBag.Message = chapterID;
            return View();
        }

        // POST: SHE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSHE([Bind("SHEId,SHEName,DateOfFormation,NumberOfMembers,ElectedPresident,PresidentEmail,PresidentPhoneNumber,ElectedSecretary,SecretaryEmail,SecretaryPhoneNumber,ElectedTreasurer,TreasurerEmail,TreasurerPhoneNumber")] SHEModel sHEModel, int chapterID)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sHEModel);
                await _context.SaveChangesAsync();
                // assigning this SHE to the parent chapter
                AssociateSHEToChapter(chapterID, sHEModel.SHEId);
                return RedirectToAction("Details", "ChapterModels", new { id = chapterID });
            }
            return View(sHEModel);
        }

        // GET: SHE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sHEModel = await _context.sheModels.FindAsync(id);
            if (sHEModel == null)
            {
                return NotFound();
            }
            return View(sHEModel);
        }

        // POST: SHE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SHEId,SHEName,DateOfFormation,NumberOfMembers,ElectedPresident,PresidentEmail,PresidentPhoneNumber,ElectedSecretary,SecretaryEmail,SecretaryPhoneNumber,ElectedTreasurer,TreasurerEmail,TreasurerPhoneNumber")] SHEModel sHEModel)
        {
            if (id != sHEModel.SHEId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sHEModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SHEModelExists(sHEModel.SHEId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sHEModel);
        }

        // GET: SHE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sHEModel = await _context.sheModels
                .FirstOrDefaultAsync(m => m.SHEId == id);
            if (sHEModel == null)
            {
                return NotFound();
            }

            return View(sHEModel);
        }

        // POST: SHE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sHEModel = await _context.sheModels.FindAsync(id);
            _context.sheModels.Remove(sHEModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SHEModelExists(int id)
        {
            return _context.sheModels.Any(e => e.SHEId == id);
        }
    }
}
