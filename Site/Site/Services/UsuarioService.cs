using Site.Controllers;
using Site.Interfaces;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class UsuarioService : IUsuarioService
    {
        public IUnitOfWork _unitOfWork;
        //private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_logger = logger;
        }

        public async Task<bool> Add(Usuario entity)
        {

            try
            {
                if (entity != null)
                {
                    entity.CreatedAt = DateTime.Now;

                    await _unitOfWork.Usuarios.Add(entity);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                //Pegar o usuario com CLAIMS
                //_logger.LogInformation($"Usuario Xyz tentou adicinar um novo Registro: " + ex.Message);
                throw new Exception(ex.Message);
            }

            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (id.ToString() != null)
            {
                var usuarioQuery = await _unitOfWork.Usuarios.GetById(id);

                if (usuarioQuery != null)
                {
                    usuarioQuery.RemovedAt = DateTime.Now;

                    _unitOfWork.Usuarios.Delete(usuarioQuery);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            //Pegar o usuario com CLAIMS
            //_logger.LogInformation($"Usuario Xyz removeu um Registro");

            return false;
        }
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var usuarios = await _unitOfWork.Usuarios.GetAll();

            //Pegar o usuario com CLAIMS
            //_logger.LogInformation($"Usuario Xyz realizou uma consulta");

            return usuarios;
        }

        public async Task<IEnumerable<Usuario>> GetAllActives()
        {
            //Pegar o usuario com CLAIMS
            //_logger.LogInformation($"Usuario Xyz realizou uma consulta");

            var usuarios = await _unitOfWork.Usuarios.GetAllActives();

            return usuarios;
        }

        public async Task<Usuario> GetById(Guid id)
        {
            var usuario = await _unitOfWork.Usuarios.FindByConditionAsync(x => x.Id == id);

            //Pegar o usuario com CLAIMS
            //_logger.LogInformation($"Usuario Xyz realizou uma consulta");

            return usuario;
        }

        public async Task<Usuario> GetByName(string nome)
        {
            //Pegar o usuario com CLAIMS
            //_logger.LogInformation($"Usuario Xyz realizou uma consulta");

            var usuario = await _unitOfWork.Usuarios.FindByConditionAsync(x => x.Usernaname == nome);

            return usuario;
        }

        public Task<bool> LogicalRemove(Usuario entity)
        {
            //Pegar o usuario com CLAIMS
            //_logger.LogInformation($"Usuario removeu lógicamente um registro");

            entity.RemovedAt = DateTime.Now;
            return Update(entity);
        }

        public async Task<bool> Update(Usuario entity)
        {
            if (entity != null)
            {
                var usuarioQuery = await _unitOfWork.Usuarios.GetById(entity.Id);

                if (usuarioQuery != null)
                {
                    usuarioQuery.UpdateAt = DateTime.Now;

                    _unitOfWork.Usuarios.Update(usuarioQuery);

                    var result = _unitOfWork.Save();

                    //Pegar o usuario com CLAIMS
                    //_logger.LogInformation($"Usuario Xyz atualizou um registro");

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }


    }
}
