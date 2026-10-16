// <copyright file="Program.cs" company="CSTJEAN">
// Alexandre Goddard, Ian Leblanc
// </copyright>

namespace Tp2Algo3;

/// <summary>
/// Validation des classes et méthodes.
/// </summary>
public static class Program
{
    private static readonly MiniGolf MiniGolf = new();
    private static readonly Map Map = new();
    private static readonly GestionJoueurs GestionJoueurs = new(MiniGolf);

    private static void Afficher()
    {
        Thread.Sleep(1000);
        AffichageConsole.Afficher(MiniGolf, Map, GestionJoueurs);
    }

    private static void TestEntrerJoueur(Joueur joueur)
    {
        GestionJoueurs.EntrerJoueurDansMiniGolf(joueur);
        GestionJoueurs.EntrerJoueurDansFileAttente("P0002", joueur);
        Afficher();
    }

    private static void TestSortirJoueur(Joueur joueur)
    {
        GestionJoueurs.SortirJoueurDuMiniGolf(joueur);
        Afficher();
    }

    /// <summary>
    /// Point d'entrée du programme.
    /// </summary>
    public static void Main()
    {
        AffichageConsole.Afficher(MiniGolf, Map, GestionJoueurs);

        var joueur1 = new Joueur("Nom 1");
        TestEntrerJoueur(joueur1);

        var joueur2 = new Joueur("Nom 2");
        TestEntrerJoueur(joueur2);

        var joueur3 = new Joueur("Nom 3");
        TestEntrerJoueur(joueur3);

        var joueur4 = new Joueur("Nom 4");
        TestEntrerJoueur(joueur4);

        for (var i = 1; i <= 4; i++)
        {
            GestionJoueurs.EntrerJoueurDansPiste("P0002");
            Afficher();
        }

        TestSortirJoueur(joueur3);
        TestSortirJoueur(joueur4);
        TestSortirJoueur(joueur2);
        TestSortirJoueur(joueur1);

        AffichageConsole.AfficherHistoriqueJoueur(joueur1);
    }
}
