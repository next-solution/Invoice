using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}
