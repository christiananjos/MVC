﻿using Site.Data;
using Site.Interfaces;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public EnderecoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");
        }
    }
}
