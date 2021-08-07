using GeekSeat.Entity.Entities;
using GeekSeat.Service.Infrasturctures;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GeekSeat.Web.CQRS.Commands
{
    public class CalculateAverageDeathsCommand : IRequest<double>
    {
        public List<Villager> Villagers { get; set; }

        public class CalculateAverageDeathsHandler : IRequestHandler<CalculateAverageDeathsCommand, double>
        {
            private readonly IWitchService _witchService;

            public CalculateAverageDeathsHandler(IWitchService witchService)
            {
                _witchService = witchService;
            }

            public async Task<double> Handle(CalculateAverageDeathsCommand request, CancellationToken cancellationToken)
            {
                return _witchService.CalculateAverageDeath(request.Villagers);
            }
        }
    }
}
