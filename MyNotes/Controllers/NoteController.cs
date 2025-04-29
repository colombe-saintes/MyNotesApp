using Microsoft.AspNetCore.Mvc;
using MyNotes.Data;
using MyNotes.Models;
using System.Linq;

namespace MyNotes.Controllers
{
    public class NoteController : Controller
    {
        private readonly AppDbContext _context;

        public NoteController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notes = _context.Notes.OrderByDescending(n => n.Date).ToList();
            return View(notes);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Note note)
        {
            note.Date = DateTime.Now.ToString();

            if (note.Id == 0)
            {
                _context.Notes.Add(note);
            }
            else
            {
                var existing = _context.Notes.FirstOrDefault(n => n.Id == note.Id);
                if (existing != null)
                {
                    existing.Title = note.Title;
                    existing.Content = note.Content;
                    existing.Date = DateTime.Now.ToString();
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Display(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            return View("Display", note);
        }

        public IActionResult Edit(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            return View("New", note);
        }

        public IActionResult Delete(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteAll()
        {
            _context.Notes.RemoveRange(_context.Notes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Duplicate(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                var duplicate = new Note
                {
                    Title = note.Title + " (Copy)",
                    Content = note.Content,
                    Date = note.Date
                };

                _context.Notes.Add(duplicate);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult SortNewestToOldest()
        {
            var sortedNotes = _context.Notes.OrderByDescending(n => n.Date).ToList();
            return View("Index", sortedNotes);
        }

        public IActionResult SortOldestToNewest()
        {
            var sortedNotes = _context.Notes.OrderBy(n => n.Date).ToList();
            return View("Index", sortedNotes);
        }
    }
}
