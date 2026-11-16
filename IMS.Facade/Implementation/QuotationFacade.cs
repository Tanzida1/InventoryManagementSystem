using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class QuotationFacade : IQuotationFacde
    {
        private readonly IQuotationRepository _quotationRepository;

        public QuotationFacade(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        public async Task<List<Quotation>> GetAllAsync()
        {
            return await _quotationRepository.GetAllAsync();
        }

        public async Task<Quotation?> GetByIdAsync(int quotationId)
        {
            return await _quotationRepository.GetByIdAsync(quotationId);
        }

        public async Task<List<Quotation>> GetBySupplierIdAsync(int supplierId)
        {
            return await _quotationRepository.GetBySupplierIdAsync(supplierId);
        }

        public async Task AddAsync(Quotation quotation)
        {
            ArgumentNullException.ThrowIfNull(quotation);
            await _quotationRepository.AddAsync(quotation);
        }

        public async Task UpdateAsync(Quotation quotation)
        {
            ArgumentNullException.ThrowIfNull(quotation);
            await _quotationRepository.UpdateAsync(quotation);
        }
    }
}