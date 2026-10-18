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

        /// <summary>
        ///     Construceur du minigolf, initialise les files d'attente pour toutes les pistes du mini-golf.
        /// </summary>
        /// <param name="minigolf">
        ///     Le mini-golf contenant les pistes à initialiser.
        /// </param>
        public GestionJoueurs(MiniGolf minigolf)
        {
            foreach (Piste piste in minigolf.RetournerPistes())
            {
                _filesAttente.Add(piste.Id, new Queue<Joueur>());
            }
        }

        /// <summary>
        ///     Ajoute un joueur à la file d'attente d'une piste et enregistre l'action dans son historique.
        /// </summary>
        /// <param name="pisteId">
        ///     L'identifiant de la piste.
        /// </param>
        /// <param name="joueur">
        ///     Le joueur à ajouter à la file d'attente.
        /// </param>
        public void EntrerJoueurDansFileAttente(string pisteId, Joueur joueur)
        {
            _filesAttente[pisteId].Enqueue(joueur);
            joueur.AjouterHistorique($"C'est ajoute a la fille d'attente de la piste{pisteId}");
        }

        /// <summary>
        ///     Retire le premier joueur de la file d'attente d'une piste et enregistre son entree dans la piste dans son historique.
        /// </summary>
        /// <param name="pisteId">
        ///     L'identifiant de la piste.
        /// </param>
        public void EntrerJoueurDansPiste(string pisteId)
        {
           Joueur joueur = _filesAttente[pisteId].Dequeue();
           joueur.AjouterHistorique($"Est entre dans la piste {pisteId}");
        }

        /// <summary>
        ///     Ajoute un joueur à la liste des joueurs présents dans le mini-golf et enregistre son entree dans son historique.
        /// </summary>
        /// <param name="joueur">
        ///     Le joueur qui entre dans le mini-golf.
        /// </param>
        public void EntrerJoueurDansMiniGolf(Joueur joueur)
        {
            _joueurs.AddLast(joueur);
            joueur.AjouterHistorique("Est entre au minigolf");
        }

        /// <summary>
        ///     Retire un joueur de la liste des joueurs présents dans le mini-golf et enregistre son depart dans son historique.
        /// </summary>
        /// <param name="joueur">
        ///     Le joueur qui quitte le mini-golf.
        /// </param>
        public void SortirJoueurDuMiniGolf(Joueur joueur)
        {
            _joueurs.Remove(joueur);
            joueur.AjouterHistorique("Sortir du minigolf");
        }

        /// <summary>
        ///     Retourne la file d'attente associée à une piste.
        /// </summary>
        /// <param name="pisteId">
        ///     L'identifiant de la piste dont on souhaite obtenir la file d'attente.
        /// </param>
        /// <returns>
        ///     La file d'attente des joueurs associés à la piste spécifiée.
        /// </returns>
        public Queue<Joueur> GetQueue(string pisteId) => _filesAttente[pisteId];
    }
}
