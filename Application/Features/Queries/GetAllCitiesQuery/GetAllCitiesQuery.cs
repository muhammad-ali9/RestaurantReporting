using Application.DTOs;
using Domain;
using MediatR;

namespace Application.Features.Queries.GetAllCitiesQuery
{
    public class GetAllCitiesQuery : IRequest<List<string>>
    {
    }
}
