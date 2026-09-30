using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;

namespace TestProjectABP.Invoices
{
    public class InvoiceAppService : CrudAppService<Invoice,InvoiceDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateInvoiceDto>, IInvoiceAppService
    {
        public InvoiceAppService(IRepository<Invoice,Guid> repository) : base(repository)
        {
        }
        protected async override Task<IQueryable<Invoice>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {
            var query = await base.CreateFilteredQueryAsync(input);
            return query.Include(x => x.Items);
        }
        public override async Task<InvoiceDto> CreateAsync(CreateUpdateInvoiceDto input)
        {
            var invoice = new Invoice(input.InvoiceNumber); 
            
            foreach(var item in input.Items)
            {
                invoice.AddAsync(item.Description,item.UnitPrice,item.Quantity);
            }
            await Repository.InsertAsync(invoice, autoSave: true);
            return ObjectMapper.Map<Invoice, InvoiceDto>(invoice);
            
        }
        public async Task PayAsync(Guid id)
        {
            var invoice = await Repository.GetAsync(id);
            invoice.Pay();
            await Repository.UpdateAsync(invoice, autoSave: true);
        }
        public async Task CancelAsync(Guid id)
        {
            var invoice = await Repository.GetAsync(id);
            invoice.Cancel();
            await Repository.UpdateAsync(invoice, autoSave: true);
        }
    }
}
