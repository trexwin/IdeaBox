using IdeaBox.Data.Models;
using IdeaBox.Data.Extensions;
using IdeaBox.Logic.JsonConverters;
using IdeaBox.Logic.Validators;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IdeaBox.Data.Models.Types;
using IdeaBox.Data.Helper;

namespace IdeaBox.Web.Models
{
    public class NewIdeaViewModel
    {
        [Display(Name = "Onderwerp")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(512)]
        [JsonPropertyName("onderwerp")]
        public string? Subject 
        {
            get => Idea.Subject;
            set => Idea.Subject = value; 
        }

        [Display(Name = "Beschrijving")]
        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("beschrijving")]
        public string? Body
        {
            get => Idea.Body;
            set => Idea.Body = value;
        }

        // User
        [Display(Name = "Gebruikers id")]
        [RequiredIfSet(nameof(UserName))]
        [JsonPropertyName("userId")]
        public int? UserId 
        {
            get => Idea.User?.UserId;
            set
            {
                Idea.User ??= new User();
                Idea.User.UserId = value;
            }
        }

        [Display(Name = "Gebruikersnaam")]
        [RequiredIfSet(nameof(UserId))]
        [MaxLength(512)]
        [JsonPropertyName("userName")]
        public string? UserName
        {
            get => Idea.User?.UserName;
            set
            {
                Idea.User ??= new User();
                Idea.User.UserName = value;
            }
        }

        // Type
        [Display(Name = "Type")]
        [Required(AllowEmptyStrings = false)]
        [IdeaTypeRange]
        [JsonPropertyName("type")]
        public string? Type 
        {
            get => Idea.IdeaType?.GetIdeaTypeAttributeName();
            set => Idea.IdeaType = IdeaTypeHelper.CreateIdeaType(value);
        }

        [Display(Name = "Begin datum")]
        [RequiredIfValue(nameof(Type), "uitje")]
        [FutureDate]
        [JsonPropertyName("beginDatum")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? Begin 
        {
            get => (Idea.IdeaType as Outing)?.Begin;
            set
            {
                if(Idea.IdeaType is Outing outing)
                    outing.Begin = value;
            } 
        }

        [Display(Name = "Eind datum")]
        [RequiredIfValue(nameof(Type), "uitje")]
        [GreaterThan(nameof(Begin))]
        [JsonPropertyName("eindDatum")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? End 
        {
            get => (Idea.IdeaType as Outing)?.End;
            set
            {
                if (Idea.IdeaType is Outing outing)
                    outing.End = value;
            }
        }

        // Misc?
        [Display(Name = "Categorieën")]
        [ArrayMemberMaxLenght(512)]
        [JsonPropertyName("categories")]
        public string[]? Categories 
        {
            get => Idea.Categories;
            set => Idea.Categories = value; 
        }

        [JsonIgnore]
        public Idea Idea { get; }

        public NewIdeaViewModel()
            => Idea = new Idea();

    }
}
