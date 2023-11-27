using MediatR;
using ATM.Domain.Entities;

namespace ATM.Application.Features.BanknoteFeatures.Commands.CreateBanknote
{
    public sealed record class CreateBanknoteCommand(string name, int amount) : IRequest<Banknote>;
}
