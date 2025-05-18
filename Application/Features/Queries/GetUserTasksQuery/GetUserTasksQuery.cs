using Application.DTOs;
using MediatR;

namespace Application.Features.Queries.GetUserTasksQuery
{
    public class GetUserTasksQuery : IRequest<List<UsersTaskDto>>
    {      
   
    }
}
