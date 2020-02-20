using System.Threading.Tasks;

namespace Interfaces
{
    public interface IMyService
    {
        Task<int> GetAsync();
    }
}
