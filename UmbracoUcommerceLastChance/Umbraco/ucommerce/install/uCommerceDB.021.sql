-- Move reference from shipment to orderline part 1 of 3
PRINT N'Dropping foreign keys from [dbo].[uCommerce_Shipment]'

ALTER TABLE [dbo].[uCommerce_Shipment] DROP
CONSTRAINT [uCommerce_FK_Shipment_OrderLine]