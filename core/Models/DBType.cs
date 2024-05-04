namespace core.Models
{
    /// <summary>
    /// DBType Configuration 
    /// </summary>
    public class DBType
    {
        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public string? dbType { get; set; }

        /// <summary>
        /// OverrideToString
        /// </summary>
        /// <returns></returns>
        override
        public string ToString() => $"dbType={dbType}";
    }
}
