using Ecommerce.Application.Common.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommand
    {
        public CreateTagDto Tag { get; set; }
    }
}
