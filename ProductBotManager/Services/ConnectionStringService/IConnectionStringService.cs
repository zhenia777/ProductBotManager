using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.ConnectionStringService
{
    public interface IConnectionStringService
    {
        public string ConnectionString { get; }
    }
}
