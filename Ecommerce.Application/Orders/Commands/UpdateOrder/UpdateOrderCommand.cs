using Ecommerce.Application.Common.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public UpdateOrderDto Order { get; set; }
    }
}
