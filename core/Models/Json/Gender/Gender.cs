namespace core.Models.Json.Gender
{
    /// <summary>
    /// Definition of Gender
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Definition of Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Definition of Descrizione
        /// </summary>
        public char? Descrizione { get; set; }
        /// <summary>
        /// Definition of CreatedUser
        /// </summary>
        public int CreatedUser { get; set; }
        /// <summary>
        /// Definition of CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
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
