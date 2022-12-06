using premierProjet.Library;
using System;

// intro + get player name
Console.WriteLine("C'est un jeu de carte très basique où vous affrontez le pc");
Console.WriteLine("Votre deck est composé de 13 cartes dont les valeurs vont de 1 à 13");
Console.WriteLine("Au début de la partie vous piochez 3 cartes, vous devrez finir la partie avec ...");
Console.WriteLine("Le gagnant est celui qui a le plus haut score à la fin de la 3eme manche.");
Console.WriteLine("Comment vous appellez vous ?");

string playerName = playerName = Console.ReadLine();

// build Cards and deck
int[] Cards = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
Deck playerDeck = new Deck(Cards);
Deck computerDeck = new Deck(Cards);

/*
 Fonction qui prends en paramètre un nombre de carte à tirer et un deck
 tire aléatoirement 3 cartes parmis les cartes du deck
 Retourne ces 3 cartes
 */
Array drawCards(int numberOfCards, Deck deck) {
    var random = new Random();
    int[] Draw = new int[numberOfCards];
    for (int i = 0; i < numberOfCards; i++)
    {
        int number = random.Next(1, 13);
        Draw[i] = number;
    }
    return Draw;
}

Array playerDraw = drawCards(3, playerDeck); // tire 3 cartes pour le player
Array computerDraw = drawCards(3, computerDeck); // tire 3 cartes pour le computer
// ajoute ces 3 cartes aux mains
int[] playerHand = (int[])drawCards(3, computerDeck);
int[] computerHand = (int[])drawCards(1, computerDeck);
// TODO (version 2) retire les 3 cartes piochés des decks de player et computer


// build players
Player player = new Player(playerName, playerDeck, 0, playerHand);
Player computer = new Player("Ordinateur", computerDeck, 0, computerHand);

// Game
Console.WriteLine(" ");
Console.WriteLine(" ");
Console.WriteLine(" ");

int cardA = (int)player.hand.GetValue(0);
int cardB = (int)player.hand.GetValue(1);
int cardC = (int)player.hand.GetValue(2);

while (player.Hand.Length > 0)
{
    Console.WriteLine(" *********************** Manche 1 ***********************");
    Console.WriteLine("     " + player.name + " vous avez un score de : " + player.score);
    Console.WriteLine("     Le pc a un score de " + computer.score);
    Console.WriteLine("Vos cartes sont : ");
    Console.WriteLine("La carte 0 a une valeur de " + cardA);
    Console.WriteLine("La carte 1 a une valeur de " + cardB);
    Console.WriteLine("La carte 2 a une valeur de " + cardC);
    int playerChoice = 99;
    int[] possibleChoices = new int[3] {0, 1, 2};
    int[] possibleCards = new int[3] {cardA, cardB, cardC};
    
    while(!possibleChoices.Contains(playerChoice))
    {
        Console.WriteLine("Quelle carte voulez-vous jouer ? ");
        Console.WriteLine("Vous devez écrire 0 ou 1 ou 2");
        playerChoice = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Vous jouez la carte " + playerChoice + " qui a une valeur de " + possibleCards[playerChoice]);
    }

    // retire la carte playerChoice qui vient d'être joué de la main de player
    player.RemoveCardFromHand(possibleCards[playerChoice]);
    // Tire une carte pour le pc
    int computerCard = (int)drawCards(1, computerDeck).GetValue(0);
    Console.WriteLine("Le pc a joué la carte : " + computerCard);
    // On incremente le score du gagnant
    if (possibleCards[playerChoice] > computerCard) {
        Console.WriteLine("Bravo vous avez gagné cette manche !");
        player.Score = (byte)(player.score + 1);
    } else
    {
        Console.WriteLine("Désolé c'est perdu !");
        computer.Score = (byte)(computer.score + 1);
    }
  


    // MANCHE 2
    // reassigne les cartes jouables :
    cardA = (int)player.hand.GetValue(0);
    cardB = (int)player.hand.GetValue(1);
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    Console.WriteLine(" *********************** Manche 2 ***********************");
    possibleChoices = new int[2] { 0, 1 };
    playerChoice = 99;
    Console.WriteLine("Les scores  sont : ");
    Console.WriteLine(player.name + " vous avez un score de : " + player.score);
    Console.WriteLine("Le pc a un score de " + computer.score);
    while (!possibleChoices.Contains(playerChoice))
    {
        Console.WriteLine("Quelle carte voulez-vous jouer ? ");
        Console.WriteLine("Vos cartes sont : ");
        Console.WriteLine("La carte 0 a une valeur de " + cardA);
        Console.WriteLine("La carte 1 a une valeur de " + cardB);
        Console.WriteLine("Vous devez écrire 0 ou 1");
        playerChoice = Int32.Parse(Console.ReadLine());
    }
    // retire la carte playerChoice qui vient d'être joué de la main de player
    player.RemoveCardFromHand(possibleCards[playerChoice]);
    computerCard = (int)drawCards(1, computerDeck).GetValue(0);
    Console.WriteLine("Le pc a joué une carte ayant pour valeur " + computerCard);
    // On calcul qui gagne la bataille et incremente le score du joueur qui a gagné
    if (possibleCards[playerChoice] > computerCard)
    {
        Console.WriteLine("Bravo vous avez gagné cette manche !");
        player.Score = (byte)(player.score + 1);
    }
    else
    {
        Console.WriteLine("Désolé c'est perdu !");
        computer.Score = (byte)(computer.score + 1);
    }


    // MANCHE 3
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    Console.WriteLine(" *********************** Manche 3 ***********************");
    cardA = (int)player.hand.GetValue(0);
    Console.WriteLine("C'est le dernier tour ! ");
    Console.WriteLine(" Vous jouez votre dernière carte : " + cardA);
    computerCard = (int)drawCards(1, computerDeck).GetValue(0);
    Console.WriteLine("Le pc a joué une carte ayant pour valeur " + computerCard);
    // On calcul qui gagne la bataille et incremente le score du joueur qui a gagné
    if (possibleCards[playerChoice] > computerCard)
    {
        Console.WriteLine("Bravo vous avez gagné cette manche !");
        player.Score = (byte)(player.score + 1);
    }
    else
    {
        Console.WriteLine("Désolé c'est perdu !");
        computer.Score = (byte)(computer.score + 1);
    }
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    Console.WriteLine(" *********************** La partie est terminée ! ***********************");
    Console.WriteLine(" Le joueur ... ");
    if (player.score > computer.score)
    {
        Console.WriteLine(player.name);
    }
    else { Console.WriteLine("Pc"); }
    Console.WriteLine(" ... a gagné !");
    Console.WriteLine("Les scores  sont : ");
    Console.WriteLine(player.name + " vous avez un score de : " + player.score);
    Console.WriteLine("Le pc a un score de " + computer.score);
}

