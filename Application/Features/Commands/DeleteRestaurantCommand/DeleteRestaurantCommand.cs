using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Commands.DeleteRestaurantCommand
{
    public class DeleteRestaurantCommand : IRequest<int>
    {
        public int Id { get; set; }
        
    }
}
