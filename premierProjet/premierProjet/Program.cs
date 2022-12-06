// explication des regles
// on crée un nouveau joueur qui crée un nouveau deck qui cree des cards
// Tant que le score du player 1 + score player 2 =/= 5 on boucle
/* A chaque tour :
 *      - P1 retire une card de son deck et l'ajoute à sa main
 *      - La main est affiché à l'écran
 *      - P1 choisit une carte : elle est retiré de la main
 *      - P2 tire aléatoirement une carte
 *      - VS des cartes 1 score s'incrémente
 */

using premierProjet.Library;

// intro + get player name
Console.WriteLine("C'est un jeu de carte très basique, vous affrontez le pc");
Console.WriteLine("Votre deck est composé des 13 cartes d'un jeu classique (sans couleur)");
Console.WriteLine("Le premier arrivé à 3 points gagne la partie");
Console.WriteLine("Comme vous tirez une nouvelle carte à chaque début de tour");
Console.WriteLine("Et que votre main ne possède que 3 cartes vous ne piocherai pas toutes les cartes du deck");
Console.WriteLine("Comment vous appellez vous ?");

string playerName;
playerName = Console.ReadLine(); // while pas tring

// build cards and deck
int[] Cards = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
Deck playerDeck = new Deck(Cards);
Deck computerDeck = new Deck(Cards);


// build players
Player player = new Player(playerName, playerDeck, 0, null);
Player computer = new Player("Ordinateur", computerDeck, 0, null);


// Game
while (player.score + computer.score < 5)
{
    Console.WriteLine(player.name + " a un score de : " + player.score);
    Console.WriteLine(player.name + " la 1er carte dans son deck est : " + player.deck.CurrentDeck);

    player.Score = (byte)(player.score + 1);
}


