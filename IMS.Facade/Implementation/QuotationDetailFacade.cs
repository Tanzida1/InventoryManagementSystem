using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class QuotationDetailFacade : IQuotationDetailFacade
    {
        private readonly IQuotationDetailRepository _quotationDetailRepository;

        public QuotationDetailFacade(IQuotationDetailRepository quotationDetailRepository)
        {
            _quotationDetailRepository = quotationDetailRepository;
        }

        public async Task<List<QuotationDetail>> GetAllAsync()
        {
            return await _quotationDetailRepository.GetAllAsync();
        }

        public async Task<QuotationDetail?> GetByIdAsync(int quotationDetailId)
        {
            return await _quotationDetailRepository.GetByIdAsync(quotationDetailId);
        }

        public async Task<List<QuotationDetail>> GetByQuotationIdAsync(int quotationId)
        {
            return await _quotationDetailRepository.GetByQuotationIdAsync(quotationId);
        }

        public async Task<List<QuotationDetail>> GetByItemIdAsync(int itemId)
        {
            return await _quotationDetailRepository.GetByItemIdAsync(itemId);
        }

        public async Task AddAsync(QuotationDetail quotationDetail)
        {
            ArgumentNullException.ThrowIfNull(quotationDetail);
            await _quotationDetailRepository.AddAsync(quotationDetail);
        }

        public async Task UpdateAsync(QuotationDetail quotationDetail)
        {
            ArgumentNullException.ThrowIfNull(quotationDetail);
            await _quotationDetailRepository.UpdateAsync(quotationDetail);
        }
    }
}