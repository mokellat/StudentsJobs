namespace StudentsJobs.Library.Utility.ApiResponse
{
    /// <summary>
    /// Enum de gestion des codes retour des APIs
    /// </summary>
    public enum CodeReponse
    {
        /// <summary>
        /// Succès
        /// </summary>
        ok = 200,

        /// <summary>
        /// Pas de contenu
        /// </summary>
        no_content = 204,

        /// <summary>
        /// Non modifier
        /// </summary>
        not_modified = 304,

        /// <summary>
        /// Mauvaise demande 
        /// </summary>
        bad_request = 400,

        /// <summary>
        /// Non autorisée
        /// </summary>
        unauthorized = 401,

        /// <summary>
        /// Interdit
        /// </summary>
        forbidden = 403,

        /// <summary>
        /// Données non trouvées
        /// </summary>
        not_found = 404,

        /// <summary>
        /// API a retourné une erreur
        /// </summary>
        error = 500,

        /// <summary>
        /// Paramètres d'appel vide
        /// </summary>
        error_missing_all_params = 501,

        /// <summary>
        /// Paramètre(s) manquant(s) ou invalide(s)
        /// </summary>
        error_invalid_missing_params = 502,

        /// <summary>
        /// Format paramètre(s) invalide
        /// </summary>
        error_invalid_params = 503,

        /// <summary>
        /// IP non authorisée par les WS Certus
        /// </summary>
        unauthorizedIP = 620,

    }
}
