// <copyright file="MiniGolf.cs" company="CSTJEAN">
// Alexandre Goddard, Ian Leblanc
// </copyright>

namespace Tp2Algo3;

/// <summary>
///     La classe Minigolf.
///     Charge les pistes dans le Mini-golf.
/// </summary>
public class MiniGolf
{
    /// <summary>
    ///     Dictionary est la seule structure (vu jusqu'à ici) à offrir l'accès direct via ID/Clé et de façon rapide.
    ///     O(n)* pour l'insertion et O(n) pour la suppression, ce qui convient au peu de modifications nécessaires.
    ///     Dictionary n'est pas de taille fixe, ce qui convient à la quantité inconnue de pistes.
    /// </summary>
    private readonly Dictionary<string, Piste> _pistes = new();

    /// <summary>
    ///     Constructeur de la classe MiniGolf.
    /// </summary>
    public MiniGolf()
    {
        string[] lignes = File.ReadAllLines("txts/pistes.txt");

        foreach (string ligne in lignes)
        {
            string[] donnees = ligne.Split(";");

            char symDiff = donnees[2][0];
            Difficulte difficulte = (Difficulte)symDiff;
            Piste piste = new(donnees[0], donnees[1], difficulte);
            _pistes.Add(donnees[0], piste);
        }
    }

    /// <summary>
    ///     Retourne la piste demandée par son Id.
    /// </summary>
    /// <param name="id">Le Id de la piste.</param>
    /// <returns>La piste correspondante.</returns>
    public Piste RetournerPiste(string id)
    {
        Piste piste = _pistes[id];
        return piste;
    }

    /// <summary>
    ///     Retourne toutes les pistes dans le dictionnaire.
    /// </summary>
    /// <returns>Les pistes.</returns>
    public IEnumerable<Piste> RetournerPistes() => _pistes.Values;
}
