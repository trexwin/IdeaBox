using IdeaBox.Data.Extensions;
using IdeaBox.Data.Models.Types;
using IdeaBox.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IdeaBox.Backend.JsonConverters;

namespace IdeaBox.Web.Models
{
    public class IdeaViewModel
    {
        [Display(Name = "Id")]
        [JsonPropertyName("id")]
        public int Id { get => _idea.Id; }

        [Display(Name = "Aanmaakdatum")]
        [JsonPropertyName("aanmaakDatum")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime CreationDate { get => _idea.CreationDate; }


        [Display(Name = "Onderwerp")]
        [JsonPropertyName("onderwerp")]
        public string? Subject { get => _idea.Subject; }

        [Display(Name = "Beschrijving")]
        [JsonPropertyName("beschrijving")]
        public string? Body { get => _idea.Body; }

        // User
        [Display(Name = "Gebruikers id")]
        [JsonPropertyName("userId")]
        public int? UserId { get => _idea.User?.UserId; }

        [Display(Name = "Gebruikersnaam")]
        [JsonPropertyName("userName")]
        public string? UserName { get => _idea.User?.UserName; }

        // Type
        [Display(Name = "Type")]
        [JsonPropertyName("type")]
        public string? Type { get => _idea.IdeaType?.GetIdeaTypeAttributeName(); }

        [Display(Name = "Begin datum")]
        [JsonPropertyName("beginDatum")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? Begin { get => (_idea.IdeaType as Outing)?.Begin; }

        [Display(Name = "Eind datum")]
        [JsonPropertyName("eindDatum")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? End { get => (_idea.IdeaType as Outing)?.End; }

        // Misc?
        [Display(Name = "Categorieën")]
        [JsonPropertyName("categories")]
        public string[]? Categories { get => _idea.Categories; }

        [Display(Name = "Duur")]
        [JsonIgnore]
        public TimeSpan? Duration { get => End - Begin; }

        private Idea _idea;

        public IdeaViewModel(Idea idea)
            => _idea = idea;

    }
}
