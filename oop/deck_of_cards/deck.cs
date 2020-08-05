using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    class Deck
    {
        public int cardNum;
        public List<Card> cards{get;set;}

        public object deal()
        {
            cards.Remove(cards[0]);
            return cards[0];
        }

        public void reset()
        {
            if (cards.Count < 52)
            {
                cards.Add(new Card());
            }
        }

        public void shuffle(List<Card> cards)
        {
            Random rand = new Random();
            for(int i = 0; i < cards.Count; i++)
            {
                cards[i] = cards[rand.Next(0, cards.Count)];
            }
        }

    }

}