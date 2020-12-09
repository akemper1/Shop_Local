using Plugin.CloudFirestore;
using Shop_Local.Models;
using System.Threading.Tasks;

namespace Shop_Local.Services
{
    public class FirestoreDatabase
    {
        public async Task RecommendShop(Business business)
        {
            await CrossCloudFirestore.Current.Instance.Collection("recommended_businesses").AddAsync(business);
        }
    }
}
