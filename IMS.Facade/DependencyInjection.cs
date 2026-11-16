
using IMS.DataAccess;
using IMS.DataAccess.Interface;
using IMS.DataAccess.Implementation;
using IMS.Facade.Interface;
using IMS.Facade.Implementation;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.Facade
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddImsFacade(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Database Connection
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            // 1. AI Model Configuration
            services.AddScoped<IAIModelConfigurationRepository, AIModelConfigurationRepository>();
            services.AddScoped<IAIModelConfigurationFacade, AIModelConfigurationFacade>();

            // 2. Anomaly Detection
            services.AddScoped<IAnomalyDetectionRepository, AnomalyDetectionRepository>();
            services.AddScoped<IAnomalyDetectionFacade, AnomalyDetectionFacade>();

            // 3. Approval History
            services.AddScoped<IApprovalHistoryRepository, ApprovalHistoryRepository>();
            services.AddScoped<IApprovalHistoryFacade, ApprovalHistoryFacade>();

            // 4. Assistant Conversation
            services.AddScoped<IAssistantConversationRepository, AssistantConversationRepository>();
            services.AddScoped<IAssistantConversationFacade, AssistantConversationFacade>();

            // 5. Assistant Message
            services.AddScoped<IAssistantMessageRepository, AssistantMessageRepository>();
            services.AddScoped<IAssistantMessageFacade, AssistantMessageFacade>();

            // 6. Audit Log
            services.AddScoped<IAuditLogRepository, AuditLogRepository>();
            services.AddScoped<IAuditLogFacade, AuditLogFacade>();

            // 7. Category
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryFacade, CategoryFacade>();

            // 8. Demand Forecast
            services.AddScoped<IDemandForecastRepository, DemandForecastRepository>();
            services.AddScoped<IDemandForecastFacade, DemandForecastFacade>();

            // 9. Document Attachment
            services.AddScoped<IDocumentAttachmentRepository, DocumentAttachmentRepository>();
            services.AddScoped<IDocumentAttachmentFacade, DocumentAttachmentFacade>();

            // 10. Document Sequence
            services.AddScoped<IDocumentSequenceRepository, DocumentSequenceRepository>();
            services.AddScoped<IDocumentSequenceFacade, DocumentSequenceFacade>();

            // 11. Document Status History
            services.AddScoped<IDocumentStatusHistoryRepository, DocumentStatusHistoryRepository>();
            services.AddScoped<IDocumentStatusHistoryFacade, DocumentStatusHistoryFacade>();

            // 12. Forecast Run
            services.AddScoped<IForecastRunRepository, ForecastRunRepository>();
            services.AddScoped<IForecastRunFacade, ForecastRunFacade>();

            // 13. Goods Receipt
            services.AddScoped<IGoodsReceiptRepository, GoodsReceiptRepository>();
            services.AddScoped<IGoodsReceiptFacade, GoodsReceiptFacade>();

            // 14. Goods Receipt Detail
            services.AddScoped<IGoodsReceiptDetailRepository, GoodsReceiptDetailRepository>();
            services.AddScoped<IGoodsReceiptDetailFacade, GoodsReceiptDetailFacade>();

            // 15. Inventory Ledger
            services.AddScoped<IInventoryLedgerRepository, InventoryLedgerRepository>();
            services.AddScoped<IInventoryLedgerFacade, InventoryLedgerFacade>();

            // 16. Invoice Receipt Match
            services.AddScoped<IInvoiceReceiptMatchRepository, InvoiceReceiptMatchRepository>();
            services.AddScoped<IInvoiceReceiptMatchFacade, InvoiceReceiptMatchFacade>();

            // 17. Issue Order
            services.AddScoped<IIssueOrderRepository, IssueOrderRepository>();
            services.AddScoped<IIssueOrderFacade, IssueOrderFacade>();

            // 18. Issue Order Detail
            services.AddScoped<IIssueOrderDetailRepository, IssueOrderDetailRepository>();
            services.AddScoped<IIssueOrderDetailFacade, IssueOrderDetailFacade>();

            // 19. Item
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemFacade, ItemFacade>();

            // 20. Model Evaluation
            services.AddScoped<IModelEvaluationRepository, ModelEvaluationRepository>();
            services.AddScoped<IModelEvaluationFacade, ModelEvaluationFacade>();

            // 21. Notification
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationFacade, NotificationFacade>();

            // 22. Permission
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionFacade, PermissionFacade>();

            // 23. Physical Stock Count
            services.AddScoped<IPhysicalStockCountRepository, PhysicalStockCountRepository>();
            services.AddScoped<IPhysicalStockCountFacade, PhysicalStockCountFacade>();

            // 24. Physical Stock Count Detail
            services.AddScoped<IPhysicalStockCountDetailRepository, PhysicalStockCountDetailRepository>();
            services.AddScoped<IPhysicalStockCountDetailFacade, PhysicalStockCountDetailFacade>();

            // 25. Purchase Order
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderFacade, PurchaseOrderFacade>();

            // 26. Purchase Order Detail
            services.AddScoped<IPurchaseOrderDetailRepository, PurchaseOrderDetailRepository>();
            services.AddScoped<IPurchaseOrderDetailFacade, PurchaseOrderDetailFacade>();

            // 27. Purchase Order Requisition Detail
            services.AddScoped<IPurchaseOrderRequisitionDetailRepository, PurchaseOrderRequisitionDetailRepository>();
            services.AddScoped<IPurchaseOrderRequisitionDetailFacade, PurchaseOrderRequisitionDetailFacade>();

            // 28. Purchase Requisition
            services.AddScoped<IPurchaseRequisitionRepository, PurchaseRequisitionRepository>();
            services.AddScoped<IPurchaseRequisitionFacade, PurchaseRequisitionFacade>();

            // 29. Purchase Requisition Detail
            services.AddScoped<IPurchaseRequisitionDetailRepository, PurchaseRequisitionDetailRepository>();
            services.AddScoped<IPurchaseRequisitionDetailFacade, PurchaseRequisitionDetailFacade>();

            // 30. Quotation
            services.AddScoped<IQuotationRepository, QuotationRepository>();
            services.AddScoped<IQuotationFacde, QuotationFacade>();

            // 31. Quotation Detail
            services.AddScoped<IQuotationDetailRepository, QuotationDetailRepository>();
            services.AddScoped<IQuotationDetailFacade, QuotationDetailFacade>();

            // 32. Reorder Recommendation
            services.AddScoped<IReorderRecommendationRepository, ReorderRecommendationRepository>();
            services.AddScoped<IReorderRecommendationFacade, ReorderRecommendationFacade>();

            // 33. Role
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleFacade, RoleFacade>();

            // 34. Role Permission
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IRolePermissionFacade, RolePermissionFacade>();

            // 35. Sale
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleFacade, SaleFacade>();

            // 36. Sale Detail
            services.AddScoped<ISaleDetailRepository, SaleDetailRepository>();
            services.AddScoped<ISaleDetailFacade, SaleDetailFacade>();

            // 37. Stock
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IStockFacade, StockFacade>();

            // 38. Stock Adjustment
            services.AddScoped<IStockAdjustmentRepository, StockAdjustmentRepository>();
            services.AddScoped<IStockAdjustmentFacade, StockAdjustmentFacade>();

            // 39. Stock Adjustment Detail
            services.AddScoped<IStockAdjustmentDetailRepository, StockAdjustmentDetailRepository>();
            services.AddScoped<IStockAdjustmentDetailFacade, StockAdjustmentDetailFacade>();

            // 40. Stock Requisition
            services.AddScoped<IStockRequisitionRepository, StockRequisitionRepository>();
            services.AddScoped<IStockRequisitionFacade, StockRequisitionFacade>();

            // 41. Stock Requisition Detail
            services.AddScoped<IStockRequisitionDetailRepository, StockRequisitionDetailRepository>();
            services.AddScoped<IStockRequisitionDetailFacade, StockRequisitionDetailFacade>();

            // 42. Supplier
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierFacade, SupplierFacade>();

            // 43. Supplier Invoice
            services.AddScoped<ISupplierInvoiceRepository, SupplierInvoiceRepository>();
            services.AddScoped<ISupplierInvoiceFacade, SupplierInvoiceFacade>();

            // 44. Supplier Invoice Detail
            services.AddScoped<ISupplierInvoiceDetailRepository, SupplierInvoiceDetailRepository>();
            services.AddScoped<ISupplierInvoiceDetailFacade, SupplierInvoiceDetailFacade>();

            // 45. Supplier Item
            services.AddScoped<ISupplierItemRepository, SupplierItemRepository>();
            services.AddScoped<ISupplierItemFacade, SupplierItemFacade>();

            // 46. Transfer Order
            services.AddScoped<ITransferOrderRepository, TransferOrderRepository>();
            services.AddScoped<ITransferOrderFacade, TransferOrderFacade>();

            // 47. Transfer Order Detail
            services.AddScoped<ITransferOrderDetailRepository, TransferOrderDetailRepository>();
            services.AddScoped<ITransferOrderDetailFacade, TransferOrderDetailFacade>();

            // 48. Unit
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IUnitFacade, UnitFacade>();

            // 49. User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserFacade, UserFacade>();

            // 50. User Role
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRoleFacade, UserRoleFacade>();

            // 51. User Warehouse
            services.AddScoped<IUserWarehouseRepository, UserWarehouseRepository>();
            services.AddScoped<IUserWarehouseFacade, UserWarehouseFacade>();

            // 52. Warehouse
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IWarehouseFacade, WarehouseFacade>();

            return services;
        }
    }
}
