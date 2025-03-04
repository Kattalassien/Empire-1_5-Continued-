using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FactionColonies
{
    public static class CompatibilityPatchManager
    {
        private static readonly List<Action> patchActions = new List<Action>();

        public static void RegisterPatch(Action patchAction)
        {
            patchActions.Add(patchAction);
        }

        public static void ApplyPatches()
        {
            foreach (var patchAction in patchActions)
            {
                patchAction.Invoke();
            }
        }

        public static void PatchMethod(Type targetType, string methodName, Type patchType, string prefix = null, string postfix = null)
        {
            var harmony = new Harmony("com.factioncolonies.compatibilitypatches");
            var original = targetType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var prefixMethod = prefix != null ? patchType.GetMethod(prefix, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) : null;
            var postfixMethod = postfix != null ? patchType.GetMethod(postfix, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) : null;

            harmony.Patch(original, prefixMethod != null ? new HarmonyMethod(prefixMethod) : null, postfixMethod != null ? new HarmonyMethod(postfixMethod) : null);
        }
    }
}
