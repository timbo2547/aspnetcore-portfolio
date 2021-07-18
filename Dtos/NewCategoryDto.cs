﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePostgreSQLDockerApp.Dtos
{
    public class NewCategoryDto
    {
        [Required(ErrorMessage = "Please enter Category name")]
        [StringLength(255)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
