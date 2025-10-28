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

        // This action runs when the "Delete" form is posted
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Find the note in the database by its ID
            var note = await _context.Notes.FindAsync(id);
                    
            if (note != null)
            {
                // If we found the note, remove it from the context
                _context.Notes.Remove(note);
                
                // Save the changes to the database
                await _context.SaveChangesAsync();
            }
            
            // Redirect back to the homepage
            return RedirectToAction(nameof(Index));
        }

        // This action runs when you click the "Edit" button
// It GETS the data and shows the Edit page
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // Find the note by its ID
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
            {
                // If no note is found, return a 404 error
                return NotFound();
            }
                    
            // Pass the found note to the "Edit.cshtml" view
            return View(note);
        }

        // This action runs when you submit the "Save Changes" form
        // It POSTS the updated data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,CreatedAt")] Note note)
        {
            // Check if the ID from the URL matches the ID from the form's hidden field
            if (id != note.Id)
            {
                return NotFound();
            }

            // Check if the model is valid (e.g., Title and Content aren't empty)
            if (ModelState.IsValid)
            {
                try
                {
                    // Tell the context to track this note and mark it as "Modified"
                    _context.Update(note);
                    
                    // Save the changes
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // This is a safety check in case the note was deleted by someone else
                    // while you were editing it.
                    if (!_context.Notes.Any(e => e.Id == note.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // If save was successful, redirect to the homepage
                return RedirectToAction(nameof(Index));
            }
                    
            // If the model was invalid (e.g., empty title),
            // stay on the Edit page and show the errors.
            return View(note);
        }
    }
}