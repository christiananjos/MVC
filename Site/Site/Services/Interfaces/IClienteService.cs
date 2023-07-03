﻿using Site.Models;

namespace Site.Services.Interfaces
{
    public interface IClienteService : IBaseService<Cliente>
    {
        Task<bool> ValidarExistente(Cliente cliente);
    }
}
