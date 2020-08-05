using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    class Player
    {
        public string Name;

        public List<Card> hand;

        public Player(string name)
        {
            Name = name;
            hand = new List<Card>();
        }
        public Card draw(Deck deck)
        {
            hand.Add(deck.deal());
            return deck.deal();
        }

        public Card discard(int index)
        {
            Card removedCard = hand[index];
            hand.Remove(hand[index]);
            return removedCard;
        }
    }
}