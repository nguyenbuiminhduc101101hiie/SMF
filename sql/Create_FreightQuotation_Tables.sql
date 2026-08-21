-- =============================================================================
-- Freight Quotation Sea-Air (FCL/LCL/AIR - FOB/EXW)
-- Chay script nay tren database SMF TRUOC KHI dung form Import Freight Quotation.
-- File Excel mau: FREIGHT QUOTATION SEA-AIR-T5-2026-FWD
-- Sheets: FCL-FOB, FCL-EXW, LCL-FOB, LCL-EXW, AIR-FOB, AIR-EXW
-- =============================================================================

IF OBJECT_ID(N'dbo.FreightQuotation_AIREXW', N'U') IS NULL
    PRINT 'Creating Freight Quotation tables...'
GO

IF OBJECT_ID(N'dbo.FreightQuotationBatch', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.FreightQuotationBatch (
        BatchId         UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_FreightQuotationBatch PRIMARY KEY,
        QuotationName   NVARCHAR(200)    NULL,
        FileName        NVARCHAR(500)    NULL,
        FilePath        NVARCHAR(1000)   NULL,
        ValidMonth      NVARCHAR(50)     NULL,
        UserCreate      NVARCHAR(50)     NULL,
        CreatedDate     DATETIME         NOT NULL CONSTRAINT DF_FQBatch_CreatedDate DEFAULT (GETDATE()),
        RowCountTotal   INT              NULL,
        Remark          NVARCHAR(500)    NULL,
        Continued       BIT              NOT NULL CONSTRAINT DF_FQBatch_Continued DEFAULT (1)
    )
END
GO

-- -----------------------------------------------------------------------------
-- 1) FCL-FOB  (data tu dong 5, header dong 3)
-- -----------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.FreightQuotation_FCLFOB', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.FreightQuotation_FCLFOB (
        Id              UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_FQ_FCLFOB PRIMARY KEY,
        BatchId         UNIQUEIDENTIFIER NOT NULL,
        ExcelRow        INT              NULL,
        Agent           NVARCHAR(50)     NULL,
        Carrier         NVARCHAR(50)     NULL,
        CutOff          NVARCHAR(100)    NULL,
        Frequency       NVARCHAR(100)    NULL,
        TransitTime     NVARCHAR(100)    NULL,
        PolCode         NVARCHAR(20)     NULL,
        PolName         NVARCHAR(100)    NULL,
        Pod             NVARCHAR(20)     NULL,
        ContType        NVARCHAR(20)     NULL,
        Term            NVARCHAR(20)     NULL,
        Currency        NVARCHAR(10)     NULL,
        BuyTotal        DECIMAL(18,4)    NULL,
        BuyOF           DECIMAL(18,4)    NULL,
        BuyLccPod       DECIMAL(18,4)    NULL,
        BuyOF2          DECIMAL(18,4)    NULL,
        BuyOldT4        DECIMAL(18,4)    NULL,
        BuyTG           DECIMAL(18,4)    NULL,
        BuyLSS          DECIMAL(18,4)    NULL,
        BuyDTHC         DECIMAL(18,4)    NULL,
        BuyDCIC         DECIMAL(18,4)    NULL,
        BuyCleaningFee  DECIMAL(18,4)    NULL,
        BuyDOFee        DECIMAL(18,4)    NULL,
        AppliedMonth    NVARCHAR(50)     NULL,
        ValidRate       NVARCHAR(50)     NULL,
        BuyRemark       NVARCHAR(500)    NULL,
        SellTotal       DECIMAL(18,4)    NULL,
        SellOF          DECIMAL(18,4)    NULL,
        SellTHC         DECIMAL(18,4)    NULL,
        SellCFS         DECIMAL(18,4)    NULL,
        SellCIC         DECIMAL(18,4)    NULL,
        SellCleaningFee DECIMAL(18,4)    NULL,
        SellUnloading   DECIMAL(18,4)    NULL,
        SellHandling    DECIMAL(18,4)    NULL,
        SellDocFee      DECIMAL(18,4)    NULL,
        PNL             DECIMAL(18,4)    NULL,
        SellRemark      NVARCHAR(500)    NULL,
        Continued       BIT              NOT NULL CONSTRAINT DF_FQ_FCLFOB_Continued DEFAULT (1),
        CONSTRAINT FK_FQ_FCLFOB_Batch FOREIGN KEY (BatchId) REFERENCES dbo.FreightQuotationBatch(BatchId)
    )
    CREATE INDEX IX_FQ_FCLFOB_Batch ON dbo.FreightQuotation_FCLFOB(BatchId)
    CREATE INDEX IX_FQ_FCLFOB_Route ON dbo.FreightQuotation_FCLFOB(PolCode, Pod, ContType)
