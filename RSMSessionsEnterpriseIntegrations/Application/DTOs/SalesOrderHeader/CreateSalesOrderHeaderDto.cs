namespace Application.DTOs.SalesOrderHeader
{
    public class CreateSalesOrderHeaderDto
    {
        public short RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public short Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public string? AccountNumber { get; set; }
        public int CustomerId { get; set; }
        public int SalesPersonID { get; set; }
        public int? TerritoryID { get; set; }
        public int BillToAddressID { get; set; }
        public int ShipToAddressID { get; set; }
        public int ShipMethodID { get; set; }
        public int? CreditCardID { get; set; }
        public string? CreditCardApprovalCode { get; set; }
        public int? CurrencyRateID { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public string? Comment { get; set; }
    }
}
