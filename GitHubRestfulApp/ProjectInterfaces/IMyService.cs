using System;
using System.Threading.Tasks;

namespace ProjectInterfaces
{
    public interface IMyService
    {       
         Task<int> GetAsync();
    }
}
