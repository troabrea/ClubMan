namespace ClubMan.Shared.Events;

public record SolicitarInvitadoEvent(
    Guid SolicitudId,
    string CarnetId,
    DateTime FechaHora,
    string NumeroIdentidad,
    string Nombre,
    string WhatsApp,
    string Email
);

