using System;
using Volo.Abp.Application.Dtos;

namespace TestProjectABP.Categories
{
    public class CategoryDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
