using Application.DTOs;
using MediatR;

namespace Application.Features.Queries.GetAllUserQuery
{
    public class GetAllUserQuery : IRequest<List<UserDetailsDto>>
    {
    }
}
