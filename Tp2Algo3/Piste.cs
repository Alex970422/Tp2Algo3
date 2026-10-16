// <copyright file="Piste.cs" company="CSTJEAN">
// Alexandre Goddard, Ian Leblanc
// </copyright>

namespace Tp2Algo3;

/// <summary>
///     Classe pour Piste.
/// </summary>
public class Piste
{
    /// <summary>
    ///     Constructeur de Piste.
    /// </summary>
    /// <param name="id">Identifiant, de type String, de la piste.</param>
    /// <param name="nom">Nom de la piste.</param>
    /// <param name="difficulte">Difficulté de la piste (Enum).</param>
    public Piste(string id, string nom, Difficulte difficulte)
    {
        Id = id;
        Nom = nom;
        Difficulte = difficulte;
    }

    /// <summary>
    ///     Retourne l'Id.
    /// </summary>
    public string Id { get; }

    /// <summary>
    ///     Retourne le nom.
    /// </summary>
    public string Nom { get; }

    /// <summary>
    ///     Retourne la difficulté.
    /// </summary>
    public Difficulte Difficulte { get; }
}
