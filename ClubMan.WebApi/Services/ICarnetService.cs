using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;
using Microsoft.CodeAnalysis;

namespace ClubMan.WebApi.Services;

public interface ICarnetService
{
    Task CreateInitialCarnets(ClubManContext session, Socio socio);
    Task ActivaCarnetMembresia(ClubManContext session, Socio socio);
    Task InactivaCarnetMembresia(ClubManContext session, Socio socio);
    Task ActivaCarnetDependiente(ClubManContext session, Socio socio, DependienteSocio dependienteSocio);
    Task InactivaCarnetDependiente(ClubManContext session, Socio socio, DependienteSocio dependienteSocio);
    Task ActivaCarnetHuesped(ClubManContext session, Socio socio, HuespedSocio huespedSocio);
    Task InactivaCarnetHuesped(ClubManContext session, Socio socio, HuespedSocio huespedSocio);
    Task ExpiraCarnetHuesped(ClubManContext session, Socio socio, HuespedSocio huespedSocio);
}