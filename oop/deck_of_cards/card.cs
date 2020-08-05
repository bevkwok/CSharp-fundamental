using System;

namespace deck_of_cards
{
    class Card
    {
        public string stringVal;
        public string suit;
        public int val;

        public Card(string strval, string suits, int value)
        {
            stringVal = strval;
            suit = suits;
            val = value;
        }

    }
}