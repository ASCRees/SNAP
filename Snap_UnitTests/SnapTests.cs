using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewGame.Snap;
using System.Collections.Generic;
using System.Linq;

namespace NewGame.SnapTest
{
    [TestClass]
    public class SnapTests
    {
        [TestMethod]
        public void DeckOfCards_CreateCardDeck_CountCards_FiftyTwoCard()
        {
            DeckOfCards deckOfCards = new DeckOfCards();
            List<NewGame.Snap.PlayingCard> pc = deckOfCards.CreateDeckOfCards();
            Assert.IsTrue(pc.Count.Equals(52));
        }

        [TestMethod]
        public void DeckOfCards_CreateCardDeck_CountSuits_FourSuits()
        {
            DeckOfCards deckOfCards = new DeckOfCards();
            List<NewGame.Snap.PlayingCard> pc = deckOfCards.CreateDeckOfCards();
            // Check there are four different suits
            Assert.IsTrue(pc.GroupBy(c => c.CardSuit).Count().Equals(4));
        }

        [TestMethod]
        public void DeckOfCards_CreateCardDeck_CountCardsInSuits_ThirteenCards()
        {
            DeckOfCards deckOfCards = new DeckOfCards();
            List<NewGame.Snap.PlayingCard> pc = deckOfCards.CreateDeckOfCards();
            // Check there are four different suits
            Assert.IsTrue(pc.GroupBy(c => c.CardValue).Count().Equals(13));
        }

        [TestMethod]
        public void DeckOfCards_ShuffleCards_CheckCardsDiffer_DifferentList()
        {
            DeckOfCards deckOfCards = new DeckOfCards();
            List<PlayingCard> pcbefore = deckOfCards.CreateDeckOfCards();
            List<PlayingCard> pcafter = deckOfCards.ShuffleCards(pcbefore);
            Assert.IsFalse(pcbefore.Equals(pcafter));
        }

        [TestMethod]
        public void DeckOfCards_SelectCards_DrawCard_CardPopulated()
        {
            DeckOfCards deckOfCards = new DeckOfCards();
            List<PlayingCard> shuffledDeckOfCards = deckOfCards.ShuffleCards(deckOfCards.CreateDeckOfCards());

            PlayingCard playingCard = deckOfCards.SelectCard(shuffledDeckOfCards);

            Assert.IsTrue(playingCard != null);
        }

        [TestMethod]
        public void DeckOfCards_SelectCards_DrawTwoCards_CheckCardsDiffer()
        {
            DeckOfCards deckOfCards = new DeckOfCards();
            List<PlayingCard> shuffledDeckOfCards = deckOfCards.ShuffleCards(deckOfCards.CreateDeckOfCards());

            PlayingCard firstPlayingCard = deckOfCards.SelectCard(shuffledDeckOfCards);
            PlayingCard secondPlayingCard = deckOfCards.SelectCard(shuffledDeckOfCards);

            Assert.IsFalse(firstPlayingCard.Equals(secondPlayingCard));
        }

        [TestMethod]
        public void PlaySnap_InitializeGame_CountCards_EqualsFiftyTwo()
        {
            PlaySnap playSnap = new PlaySnap();
            List<PlayingCard> ShuffledCardDeck;
            List<Player> Players;

            playSnap.InitializeGame(out ShuffledCardDeck, out Players);

            Assert.IsTrue(ShuffledCardDeck.Count.Equals(52));
        }

        [TestMethod]
        public void PlaySnap_InitializeGame_CountPlayers_EqualsTwo()
        {
            PlaySnap playSnap = new PlaySnap();
            List<PlayingCard> ShuffledCardDeck;
            List<Player> Players;

            playSnap.InitializeGame(out ShuffledCardDeck, out Players);

            Assert.IsTrue(Players.Count.Equals(2));
        }

        [TestMethod]
        public void PlaySnap_PlayGame_VerifyNoExceptions_NoExceptions()
        {
            try
            {
                PlaySnap playSnap = new PlaySnap();
                playSnap.PlayGame();
            }
            catch (System.Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void PlaySnap_PlayGame_CheckForResult_CheckForWinnerOrDraw()
        {
            PlaySnap playSnap = new PlaySnap();
            playSnap.PlayGame();
            Assert.IsTrue(playSnap.winnerChosen > -1);
        }

        [TestMethod]
        public void PlayingCard_Card_CheckValueAndSuit_CardEqualsCardAndSuit()
        {
            PlayingCard playingCard = new PlayingCard();
            playingCard.CardValue = "4";
            playingCard.CardSuit = "H";

            Assert.IsTrue(playingCard.Card.Equals("4H"));
        }

        [TestMethod]
        public void Player_Name_CheckNameIsSet_NameIsEqualToGeorge()
        {
            Player player = new Player();
            player.Name = "George";
            player.PlayerID = 0;

            Assert.IsTrue(player.Name.Equals("George"));
        }
    }
}