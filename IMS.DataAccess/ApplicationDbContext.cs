using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.EntityFrameworkCore;
using IMS.Entities;
using IMS.Entities.Access;
using IMS.Entities.Inventory;

namespace IMS.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Access Management
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        // Inventory Master
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierItem> SupplierItems { get; set; }
        public DbSet<UserWarehouse> UserWarehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        // Stock Requisition and Issue
        public DbSet<StockRequisition> StockRequisitions { get; set; }
        public DbSet<StockRequisitionDetail> StockRequisitionDetails { get; set; }
        public DbSet<IssueOrder> IssueOrders { get; set; }
        public DbSet<IssueOrderDetail> IssueOrderDetails { get; set; }

        // Transfer
        public DbSet<TransferOrder> TransferOrders { get; set; }
        public DbSet<TransferOrderDetail> TransferOrderDetails { get; set; }

        // Purchase and Quotation
        public DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }
        public DbSet<PurchaseRequisitionDetail> PurchaseRequisitionDetails { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationDetail> QuotationDetails { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<PurchaseOrderRequisitionDetail> PurchaseOrderRequisitionDetails { get; set; }

        // Goods Receipt and Supplier Invoice
        public DbSet<GoodsReceipt> GoodsReceipts { get; set; }
        public DbSet<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
        public DbSet<SupplierInvoice> SupplierInvoices { get; set; }
        public DbSet<SupplierInvoiceDetail> SupplierInvoiceDetails { get; set; }
        public DbSet<InvoiceReceiptMatch> InvoiceReceiptMatches { get; set; }

        // Sales
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }

        // Stock Adjustment and Physical Count
        public DbSet<StockAdjustment> StockAdjustments { get; set; }
        public DbSet<StockAdjustmentDetail> StockAdjustmentDetails { get; set; }
        public DbSet<PhysicalStockCount> PhysicalStockCounts { get; set; }
        public DbSet<PhysicalStockCountDetail> PhysicalStockCountDetails { get; set; }

        // Inventory Ledger
        public DbSet<InventoryLedger> InventoryLedgers { get; set; }

        // Workflow and System
        public DbSet<ApprovalHistory> ApprovalHistories { get; set; }
        public DbSet<DocumentStatusHistory> DocumentStatusHistories { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<DocumentSequence> DocumentSequences { get; set; }
        public DbSet<DocumentAttachment> DocumentAttachments { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        // AI and Analytics
        public DbSet<AIModelConfiguration> AIModelConfigurations { get; set; }
        public DbSet<ForecastRun> ForecastRuns { get; set; }
        public DbSet<DemandForecast> DemandForecasts { get; set; }
        public DbSet<ReorderRecommendation> ReorderRecommendations { get; set; }
        public DbSet<ModelEvaluation> ModelEvaluations { get; set; }
        public DbSet<AnomalyDetection> AnomalyDetections { get; set; }
        public DbSet<AssistantConversation> AssistantConversations { get; set; }
        public DbSet<AssistantMessage> AssistantMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationship configuration will be added here.

            //  Primary Key

            // Access & User Management
            modelBuilder.Entity<Permission>().HasKey(e => e.PermissionId);
            modelBuilder.Entity<Role>().HasKey(e => e.RoleId);
            modelBuilder.Entity<RolePermission>().HasKey(e => e.RolePermissionId);
            modelBuilder.Entity<User>().HasKey(e => e.UserId);
            modelBuilder.Entity<UserRole>().HasKey(e => e.UserRoleId);

            // Inventory & Warehouse
            modelBuilder.Entity<Category>().HasKey(e => e.CategoryId);
            modelBuilder.Entity<Item>().HasKey(e => e.ItemId);
            modelBuilder.Entity<Supplier>().HasKey(e => e.SupplierId);
            modelBuilder.Entity<SupplierItem>().HasKey(e => e.SupplierItemId);
            modelBuilder.Entity<Unit>().HasKey(e => e.UnitId);
            modelBuilder.Entity<UserWarehouse>().HasKey(e => e.UserWarehouseId);
            modelBuilder.Entity<Warehouse>().HasKey(e => e.WarehouseId);

            // AI & Forecasting Models
            modelBuilder.Entity<AIModelConfiguration>().HasKey(e => e.ConfigurationId);
            modelBuilder.Entity<AnomalyDetection>().HasKey(e => e.AnomalyId);
            modelBuilder.Entity<DemandForecast>().HasKey(e => e.ForecastId);
            modelBuilder.Entity<ForecastRun>().HasKey(e => e.ForecastRunId);
            modelBuilder.Entity<ModelEvaluation>().HasKey(e => e.EvaluationId);
            modelBuilder.Entity<ReorderRecommendation>().HasKey(e => e.RecommendationId);

            // Document & Tracking
            modelBuilder.Entity<ApprovalHistory>().HasKey(e => e.ApprovalHistoryId);
            modelBuilder.Entity<AssistantConversation>().HasKey(e => e.ConversationId);
            modelBuilder.Entity<AssistantMessage>().HasKey(e => e.MessageId);
            modelBuilder.Entity<AuditLog>().HasKey(e => e.AuditLogId);
            modelBuilder.Entity<DocumentAttachment>().HasKey(e => e.AttachmentId);
            modelBuilder.Entity<DocumentSequence>().HasKey(e => e.SequenceId);
            modelBuilder.Entity<DocumentStatusHistory>().HasKey(e => e.DocumentStatusHistoryId);
            modelBuilder.Entity<Notification>().HasKey(e => e.NotificationId);

            // Goods & Inventory Transactions
            modelBuilder.Entity<GoodsReceipt>().HasKey(e => e.GoodsReceiptId);
            modelBuilder.Entity<GoodsReceiptDetail>().HasKey(e => e.GRNDetailId);
            modelBuilder.Entity<InventoryLedger>().HasKey(e => e.LedgerId);
            modelBuilder.Entity<InvoiceReceiptMatch>().HasKey(e => e.MatchId);
            modelBuilder.Entity<PhysicalStockCount>().HasKey(e => e.CountId);
            modelBuilder.Entity<PhysicalStockCountDetail>().HasKey(e => e.CountDetailId);
            modelBuilder.Entity<Stock>().HasKey(e => e.StockId);
            modelBuilder.Entity<StockAdjustment>().HasKey(e => e.AdjustmentId);
            modelBuilder.Entity<StockAdjustmentDetail>().HasKey(e => e.AdjustmentDetailId);
            modelBuilder.Entity<StockRequisition>().HasKey(e => e.RequisitionId);
            modelBuilder.Entity<StockRequisitionDetail>().HasKey(e => e.RequisitionDetailId);

            // Orders, Sales & Purchase
            modelBuilder.Entity<IssueOrder>().HasKey(e => e.IssueOrderId);
            modelBuilder.Entity<IssueOrderDetail>().HasKey(e => e.IssueOrderDetailId);
            modelBuilder.Entity<PurchaseOrder>().HasKey(e => e.PurchaseOrderId);
            modelBuilder.Entity<PurchaseOrderDetail>().HasKey(e => e.PODetailId);
            modelBuilder.Entity<PurchaseOrderRequisitionDetail>().HasKey(e => e.PurchaseOrderRequisitionDetailId);
            modelBuilder.Entity<PurchaseRequisition>().HasKey(e => e.PurchaseRequisitionId);
            modelBuilder.Entity<PurchaseRequisitionDetail>().HasKey(e => e.PRDetailId);
            modelBuilder.Entity<Quotation>().HasKey(e => e.QuotationId);
            modelBuilder.Entity<QuotationDetail>().HasKey(e => e.QuotationDetailId);
            modelBuilder.Entity<Sale>().HasKey(e => e.SaleId);
            modelBuilder.Entity<SaleDetail>().HasKey(e => e.SaleDetailId);
            modelBuilder.Entity<SupplierInvoice>().HasKey(e => e.SupplierInvoiceId);
            modelBuilder.Entity<SupplierInvoiceDetail>().HasKey(e => e.InvoiceDetailId);
            modelBuilder.Entity<TransferOrder>().HasKey(e => e.TransferOrderId);
            modelBuilder.Entity<TransferOrderDetail>().HasKey(e => e.TransferDetailId);


























            // User and UserRole Relationship

            modelBuilder.Entity<UserRole>()
        .HasOne(x => x.User)
        .WithMany(x => x.UserRoles)
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Restrict);


            // Role and UserRole Relationship

            modelBuilder.Entity<UserRole>()
       .HasOne(x => x.Role)
       .WithMany(x => x.UserRoles)
       .HasForeignKey(x => x.RoleId)
       .OnDelete(DeleteBehavior.Restrict);

            // Role and RolePermission Relationship

            modelBuilder.Entity<RolePermission>()
        .HasOne(x => x.Role)
        .WithMany(x => x.RolePermissions)
        .HasForeignKey(x => x.RoleId)
        .OnDelete(DeleteBehavior.Restrict);

            // Permission and RolePermission Relationship
            modelBuilder.Entity<RolePermission>()
                .HasOne(x => x.Permission)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            //Duplicate Permission Prevention


            modelBuilder.Entity<RolePermission>()
    .HasIndex(x => new { x.RoleId, x.PermissionId })
    .IsUnique();








            // Permission Parent and Child Relationship

            //modelBuilder.Entity<Permission>()
            //    .HasOne(permission => permission.ParentPermission)
            //    .WithMany(permission => permission.ChildPermissions)
            //    .HasForeignKey(permission => permission.ParentId)
            //    .OnDelete(DeleteBehavior.Restrict);
















            // User and UserWarehouse Relationship
            modelBuilder.Entity<UserWarehouse>()
                .HasOne(ur => ur.User)
                .WithMany()
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            // Warehouse and UserWarehouse Relationship
            modelBuilder.Entity<UserWarehouse>()
                .HasOne(ur => ur.Warehouse)
                .WithMany(warehouse => warehouse.UserWarehouses)
                .HasForeignKey(ur => ur.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);



            // Item and Stock Relationship
            modelBuilder.Entity<Stock>()
                .HasOne(stock => stock.Item)
                .WithMany()
                .HasForeignKey(stock => stock.ItemId)
                .OnDelete(DeleteBehavior.Restrict);


            // Warehouse and Stock Relationship
            modelBuilder.Entity<Stock>()
                .HasOne(stock => stock.Warehouse)
                .WithMany()
                .HasForeignKey(stock => stock.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);


            // One Item in one Warehouse should have only one Stock record
            modelBuilder.Entity<Stock>()
                .HasIndex(stock => new
                {
                    stock.ItemId,
                    stock.WarehouseId
                })
                .IsUnique();



            // User and StockRequisition Relationship
            modelBuilder.Entity<StockRequisition>()
                .HasOne(requisition => requisition.User)
                .WithMany()
                .HasForeignKey(requisition => requisition.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);


            // Warehouse and StockRequisition Relationship
            modelBuilder.Entity<StockRequisition>()
                .HasOne(requisition => requisition.Warehouse)
                .WithMany()
                .HasForeignKey(requisition => requisition.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);


            // StockRequisition and StockRequisitionDetail Relationship
            modelBuilder.Entity<StockRequisitionDetail>()
                .HasOne(detail => detail.StockRequisition)
                .WithMany(requisition => requisition.RequisitionDetails)
                .HasForeignKey(detail => detail.RequisitionId)
                .OnDelete(DeleteBehavior.Restrict);


            // Item and StockRequisitionDetail Relationship
            modelBuilder.Entity<StockRequisitionDetail>()
                .HasOne(detail => detail.Item)
                .WithMany()
                .HasForeignKey(detail => detail.ItemId)
                .OnDelete(DeleteBehavior.Restrict);



            // StockRequisition and IssueOrder Relationship
            modelBuilder.Entity<IssueOrder>()
                .HasOne(issueOrder => issueOrder.StockRequisition)
                .WithMany(requisition => requisition.IssueOrders)
                .HasForeignKey(issueOrder => issueOrder.RequisitionId)
                .OnDelete(DeleteBehavior.Restrict);


            // Warehouse and IssueOrder Relationship
            modelBuilder.Entity<IssueOrder>()
                .HasOne(issueOrder => issueOrder.Warehouse)
                .WithMany()
                .HasForeignKey(issueOrder => issueOrder.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);


            // User and IssueOrder Relationship
            modelBuilder.Entity<IssueOrder>()
                .HasOne(issueOrder => issueOrder.User)
                .WithMany()
                .HasForeignKey(issueOrder => issueOrder.IssuedBy)
                .OnDelete(DeleteBehavior.Restrict);


            // IssueOrder and IssueOrderDetail Relationship
            modelBuilder.Entity<IssueOrderDetail>()
                .HasOne(detail => detail.IssueOrder)
                .WithMany(issueOrder => issueOrder.IssueOrderDetails)
                .HasForeignKey(detail => detail.IssueOrderId)
                .OnDelete(DeleteBehavior.Restrict);


            // StockRequisitionDetail and IssueOrderDetail Relationship
            modelBuilder.Entity<IssueOrderDetail>()
                .HasOne(detail => detail.StockRequisitionDetail)
                .WithMany(requisitionDetail => requisitionDetail.IssueOrderDetails)
                .HasForeignKey(detail => detail.RequisitionDetailId)
                .OnDelete(DeleteBehavior.Restrict);


            // Item and IssueOrderDetail Relationship
            modelBuilder.Entity<IssueOrderDetail>()
                .HasOne(detail => detail.Item)
                .WithMany()
                .HasForeignKey(detail => detail.ItemId)
                .OnDelete(DeleteBehavior.Restrict);


            //  Transfer Order Relationships

            // TransferOrder -> Source Warehouse
            modelBuilder.Entity<TransferOrder>()
     .HasOne(transferOrder => transferOrder.SourceWarehouse)
     .WithMany()
     .HasForeignKey(transferOrder => transferOrder.SourceWarehouseId)
     .OnDelete(DeleteBehavior.Restrict);

            // TransferOrder -> Destination Warehouse
            modelBuilder.Entity<TransferOrder>()
                .HasOne(x => x.DestinationWarehouse)
                .WithMany()
                .HasForeignKey(x => x.DestinationWarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // TransferOrder -> Requesting User
            modelBuilder.Entity<TransferOrder>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.RequestedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // TransferOrderDetail -> TransferOrder
            modelBuilder.Entity<TransferOrderDetail>()
    .HasOne(transferDetail => transferDetail.TransferOrder)
    .WithMany(transferOrder => transferOrder.TransferOrderDetails)
    .HasForeignKey(transferDetail => transferDetail.TransferOrderId)
    .OnDelete(DeleteBehavior.Restrict);

            // TransferOrderDetail -> Item
            modelBuilder.Entity<TransferOrderDetail>()
      .HasOne(transferDetail => transferDetail.Item)
      .WithMany()
      .HasForeignKey(transferDetail => transferDetail.ItemId)
      .OnDelete(DeleteBehavior.Restrict);



            // Stock and Item Relationship
            modelBuilder.Entity<Stock>()
                .HasOne(stock => stock.Item)
                .WithMany()
                .HasForeignKey(stock => stock.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Stock and Warehouse Relationship
            modelBuilder.Entity<Stock>()
                .HasOne(stock => stock.Warehouse)
                .WithMany()
                .HasForeignKey(stock => stock.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);



            // Sale and Warehouse Relationship
            modelBuilder.Entity<Sale>()
                .HasOne(sale => sale.Warehouse)
                .WithMany()
                .HasForeignKey(sale => sale.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Sale and User Relationship
            modelBuilder.Entity<Sale>()
                .HasOne(sale => sale.User)
                .WithMany()
                .HasForeignKey(sale => sale.SalesOfficerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Sale and SaleDetail Relationship
            modelBuilder.Entity<SaleDetail>()
                .HasOne(saleDetail => saleDetail.Sale)
                .WithMany(sale => sale.SaleDetails)
                .HasForeignKey(saleDetail => saleDetail.SaleId)
                .OnDelete(DeleteBehavior.Restrict);

            // SaleDetail and Item Relationship
            modelBuilder.Entity<SaleDetail>()
                .HasOne(saleDetail => saleDetail.Item)
                .WithMany()
                .HasForeignKey(saleDetail => saleDetail.ItemId)
                .OnDelete(DeleteBehavior.Restrict);



            // StockAdjustment and Warehouse Relationship
            modelBuilder.Entity<StockAdjustment>()
                .HasOne(stockAdjustment => stockAdjustment.Warehouse)
                .WithMany()
                .HasForeignKey(stockAdjustment => stockAdjustment.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // StockAdjustment and Requester Relationship
            modelBuilder.Entity<StockAdjustment>()
                .HasOne(stockAdjustment => stockAdjustment.Requester)
                .WithMany()
                .HasForeignKey(stockAdjustment => stockAdjustment.RequestedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // StockAdjustment and Approver Relationship
            modelBuilder.Entity<StockAdjustment>()
                .HasOne(stockAdjustment => stockAdjustment.Approver)
                .WithMany()
                .HasForeignKey(stockAdjustment => stockAdjustment.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // StockAdjustment and StockAdjustmentDetail Relationship
            modelBuilder.Entity<StockAdjustmentDetail>()
                .HasOne(adjustmentDetail => adjustmentDetail.StockAdjustment)
                .WithMany(stockAdjustment => stockAdjustment.StockAdjustmentDetails)
                .HasForeignKey(adjustmentDetail => adjustmentDetail.AdjustmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // StockAdjustmentDetail and Item Relationship
            modelBuilder.Entity<StockAdjustmentDetail>()
                .HasOne(adjustmentDetail => adjustmentDetail.Item)
                .WithMany()
                .HasForeignKey(adjustmentDetail => adjustmentDetail.ItemId)
                .OnDelete(DeleteBehavior.Restrict);


            // PhysicalStockCount and Warehouse Relationship
            modelBuilder.Entity<PhysicalStockCount>()
                .HasOne(physicalCount => physicalCount.Warehouse)
                .WithMany()
                .HasForeignKey(physicalCount => physicalCount.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // PhysicalStockCount and User Relationship
            modelBuilder.Entity<PhysicalStockCount>()
                .HasOne(physicalCount => physicalCount.User)
                .WithMany()
                .HasForeignKey(physicalCount => physicalCount.CountedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // PhysicalStockCount and PhysicalStockCountDetail Relationship
            modelBuilder.Entity<PhysicalStockCountDetail>()
                .HasOne(countDetail => countDetail.PhysicalStockCount)
                .WithMany(physicalCount => physicalCount.PhysicalStockCountDetails)
                .HasForeignKey(countDetail => countDetail.CountId)
                .OnDelete(DeleteBehavior.Restrict);

            // PhysicalStockCountDetail and Item Relationship
            modelBuilder.Entity<PhysicalStockCountDetail>()
                .HasOne(countDetail => countDetail.Item)
                .WithMany()
                .HasForeignKey(countDetail => countDetail.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // InventoryLedger and Item Relationship
            modelBuilder.Entity<InventoryLedger>()
                .HasOne(inventoryLedger => inventoryLedger.Item)
                .WithMany()
                .HasForeignKey(inventoryLedger => inventoryLedger.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // InventoryLedger and Warehouse Relationship
            modelBuilder.Entity<InventoryLedger>()
                .HasOne(inventoryLedger => inventoryLedger.Warehouse)
                .WithMany()
                .HasForeignKey(inventoryLedger => inventoryLedger.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // InventoryLedger and User Relationship
            modelBuilder.Entity<InventoryLedger>()
                .HasOne(inventoryLedger => inventoryLedger.User)
                .WithMany()
                .HasForeignKey(inventoryLedger => inventoryLedger.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);




    
            // Phase 1: Purchase Requisition
          

            // PurchaseRequisition -> User
            modelBuilder.Entity<PurchaseRequisition>()
                .HasOne(purchaseRequisition => purchaseRequisition.User)
                .WithMany()
                .HasForeignKey(purchaseRequisition => purchaseRequisition.RequestedBy)
                .OnDelete(DeleteBehavior.Restrict);


            // PurchaseRequisitionDetail -> PurchaseRequisition
            modelBuilder.Entity<PurchaseRequisitionDetail>()
                .HasOne(requisitionDetail => requisitionDetail.PurchaseRequisition)
                .WithMany()
                .HasForeignKey(requisitionDetail => requisitionDetail.PurchaseRequisitionId)
                .OnDelete(DeleteBehavior.Restrict);


            // PurchaseRequisitionDetail -> Item
            modelBuilder.Entity<PurchaseRequisitionDetail>()
                .HasOne(requisitionDetail => requisitionDetail.Item)
                .WithMany()
                .HasForeignKey(requisitionDetail => requisitionDetail.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // Phase 2: Quotation
            

            // Quotation -> Supplier
            modelBuilder.Entity<Quotation>()
                .HasOne(quotation => quotation.Supplier)
                .WithMany()
                .HasForeignKey(quotation => quotation.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);


            // QuotationDetail -> Quotation
            modelBuilder.Entity<QuotationDetail>()
                .HasOne(quotationDetail => quotationDetail.Quotation)
                .WithMany()
                .HasForeignKey(quotationDetail => quotationDetail.QuotationId)
                .OnDelete(DeleteBehavior.Restrict);


            // QuotationDetail -> Item
            modelBuilder.Entity<QuotationDetail>()
                .HasOne(quotationDetail => quotationDetail.Item)
                .WithMany()
                .HasForeignKey(quotationDetail => quotationDetail.ItemId)
                .OnDelete(DeleteBehavior.Restrict);


            // =====================================
            // Phase 3: Purchase Order
            // =====================================

            // PurchaseOrder -> Supplier
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(purchaseOrder => purchaseOrder.Supplier)
                .WithMany()
                .HasForeignKey(purchaseOrder => purchaseOrder.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);


            // PurchaseOrder -> Warehouse
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(purchaseOrder => purchaseOrder.Warehouse)
                .WithMany()
                .HasForeignKey(purchaseOrder => purchaseOrder.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);


            // PurchaseOrder -> Quotation
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(purchaseOrder => purchaseOrder.Quotation)
                .WithMany()
                .HasForeignKey(purchaseOrder => purchaseOrder.QuotationId)
                .OnDelete(DeleteBehavior.Restrict);


            // PurchaseOrderDetail -> PurchaseOrder
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(purchaseOrderDetail => purchaseOrderDetail.PurchaseOrder)
                .WithMany()
                .HasForeignKey(purchaseOrderDetail => purchaseOrderDetail.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict);


            // PurchaseOrderDetail -> Item
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(purchaseOrderDetail => purchaseOrderDetail.Item)
                .WithMany()
                .HasForeignKey(purchaseOrderDetail => purchaseOrderDetail.ItemId)
                .OnDelete(DeleteBehavior.Restrict);


            // PurchaseOrderDetail -> QuotationDetail
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(purchaseOrderDetail => purchaseOrderDetail.QuotationDetail)
                .WithMany()
                .HasForeignKey(purchaseOrderDetail => purchaseOrderDetail.QuotationDetailId)
                .OnDelete(DeleteBehavior.Restrict);


            // PurchaseOrderRequisitionDetail -> PurchaseOrderDetail
            modelBuilder.Entity<PurchaseOrderRequisitionDetail>()
                .HasOne(orderRequisitionDetail => orderRequisitionDetail.PurchaseOrderDetail)
                .WithMany()
                .HasForeignKey(orderRequisitionDetail => orderRequisitionDetail.PODetailId)
                .OnDelete(DeleteBehavior.Restrict);


            // PurchaseOrderRequisitionDetail -> PurchaseRequisitionDetail
            modelBuilder.Entity<PurchaseOrderRequisitionDetail>()
                .HasOne(orderRequisitionDetail => orderRequisitionDetail.PurchaseRequisitionDetail)
                .WithMany()
                .HasForeignKey(orderRequisitionDetail => orderRequisitionDetail.PRDetailId)
                .OnDelete(DeleteBehavior.Restrict);


            // =====================================
            // Phase 4: Goods Receipt
            // =====================================

            // GoodsReceipt -> PurchaseOrder
            modelBuilder.Entity<GoodsReceipt>()
                .HasOne(goodsReceipt => goodsReceipt.PurchaseOrder)
                .WithMany()
                .HasForeignKey(goodsReceipt => goodsReceipt.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict);


            // GoodsReceipt -> Received By User
            modelBuilder.Entity<GoodsReceipt>()
                .HasOne(goodsReceipt => goodsReceipt.User)
                .WithMany()
                .HasForeignKey(goodsReceipt => goodsReceipt.ReceivedBy)
                .OnDelete(DeleteBehavior.Restrict);


            // GoodsReceiptDetail -> GoodsReceipt
            modelBuilder.Entity<GoodsReceiptDetail>()
                .HasOne(goodsReceiptDetail => goodsReceiptDetail.GoodsReceipt)
                .WithMany()
                .HasForeignKey(goodsReceiptDetail => goodsReceiptDetail.GoodsReceiptId)
                .OnDelete(DeleteBehavior.Restrict);


            // GoodsReceiptDetail -> PurchaseOrderDetail
            modelBuilder.Entity<GoodsReceiptDetail>()
                .HasOne(goodsReceiptDetail => goodsReceiptDetail.PurchaseOrderDetail)
                .WithMany()
                .HasForeignKey(goodsReceiptDetail => goodsReceiptDetail.PODetailId)
                .OnDelete(DeleteBehavior.Restrict);

            // =====================================
            // Phase 5: Supplier Invoice
            // =====================================

            // SupplierInvoice -> Supplier
            modelBuilder.Entity<SupplierInvoice>()
                .HasOne(supplierInvoice => supplierInvoice.Supplier)
                .WithMany()
                .HasForeignKey(supplierInvoice => supplierInvoice.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);


            // SupplierInvoiceDetail -> SupplierInvoice
            modelBuilder.Entity<SupplierInvoiceDetail>()
                .HasOne(invoiceDetail => invoiceDetail.SupplierInvoice)
                .WithMany()
                .HasForeignKey(invoiceDetail => invoiceDetail.SupplierInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);


            // SupplierInvoiceDetail -> PurchaseOrderDetail
            modelBuilder.Entity<SupplierInvoiceDetail>()
                .HasOne(invoiceDetail => invoiceDetail.PurchaseOrderDetail)
                .WithMany()
                .HasForeignKey(invoiceDetail => invoiceDetail.PODetailId)
                .OnDelete(DeleteBehavior.Restrict);


            // InvoiceReceiptMatch -> SupplierInvoiceDetail
            modelBuilder.Entity<InvoiceReceiptMatch>()
                .HasOne(invoiceReceiptMatch => invoiceReceiptMatch.SupplierInvoiceDetail)
                .WithMany()
                .HasForeignKey(invoiceReceiptMatch => invoiceReceiptMatch.InvoiceDetailId)
                .OnDelete(DeleteBehavior.Restrict);


            // InvoiceReceiptMatch -> GoodsReceiptDetail
            modelBuilder.Entity<InvoiceReceiptMatch>()
                .HasOne(invoiceReceiptMatch => invoiceReceiptMatch.GoodsReceiptDetail)
                .WithMany()
                .HasForeignKey(invoiceReceiptMatch => invoiceReceiptMatch.GRNDetailId)
                .OnDelete(DeleteBehavior.Restrict);


            // =====================================
            // Phase 18: AI Model Configuration
            // =====================================

            // AIModelConfiguration Primary Key
            modelBuilder.Entity<AIModelConfiguration>()
                .HasKey(configuration => configuration.ConfigurationId);


            // ForecastRun Primary Key
            modelBuilder.Entity<ForecastRun>()
                .HasKey(forecastRun => forecastRun.ForecastRunId);


            // ForecastRun -> AIModelConfiguration
            modelBuilder.Entity<ForecastRun>()
                .HasOne(forecastRun => forecastRun.AIModelConfiguration)
                .WithMany()
                .HasForeignKey(forecastRun => forecastRun.ConfigurationId)
                .OnDelete(DeleteBehavior.Restrict);

            // =====================================
            // Phase 19: Demand Forecast
            // =====================================

            // DemandForecast Primary Key
            modelBuilder.Entity<DemandForecast>()
                .HasKey(demandForecast => demandForecast.ForecastId);


            // DemandForecast -> ForecastRun
            modelBuilder.Entity<DemandForecast>()
                .HasOne(demandForecast => demandForecast.ForecastRun)
                .WithMany(forecastRun => forecastRun.DemandForecasts)
                .HasForeignKey(demandForecast => demandForecast.ForecastRunId)
                .OnDelete(DeleteBehavior.Restrict);


            // DemandForecast -> Item
            modelBuilder.Entity<DemandForecast>()
                .HasOne(demandForecast => demandForecast.Item)
                .WithMany()
                .HasForeignKey(demandForecast => demandForecast.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // =====================================
            // Phase 20: Reorder Recommendation
            // =====================================

            // ReorderRecommendation Primary Key
            modelBuilder.Entity<ReorderRecommendation>()
                .HasKey(recommendation => recommendation.RecommendationId);


            // ReorderRecommendation -> Item
            modelBuilder.Entity<ReorderRecommendation>()
                .HasOne(recommendation => recommendation.Item)
                .WithMany()
                .HasForeignKey(recommendation => recommendation.ItemId)
                .OnDelete(DeleteBehavior.Restrict);


            // ReorderRecommendation -> DemandForecast
            modelBuilder.Entity<ReorderRecommendation>()
                .HasOne(recommendation => recommendation.DemandForecast)
                .WithMany(demandForecast => demandForecast.ReorderRecommendations)
                .HasForeignKey(recommendation => recommendation.ForecastId)
                .OnDelete(DeleteBehavior.Restrict);


            // ReorderRecommendation -> Warehouse
            modelBuilder.Entity<ReorderRecommendation>()
                .HasOne(recommendation => recommendation.Warehouse)
                .WithMany()
                .HasForeignKey(recommendation => recommendation.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);


            // =====================================
            // Phase 21: Model Evaluation
            // =====================================

            // ModelEvaluation Primary Key
            modelBuilder.Entity<ModelEvaluation>()
                .HasKey(evaluation => evaluation.EvaluationId);


            // ModelEvaluation -> ForecastRun
            modelBuilder.Entity<ModelEvaluation>()
                .HasOne(evaluation => evaluation.ForecastRun)
                .WithMany(forecastRun => forecastRun.ModelEvaluations)
                .HasForeignKey(evaluation => evaluation.ForecastRunId)
                .OnDelete(DeleteBehavior.Restrict);


            // =====================================
            // Phase 22: Anomaly Detection
            // =====================================

            // AnomalyDetection Primary Key
            modelBuilder.Entity<AnomalyDetection>()
                .HasKey(anomaly => anomaly.AnomalyId);


            // AnomalyDetection -> Item
            modelBuilder.Entity<AnomalyDetection>()
                .HasOne(anomaly => anomaly.Item)
                .WithMany()
                .HasForeignKey(anomaly => anomaly.ItemId)
                .OnDelete(DeleteBehavior.Restrict);


            // AnomalyDetection -> Warehouse
            modelBuilder.Entity<AnomalyDetection>()
                .HasOne(anomaly => anomaly.Warehouse)
                .WithMany()
                .HasForeignKey(anomaly => anomaly.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);


            // AnomalyDetection -> InventoryLedger
            modelBuilder.Entity<AnomalyDetection>()
                .HasOne(anomaly => anomaly.InventoryLedger)
                .WithMany()
                .HasForeignKey(anomaly => anomaly.LedgerId)
                .OnDelete(DeleteBehavior.Restrict);

            // =====================================
            // Phase 23: AI Assistant
            // =====================================

            // AssistantConversation Primary Key
            modelBuilder.Entity<AssistantConversation>()
                .HasKey(conversation => conversation.ConversationId);


            // AssistantMessage Primary Key
            modelBuilder.Entity<AssistantMessage>()
                .HasKey(message => message.MessageId);


            // AssistantConversation -> User
            modelBuilder.Entity<AssistantConversation>()
                .HasOne(conversation => conversation.User)
                .WithMany()
                .HasForeignKey(conversation => conversation.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            // AssistantMessage -> AssistantConversation
            modelBuilder.Entity<AssistantMessage>()
                .HasOne(message => message.AssistantConversation)
                .WithMany(conversation => conversation.AssistantMessages)
                .HasForeignKey(message => message.ConversationId)
                .OnDelete(DeleteBehavior.Restrict);



    //        modelBuilder.Entity<Permission>()
    //.HasOne(permission => permission.ParentPermission)
    //.WithMany(permission => permission.ChildPermissions)
    //.HasForeignKey(permission => permission.ParentId)
    //.OnDelete(DeleteBehavior.Restrict);




        }

    }
}
