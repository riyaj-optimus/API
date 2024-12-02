namespace DbOperationWithEfCode.Data
{
    public class CurrencyType
    {
        public int Id {  get; set; }
        public string Currency { get; set; }

        //public string Desc { get; set; }

        public BookPrice? BookPrices { get; set; }//1 -1 relationship from  CurrencyType :BookPrices
    }
}
