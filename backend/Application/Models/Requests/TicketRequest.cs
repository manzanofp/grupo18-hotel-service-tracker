using Domain.Enums;

namespace Application.Models.Requests;

public record TicketRequest(
    string Name,
    string Cpf,
    string Email,
    long RoomNumber,
    string Description,
    string Address,
    EProblemStatus Status,
    EProblemTypes ProblemType,
    long GuestId);
