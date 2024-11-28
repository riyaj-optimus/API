namespace DbOperationWithEfCode.Data
{
    public class BookPrice
    {
        public int Id { get; set; }
        public int BookId {  get; set; }//fk for Books
        public int Amount { get; set; }
        public int CurrencyTypeId { get; set; }//fk for currencyType

        public Book Book { get; set; }//Relationship establisher

        public CurrencyType CurrencyType { get; set; }//Relationship establisher
    }
}
