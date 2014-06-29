namespace Poker
{
    using System;
    using System.Text;

    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        /// <summary>
        /// Create a card with the specified face and suit
        /// </summary>
        /// <param name="face"></param>
        /// <param name="suit"></param>
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;                                    
        }

        /// <summary>
        /// Convers the specified card to its respective string representation using numerals to represent face values between 2 and 10 and character symbols for Jack and above. Suits are represented by their respective character symbol.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();            
            int faceValue = (int)Face;            
            if (faceValue < 11)
            {
                result.Append(faceValue);
            }
            else
            {
                result.Append(Face.ToString()[0]);
            }

            switch (Suit)
            {
                case CardSuit.Clubs:
                    result.Append("♣");
                    break;
                case CardSuit.Diamonds:
                    result.Append("♦");
                    break;
                case CardSuit.Hearts:
                    result.Append("♥");
                    break;
                case CardSuit.Spades:
                    result.Append("♠");
                    break;
            }

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Card))
            {
                return false;
            }
            else if (((Card)obj).Face != this.Face || ((Card)obj).Suit != this.Suit)
            {
                return false;
            }
            return true;
        }
    }
}
