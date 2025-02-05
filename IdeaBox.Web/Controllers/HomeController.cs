using IdeaBox.Storage;
using IdeaBox.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdeaBox.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStorage<Idea> _ideaStorage;
        
        public HomeController(IStorage<Idea> ideaStorage)
        {
            _ideaStorage = ideaStorage;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Idea>>> Index(string? type)
        {
            var ideas = await _ideaStorage.LoadValues();
            if (type != null)
                ideas = ideas.Where(i => i.Type == type);

            return View(ideas.OrderByDescending(i => i.CreationDate));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Idea?>> Item(int id)
        {
            var ideas = await _ideaStorage.LoadValues();
            return View(ideas.FirstOrDefault(i => i.Id == id));
        }

        [HttpGet]
        public ActionResult Create()
            => View();


        [HttpPost]
        public async Task<ActionResult<Idea>> Create(Idea idea)
        {
            if (ModelState.IsValid)
            {
                await _ideaStorage.StoreValue(idea);
                return RedirectToAction("Index");
            }
            return View(idea);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
