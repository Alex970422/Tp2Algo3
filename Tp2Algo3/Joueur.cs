// <copyright file="Joueur.cs" company="CSTJEAN">
// Alexandre Goddard, Ian Leblanc
// </copyright>

namespace Tp2Algo3;

/// <summary>
///     La classe de Joueur.
/// </summary>
public class Joueur
{
    /// <summary>
    ///     LinkedList vs List
    ///     On ne connait pas la quantité d'éléments à l'avance, ce qui exclut Array par défaut.
    ///     On tendait vers LinkedList au début, mais on s'est rendu compte en relisant le pdf que LinkedList est
    ///     beaucoup plus lourd en mémoire que List. La capacité à changer n'arrive que de temps en temps,
    ///     alors on a l'insertion O(1) la grande majorité du temps.
    ///     List répond au besoin de la quantité dynamique d'éléments, son grand désavantage de recopiage lors des
    ///     modifications (insertions ou suppressions au milieu) ne s'applique pas ici (insertions à la fin seulement)
    ///     et on pourrait vouloir accéder aux éléments de la structure de données facilement (Accès O(1)),
    ///     tel que l'indique l'usage du terme "historique".
    /// </summary>
    private readonly List<string> _historique = new();

    /// <summary>
    ///     Constructeur de la classe Joueur.
    /// </summary>
    /// <param name="nom"> Le nom du joueur. </param>
    public Joueur(string nom) => Nom = nom;

    /// <summary>
    ///     Le nom du Joueur.
    /// </summary>
    public string Nom { get; }

    /// <summary>
    ///     Ajoute à l'historique une action du joueur.
    /// </summary>
    /// <param name="action"> L'action du joueur (en string). </param>
    public void AjouterHistorique(string action) => _historique.Add(action);

    /// <summary>
    ///     Retourne la liste en lecture seule, pour éviter des modifications non-souhaitées.
    /// </summary>
    /// <returns> La liste historique. </returns>
    public IReadOnlyList<string> RetournerHistorique() => _historique;
}
