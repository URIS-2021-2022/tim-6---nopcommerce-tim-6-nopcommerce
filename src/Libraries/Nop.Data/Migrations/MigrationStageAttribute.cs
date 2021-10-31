using System;

namespace Nop.Data.Migrations
{
    /// <summary>
    /// That describe the type of migration process for the migration
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class MigrationStageAttribute : Attribute
    {
        public MigrationStageAttribute(MigrationProcess stage = MigrationProcess.Update)
        {
            Stage = stage;
        }

        public MigrationProcess Stage { get; protected set; }
    }
}