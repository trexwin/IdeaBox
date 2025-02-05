using IdeaBox.Storage;
using IdeaBox.Web.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Diagnostics;

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
        public async Task<ActionResult<IEnumerable<Idea>>> Index(string? type)
        {
            var ideas = await _ideaStorage.LoadValues();
            if (type != null)
                ideas = ideas.Where(i => i.Type == type);
            return Ok(ideas);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<Idea>>> Item(int id)
        {
            var ideas = await _ideaStorage.LoadValues();
            var idea = ideas.FirstOrDefault(i => i.Id == id);
            return idea == null ? NotFound() : Ok(idea);
        }

        [HttpPost]
        public async Task<ActionResult<Idea>> Post([FromBody] Idea idea)
        {
            var newIdea = await _ideaStorage.StoreValue(idea);
            return CreatedAtAction(nameof(Item), new { id = newIdea.Id }, newIdea);
        }

    }
}
