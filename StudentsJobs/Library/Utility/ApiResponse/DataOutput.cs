using System;
using System.Collections;
using System.Collections.Generic;

namespace StudentsJobs.Library.Utility.ApiResponse
{
    /// <summary>
    /// Classe de gestion des objets de retour des APIs
    /// </summary>
    public class DataOutput
    {
        /// <summary>
        /// Codes d'état de réponse HTTP
        /// </summary>
        public CodeReponse status_code { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Les données
        /// </summary>
        public IEnumerable data { get; set; }

        /// <summary>
        /// Nombres de lignes
        /// </summary>
        public Int64 nb_rows { get; set; }

        /// <summary>
        /// Total de lignes
        /// </summary>
        public Int64 total_rows { get; set; }

        /// <summary>
        /// Constructeur sans argument 
        /// </summary>
        public DataOutput()
        {
            this.data = new List<object>();
            this.nb_rows = 0;
            this.total_rows = 0;
        }
    }
}
