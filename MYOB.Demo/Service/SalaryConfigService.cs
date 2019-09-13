using Microsoft.Extensions.Configuration;
using System;

namespace MYOB.Demo.Service
{
    public interface ISalaryConfigService
    {
        T GetSection<T>(string sectionName) where T : class;
    }
    class SalaryConfigService : ISalaryConfigService
    {
        private readonly IConfiguration _configuration;

        public SalaryConfigService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public T GetSection<T>(string sectionName) where T : class
        {
            T section = default(T);

            if (string.IsNullOrEmpty(sectionName)) //always good to validate / check the input
            {
                return section;
            }

            try
            {
                section = Activator.CreateInstance(typeof(T)) as T;

                _configuration.GetSection(sectionName).Bind(section);
            }
            catch
            {
                // Yell    Log    Catch  Throw     
            }
            return section;
        }
    }
}
