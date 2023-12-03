using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.Sound;
using Verse.AI.Group;
using RimWorld;
using UnityEngine;

namespace Sleepys_PharmaceuticalsAddon
{
    public class SLP_CompGiveInspiration : ThingComp
    {
        public SLP_CompProperties_GiveInspiration Props => (SLP_CompProperties_GiveInspiration)this.props;

        public override void PrePostIngested(Pawn ingester)
        {
            if (ingester == null)
                return;
            InspirationDef SLP_inspiration = this.Props.SLP_inspiration;
            if (SLP_inspiration != null)
                ingester.mindState.inspirationHandler.TryStartInspiration(SLP_inspiration);
        }
    }

    public class SLP_CompProperties_GiveInspiration : CompProperties
    {
        public InspirationDef SLP_inspiration;

        public SLP_CompProperties_GiveInspiration() => this.compClass = typeof (SLP_CompGiveInspiration);
    }

}
