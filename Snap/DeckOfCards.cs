using System;
using System.Collections.Generic;
using System.Linq;

namespace NewGame.Snap
{
    /// <summary>
    /// DeckOfCards
    /// Contains the methods for creating a shuffled deck of cards
    /// </summary>
    /// <remarks>
    /// This class can creates a shuffled deck of cards and allows selection of a card from the deck
    /// </remarks>
    public class DeckOfCards
    {
        /// <value> Specifies the number of cards in a suit</value>
        private readonly Int16 CardsInSuit = 13;

        /// <value> Specifies the number of suits</value>
        private readonly Int16 Suits = 4;

        // Create the deck of cards
        /// <summary>
        /// Create the deck of cards
        /// </summary>
        /// <returns>
        /// A collection of the playing cards
        /// </returns>
        public List<PlayingCard> CreateDeckOfCards()
        {
            // Create a new empty collection of playing cards
            List<PlayingCard> deckOfCards = new List<PlayingCard>();

            string cardsuitlabel = string.Empty;
            string cardvaluelabel = string.Empty;

            // Loop for each suit and assign the suit
            for (int cardsuit = 0; cardsuit <= Suits - 1; cardsuit++)
            {
                cardsuitlabel = string.Empty;

                switch (cardsuit)
                {
                    case 0:
                        cardsuitlabel = "H"; // Hearts
                        break;

                    case 1:
                        cardsuitlabel = "D"; // Diamonds
                        break;

                    case 2:
                        cardsuitlabel = "C"; // clubs
                        break;

                    case 3:
                        cardsuitlabel = "S"; // Spades
                        break;

                    default:
                        break;
                }

                // Loop for each card and create the card in the suit.
                for (int cardvalue = 1; cardvalue <= CardsInSuit; cardvalue++)
                {
                    cardvaluelabel = string.Empty;

                    // Instantiate the new playing card
                    PlayingCard mycard = new PlayingCard();

                    // Assign the value of the card
                    switch (cardvalue)
                    {
                        case 1:
                            cardvaluelabel = "A"; // Ace
                            break;

                        case 11:
                            cardvaluelabel = "J"; // Jack
                            break;

                        case 12:
                            cardvaluelabel = "Q"; // Queen
                            break;

                        case 13:
                            cardvaluelabel = "K"; // King
                            break;

                        default:
                            cardvaluelabel = cardvalue.ToString(); // Value of the card
                            break;
                    }
                    mycard.CardSuit = cardsuitlabel;
                    mycard.CardValue = cardvaluelabel;
                    mycard.CardPlayed = false;

                    // Add the playing card to the deck
                    deckOfCards.Add(mycard);
                }
            }

            return deckOfCards;
        }

        // Shuffle the deck of playing cards
        /// <summary>
        /// Shuffle the deck of playing cards
        /// </summary>
        /// <returns>
        /// A shuffled collection of the playing cards
        /// </returns>
        public List<PlayingCard> ShuffleCards(List<PlayingCard> deckOfCards)
        {
            return deckOfCards.OrderBy(c => Guid.NewGuid()).ToList(); ;
        }

        // Select a card from the deck of cards
        /// <summary>
        /// Select a card from the deck of cards
        /// </summary>
        /// <returns>
        /// A playing card from the deck that has not been played previously,
        /// </returns>
        public PlayingCard SelectCard(List<PlayingCard> ShuffledCardDeck)
        {
            var selectedCard = ShuffledCardDeck.Where(c => !c.CardPlayed).OrderBy(c => Guid.NewGuid()).Take(1).FirstOrDefault();

            if (selectedCard != null)
            {
                selectedCard.CardPlayed = true;
            }

            return selectedCard;
        }
    }
}