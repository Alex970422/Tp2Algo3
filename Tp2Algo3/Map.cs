// <copyright file="Map.cs" company="CSTJEAN">
// Alexandre Goddard, Ian Leblanc
// </copyright>

namespace Tp2Algo3;

/// <summary>
///     Classe Map, qui charge la carte du mini-golf.
/// </summary>
public class Map
{
    /// <summary>
    ///     Taille fixe : Array est la seule structure vue en cours (à date) qui est de taille fixe.
    ///     Aucune modification : Array est parfait pour ce rôle, il est hautement efficace en accès (O(1)).
    ///     On évite aussi les désavantages de cette structure (O(n) en insertion et suppression).
    ///     C'est un choix évident.
    /// </summary>
    private readonly string[,] _grille;

    /// <summary>
    ///     Constructeur de Map.
    /// </summary>
    public Map()
    {
        string[] lignes = File.ReadAllLines("txts/map.txt");
        string[] taille = lignes[0].Split(';');
        Hauteur = int.Parse(taille[0]);
        Largeur = int.Parse(taille[1]);

        _grille = new string[Hauteur, Largeur];

        for (int i = 0; i < Hauteur; i++)
        {
            string[] ligne = lignes[i + 1].Split("   ");
            for (int j = 0; j < Largeur; j++)
            {
                _grille[i, j] = ligne[j];
            }
        }
    }

    /// <summary>
    ///     La hauteur du tableau.
    /// </summary>
    public int Hauteur { get; }

    /// <summary>
    ///     La Largeur du tableau.
    /// </summary>
    public int Largeur { get; }

    /// <summary>
    ///     Méthode pour éviter la modification du tableau original.
    ///     Retourne l'élément souhaité.
    /// </summary>
    /// <param name="ligne">La ligne voulue.</param>
    /// <param name="colonne">La colonne voulue.</param>
    /// <returns>L'élément du tableau. </returns>
    public string ObtenirCase(int ligne, int colonne) => _grille[ligne, colonne];
}
