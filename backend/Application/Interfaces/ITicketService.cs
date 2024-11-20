using Application.Models.Requests;
using Domain.Entities;

namespace Application.Interfaces;

public interface ITicketService
{
    Task<TicketEntity> GuestCreateTicketAsync(TicketRequest request);
    Task<TicketEntity> UpdateTicketAsync(long ticketId, TicketEntity ticketEntity);
    Task<ICollection<TicketEntity>> GetAllTickets();
}
