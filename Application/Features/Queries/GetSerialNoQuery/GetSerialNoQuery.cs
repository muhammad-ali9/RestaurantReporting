using Application.DTOs;
using MediatR;

namespace Application.Features.Queries.GetSerialNoQuery
{
    public class GetSerialNoQuery : IRequest<List<RestaurantSerialDto>>
    {
        public int CityId { get; set; }
    }
}
