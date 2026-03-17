using Microsoft.EntityFrameworkCore;
using ToyAPI.Data;
using ToyAPI.DTOs;
using ToyAPI.Models;

namespace ToyAPI.Services;

public class BrinquedoService : IBrinquedoService
{
    private readonly ToyDbContext _context;

    public BrinquedoService(ToyDbContext context)
    {
        _context = context;
    }

    public async Task<List<BrinquedoReadDto>> GetAllAsync()
    {
        return await _context.Brinquedos
            .AsNoTracking()
            .Select(b => new BrinquedoReadDto
            {
                IdBrinquedo = b.IdBrinquedo,
                NomeBrinquedo = b.NomeBrinquedo,
                TipoBrinquedo = b.TipoBrinquedo,
                Classificacao = b.Classificacao,
                Tamanho = b.Tamanho,
                Preco = b.Preco
            })
            .ToListAsync();
    }

    public async Task<BrinquedoReadDto?> GetByIdAsync(int id)
    {
        return await _context.Brinquedos
            .AsNoTracking()
            .Where(b => b.IdBrinquedo == id)
            .Select(b => new BrinquedoReadDto
            {
                IdBrinquedo = b.IdBrinquedo,
                NomeBrinquedo = b.NomeBrinquedo,
                TipoBrinquedo = b.TipoBrinquedo,
                Classificacao = b.Classificacao,
                Tamanho = b.Tamanho,
                Preco = b.Preco
            })
            .FirstOrDefaultAsync();
    }

    public async Task<BrinquedoReadDto> CreateAsync(BrinquedoCreateDto dto)
    {
        var entity = new Brinquedo
        {
            NomeBrinquedo = dto.NomeBrinquedo,
            TipoBrinquedo = dto.TipoBrinquedo,
            Classificacao = dto.Classificacao,
            Tamanho = dto.Tamanho,
            Preco = dto.Preco
        };

        _context.Brinquedos.Add(entity);
        await _context.SaveChangesAsync();

        return MapToReadDto(entity);
    }

    public async Task<bool> UpdateAsync(int id, BrinquedoUpdateDto dto)
    {
        var entity = await _context.Brinquedos.FindAsync(id);
        if (entity is null)
        {
            return false;
        }

        entity.NomeBrinquedo = dto.NomeBrinquedo;
        entity.TipoBrinquedo = dto.TipoBrinquedo;
        entity.Classificacao = dto.Classificacao;
        entity.Tamanho = dto.Tamanho;
        entity.Preco = dto.Preco;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Brinquedos.FindAsync(id);
        if (entity is null)
        {
            return false;
        }

        _context.Brinquedos.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    private static BrinquedoReadDto MapToReadDto(Brinquedo entity)
    {
        return new BrinquedoReadDto
        {
            IdBrinquedo = entity.IdBrinquedo,
            NomeBrinquedo = entity.NomeBrinquedo,
            TipoBrinquedo = entity.TipoBrinquedo,
            Classificacao = entity.Classificacao,
            Tamanho = entity.Tamanho,
            Preco = entity.Preco
        };
    }
}
