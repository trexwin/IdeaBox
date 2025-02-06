using IdeaBox.Data.Extensions;
using IdeaBox.Data.Models;
using IdeaBox.Storage;
using IdeaBox.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBox.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        private readonly IStorage<Idea> _ideaStorage;

        public IdeaController(IStorage<Idea> ideaStorage)
        {
            _ideaStorage = ideaStorage;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdeaViewModel>>> Index(string? type)
        {
            var ideas = await _ideaStorage.LoadValues();
            if (type != null)
                ideas = ideas.Where(i => i.IdeaType?.GetIdeaTypeAttributeName() == type);
            return Ok(ideas.Select(i => new IdeaViewModel(i)));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IdeaViewModel>> Item(int id)
        {
            var ideas = await _ideaStorage.LoadValues();
            var idea = ideas.FirstOrDefault(i => i.Id == id);
            return idea == null ? NotFound() : Ok(new IdeaViewModel(idea));
        }

        [HttpPost]
        public async Task<ActionResult<IdeaViewModel>> Post([FromBody] NewIdeaViewModel idea)
        {
            var newIdea = await _ideaStorage.StoreValue(idea.Idea);
            var ideaViewModel = new IdeaViewModel(newIdea);
            return CreatedAtAction(nameof(Item), new { id = ideaViewModel.Id }, ideaViewModel);
        }
    }
}
