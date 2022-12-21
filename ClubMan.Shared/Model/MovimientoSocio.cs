namespace ClubMan.Shared.Model;

public record MovimientoSocio
{
    public long Id { get; set; }
    public long SocioId { get; set; }
    public long DependienteId { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }
    public Guid ReferenciaId { get; set; }
    public String Nota { get; set; }
    public DateTime FechaRegistro { get; set; }
    public String RegistradaPor { get; set; }
    public DateTime FechaRevision { get; set; }
    public String RevisadoPor { get; set; }
    public String Comentario { get; set; }
    public EstatusMovimiento Estatus { get; set; }

    public string TipoDeMovimiento =>
        TipoMovimiento switch
        {
            TipoMovimiento.AgregarAdicional => "Agregar Adicional",
            TipoMovimiento.CambiarAPasiva => "Cambiar a Pasiva",
            TipoMovimiento.ReActivar => "Reactivar Membresía",
            TipoMovimiento.BloquearEntrada => "Bloquear Entrada",
            TipoMovimiento.MarcarComoNoResidente => "Marcar No-Residente",
            TipoMovimiento.CancelarMembresia => "Cancelar Membresia",
            TipoMovimiento.AgregarDependiente => "Agregar Dependiente",
            TipoMovimiento.QuitarDependiente => "Remover Dependiente",
            TipoMovimiento.QuitarAdicional => "Remover Adicional",
            TipoMovimiento.SolicitarHuesped => "Activar Huesped(es)",
            TipoMovimiento.SolicitarActividad => "Aprobar Evento",
            TipoMovimiento.SolicitarInvitadoExtraordinario => "Aprobar invitado extraordinario",
            _ => ""
        };
}