END
GO

-- -----------------------------------------------------------------------------
-- 2) FCL-EXW  (data tu dong 6, header dong 5)
-- -----------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.FreightQuotation_FCLEXW', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.FreightQuotation_FCLEXW (
        Id                  UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_FQ_FCLEXW PRIMARY KEY,
        BatchId             UNIQUEIDENTIFIER NOT NULL,
        ExcelRow            INT              NULL,
        Agent               NVARCHAR(50)     NULL,
        Shipp               NVARCHAR(50)     NULL,
        Carrier             NVARCHAR(50)     NULL,
        CutOff              NVARCHAR(100)    NULL,
        Frequency           NVARCHAR(100)    NULL,
        TransitTime         NVARCHAR(100)    NULL,
        Country             NVARCHAR(50)     NULL,
        Town                NVARCHAR(100)    NULL,
        City                NVARCHAR(100)    NULL,
        Province            NVARCHAR(100)    NULL,
        PickupPlace         NVARCHAR(500)    NULL,
        GateIn              NVARCHAR(200)    NULL,
        PolCode             NVARCHAR(20)     NULL,
        PolName             NVARCHAR(100)    NULL,
        Pod                 NVARCHAR(20)     NULL,
        ContType            NVARCHAR(20)     NULL,
        Term                NVARCHAR(20)     NULL,
        Currency            NVARCHAR(10)     NULL,
        BuyTotal            DECIMAL(18,4)    NULL,
        BuyTrucking         DECIMAL(18,4)    NULL,
        BuyOF               DECIMAL(18,4)    NULL,
        BuyTotalPol         DECIMAL(18,4)    NULL,
        BuyLTHC             DECIMAL(18,4)    NULL,
        BuySeal             DECIMAL(18,4)    NULL,
        BuyVGM              DECIMAL(18,4)    NULL,
        BuyEIR              DECIMAL(18,4)    NULL,
        BuyPortCharge       DECIMAL(18,4)    NULL,
        BuyBookingFee       DECIMAL(18,4)    NULL,
        BuyWGateCharge      DECIMAL(18,4)    NULL,
        BuyStuffing         DECIMAL(18,4)    NULL,
        BuyBL               DECIMAL(18,4)    NULL,
        BuyTelexRelease     DECIMAL(18,4)    NULL,
        BuyExportLicense    DECIMAL(18,4)    NULL,
        BuyCustoms          DECIMAL(18,4)    NULL,
        BuyOtherCharge      DECIMAL(18,4)    NULL,
        BuyASM              DECIMAL(18,4)    NULL,
        BuyExwCharge        DECIMAL(18,4)    NULL,
        AppliedMonth        NVARCHAR(50)     NULL,
        ValidRate           NVARCHAR(50)     NULL,
        BuyRemark           NVARCHAR(500)    NULL,
        BuyTotalPod         DECIMAL(18,4)    NULL,
        BuyDTHC             DECIMAL(18,4)    NULL,
        BuyDCIC             DECIMAL(18,4)    NULL,
        BuyCleaningFee      DECIMAL(18,4)    NULL,
        BuyDOFee            DECIMAL(18,4)    NULL,
        SellTotal           DECIMAL(18,4)    NULL,
        SellHaulage         DECIMAL(18,4)    NULL,
        SellTrucking        DECIMAL(18,4)    NULL,
        SellTHC             DECIMAL(18,4)    NULL,
        SellBL              DECIMAL(18,4)    NULL,
        SellCustoms         DECIMAL(18,4)    NULL,
        SellStuffing        DECIMAL(18,4)    NULL,
        SellExportLicense   DECIMAL(18,4)    NULL,
        SellTLX             DECIMAL(18,4)    NULL,
        SellVGM             DECIMAL(18,4)    NULL,
        SellPortCharge      DECIMAL(18,4)    NULL,
        SellGageCharge      DECIMAL(18,4)    NULL,
        SellSeal            DECIMAL(18,4)    NULL,
        SellBooking         DECIMAL(18,4)    NULL,
        SellOF              DECIMAL(18,4)    NULL,
        SellTHC2            DECIMAL(18,4)    NULL,
        SellCIC             DECIMAL(18,4)    NULL,
        SellCleaningFee     DECIMAL(18,4)    NULL,
        SellUnloading       DECIMAL(18,4)    NULL,
        SellHandling        DECIMAL(18,4)    NULL,
        SellDocFee          DECIMAL(18,4)    NULL,
        PNL                 DECIMAL(18,4)    NULL,
        SellRemark          NVARCHAR(500)    NULL,
        Continued           BIT              NOT NULL CONSTRAINT DF_FQ_FCLEXW_Continued DEFAULT (1),
        CONSTRAINT FK_FQ_FCLEXW_Batch FOREIGN KEY (BatchId) REFERENCES dbo.FreightQuotationBatch(BatchId)
    )
    CREATE INDEX IX_FQ_FCLEXW_Batch ON dbo.FreightQuotation_FCLEXW(BatchId)
    CREATE INDEX IX_FQ_FCLEXW_Route ON dbo.FreightQuotation_FCLEXW(PolCode, Pod, ContType, Shipp)
