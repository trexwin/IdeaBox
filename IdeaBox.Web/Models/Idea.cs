using IdeaBox.JsonConverter;
using IdeaBox.Storage;
using IdeaBox.Validators;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IdeaBox.Web.Models
{
    public class Idea : IStorageItem
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Onderwerp")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(512)]
        [JsonPropertyName("onderwerp")]
        public string? Subject { get; set; }

        [Display(Name = "Beschrijving")]
        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("beschrijving")]
        public string? Body { get; set; }

        // User
        [Display(Name = "Gebruikers id")]
        [RequiredIfSet(nameof(UserName))]
        [JsonPropertyName("userId")]
        public int? UserId { get; set; }

        [Display(Name = "Gebruikersnaam")]
        [RequiredIfSet(nameof(UserId))]
        [MaxLength(512)]
        [JsonPropertyName("userName")]
        public string? UserName { get; set; }

        // Type
        [Display(Name = "Type")]
        [Required(AllowEmptyStrings = false)]
        [StringRange(["suggestie", "uitje"])]
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [Display(Name = "Begin datum")]
        [RequiredIfValue(nameof(Type), "uitje")]
        [FutureDate]
        [JsonPropertyName("beginDatum")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? Begin { get; set; }

        [Display(Name = "Eind datum")]
        [RequiredIfValue(nameof(Type), "uitje")]
        [GreaterThan(nameof(Begin))]
        [JsonPropertyName("eindDatum")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? End { get; set; }


        [Display(Name = "Duur")]
        [JsonIgnore]
        public TimeSpan? Duration { get => End - Begin; }

        // Misc?
        [Display(Name = "Categorieën")]
        [ArrayMemberMaxLenght(512)]
        [JsonPropertyName("categories")]
        public string[]? Categories { get; set; }
    }
}
