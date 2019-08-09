using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewGame.Snap
{
    /// <summary>
    /// PlaySnap
    /// This contains the methods for playing the game of Snap!
    /// </summary>
    /// <remarks>
    /// </remarks>

    public class PlaySnap
    {
        /// <value> Initializes the Deck of Cards class</value>
        private readonly DeckOfCards deckOfCards = new DeckOfCards();

        /// <value> Specifies the number of players</value>
        private readonly Int32 numberOfPlayers = 2;

        /// <value> Holds the lock object used when deciding a winner</value>
        private readonly object selectWinnerLock = new object();

        /// <value> Holds player number of the winner. If 0 then its a draw.</value>
        public int winnerChosen = -1;

        // Initializes the game to load the playes and the shuffled deck
        /// <summary>
        /// Initializes the game to load the playes and the shuffled deck
        /// </summary>
        /// <returns>
        /// A list of shuffled playing cards and a list of players
        /// </returns>
        public void InitializeGame(out List<PlayingCard> shuffledCardDeck, out List<Player> players)
        {
            // Add players
            players = new List<Player>
            {
                new Player()
                {
                    Name = "George",
                    PlayerID = 0
                },

                new Player()
                {
                    Name = "Desmond",
                    PlayerID = 1
                }
            };

            // Display a welcome for each player.
            foreach (Player player in players)
            {
                Console.WriteLine("Welcome " + player.Name);
            }
            Console.WriteLine("");

            // Create and shuffle the deck
            Console.WriteLine("Let me shuffle the deck");
            shuffledCardDeck = deckOfCards.ShuffleCards(deckOfCards.CreateDeckOfCards());
        }

        // Plays the game of Snap with the two players
        /// <summary>
        /// Plays the game of Snap with the two players
        /// </summary>
        /// <returns>
        /// </returns>
        public void PlayGame()
        {
            try
            {
                List<PlayingCard> shuffledCardDeck;
                List<Player> players;
                Random random = new Random();
                bool doWeHaveAWinner = false;
                string previousCardValue = string.Empty;
                PlayingCard turnedCard = null;

                // Initialize the game to build the deck and list of players
                InitializeGame(out shuffledCardDeck, out players);

                Console.WriteLine("");
                Console.WriteLine("Start Game");

                // Pick the player that starts the game
                Int32 currentPlayerNumber = random.Next(0, numberOfPlayers - 1);
                do
                {
                    // Wait between 300 and 800 milli seconds before drawing the card, to simulate a delay in peforming the draw
                    Thread.Sleep(random.Next(300, 800));

                    // Select a card from the deck
                    turnedCard = deckOfCards.SelectCard(shuffledCardDeck);

                    // Play the card
                    doWeHaveAWinner = PlayCard(turnedCard, players, ref previousCardValue, players[currentPlayerNumber].Name);

                    // Change the current player to the next one in the list
                    currentPlayerNumber += 1;

                    if (currentPlayerNumber > numberOfPlayers - 1)
                        currentPlayerNumber = 0;
                } while (turnedCard != null && !doWeHaveAWinner);

                Console.WriteLine("Game Over !");

                // Check if we have no winner. If not then its a draw.
                if (!doWeHaveAWinner)
                {
                    Console.WriteLine("It was a Draw !!!");
                    winnerChosen = 0;
                }

                Console.WriteLine("");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Plays a card by the current player and determines if the current card matches the previous cards value and then determines the winner
        /// <summary>
        /// Plays a card by the current player and determines if the current card matches the previous cards value and then determines the winner
        /// </summary>
        /// <returns>
        /// boolean to to indicate if we have a winner
        /// </returns>
        private bool PlayCard(PlayingCard turnedCard, List<Player> players, ref string previousCardValue, string currentPlayerName)
        {
            if (turnedCard != null)
            {
                //  Display the card chosen
                Console.WriteLine(currentPlayerName + " turns card '" + turnedCard.Card + "'");

                // Check if the current cards value matches the previous
                if (turnedCard.CardValue.Equals(previousCardValue))
                {
                    // Pick the winner at random
                    // Start two parallel threads and have each wait for a random period of time between 300 and 1000 milliseconds.
                    // before checking for a winner.
                    // If winner has been chosen then exit.

                    Parallel.Invoke(
                            () => { PickAWinner(0); },
                            () => { PickAWinner(1); }
                         );

                    // Output the name of the winner.
                    Console.WriteLine("SNAP! " + players[winnerChosen - 1].Name + " is the winner!!");

                    // Indicate we have a winner so we can terminate the code
                    return true;
                }

                // Update the previous card selected
                previousCardValue = turnedCard.CardValue;
            }

            return false;
        }

        // Decides if the player is a winner. Sleeps for a random period of time before locking the threads and then deciding if winner has been chosen
        /// <summary>
        /// Decides if the player is a winner. Sleeps for a random period of time before locking the threads and then deciding if winner has been chosen
        /// </summary>
        /// <returns>
        /// </returns>
        private void PickAWinner(Int32 player)
        {
            // Sleep for between a third and one second to simulate the players reaction time.
            Thread.Sleep(new Random().Next(300, 1000));
            // Lock the other processes while we check and update the winnerChosen
            lock (selectWinnerLock)
            {
                // If the winner has not been previously chosen set it to the current player
                if (winnerChosen < 0)
                {
                    winnerChosen = player + 1;
                }
            }
        }
    }
}