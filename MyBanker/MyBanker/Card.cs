using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
   

    public abstract class Card
    {
        private string _cardNumber;
        private string _cardName;
        private string _cardAccount;
        private int _ageRequirement;
        
        public Card(string cardNumber, string cardName, int ageRequirement)
        {
            _cardNumber = cardNumber;
            _cardName = cardName;
            _cardAccount = CardFunctions.GenerateCardAccount();
            _ageRequirement = ageRequirement;
        }

            

    }

    public class DebetCard : Card {

        private static int _ageRequirement = 0;

        public DebetCard(string cardNumber, string cardName) : base(cardNumber, cardName, _ageRequirement)
        {
        }
    }

    public class Maestro : DebetCard
    {
        public Maestro(string cardNumber, string cardName) : base(cardNumber, cardName)
        {
        }
    }



}
