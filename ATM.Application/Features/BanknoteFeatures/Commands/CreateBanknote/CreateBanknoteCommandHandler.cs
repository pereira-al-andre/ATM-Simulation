using ATM.Domain.Entities;
using ATM.Domain.Repositories;
using MediatR;

namespace ATM.Application.Features.BanknoteFeatures.Commands.CreateBanknote
{
    public sealed class CreateBanknoteCommandHandler : IRequestHandler<CreateBanknoteCommand, Banknote>
    {
        private readonly IBanknoteRepository _banknoteRepository;

        public CreateBanknoteCommandHandler(IBanknoteRepository banknoteRepository)
        {
            _banknoteRepository = banknoteRepository;
        }

        public async Task<Banknote> Handle(CreateBanknoteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var banknote = new Banknote(request.name, request.amount);

                await _banknoteRepository.CreateAsync(banknote);

                return banknote;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
