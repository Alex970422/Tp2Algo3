// <copyright file="AffichageConsole.cs" company="CSTJEAN">
// Alexandre Goddard, Ian Leblanc
// </copyright>

using System.Text;

namespace Tp2Algo3;

public class AffichageConsole
{
    public void Afficher(MiniGolf minigolf, Map map, GestionJoueurs gestionJoueurs)
    {
        for (int y = 0; y < map.Hauteur; y++)
        {
            StringBuilder stringbuilder = new StringBuilder();

            for (int x = 0; x < map.Largeur; x++)
            {
                stringbuilder.Append(map.ObtenirCase(x, y));
            }

            Console.WriteLine(stringbuilder.ToString());
        }
    }

    public void AffichageHistoriqueJoueurs()
    {

    }
}
