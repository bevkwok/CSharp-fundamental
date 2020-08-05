using System;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1= new Player("Amy");

            Deck deck1 = new Deck();

            Card card = player1.draw(deck1);

            deck1.shuffle();


        }
    }
}
