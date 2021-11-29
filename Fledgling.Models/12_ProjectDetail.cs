using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fledgling.Models
{
    public class ProjectDetail
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectAuthor { get; set; }
        public string ProjectThesis { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
