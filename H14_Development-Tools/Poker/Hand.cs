using System;
using System.Collections.Generic;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Hand cannot be null.");
                }

                foreach (var card in value)
                {
                    if (card == null)
                    {
                        throw new ArgumentNullException("No cards in hand should be null.");
                    }
                }

                this.cards = value;
            }
        }

        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;            
        }

        public override string ToString()
        {
            return string.Join(" ", cards);
        }
    }
}
