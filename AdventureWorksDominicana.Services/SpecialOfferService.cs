using AdventureWorksDominicana.Data.Context;
using AdventureWorksDominicana.Data.Models;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureWorksDominicana.Services;

public class SpecialOfferService(IDbContextFactory<Contexto> DbFactory) : IService<SpecialOffer, int>
{
    public async Task<List<SpecialOffer>> Listar(Expression<Func<SpecialOffer, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.SpecialOffers.Where(criterio).ToListAsync();
    }
    public async Task<bool> Guardar(SpecialOffer offer)
    {
        if (!await Existe(offer.SpecialOfferId))
        {
            return await Insertar(offer);
        }
        else
        {
            return await Modificar(offer);
        }
    }

    public async Task<bool> Insertar(SpecialOffer offer)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.SpecialOffers.Add(offer);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int idShip)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.SpecialOffers.AnyAsync(p => p.SpecialOfferId == idShip);
    }

    public async Task<bool> Modificar(SpecialOffer offer)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.SpecialOffers.Update(offer);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<SpecialOffer?> Buscar(int idShip)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.SpecialOffers.FirstOrDefaultAsync(p => p.SpecialOfferId == idShip);
    }

    public async Task<bool> Eliminar(int idOffer)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var offer = await Buscar(idOffer);

        if (offer == null) return false;

        contexto.SpecialOffers.Remove(offer);
        return await contexto.SaveChangesAsync() > 0;
    }

    public Task<List<SpecialOffer>> GetList(Expression<Func<SpecialOffer, bool>> criterio)
    {
        throw new NotImplementedException();
    }
}
