using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackJohanFinal
{
    /* Skapad:        2021-01-16
     * Skribent:      Johan V
     * 
     * Klassinformation:
     * Skapa kort med valör samt färg.
     */
    public class Card
    {
        public string face;                             //kortets valör
        private string suit;                            //kortets färg

        public Card(string cardFace, string cardSuit)   //skapa ett kort
        {
            face = cardFace;                            //argument bestämmer valör
            suit = cardSuit;                            //argument bestämmer färg
        }

        public override string ToString()
        {
            return face + " of " + suit;
        }
    }
}
