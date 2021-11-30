using Fledgling.Data;
using Fledgling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Services
{
    public class IdeaService
    {
        private readonly Guid _userId;

        public IdeaService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateIdea(IdeaCreate model)
        {
            var entity =
                new Idea()
                {
                    OwnerID = _userId,
                    ProjectID = model.ProjectID,
                    IdeaName = model.IdeaName,
                    IdeaAuthor = model.IdeaAuthor,
                    IdeaThesis = model.IdeaThesis,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ideas.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<IdeaListItem> GetIdeas()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ideas
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new IdeaListItem
                                {
                                    IdeaID = e.IdeaID,
                                    ProjectID = e.ProjectID,
                                    IdeaName = e.IdeaName,
                                    IdeaAuthor = e.IdeaAuthor,
                                    IdeaThesis = e.IdeaThesis,
                                    CreatedUTC = e.CreatedUTC
                                }
                        );

                return query.ToArray();
            }
        }

        public IdeaDetail GetIdeaById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ideas
                        .Single(e => e.IdeaID == id && e.OwnerID == _userId);
                return
                    new IdeaDetail
                    {
                        IdeaID = entity.IdeaID,
                        ProjectID = entity.ProjectID,
                        IdeaName = entity.IdeaName,
                        IdeaAuthor = entity.IdeaAuthor,
                        IdeaThesis = entity.IdeaThesis,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateIdea(IdeaEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ideas
                        .Single(e => e.IdeaID == model.IdeaID && e.OwnerID == _userId);

                entity.IdeaName = model.IdeaName;
                entity.IdeaAuthor = model.IdeaAuthor;
                entity.IdeaThesis = model.IdeaThesis;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteIdea(int ideaId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ideas
                        .Single(e => e.IdeaID == ideaId && e.OwnerID == _userId);

                ctx.Ideas.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
