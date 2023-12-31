﻿using Site.Models;

namespace Site.Repositories.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetAllActives();
    }
}
