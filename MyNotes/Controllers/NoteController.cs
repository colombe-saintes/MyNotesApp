using Microsoft.AspNetCore.Mvc;
using MyNotes.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyNotes.Controllers
{
    public class NoteController : Controller
    {
        // In-memory storage (temporary)
        private static List<Note> notes = new List<Note>();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(notes);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Note note)
        {
            if (note.Id == 0)
            {
                note.Id = nextId++;
                notes.Add(note);
            }
            else
            {
                var existing = notes.FirstOrDefault(n => n.Id == note.Id);
                if (existing != null)
                {
                    existing.Title = note.Title;
                    existing.Content = note.Content;
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var note = notes.FirstOrDefault(n => n.Id == id);
            return View("New", note);
        }

        public IActionResult Delete(int id)
        {
            var note = notes.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                notes.Remove(note);
            }

            return RedirectToAction("Index");
        }
    }
}
