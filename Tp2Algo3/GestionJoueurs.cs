// <copyright file="GestionJoueurs.cs" company="CSTJEAN">
// Alexandre Goddard, Ian Leblanc
// </copyright>

namespace Tp2Algo3
{
    /// <summary>
    /// Classe.
    /// </summary>
    public class GestionJoueurs
    {
        /// <summary>
        /// Les modifications fréquentes, c'est la grande force de LinkedList (O(1) pour insertion et suppression).
        /// Pas d'accès direct aux données, on évite la grande faiblesse de LinkedList.
        /// </summary>
        private readonly LinkedList<Joueur> _joueurs = new();

        /// <summary>
        /// On prend Dictionary à cause de la paire Id et valeur, ce qui nous permet d'accéder facilement à une piste
        /// et à sa liste de Joueurs associée. On prend la structure Queue pour gérer nos joueurs, car on est en principe
        /// FIFO et il y a beaucoup d'ajouts et de retraits aux extrémités.
        /// String, id de la piste.
        /// </summary>
        private readonly Dictionary<string, Queue<Joueur>> _filesAttente = new();
    }
}
