using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public record BookDtoForUpdate(int Id, string Title, decimal Price);  
}
