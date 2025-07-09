using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;
using UnityEngine;
using System.Reflection;

namespace Sleepys_Pharmaceuticals
{
    public class SLP_IngestionOutcomeDoer_GiveRandomHediff : IngestionOutcomeDoer
    {
        public HediffDef hediffDef;
        public float severity = -1f;
        public ChemicalDef toleranceChemical;
        private bool divideByBodySize;
        public bool multiplyByGeneToleranceFactors;
        private static System.Random random = new System.Random();

        public HediffDef GetRandomHediff()
        {
            // Use reflection to get all public static fields of type HediffDef
            FieldInfo[] fields = typeof(SLP_HediffDefOf).GetFields(BindingFlags.Public | BindingFlags.Static);

            // Filter out fields that are not of type HediffDef
            var hediffFields = fields.Where(field => field.FieldType == typeof(HediffDef)).ToList();

            // Randomly select one HediffDef
            int randomIndex = random.Next(hediffFields.Count);

            // Get the value of the randomly selected field
            hediffDef = (HediffDef)hediffFields[randomIndex].GetValue(null);

            return hediffDef;
        }

        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested, int ingestedCount)
        {
            int probabilityRoll = UnityEngine.Random.Range(1, 11);
            
            HediffDef randomHediffDef = GetRandomHediff();
            Hediff hediff = HediffMaker.MakeHediff(randomHediffDef, pawn);
            float effect = (double)this.severity <= 0.0 ? randomHediffDef.initialSeverity : this.severity;
            AddictionUtility.ModifyChemicalEffectForToleranceAndBodySize_NewTemp(pawn, this.toleranceChemical, ref effect, this.multiplyByGeneToleranceFactors, this.divideByBodySize);
            hediff.Severity = effect;
            pawn.health.AddHediff(hediff);

            if (probabilityRoll < 6) //50% Chance
            {
                HediffDef randomHediffDef2 = GetRandomHediff();
                Hediff hediff2 = HediffMaker.MakeHediff(randomHediffDef2, pawn);
                float effect2 = (double)this.severity <= 0.0 ? randomHediffDef2.initialSeverity : this.severity;
                AddictionUtility.ModifyChemicalEffectForToleranceAndBodySize_NewTemp(pawn, this.toleranceChemical, ref effect2, this.multiplyByGeneToleranceFactors, this.divideByBodySize);
                hediff2.Severity = effect2;
                pawn.health.AddHediff(hediff2);
            }

            if (probabilityRoll < 3) //20% Chance
            {
                HediffDef randomHediffDef3 = GetRandomHediff();
                Hediff hediff3 = HediffMaker.MakeHediff(randomHediffDef3, pawn);
                float effect3 = (double)this.severity <= 0.0 ? randomHediffDef3.initialSeverity : this.severity;
                AddictionUtility.ModifyChemicalEffectForToleranceAndBodySize_NewTemp(pawn, this.toleranceChemical, ref effect3, this.multiplyByGeneToleranceFactors, this.divideByBodySize);
                hediff3.Severity = effect3;
                pawn.health.AddHediff(hediff3);
            }


        }

        /*
        public override IEnumerable<StatDrawEntry> SpecialDisplayStats(ThingDef parentDef)
        {
            SLP_IngestionOutcomeDoer_GiveRandomHediff outcomeDoerGiveHediff = this;
            if (parentDef.IsDrug && (double)outcomeDoerGiveHediff.chance >= 1.0)
            {
                foreach (StatDrawEntry specialDisplayStat in outcomeDoerGiveHediff.hediffDef.SpecialDisplayStats(StatRequest.ForEmpty()))
                    yield return specialDisplayStat;
            }
        }
        */

        [DefOf]
        public class SLP_HediffDefOf
        {

            //Vanilla
            public static HediffDef AmbrosiaHigh;
            public static HediffDef GoJuiceHigh;
            public static HediffDef PenoxycylineHigh;
            public static HediffDef FlakeHigh;
            public static HediffDef PsychiteTeaHigh;
            public static HediffDef YayoHigh;
            public static HediffDef SmokeleafHigh;
            public static HediffDef WakeUpHigh;

            //This mod
            public static HediffDef AloeVeraHigh;
            public static HediffDef RimtasyHigh;
            public static HediffDef WoofHigh;
            public static HediffDef AxcelineHigh;
            public static HediffDef DaywakeHigh;
            public static HediffDef DreamerHigh;
            public static HediffDef EpinephrineHigh;
            public static HediffDef EurekaHigh;
            public static HediffDef FluVacHigh;
            public static HediffDef FusidicAcidHigh;
            public static HediffDef HunterkillerHigh;
            public static HediffDef DiaresinoakHigh;
            public static HediffDef OxyetherHigh;
            public static HediffDef ResinetherHigh;
            public static HediffDef ResinoakHigh;
            public static HediffDef StickyoakHigh;
            public static HediffDef ExoticonHigh;
            public static HediffDef HyperconHigh;
            public static HediffDef LegiconHigh;
            public static HediffDef HypercillinHigh;
            public static HediffDef PenicillinHigh;
            public static HediffDef PenicillinOintHigh;
            public static HediffDef RimshroomHigh;
            public static HediffDef RimshroomTeaHigh;
            public static HediffDef AcetylshoomHigh;
            public static HediffDef ShboomblayHigh;
            public static HediffDef SleepezeeHigh;
            public static HediffDef SpiraHigh;
            public static HediffDef AshiferCalm;
            public static HediffDef SodestCalm;
            public static HediffDef SudoseenHigh;

            //Rare
            public static HediffDef HeroHigh;
            public static HediffDef LeviathanHigh;
            public static HediffDef LucidHigh;
            public static HediffDef MiracleHigh;
            public static HediffDef MuseHigh;
        }
    }
}
