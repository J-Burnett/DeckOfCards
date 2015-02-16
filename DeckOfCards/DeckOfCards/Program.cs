using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            Console.ReadKey();
        }

    }

    // When a new deck is created, you’ll create a card of each rank for each suit and add them to the deck of cards, 
    //      which in this case will be a List of Card objects.
    //
    // A deck can perform the following actions:
	//     void Shuffle() -- Merges the discarded pile with the deck and shuffles the cards
	//     List<card> Deal(int numberOfCards) - returns a number of cards from the top of the deck
	//     void Discard(Card card) / void Discard(List<Card> cards) - returns a card from a player to the 
	//         discard pile	
    // 
    // A deck knows the following information about itself:
	//     int CardsRemaining -- number of cards left in the deck
	//     List<Card> DeckOfCards -- card waiting to be dealt
    //     List<Card> DiscardedCards -- cards that have been played
  

    class Deck
    {   
        

        //contains cards in a deck
        public List<Card> DeckOfCards { get; set; }

        //Contains card used
        public List<Card> DiscardedCards { get; set; }


        public Deck()
        {
            this.DeckOfCards = new List<Card>();
            this.DiscardedCards = new List<Card>();
                for(int i = 2; i < 15; i++)
                {
                    for(int j = 1; j < 5; j++)
                    {
                        this.DeckOfCards.Add(new Card((Suit)j, (Rank)i));
                    }
                }
        }

      

        public List<Card> Deal(int numberOfCards)
        {
            List<Card> hand = new List<Card>();
            for(int i = 0; i <numberOfCards; i++)
            {
                Console.WriteLine(DeckOfCards[i]);
                hand.Add(DeckOfCards[i]);
                DeckOfCards.Remove(DeckOfCards[i]);
            }

            return hand;
        }

        public void Discard(List<Card> hand)
        {
            for(int i = 0; i < hand.Count; i++)
            {
                DiscardedCards.Add(hand[i]); 
            }
        }

        

        public void Shuffle()
        {
            Random rng = new Random();

            List<Card> shuffledDeck = new List<Card>();

            while (DeckOfCards.Count > 0)
            {
                Card newCard = DeckOfCards[rng.Next(0, DeckOfCards.Count())];
                shuffledDeck.Add(newCard);
                DeckOfCards.Remove(newCard);
            }

            DeckOfCards = shuffledDeck;
          
        }
    }

    
    // What makes a card?
	//     A card is comprised of it’s suit and its rank.  Both of which are enumerations.
    //     These enumerations should be "Suit" and "Rank"
    
    //Card Suits
    public enum Suit
    {
        Spade = 1,
        Diamond,
        Club,
        Heart
    }

    //Card Ranks
    public enum Rank
    {
      
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    class Card
    {
        public Suit CardSuit { get; set; }
        public Rank CardRank { get; set; }

        public Card (Suit suit, Rank rank)
        {
            this.CardSuit = suit;
            this.CardRank = rank;
        }
    }
}
