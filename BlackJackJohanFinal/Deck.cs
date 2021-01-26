using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackJohanFinal
{
    class Deck
    {
        public List<Card> deck = new List<Card>();                                                          //skapa en lista för att placera samtliga kort i stigande ordning (mall)
        private const int deckSize = 52;                                                                    //kortlekens storlek
        private int currentCard;                                                                            //markör som flyttas fram när ett kort dras från kortleken

        List<string> faces = new List<string>() { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven",    //kortens olika valörer
                                                      "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        List<string> suitType = new List<string>() { "Clubs", "Diamond", "Heart", "Spade" };                //kortens olika färger

        /** Skapa en sorterad kortlek */
        public Deck()
        {
            currentCard = 0;                                                                                //lägg markören på plats "0" då inga kort dras
            for (int i = 0; i < deckSize; i++)                                                              //for-loop för att fylla kortleken med kort
            {
                deck.Add(new Card(faces[i % 13], suitType[i / 13]));                                        //lägg in kort i stigande valör och färg
            }
        }

        /** Metod för att skapa en blandad kortlek */
        public List<Card> Shuffle()
        {
            List<Card> tempDeck = deck;                                                                     //skapa en kopia på skelettet för att inte ändra på original-kortleken
            Random rand = new Random();                                                                     //för att generera ett slumpmässigt värde
            currentCard = 0;                                                                                //sätt markören på plats "0" då vi initierar en ny full kortlek där inga kort dragits
            for (int first = 0; first < deckSize; first++)
            {
                int second = rand.Next(0, 51);                                                              //skapa ett slumpmässigt tal mellan 0 och 51
                Card temp = tempDeck[first];                                                                //swapa två kort med varandra utan att skriva över korten
                tempDeck[first] = tempDeck[second];
                tempDeck[second] = temp;
            }
            return tempDeck;                                                                                //returnera den blandade kortleken
        }

        /** Metod för att dra ett kort från kortleken */
        public Card Draw(List<Card> deck)
        {
            if (currentCard < deck.Count)                                                                   //dra ett kort om det finns kort kvar i kortleken
            {
                Card temp = deck[currentCard];                                                              //spara kortets som skall returneras
                deck.RemoveAt(currentCard);                                                                 //ta bort kortet från kortleken
                return temp;                                                                                //returnera kortet
            }
            else
            {
                return null;                                                                                //kan inte returnera kort ifall kortleken är tom
            }
        }

        /** Metod för att ta reda på kortets värde (i heltal) */
        public int GetCardValue(List<Card> hand, int index, bool aceChoice)
        {
            string faceType = hand[index].face;                                                             //ta reda på vilken valör top-deck-kortet har    
            int faceValue;
            if (faceType == "Jack" || faceType == "Queen" || faceType == "King")                            //kolla ifall det är ett klätt kort
            {
                faceValue = 10;                                                                             //om kortet är klätt: value = 10
            }
            else if (faceType == "Ace" && aceChoice == true)                                                //om spelaren väljer att räkna ess som 11
            {
                faceValue = 11;                                                                             //kort = 11
            }
            else
            {
                faceValue = faces.IndexOf(faceType) + 1;                                                    //om inget av ovan, konvertera valören till ett heltal + 1 (array börjar på index 0)                                                                                          
            }
            return faceValue;                                                                               //returnera kortets värde
        }

        /** Metod för att räkna ut en hel hands totala värde */
        public int HandValue(List<Card> hand, bool aceChoice)
        {
            int handValue = 0;                                                                              //töm värdet varje gång funktionen anropas
            for (int i = 0; i < hand.Count; i++)
            {
                handValue += GetCardValue(hand, i, aceChoice);                                              //räkna spelarens värde på handen genom att addera varje kort
            }
            return handValue;                                                                               //returnera värdet
        }   

        /** Metod för att kontrollera ifall ett intervall i handen innehåller ett ess */
        public bool CheckForAce(List<Card> hand, int offset, int index)
        {
            bool exists = false;
            for(int i = offset; i < index; i++)
            {
                if(hand[i].face == "Ace")                                                                   //kontrollera ifall ett kort är ess
                {
                    exists = true;                                                                          //isåfall, flagga att det finns på intervallet
                }
            }
            return exists;                                                                                  //returnera flaggan
        }

    }
}