using Domain.Entities;
using Persistence.Context;

namespace Application.Repositories;

public interface ITicketRepository : IBaseRepository<TicketEntity, ApplicationDbContext>
{
}
