using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestProjectABP.Brands
{
    public class CreateUpdateBrandDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [StringLength(512)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
