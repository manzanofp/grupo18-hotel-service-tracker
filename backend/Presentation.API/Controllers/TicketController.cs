using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(TicketEntity), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TicketEntity>> GuestCreateTicket([FromBody] TicketRequest request)
    {
        var ticket = await _ticketService.GuestCreateTicketAsync(request);
        return Ok(ticket);
    }

    [HttpPut("{ticketId:long}")]
    [ProducesResponseType(typeof(TicketEntity), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TicketEntity>> UpdateTicketAsync(long ticketId, TicketEntity ticketEntity)
    {
        var ticket = await _ticketService.UpdateTicketAsync(ticketId, ticketEntity);
        return Ok(ticket);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ICollection<TicketEntity>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ICollection<TicketEntity>>> GetAllTicketsAsync()
    {
        var tickets = await _ticketService.GetAllTickets();
        return Ok(tickets);
    }
}