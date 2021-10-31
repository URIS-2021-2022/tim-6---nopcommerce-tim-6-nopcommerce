namespace Nop.Data.Migrations
{
    /// <summary>
    /// Represents target for executing a migration
    /// </summary>
    public enum MigrationTarget
    {
        /// <summary>
        /// Database schema
        /// </summary>
        Schema = 0,

        /// <summary>
        /// Database data
        /// </summary>
        Data = 5,

        /// <summary>
        /// Setting
        /// </summary>
        Settings = 10,

        /// <summary>
        /// Localization
        /// </summary>
        Localization = 15,

        /// <summary>
        /// Other targets
        /// </summary>
        Unset = 20,
    }
}