END
GO

-- -----------------------------------------------------------------------------
-- 3) LCL-FOB  (data tu dong 6, header dong 3-5)
-- -----------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.FreightQuotation_LCLFOB', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.FreightQuotation_LCLFOB (
        Id                  UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_FQ_LCLFOB PRIMARY KEY,
        BatchId             UNIQUEIDENTIFIER NOT NULL,
        ExcelRow            INT              NULL,
        Agent               NVARCHAR(50)     NULL,
        ShippingLine        NVARCHAR(50)     NULL,
        CutOffDoc           NVARCHAR(100)    NULL,
        CutOffCargo         NVARCHAR(100)    NULL,
        Frequency           NVARCHAR(100)    NULL,
        TransitTime         NVARCHAR(100)    NULL,
        PolCode             NVARCHAR(20)     NULL,
        PolName             NVARCHAR(100)    NULL,
        Pod                 NVARCHAR(20)     NULL,
        CargoType           NVARCHAR(20)     NULL,
        Term                NVARCHAR(20)     NULL,
        Currency            NVARCHAR(10)     NULL,
        LevelLimitVolume    NVARCHAR(50)     NULL,
        Qty                 DECIMAL(18,4)    NULL,
        BuyTotalPod         DECIMAL(18,4)    NULL,
        BuyTotalOF          DECIMAL(18,4)    NULL,
        BuyLccPod           DECIMAL(18,4)    NULL,
        BuyOF               DECIMAL(18,4)    NULL,
        BuyPSSRR            DECIMAL(18,4)    NULL,
        BuyLSS              DECIMAL(18,4)    NULL,
        BuyDTHC             DECIMAL(18,4)    NULL,
        BuyDCIC             DECIMAL(18,4)    NULL,
        BuyCFS              DECIMAL(18,4)    NULL,
        BuyDOFee            DECIMAL(18,4)    NULL,
        AppliedMonth        NVARCHAR(50)     NULL,
        ValidRate           NVARCHAR(50)     NULL,
        BuyRemark           NVARCHAR(500)    NULL,
        QtyLimit            DECIMAL(18,4)    NULL,
        BuyDetailTotalPod   DECIMAL(18,4)    NULL,
        BuyDetailTotalOF    DECIMAL(18,4)    NULL,
        BuyDetailLccPod     DECIMAL(18,4)    NULL,
        BuyDetailOF         DECIMAL(18,4)    NULL,
        BuyDetailPSSRR      DECIMAL(18,4)    NULL,
        BuyDetailLSS        DECIMAL(18,4)    NULL,
        BuyDetailDTHC       DECIMAL(18,4)    NULL,
        BuyDetailDCIC       DECIMAL(18,4)    NULL,
        BuyDetailCFS        DECIMAL(18,4)    NULL,
        BuyDetailDOFee      DECIMAL(18,4)    NULL,
        SellTotal           DECIMAL(18,4)    NULL,
        SellOF              DECIMAL(18,4)    NULL,
        SellTHC             DECIMAL(18,4)    NULL,
        SellCFS             DECIMAL(18,4)    NULL,
        SellCIC             DECIMAL(18,4)    NULL,
        SellCleaning        DECIMAL(18,4)    NULL,
        SellUnloading       DECIMAL(18,4)    NULL,
        SellHandling        DECIMAL(18,4)    NULL,
        SellDO              DECIMAL(18,4)    NULL,
        PNL                 DECIMAL(18,4)    NULL,
        Continued           BIT              NOT NULL CONSTRAINT DF_FQ_LCLFOB_Continued DEFAULT (1),
        CONSTRAINT FK_FQ_LCLFOB_Batch FOREIGN KEY (BatchId) REFERENCES dbo.FreightQuotationBatch(BatchId)
    )
    CREATE INDEX IX_FQ_LCLFOB_Batch ON dbo.FreightQuotation_LCLFOB(BatchId)
    CREATE INDEX IX_FQ_LCLFOB_Route ON dbo.FreightQuotation_LCLFOB(PolCode, Pod, LevelLimitVolume)
