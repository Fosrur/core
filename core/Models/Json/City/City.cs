namespace core.Models.Json.City
{
    /// <summary>
    /// Definition of City
    /// </summary>
    public class City
    {
        /// <summary>
        /// Definition of Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Definition of Nome
        /// </summary>
        public string? Nome { get; set; }
        /// <summary>
        /// Definition of Provincia
        /// </summary>
        public string? Provincia { get; set; }
        /// <summary>
        /// Definition of Regione
        /// </summary>
        public string? Regione { get; set; }
        /// <summary>
        /// Definition of Nazione
        /// </summary>
        public string? Nazione { get; set; }
        /// <summary>
        /// Definition of Popolazione
        /// </summary>
        public int? Popolazione { get; set; }
        /// <summary>
        /// Definition of Superficie
        /// </summary>
        public decimal? Superficie { get; set; }
        /// <summary>
        /// Definition of Altitudine
        /// </summary>
        public int? Altitudine { get; set; }
        /// <summary>
        /// Definition of Longitudine
        /// </summary>
        public decimal Longitudine { get; set; } 
        /// <summary>
        /// Definition of Latitudine
        /// </summary>
        public decimal Latitudine { get; set; }
        /// <summary>
        /// Definition of DataFondazione
        /// </summary>
        public DateTime? DataFondazione { get; set; }
        /// <summary>
        /// Definition of SitoWeb
        /// </summary>
        public string? SitoWeb { get; set; }
        /// <summary>
        /// Definition of SitoWeb
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// Definition of CreatedUser
        /// </summary>
        public int? CreatedUser { get; set; }
        /// <summary>
        /// Definition of CreatedDate
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Definition of UpdatedUser
        /// </summary>
        public int? UpdatedUser { get; set; }
        /// <summary>
        /// Definition of UpdatedDate
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// Definition of Status
        /// </summary>
        public int Status { get; set; }
    }
}
