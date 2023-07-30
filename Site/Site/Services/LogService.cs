using Site.Interfaces;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class LogService : ILogService
    {
        public IUnitOfWork _unitOfWork;
        //private readonly ILogger<LogService> _logger;

        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_logger = logger;
        }

        public async Task<bool> Add(Log entity)
        {
            try
            {
                if (entity != null)
                {
                    await _unitOfWork.Logs.Add(entity);

                    var result = _unitOfWork.Save();

                    //Pegar o usuario com CLAIMS
                    //_logger.LogInformation($"Xyz adicinou um novo Registro de Log");

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

            //Pegar o usuario com CLAIMS
            //_logger.LogInformation($"Usuario Xyz realizou uma consulta em LOG");

            return logs;
        }

        public async Task<Log> GetById(Guid id)
        {
            var usuario = await _unitOfWork.Logs.FindByConditionAsync(x => x.Id == id);

            //Pegar o usuario com CLAIMS
            //_logger.LogInformation($"Usuario Xyz realizou uma consulta em LOG");

            return usuario;
        }

        public async Task<bool> Update(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
