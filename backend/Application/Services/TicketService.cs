using Application.Interfaces;
using Application.Models.Requests;
using Application.Repositories;
using Domain.Entities;

namespace Application.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public async Task<ICollection<TicketEntity>> GetAllTickets()
    {
        try
        {
            var tickets = await _ticketRepository.SelectAsync();
            return tickets;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TicketEntity> GuestCreateTicketAsync(TicketRequest request)
    {
        try
        {
            var ticket = new TicketEntity
            {
                Name = request.Name,
                Cpf = request.Cpf,
                Email = request.Email,
                RoomNumber = request.RoomNumber,
                Description = request.Description,
                Address = request.Address,
                Status = request.Status,
                ProblemType = request.ProblemType,
                GuestId = request.GuestId,
                IsFinished = false,
            };

            var ticketInDb = await _ticketRepository.InsertAsync(ticket);

            return ticketInDb;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TicketEntity> UpdateTicketAsync(long ticketId, TicketEntity ticketEntity)
    {
        try
        {
            var oldEntity = _ticketRepository.SelectAsync(ticketId).Result ?? throw new Exception("Ticket not found");

            var updatedEntity = await _ticketRepository.UpdateAsync(ticketEntity);

            return updatedEntity;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
