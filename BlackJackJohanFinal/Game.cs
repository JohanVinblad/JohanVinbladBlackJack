using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackJohanFinal
{
    class Game
    {
        /** Enum för att bestämma spelets status */
        public enum GameStatus
        {
            Won = 1,
            Lost,
            Playing,
            Tie,
            BlackJack
        }

        /** Metod för att fylla playingDeck (den vi använder i spelet) med nrOfDecks stycken blandade kortlekar */
        public List<Card> DeckSetup(int nrOfDecks)
        {
            Deck deck1 = new Deck();                                                                        //skapa en instans av deck-klassen för att komma åt dess metoder
            List<Card> playingDeck = new List<Card>();                                                   //skapa en ny lista som sedan ska hålla alla kortlekar (ex 4st)
            for (int i = 0; i < nrOfDecks; i++)
            {
                playingDeck.AddRange(deck1.Shuffle());                                                      //lägg på en blandad kortlek varje iteration
            }
            return playingDeck;
        }

        public void Reset(List<Card> player, List<Card> dealer)
        {
            player.Clear();
            dealer.Clear();
        }

        public int HandValue(List<Card> hand, bool aceChoice)
        {
            Deck deck = new Deck();
            int handValue = 0;                                                         //töm värdet varje gång funktionen anropas
            for (int i = 0; i < hand.Count; i++)
            {
                handValue += deck.GetCardValue(hand, i, aceChoice);                               //räkna spelarens värde på handen genom att addera varje kort
            }
            return handValue;
        }

        /** Metod för att skriva ut spelarens hand i consolen */
        public void PrintHand(List<Card> deck, int playerHandValue, int index, string player)
        {
            Console.Write("\n" + player + " has:\n");
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(deck[i]);                                                                 //printa samtliga kort
            }
            Console.Write("(" + playerHandValue + ")\n");
        }

        public bool ChooseAceValue(int playerHandValue)
        {
            bool highAce = false;
            Console.WriteLine("Do you want to count Ace as 11? (Default is 1)\n(Y/N)\n");
            invalidInput:
            ConsoleKeyInfo response = Console.ReadKey();
            if(response.KeyChar == 'Y')
            {
                playerHandValue += 0;
                highAce = true;
            } else if (response.KeyChar == 'N')
            {
                playerHandValue -= 10;
            } else
            {
                Console.WriteLine("\nInvalid input.");
                goto invalidInput;
            }
            return highAce;
        }

    }
}
