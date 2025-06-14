using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravelApp.Pages;

public class ViewNotesModel : PageModel
{
    [BindProperty] public InputModel Input { get; set; }

    public List<string> FileNames { get; set; } = [];

    public string? SelectedFileName { get; set; }

    public string? SelectedFileContent { get; set; }

    public void OnGet(string? file = null)
    {
        var dir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");
        Directory.CreateDirectory(dir);

        FileNames = Directory
            .EnumerateFiles(dir, "*.txt")
            .OrderBy(f => new FileInfo(f).CreationTime)
            .Select(Path.GetFileName)
            .Where(f => !string.IsNullOrEmpty(f))
            .Select(f => f!)
            .ToList();

        if (!string.IsNullOrEmpty(file))
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", file);
            if (System.IO.File.Exists(filePath))
            {
                SelectedFileName = file;
                SelectedFileContent = System.IO.File.ReadAllText(filePath);
            }
        }
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        var fileName = $"note-{timestamp}.txt";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", fileName);

        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        System.IO.File.WriteAllText(filePath, Input.Content);

        return RedirectToPage();
    }

    public class InputModel
    {
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Content { get; set; }
    }
}