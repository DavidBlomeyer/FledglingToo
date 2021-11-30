using Fledgling.Data;
using Fledgling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Services
{
    public class RequirementService
    {
        private readonly Guid _userId;

        public RequirementService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRequirement(RequirementCreate model)
        {
            var entity =
                new Requirement()
                {
                    OwnerID = _userId,
                    ReqOrigin = model.ReqOrigin,
                    ReqDescription = model.ReqDescription,
                    ReqLink = model.ReqLink,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Requirements.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RequirementListItem> GetRequirements()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Requirements
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new RequirementListItem
                                {
                                    RequirementID = e.RequirementID,
                                    ReqOrigin = e.ReqOrigin,
                                    ReqDescription = e.ReqDescription,
                                    ReqLink = e.ReqLink,
                                    CreatedUTC = e.CreatedUTC
                                }
                        );

                return query.ToArray();
            }
        }

        public RequirementDetail GetRequirementById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Requirements
                        .Single(e => e.RequirementID == id && e.OwnerID == _userId);
                return
                    new RequirementDetail
                    {
                        RequirementID = entity.RequirementID,
                        ReqOrigin = entity.ReqOrigin,
                        ReqDescription = entity.ReqDescription,
                        ReqLink = entity.ReqLink,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateRequirement(RequirementEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Requirements
                        .Single(e => e.RequirementID == model.RequirementID && e.OwnerID == _userId);

                entity.ReqOrigin = model.ReqOrigin;
                entity.ReqDescription = model.ReqDescription;
                entity.ReqLink = model.ReqLink;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRequirement(int requirementId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Requirements
                        .Single(e => e.RequirementID == requirementId && e.OwnerID == _userId);

                ctx.Requirements.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
