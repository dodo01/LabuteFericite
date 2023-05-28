using System;
namespace LabuteCalatoare.Infrastructure.EnvironmentUtils
{
    public class EnvironmentVariableUtils
    {
        public static string DefineConfigFile()
        {
#if DEBUG
            return "appsettings.json";
#endif
        }
    }
}
