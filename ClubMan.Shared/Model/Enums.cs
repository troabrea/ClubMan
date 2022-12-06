namespace ClubMan.Shared.Model;

public enum TipoSocio
{
    Propietario,
    Numeral,
    Corporativo,
    Diplomatico,
    Especial
}

public enum EstadoCivil
{
    Soltero,
    Casado
}

public enum Sexo
{
    Masculino,
    Femenino
}

public enum TipoDependiente
{
    Conyuge,
    Hijo
}

public enum TipoAdicional
{
    Empleado,
    Otro
}

public enum EstatusSolicitud
{
    Recibida,
    Sometida,
    Aprobado,
    Rechazado,
    Pospuesto
}
public enum EstatusEvento
{
    Recibido,
    Sometido,
    Aprobado,
    Rechazado
}
public enum EstatusRevision
{
    Pendiente,
    Aprobado,
    Rechazado,
    Pospuesto
}

public enum EstatusMembresia
{
    Activa,
    Pasiva,
    NoResidente,
    Bloqueada,
    Cancelada,
}

public enum TipoMovimiento
{
    CambiarAPasiva,
    ReActivar,
    BloquearEntrada,
    MarcarComoNoResidente,
    CancelarMembresia,
    AgregarDependiente,
    QuitarDependiente,
    AgregarAdicional,
    QuitarAdicional,
    SolicitarHuesped,
    SolicitarActividad,
    SolicitarInvitadoExtraordinario
}

public enum EstatusMovimiento
{
    Pendiente,
    Aprobado,
    Rechazado
}

public enum EstatusDependiente
{
    Pendiente,
    Activo,
    Bloqueado,
    Cancelado
}

public enum EstatusCarnet
{
    Activo,
    Bloqueado,
    Expirado,
    Cancelado
}

public enum TipoCarnet
{
    Principal,
    Dependiente,
    Huesped,
    Adicional
}