// <copyright file="AffichageConsole.cs" company="CSTJEAN">
// Alexandre Goddard, Ian Leblanc
// </copyright>

using System.Text;

namespace Tp2Algo3;

public class AffichageConsole
{
    public static void Afficher(MiniGolf minigolf, Map map, GestionJoueurs gestionJoueurs)
    {
        int playerCount = 0;

        StringBuilder stringBuilder = new StringBuilder();

        for (int y = 0; y < map.Hauteur; y++)
        {
            for (int x = 0; x < map.Largeur; x++)
            {
                string caseObtenue = map.ObtenirCase(x, y);
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
                     }

                    playerCount += gestionJoueurs.GetQueue(caseObtenue).Count();
                }

                Console.Write(caseObtenue);
                Console.ResetColor();
            }

            Console.Write("\n");
        }

        stringBuilder.Append("\n");
        stringBuilder.Append($"{playerCount} joueur(s) present(s) dans le mini golf");
        stringBuilder.Append("\n");

        foreach (Piste piste in minigolf.RetournerPistes())
        {
            int playercount = gestionJoueurs.GetQueue(piste.Id).Count();
            switch (playercount)
            {
                case 4:
                    stringBuilder.AppendLine("🔴   ");
                    break;
                case 3:
                    stringBuilder.AppendLine("🟡   ");
                    break;
                default:
                    stringBuilder.AppendLine("🟢   ");
                    break;
            }

            stringBuilder.AppendLine(
        $"{test}        {piste.Id,-10}{piste.Nom + " (" + piste.Difficulte + ")",-35} {playercount,2} / 4 \n");
        }

        Console.WriteLine(stringBuilder.ToString());
    
    }

    public static void AfficherHistoriqueJoueur(Joueur joueur)
    {
        Console.WriteLine($"#{joueur.Nom}#");

        foreach(string ligne in joueur.RetournerHistorique())
        {
            Console.WriteLine($"- {ligne}");
        }
    }
}
