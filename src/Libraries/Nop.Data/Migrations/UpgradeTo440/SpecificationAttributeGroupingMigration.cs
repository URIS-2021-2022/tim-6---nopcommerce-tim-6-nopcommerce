﻿using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Data.Mapping;
using Nop.Data.Extensions;

namespace Nop.Data.Migrations.UpgradeTo440
{
    [NopMigration("2020/03/08 11:26:08:9037680", "Specification attribute grouping", MigrationTarget = MigrationTarget.Schema)]
    [MigrationStage(MigrationProcess.Update)]
    public class SpecificationAttributeGroupingMigration : ForwardOnlyMigration
    {
        #region Methods

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(SpecificationAttributeGroup))).Exists())
                Create.TableFor<SpecificationAttributeGroup>();

            if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(SpecificationAttribute))).Column(nameof(SpecificationAttribute.SpecificationAttributeGroupId)).Exists())
            {
                //add new column
                Alter.Table(NameCompatibilityManager.GetTableName(typeof(SpecificationAttribute)))
                    .AddColumn(nameof(SpecificationAttribute.SpecificationAttributeGroupId)).AsInt32().Nullable().ForeignKey<SpecificationAttributeGroup>();
            }
        }

        #endregion
    }
}
