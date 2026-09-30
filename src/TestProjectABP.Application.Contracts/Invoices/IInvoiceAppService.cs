using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TestProjectABP.Invoices
{
    public interface IInvoiceAppService : ICrudAppService<InvoiceDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateInvoiceDto>
    {
        Task PayAsync(Guid id);
        Task CancelAsync(Guid id);
    }
}
