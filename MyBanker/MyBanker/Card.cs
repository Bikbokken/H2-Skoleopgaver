using System.Text;

namespace MyBanker
{
    class CardFunctions
    {
        public static string GenerateCardAccount()
        {
            Random random = new Random();

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < 14; i++)
            {
                builder.Append("3520").Append(random.Next(100000, 1000000));

                builder.AppendLine();
            }

            return builder.ToString();
        }
        public static string GenerateCardNumber(CardType type)
        {
            string prefix = "";
            int length = 16;

            switch (type)
            {
                case CardType.VisaElectron:
                    prefix = "4026, 417500, 4508, 4844, 4913, 4917";
                    length = 16;
                    break;
                case CardType.Visa:
                    prefix = "4";
                    length = 16;
                    break;
                case CardType.Mastercard:
                    prefix = "51, 52, 53, 54, 55";
                    length = 16;
                    break;
                case CardType.Maestro:
                    prefix = "5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763";
                    length = 19;
                    break;
                case CardType.DebitCard:
                    prefix = "2400";
                    length = 16;
                    break;
            }

            string cardNumber = prefix + GenerateRandomNumbers(length - prefix.Length);
            return cardNumber;
        }

        private static string GenerateRandomNumbers(int number)
        {
            string digits = "";
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                digits += random.Next(0, 9).ToString();
            }

            return digits;
        }

        public enum CardType
        {
            VisaElectron,
            Visa,
            Mastercard,
            Maestro,
            DebitCard
        }
      

    }
   

    public abstract class Card
    {
        public string CardNumber { get; private set; }
        public string CardName { get; private set; }
        public string CardAccount { get; private set; }
        public int AgeRequirement { get; private set; }
        public string RegNumber { get; private set; }
        public DateTime? ExpiryDate { get; private set; }

        public Card(string cardName, string cardNumber, int ageRequirement, DateTime expiryDate)
        {
            CardNumber = cardNumber;
            CardName = cardName;
            CardAccount = CardFunctions.GenerateCardAccount();
            AgeRequirement = ageRequirement;
            RegNumber = "3520";
            ExpiryDate = expiryDate;
        }


        public override string ToString()
        {
            return $"CardNumber: {CardNumber} - CardName: {CardName} - CardAccount: {CardAccount} - AgeRequirement: {AgeRequirement} - RegNumber: {3520} - Expiry Date: {ExpiryDate}";
        }


    }

    public abstract class DebetCard : Card
    {
        public bool InternationalUse { get; private set; }

        public DebetCard(string cardName, string cardNumber,int ageRequirement, bool international, DateTime expiryDate) : base(cardName, cardNumber, ageRequirement, expiryDate)
        {
            InternationalUse = international;
        }

        public override string ToString()
        {
            return base.ToString() + $" - International Use: {InternationalUse}"; 
        }
    }

    public class CashCard : DebetCard
    {
        public CashCard(string cardName) : base(cardName, CardFunctions.GenerateCardNumber(CardFunctions.CardType.DebitCard), 0, false, default(DateTime))
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Maestro : DebetCard
    {
        public Maestro(string cardName) : base(cardName, CardFunctions.GenerateCardNumber(CardFunctions.CardType.Maestro), 18, true, DateTime.Now.AddYears(5).AddMonths(8))
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public abstract class CreditCard : Card
    {
        public int MonthlyLimit { get; private set; }

        public CreditCard(string cardName, string cardNumber, int ageRequirement, int monthlyLimit, DateTime expiryDate) : base(cardName, cardNumber, ageRequirement, expiryDate)
        {
            MonthlyLimit = monthlyLimit;
        }
        public override string ToString()
        {
            return base.ToString() + $" - Monthly Limit: {MonthlyLimit}";
        }
    }

    public class VisaElectron : DebetCard
    {
        public VisaElectron(string cardName) : base(cardName, CardFunctions.GenerateCardNumber(CardFunctions.CardType.VisaElectron), 15, true, DateTime.Now.AddYears(5))
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Dankort : CreditCard
    {

        public int MaxWithdrawMonthly { get; private set; }

        public Dankort(string cardName) : base(cardName, CardFunctions.GenerateCardNumber(CardFunctions.CardType.Visa), 18,  20000, DateTime.Now.AddYears(5))
        {
            MaxWithdrawMonthly = 25000;
        }
        public override string ToString()
        {
            return base.ToString() + $" - MaxWithDrawMonthly: {MaxWithdrawMonthly}";
        }
    }

    public class Mastercard : CreditCard
    {
        public Mastercard(string cardName) : base(cardName, CardFunctions.GenerateCardNumber(CardFunctions.CardType.Mastercard), 0, 30000, DateTime.Now.AddYears(5))
        {
            AvailableCredit = 40000;
            DailyMax = 5000;
        }

        public int AvailableCredit { get; private set; }
        public int DailyMax { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $" - Avaliable Credit: {AvailableCredit} - DailyMax: {DailyMax}";
        }
    }
}
