using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ToyAPI.Data;
using ToyAPI.DTOs;
using ToyAPI.Services;

namespace ToyAPI.Tests;

public class BrinquedoServiceTests
{
    private static ToyDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ToyDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new ToyDbContext(options);
    }

    [Fact]
    public async Task TestCreateToy()
    {
        await using var context = CreateContext();
        var service = new BrinquedoService(context);

        var dto = new BrinquedoCreateDto
        {
            NomeBrinquedo = "Carrinho Hot Wheels",
            TipoBrinquedo = "Carro",
            Classificacao = "5+",
            Tamanho = "Pequeno",
            Preco = 29.90m
        };

        var created = await service.CreateAsync(dto);

        Assert.True(created.IdBrinquedo > 0);
        Assert.Equal("Carrinho Hot Wheels", created.NomeBrinquedo);
    }

    [Fact]
    public async Task TestGetToy()
    {
        await using var context = CreateContext();
        var service = new BrinquedoService(context);

        var created = await service.CreateAsync(new BrinquedoCreateDto
        {
            NomeBrinquedo = "Boneca",
            TipoBrinquedo = "Boneca",
            Classificacao = "3+",
            Tamanho = "Medio",
            Preco = 49.90m
        });

        var fetched = await service.GetByIdAsync(created.IdBrinquedo);

        Assert.NotNull(fetched);
        Assert.Equal(created.IdBrinquedo, fetched!.IdBrinquedo);
    }

    [Fact]
    public async Task TestUpdateToy()
    {
        await using var context = CreateContext();
        var service = new BrinquedoService(context);

        var created = await service.CreateAsync(new BrinquedoCreateDto
        {
            NomeBrinquedo = "Pipa",
            TipoBrinquedo = "Ar",
            Classificacao = "6+",
            Tamanho = "Grande",
            Preco = 15.00m
        });

        var updated = await service.UpdateAsync(created.IdBrinquedo, new BrinquedoUpdateDto
        {
            NomeBrinquedo = "Pipa Colorida",
            TipoBrinquedo = "Ar",
            Classificacao = "6+",
            Tamanho = "Grande",
            Preco = 18.00m
        });

        var fetched = await service.GetByIdAsync(created.IdBrinquedo);

        Assert.True(updated);
        Assert.Equal("Pipa Colorida", fetched!.NomeBrinquedo);
        Assert.Equal(18.00m, fetched.Preco);
    }

    [Fact]
    public async Task TestDeleteToy()
    {
        await using var context = CreateContext();
        var service = new BrinquedoService(context);

        var created = await service.CreateAsync(new BrinquedoCreateDto
        {
            NomeBrinquedo = "Bola",
            TipoBrinquedo = "Esporte",
            Classificacao = "4+",
            Tamanho = "Medio",
            Preco = 25.00m
        });

        var deleted = await service.DeleteAsync(created.IdBrinquedo);
        var fetched = await service.GetByIdAsync(created.IdBrinquedo);

        Assert.True(deleted);
        Assert.Null(fetched);
    }

    [Fact]
    public void TestValidation()
    {
        var dto = new BrinquedoCreateDto
        {
            NomeBrinquedo = "",
            TipoBrinquedo = "",
            Classificacao = "",
            Tamanho = "",
            Preco = 0m
        };

        var results = new List<ValidationResult>();
        var context = new ValidationContext(dto);
        var isValid = Validator.TryValidateObject(dto, context, results, true);

        Assert.False(isValid);
        Assert.True(results.Count > 0);
    }
}
