using BaseProject.Application.Interfaces;
using BaseProject.Domain.Attributes;
using BaseProject.Domain.Dtos;
using BaseProject.Infrastructure.Models;
using BaseProject.Infrastructure.Persistences.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Application.Implementations;

[Domain(typeof(IMasterService), ServiceLifetime.Transient)]
public class MasterService(IBDBaseContext context) : IMasterService
{
    public async Task<FormDTO?> GetFormByIdAsync(int id)
    {
        var form = await context.Forms.FindAsync(id);
        if (form == null)
        {
            return null;
        }

        return new FormDTO
        {
            Id = form.Id,
            Name = form.Name,
            Fields = form.Fields
        };
    }

    public async Task<bool> AddFormAsync(FormDTO formDto)
    {
        var form = new Form
        {
            Name = formDto.Name,
            Fields = formDto.Fields
        };
        await context.Forms.AddAsync(form);
        await context.CommitAsync();
        return true;
    }
}
