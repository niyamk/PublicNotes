using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicNotes.Data;
using PublicNotes.Models;
using System.Threading.Tasks;

namespace PublicNotes.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // This action runs when you visit the homepage
        // It GETS all notes and displays them
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Get all notes from the DB, ordered by newest first
            var notes = await _context.Notes
                                      .OrderByDescending(n => n.CreatedAt)
                                      .ToListAsync();
            
            // Pass the list of notes to the View
            return View(notes);
        }

        // This action runs when you submit the "Create Note" form
        // It POSTS the new note data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content")] Note note)
        {
            if (ModelState.IsValid)
            {
                // Set the creation time and add the new note to the context
                note.CreatedAt = DateTime.UtcNow;
                _context.Add(note);
                
                // Save changes to the database
                await _context.SaveChangesAsync();
                
                // Redirect back to the homepage to see the new note
                return RedirectToAction(nameof(Index));
            }
            
            // If the model is not valid (e.g., empty title),
            // just redisplay the page.
            var notes = await _context.Notes
                                      .OrderByDescending(n => n.CreatedAt)
                                      .ToListAsync();
            return View("Index", notes);
        }
    }
}