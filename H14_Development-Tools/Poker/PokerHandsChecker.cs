namespace Poker
{
    using System;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        /// <summary>
        /// Checks if the provided hand consists of exactly five cards and that no two cards are the same.
        /// </summary>
        /// <param name="hand">The hand to check.</param>
        /// <returns>True if the hand is valid, false otherwise.</returns>
        public bool IsValidHand(IHand hand)
        {
            ICard[] cards = hand.Cards.ToArray();
            if (cards.Length != 5)
            {
                return false;
            }            
            else 
            {
                for (int i = 0; i < cards.Length; i++)
			    {
                    for (int j = i + 1; j < cards.Length; j++)
                    {
                        if (cards[i].Equals(cards[j]))
                        {
                            return false;
                        }
                    }
			    }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if a given hand is valid and if so, whether any four cards have the same face.
        /// </summary>
        /// <param name="hand">The hand to check.</param>
        /// <returns>True if the hand is valid and four of a kind, false otherwise.</returns>
        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }
            else
            {
                ICard[] cards = hand.Cards.ToArray();
                int firstFaceCount = 1;
                int secondFaceCount = 0;
                ICard firstFaceType = cards[0];
                ICard secondFaceType = null;

                for (int i = 1; i < cards.Length; i++)
                {
                    if (cards[i].Face != firstFaceType.Face)
                    {
                        if (secondFaceType != null && secondFaceType.Face != cards[i].Face)
                        {
                            return false;
                        }
                        else if (secondFaceType != null)
                        {
                            secondFaceCount++;
                        }
                        else
                        {
                            secondFaceType = cards[i];
                            secondFaceCount = 1;
                        }
                    }
                    else
                    {
                        firstFaceCount++;
                    }
                }

                if (secondFaceCount == 4 || firstFaceCount == 4)
                {
                    return true;
                }

                return false;
            }            
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if a given hand is a valid poker hand and if so, whether all cards are the same suit.
        /// </summary>
        /// <param name="hand">The hand to check.</param>
        /// <returns>True if the hand is valid and a flush, false otherwise.</returns>
        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }
            else
            {
                ICard[] cards = hand.Cards.ToArray();
                for (int i = 0; i < cards.Length - 1; i++)
                {
                    if (cards[i].Suit != cards[i + 1].Suit)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
