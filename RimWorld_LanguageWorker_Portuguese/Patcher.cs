// <code-header>
//   <author>b606</author>
//   <summary>
//		libHarmony patches manager.
//	 </summary>
// </code-header>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using HarmonyLib;
using Verse;
using Verse.Grammar;

namespace RimWorld_LanguageWorker_Portuguese
{
	public static class LanguageWorkerPatcher
	{
		public static Type GetWorkerType() => typeof(LanguageWorker_Portuguese);

		public static bool IsTargetLanguage(string aLang) => LanguageWorker_Portuguese.IsTargetLanguage(aLang);

		public static string GetTargetLanguageFamily() => LanguageWorker_Portuguese.GetTargetLanguageFamily();

		public static void LogMessage(string a_str) => LanguageWorker_Portuguese.LogMessage(a_str);

		public static void FixPawnGender(ref PawnKindDef kind, ref Gender gender, string relationInfo)
		{
			LanguageWorker_Portuguese.FixPawnGender(ref kind, ref gender, relationInfo);
		}

		public static IEnumerable<Rule> FixRulesForBodyPartRecord(string prefix, BodyPartRecord part)
		{
			return LanguageWorker_Portuguese.FixRulesForBodyPartRecord(prefix, part);
		}

		public static IEnumerable<Rule> FixRulesForDef(string prefix, Def def)
		{
			return LanguageWorker_Portuguese.FixRulesForDef(prefix, def);
		}

		public static void DoPatching()
		{
#if DEBUG
			Harmony.DEBUG = true;
#endif
			try
			{
				Harmony harmony = new Harmony(id: "com.b606.mods.languageworker" + GetTargetLanguageFamily());
				Assembly assembly = Assembly.GetExecutingAssembly();

				LogMessage("Installing com.b606.mods.languageworker" + GetTargetLanguageFamily() + "...");
				LogMessage(string.Format("Active language: {0}",
					LanguageDatabase.activeLanguage.FriendlyNameEnglish));

				harmony.PatchAll(assembly);
				InspectPatches(harmony);

				LogMessage("Done.");
			}
			catch (Exception e)
			{
				LogMessage("Mod installation failed.");
				LogMessage(string.Format("Exception: {0}", e));
			}
		}

		// Retrieve all patches
		[Conditional("DEBUG")]
		public static void InspectPatches(Harmony harmony)
		{
			try
			{
				LogMessage("Existing patches:");

				IEnumerable<MethodBase> myOriginalMethods = harmony.GetPatchedMethods();
				foreach (MethodBase method in myOriginalMethods)
				{
					Patches patches = Harmony.GetPatchInfo(method);
					if (patches != null)
					{
						foreach (var patch in patches.Prefixes)
						{
							// already patched
							LogMessage("index: " + patch.index);
							LogMessage("owner: " + patch.owner);
							LogMessage("patch method: " + patch.PatchMethod);
							LogMessage("priority: " + patch.priority);
							LogMessage("before: " + patch.before.Join());
							LogMessage("after: " + patch.after.Join());
						}
					}
				}
			}
			catch (Exception e)
			{
				LogMessage("Patches inspection failed.");
				LogMessage(string.Format("Exception: {0}", e));
			}
		}
	}
}
