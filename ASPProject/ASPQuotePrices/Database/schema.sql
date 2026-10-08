-- =====================================================================
-- DATABASE CONFIGURATION & DDL FOR MS SQL SERVER (LINK Q INTEGRATION)
-- =====================================================================

-- 1. Create Table: ComponentsMaster
-- Represents the master list with all functions, sections, pricing, and PICs.
CREATE TABLE ComponentsMaster (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Revision NVARCHAR(50) NOT NULL,               -- e.g., A01
    Section NVARCHAR(50) NOT NULL,                -- e.g., ASM1
    SubSection NVARCHAR(50) NULL,                 -- e.g., SUB1
    QuotationDate DATE NULL,                      -- e.g., 2025-11-02
    EffectiveDate DATE NULL,                      -- e.g., 2026-01-01
    Customer NVARCHAR(100) NULL,                  -- e.g., GENERAC
    CustomerPN NVARCHAR(100) NULL,                -- Customer Part Number
    InternalPN NVARCHAR(100) NOT NULL,            -- e.g., A0006166735 or P011428_P
    GIL_PN_Ref NVARCHAR(100) NULL,                -- e.g., B018721
    Spec NVARCHAR(255) NULL,                      -- Specifications
    Manufacturer NVARCHAR(100) NULL,              -- e.g., MOLEX
    LeadTime DECIMAL(18,2) NULL DEFAULT 0.00,     -- GAP LT check (Weeks)
    TargetPrice DECIMAL(18,4) NULL DEFAULT 0.0000, -- Target BOM Unit Price
    PercentPricing DECIMAL(18,4) NULL DEFAULT 0.00,-- % pricing mark-up or change
    CostBOM DECIMAL(18,4) NULL DEFAULT 0.0000,     -- Cost BOM Price
    Vendor NVARCHAR(100) NULL,                    -- Supplier/Vendor (e.g., AVNET)
    POPrice DECIMAL(18,4) NULL DEFAULT 0.0000,    -- Purchase Order Price
    POQty DECIMAL(18,2) NULL DEFAULT 0.00,        -- Purchase Order Quantity
    PIC_Section NVARCHAR(100) NULL,               -- Person in Charge (PIC) of this Section
    Status NVARCHAR(50) NULL DEFAULT 'Active',    -- Row status
    CreatedBy NVARCHAR(100) NULL,                 -- Created by User
    CreatedDate DATETIME NULL DEFAULT GETDATE(),  -- Creation timestamp
    UpdatedDate DATETIME NULL                     -- Last update timestamp
);

-- Index for searching parts and sections quickly
CREATE INDEX IX_Components_InternalPN ON ComponentsMaster(InternalPN);
CREATE INDEX IX_Components_Section ON ComponentsMaster(Section);

-- 2. Create Table: UserPermissions
-- Manages Section Permission Assignment for Users/PICs
CREATE TABLE UserPermissions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    Section NVARCHAR(50) NOT NULL,
    HasRead BIT NOT NULL DEFAULT 1,
    HasWrite BIT NOT NULL DEFAULT 0,
    AssignedBy NVARCHAR(100) NULL,
    AssignedDate DATETIME NULL DEFAULT GETDATE(),
    CONSTRAINT UC_User_Section UNIQUE (Username, Section)
);

-- 3. Create Table: HistoryChanges
-- Tracks audits of modifications on any row or cell
CREATE TABLE HistoryChanges (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ComponentId INT NOT NULL,
    InternalPN NVARCHAR(100) NOT NULL,
    FieldName NVARCHAR(100) NOT NULL,
    OldValue NVARCHAR(MAX) NULL,
    NewValue NVARCHAR(MAX) NULL,
    ChangedBy NVARCHAR(100) NOT NULL,
    ChangedDate DATETIME NOT NULL DEFAULT GETDATE()
);

-- =====================================================================
-- SEED DATA (BASED ON THE ALIGNED QUOTATION DATA & TRIAL GIL PN)
-- =====================================================================

