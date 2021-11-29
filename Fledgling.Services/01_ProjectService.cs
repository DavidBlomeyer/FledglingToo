using Fledgling.Data;
using Fledgling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Services
{
    public class ProjectService
    {
        private readonly Guid _userId;

        public ProjectService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProject(ProjectCreate model)
        {
            var entity =
                new Project()
                {
                    OwnerID = _userId,
                    ProjectName = model.ProjectName,
                    ProjectAuthor = model.ProjectAuthor,
                    ProjectThesis = model.ProjectThesis,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProjectListItem> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Projects
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new ProjectListItem
                                {
                                    ProjectID = e.ProjectID,
                                    ProjectName = e.ProjectName,
                                    ProjectAuthor = e.ProjectAuthor,
                                    ProjectThesis = e.ProjectThesis,
                                    CreatedUTC = e.CreatedUTC
                                }
                        );

                return query.ToArray();
            }
        }

        public ProjectDetail GetProjectById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectID == id && e.OwnerID == _userId);
                return
                    new ProjectDetail
                    {
                        ProjectID = entity.ProjectID,
                        ProjectName = entity.ProjectName,
                        ProjectAuthor = entity.ProjectAuthor,
                        ProjectThesis = entity.ProjectThesis,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateProject(ProjectEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectID == model.ProjectID && e.OwnerID == _userId);

                entity.ProjectName = model.ProjectName;
                entity.ProjectAuthor = model.ProjectAuthor;
                entity.ProjectThesis = model.ProjectThesis;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProject(int projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectID == projectId && e.OwnerID == _userId);

                ctx.Projects.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
