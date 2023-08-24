﻿using Hangfire.FluentNHibernateStorage.Entities;
using Hangfire.FluentNHibernateStorage.Extensions;

namespace Hangfire.FluentNHibernateStorage.Maps
{
    internal class _JobStateMap : Int32IdMapBase<_JobState>
    {
        public _JobStateMap()
        {
            Map(i => i.Name).Column("Name".WrapObjectName()).Length(Constants.StateNameLength).Not.Nullable();
            Map(i => i.Reason).Column("Reason".WrapObjectName()).Length(Constants.StateReasonLength).Nullable();
            Map(i => i.Data).Column(Constants.ColumnNames.Data.WrapObjectName()).Length(Constants.StateDataLength)
                .Nullable();
            this.MapCreatedAt();
            References(i => i.Job).Column(Constants.ColumnNames.JobId.WrapObjectName()).Not.Nullable().Cascade.Delete()
                .ForeignKey($"FK_Hangfire_{Tablename}_Job");
        }

        public override string Tablename => "JobS";
    }
}