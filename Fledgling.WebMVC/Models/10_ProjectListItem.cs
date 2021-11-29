﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fledgling.WebMVC.Models
{
    public class ProjectListItem
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}