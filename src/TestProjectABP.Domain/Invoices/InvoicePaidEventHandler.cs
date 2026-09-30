using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.EventBus;

namespace TestProjectABP.Invoices
{
    public class InvoicePaidEventHandler : ILocalEventHandler<InvoicePaidEventData>, ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        public InvoicePaidEventHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public async Task HandleEventAsync(InvoicePaidEventData eventData)
        {
            try {
                await _emailSender.SendAsync("Jejdjkr1646929@gmail.com", "Invoices", $"success pay is invoice Id: {eventData.InvoiceId} Total Amount: {eventData.TotalAmount}");
            }
            catch { Console.WriteLine("[Log]: Faild Send Email"); }
        }
    }
}
