using IdeaBox.Data.Extensions;
using IdeaBox.Data.Models;
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
        public async Task<ActionResult<IEnumerable<IdeaViewModel>>> Index(string? type)
        {
            var ideas = await _ideaStorage.LoadValues();
            if (type != null)
                ideas = ideas.Where(i => i.IdeaType?.GetIdeaTypeAttributeName() == type);
            
            var ideaViewModels = ideas.Select(i => new IdeaViewModel(i));
            return View(ideaViewModels.OrderByDescending(i => i.CreationDate));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IdeaViewModel?>> Item(int id)
        {
            var ideas = await _ideaStorage.LoadValues();
            var idea = ideas.FirstOrDefault(i => i.Id == id);
            return View(idea == null ? null : new IdeaViewModel(idea));
        }

        [HttpGet]
        public ActionResult Create()
            => View();


        [HttpPost]
        public async Task<ActionResult<NewIdeaViewModel>> Create(NewIdeaViewModel ideaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _ideaStorage.StoreValue(ideaViewModel.Idea);
                return RedirectToAction("Index");
            }
            return View(ideaViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
