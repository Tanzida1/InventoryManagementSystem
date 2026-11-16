
using IMS.Entities.Inventory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface ISupplierRepository
    {
        // 1. Get all suppliers
        Task<List<Supplier>> GetAllAsync();

        // 2. Get supplier by ID
        Task<Supplier?> GetByIdAsync(int supplierId);

        // 3. Add new supplier
        Task AddAsync(Supplier supplier);

        // 4. Update supplier
        Task UpdateAsync(Supplier supplier);

        // 5. Delete supplier
        Task DeleteAsync(int supplierId);
    }
}
