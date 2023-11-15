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
    public class SLP_HediffComp_CureAddition : HediffComp
    {
        public void SLP_CureAddiction(Pawn pawn)
        {
            Hediff_Addiction addiction = SLP_PHA_Utilities.SLP_FindAddiction(pawn);
            if (addiction != null)
                pawn.health.RemoveHediff(addiction);
            else
                System.Console.WriteLine("Pawn had no addiction to cure");
        }
    }

    public class SLP_PHA_Utilities
    {
        public static Hediff_Addiction SLP_FindAddiction(Pawn pawn)
        {
            List<Hediff> hediffs = pawn.health.hediffSet.hediffs.ToList();
            for (int index = 0; index < hediffs.Count; ++index)
            {
                //if (hediffs[index] is Hediff_Addiction addiction && addiction.Visible && addiction.def.everCurableByItem)
                if (hediffs[index] is Hediff_Addiction addiction)
                return addiction;
            }
            return (Hediff_Addiction)null;
        }

    }
}
