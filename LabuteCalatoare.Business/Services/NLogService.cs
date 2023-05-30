using LabuteCalatoare.Infrastructure.EnvironmentUtils;
using NLog;
using NLog.Web;

namespace LabuteCalatoare.Business.Services
{
    public static class NLogService
    {
        public static Logger GetLogger()
        {
            return NLogBuilder.ConfigureNLog(EnvironmentVariableUtils.DefineNlogConfig()).GetCurrentClassLogger();
        }
    }
}
