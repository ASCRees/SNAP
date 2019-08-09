namespace NewGame.Snap
{
    /// <summary>
    /// PlayingCard
    /// Holds the properties of the playing card
    /// </summary>
    /// <remarks>
    /// </remarks>

    public class PlayingCard
    {
        /// <value> Value and suit of the card</value>
        public string Card
        {
            get
            {
                return CardValue + CardSuit;
            }
        }

        /// <value> Indicates if the card has been played</value>
        public bool CardPlayed { get; set; }

        /// <value> Suit of the card</value>
        public string CardSuit { get; set; }

        /// <value> Value of the card</value>
        public string CardValue { get; set; }
    }
}