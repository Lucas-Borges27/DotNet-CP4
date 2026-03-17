using ToyAPI.DTOs;

namespace ToyAPI.Services;

public interface IBrinquedoService
{
    Task<List<BrinquedoReadDto>> GetAllAsync();
    Task<BrinquedoReadDto?> GetByIdAsync(int id);
    Task<BrinquedoReadDto> CreateAsync(BrinquedoCreateDto dto);
    Task<bool> UpdateAsync(int id, BrinquedoUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
