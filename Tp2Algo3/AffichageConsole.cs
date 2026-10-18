// <copyright file="AffichageConsole.cs" company="CSTJEAN">
// Alexandre Goddard, Ian Leblanc
// </copyright>

using System.Text;

namespace Tp2Algo3;

/// <summary>
///     Gère l'affichage des informations du mini-golf dans la console.
/// </summary>
public class AffichageConsole
{
    /// <summary>
    ///     Affiche la carte du mini-golf, le nombre de joueurs présents ainsi que l'état d'occupation de chaque piste.
    /// </summary>
    /// <param name="minigolf">
    ///     Le mini-golf.
    /// </param>
    /// <param name="map">
    ///     La carte du mini-golf contenant les cases à afficher.
    /// </param>
    /// <param name="gestionJoueurs">
    ///     Le gestionnaire permettant d'obtenir les joueurs présents sur chaque piste.
    /// </param>
    public static void Afficher(MiniGolf minigolf, Map map, GestionJoueurs gestionJoueurs)
    {
        Console.OutputEncoding = Encoding.UTF8;

        StringBuilder stringBuilder = new();

        for (int y = 0; y < map.Hauteur; y++)
        {
            for (int x = 0; x < map.Largeur; x++)
            {
                string caseObtenue = map.ObtenirCase(y, x);
                if (caseObtenue != "-----")
                {
                    switch (gestionJoueurs.GetQueue(caseObtenue).Count())
                    {
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                    }
                }

                Console.Write(caseObtenue);
                Console.ResetColor();
            }

            Console.Write("\n");
        }

        stringBuilder.Append("\n");
        stringBuilder.AppendLine($"{gestionJoueurs.NombreJoueurs} joueur(s) présent(s) dans le mini-golf. \n");

        foreach (Piste piste in minigolf.RetournerPistes())
        {
            int playercount = gestionJoueurs.GetQueue(piste.Id).Count();
            switch (playercount)
            {
                case 4:
                    stringBuilder.Append("🔴   ");
                    break;
                case 3:
                    stringBuilder.Append("🟡   ");
                    break;
                default:
                    stringBuilder.Append("🟢   ");
                    break;
            }

            stringBuilder.Append(
                $"{piste.Id,-10}{piste.Nom + " (" + (char)piste.Difficulte + ")",-35} {playercount,2} / 4 \n");
        }

        Console.WriteLine(stringBuilder.ToString());
    }

    /// <summary>
    ///     Affiche le nom d'un joueur et les entrées de son historique.
    /// </summary>
    /// <param name="joueur">
    ///     Le joueur dont l'historique doit être affiché.
    /// </param>
    public static void AfficherHistoriqueJoueur(Joueur joueur)
    {
        Console.WriteLine($"### {joueur.Nom} ###");

        foreach (string ligne in joueur.RetournerHistorique())
        {
            Console.WriteLine($"- {ligne}");
        }
    }
}
