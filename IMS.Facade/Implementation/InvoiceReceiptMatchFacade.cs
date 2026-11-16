using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class InvoiceReceiptMatchFacade : IInvoiceReceiptMatchFacade
    {
        private readonly IInvoiceReceiptMatchRepository _invoiceReceiptMatchRepository;

        public InvoiceReceiptMatchFacade(IInvoiceReceiptMatchRepository invoiceReceiptMatchRepository)
        {
            _invoiceReceiptMatchRepository = invoiceReceiptMatchRepository;
        }

        public async Task<List<InvoiceReceiptMatch>> GetAllAsync()
        {
            return await _invoiceReceiptMatchRepository.GetAllAsync();
        }

        public async Task<InvoiceReceiptMatch?> GetByIdAsync(int id)
        {
            return await _invoiceReceiptMatchRepository.GetByIdAsync(id);
        }

        public async Task<List<InvoiceReceiptMatch>> GetByInvoiceDetailIdAsync(int invoiceDetailId)
        {
            return await _invoiceReceiptMatchRepository.GetByInvoiceDetailIdAsync(invoiceDetailId);
        }

        public async Task<List<InvoiceReceiptMatch>> GetByGRNDetailIdAsync(int grnDetailId)
        {
            return await _invoiceReceiptMatchRepository.GetByGRNDetailIdAsync(grnDetailId);
        }

        public async Task AddAsync(InvoiceReceiptMatch invoiceReceiptMatch)
        {
            ArgumentNullException.ThrowIfNull(invoiceReceiptMatch);
            await _invoiceReceiptMatchRepository.AddAsync(invoiceReceiptMatch);
        }

        public async Task UpdateAsync(InvoiceReceiptMatch invoiceReceiptMatch)
        {
            ArgumentNullException.ThrowIfNull(invoiceReceiptMatch);
            await _invoiceReceiptMatchRepository.UpdateAsync(invoiceReceiptMatch);
        }
    }
}