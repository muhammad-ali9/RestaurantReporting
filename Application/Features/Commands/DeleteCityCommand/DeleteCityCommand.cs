using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Commands.DeleteCityCommand
{
    public class DeleteCityCommand : IRequest<int>
    {
        public int Cid { get; set; }
    }
}
