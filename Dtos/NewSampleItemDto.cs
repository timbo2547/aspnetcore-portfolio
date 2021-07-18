using AspNetCorePostgreSQLDockerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePostgreSQLDockerApp.Dtos
{
    public class NewSampleItemDto
    {
        [Required(ErrorMessage = "Please enter Sample Item name")]
        [StringLength(255)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public NewSampleItemCategoryDto Category { get; set; }
    }

    public class NewSampleItemCategoryDto
    {
        public int? Id { get; set; } 
        public string CategoryName { get; set; }
    }
}
