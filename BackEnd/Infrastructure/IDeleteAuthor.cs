using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistance
{
    public interface IDeleteAuthor
    {
        Task<bool> DeleteAuthorAsync(string name);
    }
}