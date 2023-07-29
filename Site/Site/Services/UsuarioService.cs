using Site.Interfaces;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class UsuarioService : IUsuarioService
    {
        public IUnitOfWork _unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> Add(Usuario entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Usuarios.Add(entity);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (id.ToString() != null)
            {
                var UsuarioQuery = await _unitOfWork.Usuarios.GetById(id);

                if (UsuarioQuery != null)
                {
                    _unitOfWork.Usuarios.Delete(UsuarioQuery);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var usuarios = await _unitOfWork.Usuarios.GetAll();

            return usuarios;
        }

        public async Task<Usuario> GetById(Guid id)
        {
            var usuario = await _unitOfWork.Usuarios.FindByConditionAsync(x => x.Id == id);

            return usuario;
        }

        public async Task<Usuario> GetByName(string nome)
        {
            var usuario = await _unitOfWork.Usuarios.FindByConditionAsync(x=> x.Usernaname == nome);

            return usuario;
        }

        public async Task<bool> Update(Usuario entity)
        {
            if (entity != null)
            {
                var usuarioQuery = await _unitOfWork.Usuarios.GetById(entity.Id);

                if (usuarioQuery != null)
                {
                    usuarioQuery.Usernaname = entity.Usernaname;
                    usuarioQuery.Password = entity.Password;


                    _unitOfWork.Usuarios.Update(usuarioQuery);

                    var result = _unitOfWork.Save();

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
