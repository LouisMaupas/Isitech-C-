﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierProjet.Library
{
    public class Player
    {
        #region 
        public string name;
        public Deck deck;
        public byte score;
        public Array hand { get; set; }
        #endregion

        public Player(string name, Deck deck, byte score, Array hand) // constructor
        {
            this.name = name;
            this.deck = deck;
            this.score = score;
            this.hand = hand;
        }

        public string Name { get { return name; } }

        public Deck Deck {
            get { return deck; }
            set { deck = value; }
        }

        public byte Score {
            get { return score; }
            set
            {
                this.score = value;
            } }

        public Array Hand {
            get { return hand; }
        }

        public Array RemoveCardFromHand(int value)
        {
            // enleve de hand la carte qui a la valeur VALUE :
            // on crée un tableau temporaire
            // on parcours le talbeau Hand et si la valeur i N'EST PAS égale à value alors on ajoute la value au tableau temporaire
            // remplace hand par le tableau temporaire       
                int[] tempArray = Array.Empty<int>();
                for (int i = 0; i < hand.Length; i++)
                {
                    if ((int)Hand.GetValue(i) != value)
                    {
                        tempArray[i] = (int)hand.GetValue(i);
                    }
                }
                this.hand = tempArray;
            return this.hand;
        }
    }

    public class Deck
    {
        public Array deck;
        public Deck(Array deck)
        {
            this.deck = deck;
        }

        public Array CurrentDeck
        {
            get { return deck; }
            set { deck = value; }
        }
    }

    //public class Card
    //{
    //    public string name;
    //    public byte value;

    //    public Card(string name, byte value)
    //    {
    //        this.name = name;
    //        this.value = value;
    //    }

    //    public object Value
    //    {
    //        get { return value; }
    //    }

    //    public object Name
    //    {
    //        get { return name; }
    //    }
    //}

    //enum Cards
    //{
    //    As = 1,
    //    Two = 2,
    //    Three = 3,
    //    Four = 4,
    //    Five = 5,
    //    Six = 6,
    //    Seven = 7,
    //    Eight = 8,
    //    Nine = 9,
    //    Ten = 10,
    //    Jack = 11,
    //    Queen = 12,
    //    King = 13,
    //}

}
