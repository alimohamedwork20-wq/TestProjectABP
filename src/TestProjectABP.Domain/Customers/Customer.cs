using System;
using System.Collections.Generic;
using System.Text;
using TestProjectABP.Invoices;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace TestProjectABP.Customers
{
    public class Customer : FullAuditedAggregateRoot<Guid>
    {
        public Guid? UserId { get; private set; }

        public string Name { get; private set; }
        public decimal CreditLimit { get; private set; }
        private readonly List<Invoice> _invoices;
        public IReadOnlyCollection<Invoice> Invoices => _invoices.AsReadOnly();
        private Customer()
        {
            _invoices = new List<Invoice>();
        }
        public Customer(Guid id, string name, decimal creditLimit = 5000, Guid? userId = null) : base(id)
        {
            SetName(name);
            SetCreditLimit(creditLimit);
            UserId = userId;
        }
        public Customer SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: 128);
            return this;
        }
        public Customer SetCreditLimit(decimal creditLimit)
        {
            if (creditLimit <= 0)
            {
                throw new BusinessException("Customer:NegativeCreditLimit")
                    .WithData("CreditLimit", creditLimit);
            }

            CreditLimit = creditLimit;
            return this;
        }
        public void AssignToUser(Guid userId)
        {
            UserId = userId;
        }
    }
}
