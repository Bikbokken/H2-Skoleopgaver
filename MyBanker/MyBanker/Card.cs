using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public class Card
    {
        private string _cardNumber;
        private string _cardName;
        private string _cardAccount;
        
        public Card(string cardNumber, string cardName, string cardAccount)
        {
            _cardNumber = cardNumber;
            _cardName = cardName;
            _cardAccount = cardAccount;
        }

    }

}