INSERT INTO ComponentsMaster 
(Revision, Section, SubSection, QuotationDate, EffectiveDate, Customer, CustomerPN, InternalPN, GIL_PN_Ref, Spec, Manufacturer, LeadTime, TargetPrice, PercentPricing, CostBOM, Vendor, POPrice, POQty, PIC_Section, CreatedBy, CreatedDate)
VALUES
('A01', 'ASM1', NULL, '2025-11-02', NULL, 'GENERAC', NULL, 'A0006166735', NULL, NULL, 'MOLEX', 22.00, 0.00, 0.00, 0.00, 'AVNET', 2500.00, 100000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2025-11-02', NULL, 'GENERAC', NULL, 'A0006166735', NULL, NULL, 'MOLEX', 22.00, 0.00, 0.00, 0.00, 'AVNET', 2500.00, 200000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2026-01-02', NULL, 'Generac', NULL, 'A0006166735', 'B018721', NULL, 'Molex', 22.00, 0.00, 0.00, 0.00, 'Arrow', 6000.00, 100000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2026-01-02', NULL, 'Generac', NULL, 'A0006166735', 'B018721', NULL, 'Molex', 22.00, 0.00, 0.00, 0.00, 'Arrow', 6000.00, 200000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2026-01-02', NULL, 'Generac', NULL, 'A0006166735', 'B018721', NULL, 'Molex', 22.00, 0.00, 0.00, 0.00, 'Arrow', 6000.00, 100000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2026-01-02', NULL, 'Generac', NULL, 'A0006166735', 'B018721', NULL, 'Molex', 22.00, 0.00, 0.00, 0.00, 'Arrow', 6000.00, 200000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2026-01-02', NULL, 'Generac', NULL, 'A0006166735', 'B018721', NULL, 'Molex', 22.00, 0.00, 0.00, 0.00, 'Arrow', 6000.00, 100000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2026-01-02', NULL, 'Generac', NULL, 'A0006166735', 'B018721', NULL, 'Molex', 22.00, 0.00, 0.00, 0.00, 'Arrow', 6000.00, 200000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2026-01-02', NULL, 'Generac', NULL, 'A0006166735', 'B018721', NULL, 'Molex', 22.00, 0.00, 0.00, 0.00, 'Arrow', 6000.00, 100000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2026-01-02', NULL, 'Generac', NULL, 'A0006166735', 'B018721', NULL, 'Molex', 22.00, 0.00, 0.00, 0.00, 'Arrow', 6000.00, 200000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2026-01-02', NULL, 'Generac', NULL, 'A0006166735', 'B018721', NULL, 'Molex', 22.00, 0.00, 0.00, 0.00, 'Arrow', 6000.00, 100000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2026-01-02', NULL, 'Generac', NULL, 'A0006166735', 'B018721', NULL, 'Molex', 22.00, 0.00, 0.00, 0.00, 'Arrow', 6000.00, 200000.00, 'James', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2025-06-01', NULL, 'GENERAC', NULL, 'A0007261935', NULL, NULL, 'MOLEX', 22.00, 0.00, 0.00, 0.00, 'WPG VN', 2000.00, 2000.00, 'Dang Anh', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2025-06-01', NULL, 'GENERAC', NULL, 'A0007261935', NULL, NULL, 'MOLEX', 22.00, 0.00, 0.00, 0.00, 'SANLI', 5500.00, 27500.00, 'Dang Anh', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2025-06-01', NULL, 'GENERAC', NULL, 'A0007261935', NULL, NULL, 'MOLEX', 22.00, 0.00, 0.00, 0.00, 'SANLI', 4000.00, 12000.00, 'Dang Anh', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2025-06-01', NULL, 'GENERAC', NULL, 'A0007261935', NULL, NULL, 'MOLEX', 22.00, 0.00, 0.00, 0.00, 'SANLI', 57500.00, 57500.00, 'Dang Anh', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2025-06-01', NULL, 'GENERAC', NULL, 'A0007261935', NULL, NULL, 'MOLEX', 22.00, 0.00, 0.00, 0.00, 'WPG VN', 4000.00, 4000.00, 'Dang Anh', 'System', GETDATE()),
('A01', 'ASM1', NULL, '2025-07-01', NULL, 'GENTOP', NULL, '445-0733575', NULL, NULL, 'MOLEX', 22.00, 0.00, 0.00, 0.00, 'HEILI', 1.00, 1000.00, 'Dang Anh', 'System', GETDATE()),
-- Trial GIL PN: P011428_P
('A01', 'ASM2', NULL, '2026-03-10', NULL, 'GENTOP', NULL, 'P011428_P', 'B029981', 'Trial GIL Component PN', 'MOLEX', 10.00, 5.50, 2.00, 5.00, 'AVNET', 5.80, 50000.00, 'Dang Anh', 'System', GETDATE());

-- Insert User Permissions
INSERT INTO UserPermissions (Username, Section, HasRead, HasWrite, AssignedBy)
VALUES 
('james', 'ASM1', 1, 1, 'Admin'),
('james', 'ASM2', 1, 0, 'Admin'),
('danganh', 'ASM1', 1, 1, 'Admin'),
('danganh', 'ASM2', 1, 1, 'Admin');
