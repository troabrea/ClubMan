using ClubMan.Shared.Model;
using Microsoft.CodeAnalysis;
using Marten;

namespace ClubMan.Api.Services;

public interface ICarnetService
{
    Task CreateInitialCarnets(IDocumentSession session, Socio socio);
    Task ActivaCarnetMembresia(IDocumentSession session, Socio socio);
    Task InactivaCarnetMembresia(IDocumentSession session, Socio socio);
    Task ActivaCarnetDependiente(IDocumentSession session, Socio socio, DependienteSocio dependienteSocio);
    Task InactivaCarnetDependiente(IDocumentSession session, Socio socio, DependienteSocio dependienteSocio);
}