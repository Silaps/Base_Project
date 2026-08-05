using BaseProject.Domain.Dtos;

namespace BaseProject.Application.Interfaces;

public interface IMasterService
{
    Task<FormDTO?> GetFormByIdAsync(int id);
    Task<bool> AddFormAsync(FormDTO formDto);
}
