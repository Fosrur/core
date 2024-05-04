namespace core.Models.Json.AddressBook
{
    /// <summary>
    /// Definition of AddressBook
    /// </summary>
    public class AddressBook
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
        /// Definition of Cognome
        /// </summary>
        public string? Cognome { get; set; }
        /// <summary>
        /// Definition of IdSesso
        /// </summary>
        public int IdSesso { get; set; }
        /// <summary>
        /// Definition of Sesso
        /// </summary>
        public char? Sesso { get; set; }
        /// <summary>
        /// Definition of DataNascita
        /// </summary>
        public DateTime? DataNascita { get; set; }
        /// <summary>
        /// Definition of NumeroTelefono
        /// </summary>
        public string? NumeroTelefono { get; set; }
        /// <summary>
        /// Definition of Email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Definition of IdCitta
        /// </summary>
        public int? IdCitta { get; set; }
        /// <summary>
        /// Definition of Citta
        /// </summary>
        public string? Citta { get; set; }
        /// <summary>
        /// Definition of CreatedUser
        /// </summary>
        public int CreatedUser { get; set; }
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
