using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Reflection;
using Verse;

namespace FactionColonies
{
    public static class CaravanCompatibilityPatch
    {
        public static void ApplyPatches()
        {
            if (ModLister.HasActiveModWithName("Vanilla Factions Expanded - Classical"))
            {
                CompatibilityPatchManager.PatchMethod(
                    typeof(Caravan),
                    "GetGizmos",
                    typeof(CaravanCompatibilityPatch),
                    postfix: nameof(Postfix_VanillaFactionsExpandedClassical)
                );
            }

            if (ModLister.HasActiveModWithName("Inspiration Tweaks"))
            {
                CompatibilityPatchManager.PatchMethod(
                    typeof(Caravan),
                    "GetGizmos",
                    typeof(CaravanCompatibilityPatch),
                    postfix: nameof(Postfix_InspirationTweaks)
                );
            }

            if (ModLister.HasActiveModWithName("Yayo's Caravan Visual"))
            {
                CompatibilityPatchManager.PatchMethod(
                    typeof(Caravan),
                    "GetGizmos",
                    typeof(CaravanCompatibilityPatch),
                    postfix: nameof(Postfix_YayosCaravanVisual)
                );
            }
        }

        public static void Postfix_VanillaFactionsExpandedClassical(ref IEnumerable<Gizmo> __result)
        {
            // Add compatibility logic for Vanilla Factions Expanded - Classical
        }

        public static void Postfix_InspirationTweaks(ref IEnumerable<Gizmo> __result)
        {
            // Add compatibility logic for Inspiration Tweaks
        }

        public static void Postfix_YayosCaravanVisual(ref IEnumerable<Gizmo> __result)
        {
            // Add compatibility logic for Yayo's Caravan Visual
        }
    }
}
