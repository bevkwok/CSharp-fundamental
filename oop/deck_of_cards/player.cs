using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    class Player
    {
        public string Name;

        public List<Card> hand{get;set;}

        public object draw()
        {
            hand.Add(Deck.deal());
            return Deck.deal();
        }

        public object discard(int index)
        {
            hand.Remove(hand[index]);
            return hand;
        }
    }
}