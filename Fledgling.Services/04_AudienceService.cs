using Fledgling.Data;
using Fledgling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Services
{
    public class AudienceService
    {
        private readonly Guid _userId;

        public AudienceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAudience(AudienceCreate model)
        {
            var entity =
                new Audience()
                {
                    OwnerID = _userId,
                    IdeaID = model.IdeaID,
                    Who = model.Who,
                    What = model.What,
                    Why = model.Why,
                    When = model.When,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Audiences.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AudienceListItem> GetAudiences()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Audiences
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new AudienceListItem
                                {
                                    AudienceID = e.AudienceID,
                                    IdeaID = e.IdeaID,
                                    Who = e.Who,
                                    What = e.What,
                                    Why = e.Why,
                                    When = e.When,
                                    CreatedUTC = e.CreatedUTC
                                }
                        );

                return query.ToArray();
            }
        }

        public AudienceDetail GetAudienceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Audiences
                        .Single(e => e.AudienceID == id && e.OwnerID == _userId);
                return
                    new AudienceDetail
                    {
                        AudienceID = entity.AudienceID,
                        IdeaID = entity.IdeaID,
                        Who = entity.Who,
                        What = entity.What,
                        Why = entity.Why,
                        When = entity.When,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateAudience(AudienceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Audiences
                        .Single(e => e.AudienceID == model.AudienceID && e.OwnerID == _userId);

                entity.Who = model.Who;
                entity.What = model.What;
                entity.Why = model.Why;
                entity.When = model.When;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAudience(int audienceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Audiences
                        .Single(e => e.AudienceID == audienceId && e.OwnerID == _userId);

                ctx.Audiences.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
