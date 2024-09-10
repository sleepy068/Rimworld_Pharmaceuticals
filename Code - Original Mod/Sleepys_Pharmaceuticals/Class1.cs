using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.Sound;
using Verse.AI.Group;
using RimWorld;
using UnityEngine;

namespace Sleepys_Pharmaceuticals
{
    public class SLP_IngestionOutcomeDoer_GiveHediff : IngestionOutcomeDoer
    {
        public HediffDef hediffDef;
        public float severity = -1f;
        public ChemicalDef toleranceChemical;
        private bool divideByBodySize;
        public bool multiplyByGeneToleranceFactors;

        public Hediff FindHediffToApply()
        {
            
            int getHediffInt = UnityEngine.Random.Range(1, 7);

        }


        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested, int ingestedCount)
        {
            Hediff hediff = HediffMaker.MakeHediff(this.hediffDef, pawn);
            float effect = (double)this.severity <= 0.0 ? this.hediffDef.initialSeverity : this.severity;
            AddictionUtility.ModifyChemicalEffectForToleranceAndBodySize_NewTemp(pawn, this.toleranceChemical, ref effect, this.multiplyByGeneToleranceFactors, this.divideByBodySize);
            hediff.Severity = effect;
            pawn.health.AddHediff(hediff);
        }

        public override IEnumerable<StatDrawEntry> SpecialDisplayStats(
          ThingDef parentDef)
        {
            IngestionOutcomeDoer_GiveHediff outcomeDoerGiveHediff = this;
            if (parentDef.IsDrug && (double)outcomeDoerGiveHediff.chance >= 1.0)
            {
                foreach (StatDrawEntry specialDisplayStat in outcomeDoerGiveHediff.hediffDef.SpecialDisplayStats(StatRequest.ForEmpty()))
                    yield return specialDisplayStat;
            }
        }

        [DefOf]
        public class SLP_HediffDefOf
        {
            public static HediffDef AloeVeraHigh;
            public static HediffDef RimtasyHigh;
            public static HediffDef WoofHigh;
            public static HediffDef AxcelineHigh;
            public static HediffDef DaywakeHigh;
            public static HediffDef DreamerHigh;
        }
}
