using IdeaBox.Data.Archive;
using IdeaBox.Data.Models.Types;
using IdeaBox.Mapper;
using IdeaBox.Storage.Implementations;

namespace IdeaBox.Backend.Storage
{
    public class LocalIdeaStorage : BaseLocalStorage<Data.Models.Idea, Idea>
    {
        private IMapper _mapper;

        public LocalIdeaStorage(string localFolderPath) : base(localFolderPath)
            => _mapper = new Mapper.Mapper();

        protected override Data.Models.Idea ToMemory(Idea obj)
        {
            // From local storage to backend
            return _mapper.Map(obj) as Data.Models.Idea ?? throw new InvalidOperationException($"Type {obj.GetType().Name} does not map to {nameof(Data.Models.Idea)}."); ;
        }
            /*
            var res = new Data.Models.Idea();
            res.Id = obj.Id;
            res.CreationDate = obj.CreationDate;
            res.Subject = obj.Subject;
            res.Body = obj.Body;

            if (obj.User != null)
                res.User = new Data.Models.User() { UserId = obj.User.UserId, UserName = obj.User.UserName };

            res.IdeaType = ToMemory(obj.IdeaType);

            if (obj.Categories != null)
            {
                res.Categories = new string[obj.Categories.Length];
                obj.Categories.CopyTo(res.Categories, 0);
            }
            
            return res;
        }

        protected BaseIdeaType ToMemory(IdeaType obj)
        {
            var typeName = obj.TypeName;
            if (typeName == "suggestie")
                return new Suggestion();
            else if (typeName == "uitje")
                return new Outing() { Begin = obj.Begin, End = obj.End };
            else
                throw new NotSupportedException($"The IdeaType \"{typeName}\" is not supported.");
        }
            */

        protected override Idea ToStorage(Data.Models.Idea obj)
        {
            // From backend to local storage
            return _mapper.Map(obj) as Idea ?? throw new InvalidOperationException($"Type {obj.GetType().Name} does not map to {nameof(Idea)}.");
        }
            /*
            if (obj.IdeaType == null)
                throw new NullReferenceException($"The given idea does not have it's ideatype set.");

            var res = new Idea(obj.Id, obj.CreationDate, new IdeaType(obj.IdeaType.IdeaTypeName));

            res.Id = obj.Id;
            res.CreationDate = obj.CreationDate;
            res.Subject = obj.Subject;
            res.Body = obj.Body;

            if (obj.User != null && obj.User.UserName != null && obj.User.UserId != null)
                res.User = new User(obj.User.UserName, obj.User.UserId.Value);

            ToStorage(res.IdeaType, obj.IdeaType);

            if (obj.Categories != null)
            {
                res.Categories = new string[obj.Categories.Length];
                obj.Categories.CopyTo(res.Categories, 0);
            }

            return res;
        }

        protected void ToStorage(IdeaType storage, BaseIdeaType backend)
        {
            if(backend is Outing outing)
            {
                storage.Begin = outing.Begin;
                storage.End = outing.End;
            }
        }
            */
        }
    }
