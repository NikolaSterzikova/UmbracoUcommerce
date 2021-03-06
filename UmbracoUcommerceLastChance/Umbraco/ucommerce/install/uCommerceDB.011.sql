--
-- Adds OrderId for uCommerce_OrderAddress
--
SET NUMERIC_ROUNDABORT OFF

SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tmpErrors')) DROP TABLE tmpErrors

CREATE TABLE tmpErrors (Error int)

SET XACT_ABORT ON

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE

BEGIN TRANSACTION

PRINT N'Altering [dbo].[uCommerce_OrderAddress]'

ALTER TABLE [dbo].[uCommerce_OrderAddress] ADD
[OrderId] [int] NULL

IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION

IF @@TRANCOUNT=0 BEGIN INSERT INTO tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END

PRINT N'Adding foreign keys to [dbo].[uCommerce_OrderAddress]'

ALTER TABLE [dbo].[uCommerce_OrderAddress] ADD
CONSTRAINT [FK_uCommerce_OrderAddress_uCommerce_PurchaseOrder] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[uCommerce_PurchaseOrder] ([OrderId])

IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION

IF @@TRANCOUNT=0 BEGIN INSERT INTO tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END

IF EXISTS (SELECT * FROM tmpErrors) ROLLBACK TRANSACTION

IF @@TRANCOUNT>0 BEGIN
PRINT 'The database update succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The database update failed'

DROP TABLE tmpErrors