END
GO

-- -----------------------------------------------------------------------------
-- 4) LCL-EXW  (data tu dong 6, header dong 5)
-- -----------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.FreightQuotation_LCLEXW', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.FreightQuotation_LCLEXW (
        Id                      UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_FQ_LCLEXW PRIMARY KEY,
        BatchId                 UNIQUEIDENTIFIER NOT NULL,
        ExcelRow                INT              NULL,
        Agent                   NVARCHAR(50)     NULL,
        Shipp                   NVARCHAR(50)     NULL,
        Country                 NVARCHAR(50)     NULL,
        Town                    NVARCHAR(100)    NULL,
        City                    NVARCHAR(100)    NULL,
        Province                NVARCHAR(100)    NULL,
        PickupPlace             NVARCHAR(500)    NULL,
        GateIn                  NVARCHAR(200)    NULL,
        CutOffCargo             NVARCHAR(100)    NULL,
        Frequency               NVARCHAR(100)    NULL,
        TransitTime             NVARCHAR(100)    NULL,
        PolCode                 NVARCHAR(20)     NULL,
        PolName                 NVARCHAR(100)    NULL,
        Pod                     NVARCHAR(20)     NULL,
        CargoType               NVARCHAR(20)     NULL,
        Term                    NVARCHAR(20)     NULL,
        LevelLimitVolume        NVARCHAR(50)     NULL,
        Currency                NVARCHAR(10)     NULL,
        BuyTrucking1T           DECIMAL(18,4)    NULL,
        BuyTrucking3T           DECIMAL(18,4)    NULL,
        BuyTrucking5T           DECIMAL(18,4)    NULL,
        BuyTrucking8T           DECIMAL(18,4)    NULL,
        BuyTrucking10T          DECIMAL(18,4)    NULL,
        BuyTotal                DECIMAL(18,4)    NULL,
        BuyOF                   DECIMAL(18,4)    NULL,
        BuyTotalPol             DECIMAL(18,4)    NULL,
        BuyLTHC                 DECIMAL(18,4)    NULL,
        BuyLCFS                 DECIMAL(18,4)    NULL,
        BuyVGM                  DECIMAL(18,4)    NULL,
        BuyPortCharge           DECIMAL(18,4)    NULL,
        BuyBookingFee           DECIMAL(18,4)    NULL,
        BuyBL                   DECIMAL(18,4)    NULL,
        BuyExportLicense        DECIMAL(18,4)    NULL,
        BuyCustoms              DECIMAL(18,4)    NULL,
        BuyGateCharge           DECIMAL(18,4)    NULL,
        BuyWGateCharge          DECIMAL(18,4)    NULL,
        BuyWharfageDrayage      DECIMAL(18,4)    NULL,
        BuyStuffing             DECIMAL(18,4)    NULL,
        AppliedMonth            NVARCHAR(50)     NULL,
        ValidRate               NVARCHAR(50)     NULL,
        BuyRemark               NVARCHAR(500)    NULL,
        BuyTotalPod             DECIMAL(18,4)    NULL,
        BuyLSS                  DECIMAL(18,4)    NULL,
        BuyDTHC                 DECIMAL(18,4)    NULL,
        BuyDCIC                 DECIMAL(18,4)    NULL,
        BuyCFS                  DECIMAL(18,4)    NULL,
        BuyDOFee                DECIMAL(18,4)    NULL,
        SellLevel               NVARCHAR(50)     NULL,
        SellQty                 DECIMAL(18,4)    NULL,
        SellTotal               DECIMAL(18,4)    NULL,
        SellTruckingTemp        DECIMAL(18,4)    NULL,
        SellTruck1T             DECIMAL(18,4)    NULL,
        SellTruck3T             DECIMAL(18,4)    NULL,
        SellTruck5T             DECIMAL(18,4)    NULL,
        SellTruck8T             DECIMAL(18,4)    NULL,
        SellTotalPol            DECIMAL(18,4)    NULL,
        SellBL                  DECIMAL(18,4)    NULL,
        SellCFS                 DECIMAL(18,4)    NULL,
        SellTHC                 DECIMAL(18,4)    NULL,
        SellEbsCic              DECIMAL(18,4)    NULL,
        SellStuffing            DECIMAL(18,4)    NULL,
        SellCustoms             DECIMAL(18,4)    NULL,
        SellGateCharge          DECIMAL(18,4)    NULL,
        SellWGateCharge         DECIMAL(18,4)    NULL,
        SellVGM                 DECIMAL(18,4)    NULL,
        SellExportLicense       DECIMAL(18,4)    NULL,
        SellBookingFee          DECIMAL(18,4)    NULL,
        SellPortCharge          DECIMAL(18,4)    NULL,
        SellOceanFreight        DECIMAL(18,4)    NULL,
        SellTotalPod            DECIMAL(18,4)    NULL,
        SellTHCPod              DECIMAL(18,4)    NULL,
        SellCFSPod              DECIMAL(18,4)    NULL,
        SellCIC                 DECIMAL(18,4)    NULL,
        SellCleaning            DECIMAL(18,4)    NULL,
        SellUnloading           DECIMAL(18,4)    NULL,
        SellHandling            DECIMAL(18,4)    NULL,
        SellDO                  DECIMAL(18,4)    NULL,
        PNL                     DECIMAL(18,4)    NULL,
        SellRemark              NVARCHAR(500)    NULL,
        Continued               BIT              NOT NULL CONSTRAINT DF_FQ_LCLEXW_Continued DEFAULT (1),
        CONSTRAINT FK_FQ_LCLEXW_Batch FOREIGN KEY (BatchId) REFERENCES dbo.FreightQuotationBatch(BatchId)
    )
    CREATE INDEX IX_FQ_LCLEXW_Batch ON dbo.FreightQuotation_LCLEXW(BatchId)
    CREATE INDEX IX_FQ_LCLEXW_Route ON dbo.FreightQuotation_LCLEXW(PolCode, Pod, Shipp, LevelLimitVolume)
