using ClubMan.Shared.Events;

namespace ClubMan.Shared.Model;

public record VisitaManual
{
    public String Id { get; set; }
    public DateTime FechaHora { get; set; }
    public String PorteroId { get; set; }
    public String TipoIdentidad { get; set; }
    public String NumeroIdentidad { get; set; }
    public String Nombre { get; set; }
    public String Area { get; set; }
    public String MotivoVisita { get; set; }
    public String Comentario { get; set; }
}

public record Visitas
{
    public String Id { get; set; }
    public int Ano { get; set; }
    public int Mes { get; set; }
    public int Cantidad { get; set; }
    public int Socios { get; set; }
    public int Dependientes { get; set; }
    public int Huespedes { get; set; }
    public int Adicionales { get; set; }
    public int Invitados { get; set; }

    public void Apply(VisitaSocioRegistradaEvent visitaCarnet)
    {
        Ano = visitaCarnet.FechaHora.Year;
        Mes = visitaCarnet.FechaHora.Month;
        Cantidad += 1;
        switch (visitaCarnet.TipoCarnet)
        {
            case TipoCarnet.Principal:
                Socios += 1;
                break;
            case TipoCarnet.Dependiente:
                Dependientes += 1;
                break;
            case TipoCarnet.Huesped:
                Huespedes += 1;
                break;
            case TipoCarnet.Adicional:
                Adicionales += 1;
                break;
        }

    }
    
    public void Apply(VisitaInvitadoSocioRegistradaEvent visitaInvitado)
    {
        Ano = visitaInvitado.FechaHora.Year;
        Mes = visitaInvitado.FechaHora.Month;
        Cantidad += 1;
        Invitados += 1;
    }
}

public record VisitasSocio
{
    public String Id { get; set; }
    public int Ano { get; set; }
    public int Mes { get; set; }
    public long SocioId { get; set; }
    public int Cantidad { get; set; }
    
    public int CantidadPrincipal { get; set; }
    public int CantidadDependientes { get; set; }
    public int CantidadAdicionales { get; set; }
    public int CantidadHuespedes { get; set; }
    public int CantidadInvitados { get; set; }
    
    public void Apply(VisitaCarnetRegistradaEvent visitaCarnet)
    {
        Ano = visitaCarnet.FechaHora.Year;
        Mes = visitaCarnet.FechaHora.Month;
        SocioId = visitaCarnet.SocioId;
        Cantidad += 1;
        switch (visitaCarnet.TipoCarnet)
        {
            case TipoCarnet.Principal:
                CantidadPrincipal += 1;
                break;
            case TipoCarnet.Dependiente:
                CantidadDependientes += 1;
                break;
            case TipoCarnet.Adicional:
                CantidadAdicionales += 1;
                break;
            case TipoCarnet.Huesped:
                CantidadHuespedes += 1;
                break;
        }
    }

    public void Apply(VisitaAdicionalSocioRegistradaEvent visitaAdicional)
    {
        Ano = visitaAdicional.FechaHora.Year;
        Mes = visitaAdicional.FechaHora.Month;
        SocioId = visitaAdicional.SocioId;
        Cantidad += 1;
        CantidadAdicionales += 1;
    }
    
    public void Apply(VisitaInvitadoSocioRegistradaEvent visitaInvitado)
    {
        Ano = visitaInvitado.FechaHora.Year;
        Mes = visitaInvitado.FechaHora.Month;
        SocioId = visitaInvitado.SocioId;
        Cantidad += 1;
        CantidadInvitados += 1;
    }
    
}

public record VisitasInvitado
{
    public String Id { get; set; }
    public int Ano { get; set; }
    public int Mes { get; set; }
    public string NumeroIdentidad { get; set; }
    public int Cantidad { get; set; }
    
    public void Apply(VisitaInvitadoRegistradaEvent visitaInvitado)
    {
        NumeroIdentidad = visitaInvitado.NumeroIdentidad;
        Ano = visitaInvitado.FechaHora.Year;
        Mes = visitaInvitado.FechaHora.Month;
        Cantidad += 1;
    }
}
