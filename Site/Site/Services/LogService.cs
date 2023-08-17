using Site.Interfaces;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class LogService : ILogService
    {
        public IUnitOfWork _unitOfWork;

        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Log entity)
        {
            try
            {
                if (entity != null)
                {
                    entity.CreatedAt = DateTime.Now;

                    await _unitOfWork.Logs.Add(entity);

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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Log>> GetAll()
        {
            var logs = await _unitOfWork.Logs.GetAll();
            return logs;
        }

        public async Task<Log> GetById(Guid id)
        {
            var usuario = await _unitOfWork.Logs.FindByConditionAsync(x => x.Id == id);
            return usuario;
        }

        public Task<bool> LogicalRemove(Log entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
