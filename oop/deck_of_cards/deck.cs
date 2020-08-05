using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            string[] strvalue = {"Ace","2", "3","4","5","6","7","8","9","10","Jack", "Queen", "King"};

            string[] suitArr = {"Club", "Spades", "Hearts", "Diamonds"};

            int[] valArr = {1,2,3,4,5,6,7,8,9,10,11,12,13};

            cards = new List<Card>();
            for(int i = 0 ; i<strvalue.Length; i++){
                for(int j = 0; j<suitArr.Length; j++){
                    cards.Add(new Card(strvalue[i], suitArr[j],valArr[i]));
                }
            }
            
            
        }

        public Card deal()
        {
            Card card = cards[0];
            cards.Remove(cards[0]);
            return card;
        }

        public void reset()
        {
            cards = new Deck().cards;
        }

        public void shuffle()
        {
            Random rand = new Random();
            for(int i = 0; i < cards.Count; i++)
            {
                cards[i] = cards[rand.Next(0, cards.Count)];
            }
        }

    }

}