using ATM.Application.Abstractions.Requests;
using ATM.Application.Abstractions.Responses;
using ATM.Application.Features.BanknoteFeatures.Commands.CreateBanknote;
using ATM.Application.Features.BanknoteFeatures.Queries.AllBanknotes;
using ATM.Application.Features.MachineFeatures.Commands.CreateMachine;
using ATM.Application.Features.MachineFeatures.Commands.FillMachine;
using ATM.Application.Features.MachineFeatures.Commands.Withdraw;
using ATM.Application.Features.MachineFeatures.Queries.MachineBalance;
using ATM.Domain.Entities;
using ATM.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Api.Controllers
{
    [Route("api/v1/atm")]
    [ApiController]
    public class AtmController : ControllerBase
    {
        public readonly ISender _sender;
        public AtmController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Adiciona uma nova máquina
        /// </summary>
        /// <remarks>Acrescenta uma nova máquina.</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <reponse code="200">Máquina criada com sucesso</reponse>
        [HttpPost]
        [Route("machine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMachine(CreateMachineRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Machine result = await _sender.Send(new CreateMachineCommand(request.Name), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Cadastra uma nova nota
        /// </summary>
        /// <remarks>Adiciona uma nova nota à lista de notas disponíveis para uso. Esse método não deve ser usado para adicionar uma valores à máquina. Use "machine/fill" para isso.</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <reponse code="200">Nota cadastrada com sucesso</reponse>
        [HttpPost]
        [Route("machine/banknote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateBanknote(CreateBanknoteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Banknote result = await _sender.Send(new CreateBanknoteCommand(request.Name, request.Amout), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona notas à máquina.
        /// </summary>
        /// <remarks>Adiciona novas notas à máquina ou atualiza o valor das notas presentes.</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <reponse code="200">Adição realizada com sucesso</reponse>
        /// <reponse code="400">Adição não realizada</reponse>
        /// <reponse code="404">Recurso não encontrado</reponse>
        [HttpPost]
        [Route("machine/fill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FillMachine(FillMachineRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _sender.Send(new FillMachineCommand(request.MachineId, request.BanknoteId, request.Amount), cancellationToken);

                return Ok();
            }
            catch (TryingToAddLessThanOrEqualZeroNotesException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BanknoteNotFountException ex)
            {
                return NotFound(ex.Message);
            }
            catch (MachineNoteFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Realiza o saque dos valores no caixa
        /// </summary>
        /// <remarks>Executa as ações de saque na máquina.</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <reponse code="200">Saque realizado com sucesso</reponse>
        /// <reponse code="400">Saque não realizado</reponse>
        /// <reponse code="404">Recurso não encontrado</reponse>
        [HttpPost]
        [Route("withdraw")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Withdraw(WithdrawRequest request, CancellationToken cancellationToken)
        {
            try
            {
                WithdrawResponse result = await _sender.Send(new WithdrawCommand(request.MachineId, request.Amount), cancellationToken);
                return Ok(result);
            }
            catch (MachineNoteFoundException ex)
            {
                return NotFound(ex.Message);
            } 
            catch (TryingToWithdrawFromZeroBanknotesException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (OutOfRangeBanknotesAmountException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoAvailableNotesException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InsufficientAmountAvailable ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Verifica o balanço de notas presentes na máquina
        /// </summary>
        /// <remarks>Busca por todas as notas e retorna as presentes na máquina.</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <reponse code="200">Busca realizada com sucesso</reponse>
        /// <reponse code="404">Recurso não encontrado</reponse>
        [HttpGet]
        [Route("machine/balance")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMachineBalance([FromQuery]GetMachineBalanceRequest request, CancellationToken cancellationToken)
        {
            try
            {
                MachineBalanceResponse result = await _sender.Send(new MachineBalanceQuery(request.MachineId), cancellationToken);

                return Ok(result);
            }
            catch (MachineNoteFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Retorna todas as notas cadastradas.
        /// </summary>
        /// <remarks>Mostra todas as notas cadastradas no sistema. Para ver todas as notas presentes na máquina, use o método "machine/balance".</remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <reponse code="200">Busca realizada com sucesso</reponse>
        [HttpGet]
        [Route("machine/banknotes")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        public async Task<IActionResult> GetBanknotes([FromQuery]BanknotesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Dictionary<string, int> result = await _sender.Send(new BanknotesQuery(), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
