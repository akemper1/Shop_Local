using Shop_Local.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop_Local.Services.Interfaces
{
    public interface IFirestoreDatabase
    {
        Task RecommendShop(Business business);

        Task<IEnumerable<Business>> GetAllBusinessesByZipCode(int zipcode);
    }
}
