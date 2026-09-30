using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace TestProjectABP.Suppliers
{
    public class SupplierDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