END
GO

-- -----------------------------------------------------------------------------
-- 5) AIR-FOB  (data tu dong 6, header dong 5)
-- -----------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.FreightQuotation_AIRFOB', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.FreightQuotation_AIRFOB (
        Id              UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_FQ_AIRFOB PRIMARY KEY,
        BatchId         UNIQUEIDENTIFIER NOT NULL,
        ExcelRow        INT              NULL,
        CompanyName     NVARCHAR(100)    NULL,
        Origin          NVARCHAR(20)     NULL,
        Dest            NVARCHAR(20)     NULL,
        Term            NVARCHAR(20)     NULL,
        Agent           NVARCHAR(50)     NULL,
        Airline         NVARCHAR(100)    NULL,
        Currency        NVARCHAR(10)     NULL,
        Qty             DECIMAL(18,4)    NULL,
        BuyPlus45       DECIMAL(18,4)    NULL,
        BuyPlus100      DECIMAL(18,4)    NULL,
        BuyPlus300      DECIMAL(18,4)    NULL,
        BuyPlus500      DECIMAL(18,4)    NULL,
        BuyPlus1000     DECIMAL(18,4)    NULL,
        BuyFSC          DECIMAL(18,4)    NULL,
        BuySSC          DECIMAL(18,4)    NULL,
        BuyLocalDest    DECIMAL(18,4)    NULL,
        BuyAwbCgFee     DECIMAL(18,4)    NULL,
        Route           NVARCHAR(100)    NULL,
        Frequency       NVARCHAR(100)    NULL,
        TransitTime     NVARCHAR(100)    NULL,
        ValidRate       NVARCHAR(50)     NULL,
        BuyRemark       NVARCHAR(500)    NULL,
        BuyDO           DECIMAL(18,4)    NULL,
        SellPlus45      DECIMAL(18,4)    NULL,
        SellPlus100     DECIMAL(18,4)    NULL,
        SellPlus300     DECIMAL(18,4)    NULL,
        SellPlus500     DECIMAL(18,4)    NULL,
        SellPlus1000    DECIMAL(18,4)    NULL,
        SellDO          DECIMAL(18,4)    NULL,
        Pnl45           DECIMAL(18,4)    NULL,
        Pnl100          DECIMAL(18,4)    NULL,
        Pnl300          DECIMAL(18,4)    NULL,
        Pnl500          DECIMAL(18,4)    NULL,
        Pnl1000         DECIMAL(18,4)    NULL,
        SellRemark      NVARCHAR(500)    NULL,
        Continued       BIT              NOT NULL CONSTRAINT DF_FQ_AIRFOB_Continued DEFAULT (1),
        CONSTRAINT FK_FQ_AIRFOB_Batch FOREIGN KEY (BatchId) REFERENCES dbo.FreightQuotationBatch(BatchId)
    )
    CREATE INDEX IX_FQ_AIRFOB_Batch ON dbo.FreightQuotation_AIRFOB(BatchId)
    CREATE INDEX IX_FQ_AIRFOB_Route ON dbo.FreightQuotation_AIRFOB(Origin, Dest, Airline)
