using FactoryDesignPattern;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string card = "MoneyBack";
        CreditCard cardDetails = null;

        if (card == "MoneyBack")
        {
            cardDetails = new MoneyBack();
        }
        else if (card == "Titanium")
        {
            cardDetails = new Titanium();
        }
        else if (card == "Platinum")
        {
            cardDetails = new Platinum();
        }

        if(cardDetails != null)
        {
            Console.WriteLine("CardType : " + cardDetails.GetCardType());
            Console.WriteLine("CreditLimit : " + cardDetails.GetCreditLimit());
            Console.WriteLine("AnnualCharge :" + cardDetails.GetAnnualCharge());
        }
        else
        {
            Console.Write("Invalid Card Type");
        }



    }
}