namespace Application.DTOs.SalesOrderHeader
{
    public class UpdateSalesOrderHeaderDto
    {
        public int Id { get; set; }
        public short RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public short Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public string? AccountNumber { get; set; }
        public short CustomerId { get; set; }
        public short SalesPersonID { get; set; }
        public short? TerritoryID { get; set; }
        public short BillToAddressID { get; set; }
        public short ShipToAddressID { get; set; }
        public short ShipMethodID { get; set; }
        public short? CreditCardID { get; set; }
        public string? CreditCardApprovalCode { get; set; }
        public short? CurrencyRateID { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public string? Comment { get; set; }
    }
}