END
GO

-- -----------------------------------------------------------------------------
-- 6) AIR-EXW  (data tu dong 6, header dong 4-5)
-- -----------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.FreightQuotation_AIREXW', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.FreightQuotation_AIREXW (
        Id                  UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_FQ_AIREXW PRIMARY KEY,
        BatchId             UNIQUEIDENTIFIER NOT NULL,
        ExcelRow            INT              NULL,
        CompanyName         NVARCHAR(100)    NULL,
        Shipp               NVARCHAR(50)     NULL,
        Country             NVARCHAR(50)     NULL,
        Town                NVARCHAR(100)    NULL,
        City                NVARCHAR(100)    NULL,
        Province            NVARCHAR(100)    NULL,
        PickupPlace         NVARCHAR(500)    NULL,
        GateIn              NVARCHAR(200)    NULL,
        Airline             NVARCHAR(100)    NULL,
        PolCode             NVARCHAR(20)     NULL,
        PolName             NVARCHAR(100)    NULL,
        CargoType           NVARCHAR(20)     NULL,
        Term                NVARCHAR(20)     NULL,
        Currency            NVARCHAR(10)     NULL,
        Quantity            DECIMAL(18,4)    NULL,
        BuyTruck1Ton        DECIMAL(18,4)    NULL,
        BuyThcMin           DECIMAL(18,4)    NULL,
        BuyTHC              DECIMAL(18,4)    NULL,
        BuyCfsMin           DECIMAL(18,4)    NULL,
        BuyCFS              DECIMAL(18,4)    NULL,
        BuyXRay             DECIMAL(18,4)    NULL,
        BuyExportLicense    DECIMAL(18,4)    NULL,
        BuyCustoms          DECIMAL(18,4)    NULL,
        BuyBillFee          DECIMAL(18,4)    NULL,
        BuyTollFee          DECIMAL(18,4)    NULL,
        BuyENS              DECIMAL(18,4)    NULL,
        BuyGateCharge       DECIMAL(18,4)    NULL,
        BuyWGateCharge      DECIMAL(18,4)    NULL,
        BuyHC               DECIMAL(18,4)    NULL,
        BuyExwCharge        DECIMAL(18,4)    NULL,
        ValidRate           NVARCHAR(50)     NULL,
        BuyRemark           NVARCHAR(500)    NULL,
        BuyAf45             DECIMAL(18,4)    NULL,
        BuyAf100            DECIMAL(18,4)    NULL,
        BuyAf300            DECIMAL(18,4)    NULL,
        BuyAf500            DECIMAL(18,4)    NULL,
        BuyAf1000           DECIMAL(18,4)    NULL,
        BuyDO               DECIMAL(18,4)    NULL,
        SellTruckMin        DECIMAL(18,4)    NULL,
        SellTruckRate       DECIMAL(18,4)    NULL,
        SellThcMin          DECIMAL(18,4)    NULL,
        SellThcKg           DECIMAL(18,4)    NULL,
        SellCfsMin          DECIMAL(18,4)    NULL,
        SellCfsKg           DECIMAL(18,4)    NULL,
        SellCustoms         DECIMAL(18,4)    NULL,
        SellBL              DECIMAL(18,4)    NULL,
        SellAMS             DECIMAL(18,4)    NULL,
        SellExportLicense   DECIMAL(18,4)    NULL,
        SellDocSurcharge    DECIMAL(18,4)    NULL,
        SellTollFee         DECIMAL(18,4)    NULL,
        SellGateCharge      DECIMAL(18,4)    NULL,
        SellWGateCharge     DECIMAL(18,4)    NULL,
        SellAf45            DECIMAL(18,4)    NULL,
        SellAf100           DECIMAL(18,4)    NULL,
        SellAf300           DECIMAL(18,4)    NULL,
        SellAf500           DECIMAL(18,4)    NULL,
        SellAf1000          DECIMAL(18,4)    NULL,
        SellDO              DECIMAL(18,4)    NULL,
        BuyDetail45         DECIMAL(18,4)    NULL,
        BuyDetail100        DECIMAL(18,4)    NULL,
        BuyDetail300        DECIMAL(18,4)    NULL,
        SellDetail45        DECIMAL(18,4)    NULL,
        SellDetail100       DECIMAL(18,4)    NULL,
        SellDetail300       DECIMAL(18,4)    NULL,
        Pnl45               DECIMAL(18,4)    NULL,
        Pnl100              DECIMAL(18,4)    NULL,
        Pnl300              DECIMAL(18,4)    NULL,
        Continued           BIT              NOT NULL CONSTRAINT DF_FQ_AIREXW_Continued DEFAULT (1),
        CONSTRAINT FK_FQ_AIREXW_Batch FOREIGN KEY (BatchId) REFERENCES dbo.FreightQuotationBatch(BatchId)
    )
    CREATE INDEX IX_FQ_AIREXW_Batch ON dbo.FreightQuotation_AIREXW(BatchId)
    CREATE INDEX IX_FQ_AIREXW_Route ON dbo.FreightQuotation_AIREXW(PolCode, Shipp, Airline)
END
GO

PRINT 'Done. Tables:'
PRINT '  FreightQuotationBatch'
PRINT '  FreightQuotation_FCLFOB'
PRINT '  FreightQuotation_FCLEXW'
PRINT '  FreightQuotation_LCLFOB'
PRINT '  FreightQuotation_LCLEXW'
PRINT '  FreightQuotation_AIRFOB'
PRINT '  FreightQuotation_AIREXW'
GO
