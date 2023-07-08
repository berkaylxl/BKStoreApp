using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
        void Save();
    }
}
