namespace ClubMan.Shared.Model;

public record Politica
{
    public Guid Id { get; set; }
    public int InvitadosPorDia { get; set; }
    public int MenoriaDeEdad { get; set; }
    public int VisitasAlMesInvitados { get; set; }
    
    public int LimiteHuespedes { get; set; }
    public int DiasMembresiaHuesped { get; set; }
    
    public int CuotasParaPasividad { get; set; }
    
    public int EdadParaHonorifico { get; set; }
    public int AntiguedadParaHonorifico { get; set; }
    public int EdadParaHonorificoPropietario { get; set; }
    public int AntiguedadParaHonorificoPropietario { get; set; }
    
    
    public int EntradasNoResidentes { get; set; }
}