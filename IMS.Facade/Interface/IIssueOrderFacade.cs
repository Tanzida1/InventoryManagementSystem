using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface IIssueOrderFacade
    {

        // 1. Get all issue orders
        Task<List<IssueOrder>> GetAllAsync();

        // 2. Get issue order by ID
        Task<IssueOrder?> GetByIdAsync(int id);

        // 3. Get issue orders by requisition
        Task<List<IssueOrder>> GetByRequisitionIdAsync(int requisitionId);

        // 4. Get issue orders by warehouse
        Task<List<IssueOrder>> GetByWarehouseIdAsync(int warehouseId);

        // 5. Add issue order
        Task AddAsync(IssueOrder issueOrder);

        // 6. Update issue order
        Task UpdateAsync(IssueOrder issueOrder);
    }
}
