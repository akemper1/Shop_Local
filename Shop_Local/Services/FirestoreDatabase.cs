using Plugin.CloudFirestore;
using Shop_Local.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop_Local.Services
{
    public class FirestoreDatabase
    {
        public async Task RecommendShop(Business business)
        {
            // Insert into recommended businesses collection.
            await CrossCloudFirestore.Current.Instance.Collection("recommended_businesses").AddAsync(business);
        }

        public async Task<IEnumerable<Business>> GetAllBusinessesByZipCode(int zipcode)
        {
            // Setup List.
            IEnumerable<Business> result = null;

            // Query.
            var query = await CrossCloudFirestore.Current
                                                 .Instance
                                                 .Collection("approved_businesses")
                                                 .WhereEqualsTo("zip_code", zipcode)
                                                 .GetAsync();

            // Case back to object to be used.
            result = query.ToObjects<Business>();

            // Return list of objects.
            return result;
        }
    }
}
