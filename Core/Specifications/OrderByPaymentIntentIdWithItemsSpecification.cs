using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrderByPaymentIntentIdWithItemsSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdWithItemsSpecification(string paymentIntentId) 
        :base(o=>o.PaymentIntentId==paymentIntentId)
        {
            
        }
    }
}
