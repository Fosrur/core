namespace core.Models
{
    /// <summary>
    /// SQL Server Configuration 
    /// </summary>
    public class SQLConfig 
    {
        /// <summary>
        /// Gets or sets the Server.
        /// </summary>
        public string? Server { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the UserID.
        /// </summary>
        public string? UserID { get; set; }

        /// <summary>
        /// Gets or sets the InitialCatalog.
        /// </summary>
        public string? InitialCatalog { get; set; }   

        /// <summary>
        /// OverrideToString
        /// </summary>
        /// <returns></returns>
        override
        public string ToString() => $"Server={Server};database={InitialCatalog};uid={UserID};password={Password}";
    }
}
