using System;
using System.Globalization;
using FluentMigrator;

namespace Nop.Data.Migrations
{
    /// <summary>
    /// Attribute for a migration
    /// </summary>
    public partial class NopMigrationAttribute : MigrationAttribute
    {
        private static long GetVersion(string dateTime)
        {
            return DateTime.ParseExact(dateTime, NopMigrationDefaults.DateFormats, CultureInfo.InvariantCulture).Ticks;
        }

        private static long GetVersion(string dateTime, MigrationTarget migrationType)
        {
            return GetVersion(dateTime) + (int)migrationType;
        }

        private static string GetDescription(string nopVersion, MigrationTarget migrationTarget)
        {
            return string.Format(NopMigrationDefaults.UpdateMigrationDescription, nopVersion, migrationTarget.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the NopMigrationAttribute class
        /// </summary>
        /// <param name="dateTime">The migration date time string to convert on version</param>
        public NopMigrationAttribute(string dateTime) :
            base(GetVersion(dateTime), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NopMigrationAttribute class
        /// </summary>
        /// <param name="dateTime">The migration date time string to convert on version</param>
        /// <param name="description">The migration description</param>
        public NopMigrationAttribute(string dateTime, string description) :
            base(GetVersion(dateTime), description)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NopMigrationAttribute class
        /// </summary>
        /// <param name="dateTime">The migration date time string to convert on version</param>
        /// <param name="nopVersion">nopCommerce full version</param>
        /// <param name="migrationTarget">The migration type</param>
        public NopMigrationAttribute(string dateTime, string nopVersion, MigrationTarget migrationTarget) :
            base(GetVersion(dateTime, migrationTarget), GetDescription(nopVersion, migrationTarget))
        {
            MigrationTarget = migrationTarget;
        }

        public MigrationTarget MigrationTarget { get; init; }
    }
}
