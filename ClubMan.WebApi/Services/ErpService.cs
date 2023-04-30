using ClubMan.Shared.Dto;
using ClubMan.WebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ClubMan.WebApi.Services;

public class ErpService : IErpService
{
    private readonly ClubManContext _db;

    public ErpService(ClubManContext db)
    {
        _db = db;
    }
    public async Task<List<FacturaDto>> GetFacturasPendinetesAsync(long socioId)
    {
        var socio = await _db.Socios.FindAsync(socioId);

        if (socio == null)
        {
            return new List<FacturaDto>();
        }

        return await _db.Cxc
            .Where(x => x.Cliente == socio.NumeroCarnet)
            .AsNoTracking()
            .Select(x => new FacturaDto()
            {
                ErpId = x.IdInterno,
                NumeroFactura = x.Documento,
                Concepto = x.TipoDocumento,
                FechaFactura = x.Fecha,
                SocioId = socio.Id,
                Total  = x.Monto,
                Pagado = x.Monto - x.Balance,
                Balance = x.Balance,
            }).ToListAsync();
        
        // var cuota = 1000 + (500 * socio.Dependientes.Count); 
        //
        // var result = new List<FacturaDto>();
        // var fecha = DateTime.Now.Date;
        // fecha = fecha.AddDays((fecha.Day - 1)*-1);
        // result.Add( new FacturaDto()
        // {
        //     SocioId = socioId,
        //     Concepto = "Cuota Membresía",
        //     Balance = 2500,
        //     Pagado = 0,
        //     Total = 2500,
        //     ErpId = $"FAC-{fecha.ToString("MMyyyy")}-001",
        //     NumeroFactura = $"FAC-{fecha.ToString("MMyyyy")}-001",
        //     FechaFactura = fecha
        // } );
        //
        // if (socio.Embarcaciones.Count > 0)
        // {
        //     result.Insert(0, new FacturaDto()
        //     {
        //         SocioId = socioId,
        //         Concepto = "Embarcación",
        //         Balance = 5000,
        //         Pagado = 0,
        //         Total = 5000,
        //         ErpId = $"EMB-{fecha.ToString("MMyyyy")}-001",
        //         NumeroFactura = $"EMB-{fecha.ToString("MMyyyy")}-001",
        //         FechaFactura = fecha 
        //     }); 
        // }
        //
        // fecha = fecha.AddMonths(-1);
        // result.Insert(0, new FacturaDto()
        // {
        //     SocioId = socioId,
        //     Concepto = "Cuota Membresía",
        //     Balance = 2500,
        //     Pagado = 0,
        //     Total = 2500,
        //     ErpId = $"FAC-{fecha.ToString("MMyyyy")}-001",
        //     NumeroFactura = $"FAC-{fecha.ToString("MMyyyy")}-001",
        //     FechaFactura = fecha 
        // });
        //
        //
        //
        // return result;
    }
}