using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IExcelService
    {
        string UpdateCell(string docName, string column, uint row, string text);
    }
}
