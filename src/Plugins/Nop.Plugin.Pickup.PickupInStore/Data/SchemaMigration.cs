using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Pickup.PickupInStore.Domain;

namespace Nop.Plugin.Pickup.PickupInStore.Data
{
    [NopMigration("2020/02/03 09:30:17:6455422", "Pickup.PickupInStore base schema", MigrationTarget = MigrationTarget.Schema)]
    [MigrationStage(MigrationProcess.Install)]
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.TableFor<StorePickupPoint>();
        }
    }
}