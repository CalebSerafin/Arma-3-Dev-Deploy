﻿/* 
 *  ======= Antistasi Dev Deploy =======
 * 
 * Author:			Caleb S. Serafin
 * Version:			3.1
 * Date Created:	13-10-2019
 * Date Modified:	17-12-2019
 * Memory Usage:	20 MB
 * Dynamically deploys any map template into mpmissions for testing,
 * 
 */
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static Antistasi_Dev_Deploy_Shared.GetFolderLib;
using static Antistasi_Dev_Deploy.MapHandling;
using static Antistasi_Dev_Deploy.ProgramValues;
using static Antistasi_Dev_Deploy_Shared.ProgramValues;
using static Antistasi_Dev_Deploy_Shared.Registary;
using static Antistasi_Dev_Deploy.XCopyLib;
using static Antistasi_Dev_Deploy.WindowPowerLib;
using System.Linq;

namespace Antistasi_Dev_Deploy {
	class Program {
		//Needs to be Nullable as Registry calls may return null if key does not exist.
		private static bool BoolBin(int? Input) => !Input.HasValue ? false : Input > 0;

		private static bool PBOAllFiles = false;
		private static List<string> PBOList = new List<string>();
		private static bool PBOInvoked = false;
		private static string PBOArgs = string.Empty;

		static void Main(string[] args) {
#if !DEBUG
			WindowPower.ShowWindow(WindowPower.GetConsoleWindow(), WindowPower.SW_HIDE);
#endif
			foreach (string arg in args) {
				switch (arg.Substring(0, 2).ToLower()) {
					case "/v":
						ShowMessage("Version: " + CompileTimeValue.AppVersion);
						return;
					case "/h":
						ShowMessage(
							Environment.NewLine,
							"/v                 Prints current version.",
							"/h                 Prints Help list.",
							"/p                 PBO all Map-Templates. Requires A3Tools:FileBank.",
							"/p=r               PBO List specified from ADD Configurator.",
							"/p=\"Name,Name...\"  PBO only these Map-Templates."
						);
						return;
					case "/p":
						if (!HasFileBank) {
							ShowMessage("Arma 3 Tools: FileBank not installed on system.", "FileBank's Path was not found in system registry.");
							return;
						};
						if (arg.Length <= 3) {
							PBOAllFiles = true;
						} else {
							PBOInvoked = true;
							PBOArgs = arg.Substring(3);
						};
						break;
				}
			}
			if (BoolBin((int)FetchA3DD(Reg.Value_ADD_PBOForce, 0))) {
				string PBOListString = FetchA3DD(Reg.Value_ADD_PBOList, string.Empty);
				if (PBOListString == "*") {
					PBOAllFiles = true;
					PBOInvoked = false;
				} else if (!string.IsNullOrEmpty(PBOListString)) {
					PBOAllFiles = false;
					PBOInvoked = true;
					PBOArgs = "r";
				};
			}
			if (PBOInvoked) {
				try {
					string PBOListString;
					if (PBOArgs.Substring(0, 1).ToLower() == "r") {
						PBOListString = FetchA3DD(Reg.Value_ADD_PBOList, string.Empty);
					} else {
						PBOListString = PBOArgs.ToLower();
					}
					PBOList = PBOListString.Split(',').ToList();
				} catch (Exception) {
					ShowMessage("Error processing /p= arguments.");
					throw;
				};
			}
			string Reg_Value_Arma_PlayerName_Value = FetchArma(Reg.Value_Arma_PlayerName_Name, @"empty");
			bool Reg_Value_ADD_OverrideSource_Value = BoolBin((int)FetchA3DD(Reg.Value_ADD_OverrideSource_Name, 0));
			bool Reg_Value_ADD_OverrideOutput_Value = BoolBin((int)FetchA3DD(Reg.Value_ADD_OverrideOutput_Name, 0));
			bool Reg_Value_ADD_ForceOpenOutput_Value = BoolBin((int)FetchA3DD(Reg.Value_ADD_ForceOpenOutput_Name, 0));
			//Value_ADD_LastPath;
			Registry.SetValue(Reg.Key_A3DD_ADD, Reg.Value_ADD_LastPath, System.Reflection.Assembly.GetEntryAssembly().Location, RegistryValueKind.String);

			string Reg_Value_ADD_OverrideSourceFolder_Value;
			Reg_Value_ADD_OverrideSourceFolder_Value = (string)Registry.GetValue(Reg.Key_A3DD_ADD, Reg.Value_ADD_OverrideSourceFolder_Name, "C:\\");
			if (Reg_Value_ADD_OverrideSourceFolder_Value == null) Reg_Value_ADD_OverrideSourceFolder_Value = "C:\\";
			if (!Reg_Value_ADD_OverrideSourceFolder_Value.EndsWith("\\")) Reg_Value_ADD_OverrideSourceFolder_Value += "\\";

			string CurrentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
			if (Reg_Value_ADD_OverrideSource_Value) {
				CurrentDirectory = Reg_Value_ADD_OverrideSourceFolder_Value;
			}
			string Dir_AntistasiRoot = CurrentDirectory + @"\A3-Antistasi";
			string Dir_AntistasiTemplates = CurrentDirectory + @"\Map-Templates";
			string Reg_Value_ADD_OverrideOutputFolder_Value;
			string Dir_mpMissions = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Documents\Arma 3 - Other Profiles\" + Reg_Value_Arma_PlayerName_Value + @"\mpmissions\");

			Reg_Value_ADD_OverrideOutputFolder_Value = (string)Registry.GetValue(Reg.Key_A3DD_ADD, Reg.Value_ADD_OverrideOutputFolder_Name, "C:\\");
			if (Reg_Value_ADD_OverrideOutputFolder_Value == null) Reg_Value_ADD_OverrideOutputFolder_Value = "C:\\";
			if (!Reg_Value_ADD_OverrideOutputFolder_Value.EndsWith("\\")) Reg_Value_ADD_OverrideOutputFolder_Value += "\\";
			//The following handles whether the executable is placed inside a sub folder in the root git directory.
			if (!Directory.Exists(CurrentDirectory + @"\A3-Antistasi")) {
				Dir_AntistasiRoot = CurrentDirectory + @"\..\A3-Antistasi";
				Dir_AntistasiTemplates = CurrentDirectory + @"\..\Map-Templates";
			}
			/*if there is an issue fetching Arma 3 profile name or if developing on a computer that 
			does not have Arma 3 Installed this allows it to still be able to package missions. 
			The name matches the outfolder of a python tool in the Offical Repository that does this aswell.*/
			if (Reg_Value_Arma_PlayerName_Value == string.Empty || !Directory.Exists(Dir_mpMissions)) {
				Dir_mpMissions = CurrentDirectory + @"\PackagedMissions\";
			}
			if (Reg_Value_ADD_OverrideOutput_Value) Dir_mpMissions = Reg_Value_ADD_OverrideOutputFolder_Value;
			List<MapTemplate> AntistasiMapTemplates = new List<MapTemplate>();
			if (Directory.Exists(Dir_AntistasiTemplates)) {
				string[] Templates_Directories = Directory.GetDirectories(Dir_AntistasiTemplates);
				foreach (string item in Templates_Directories) {
					string LastFolder = GetFolder(item);
					string[] TemplateData = LastFolder.Split('.');
					//If spliting by '.' does not produce two string it is probably not a map template.
					if (TemplateData.Length != 2) continue;
					AntistasiMapTemplates.Add(new MapTemplate(TemplateData));
				}
			}
#if DEBUG
			List<string> TemplateNamesDebug = new List<string>();
			foreach (MapTemplate item in AntistasiMapTemplates) {
				TemplateNamesDebug.Add(item.Name + " on map " + item.Map);
			}
			Console.WriteLine(string.Join(Environment.NewLine, TemplateNamesDebug.ToArray()));
			Console.WriteLine(string.Join(Environment.NewLine,
				CurrentDirectory,
				GetFolder(CurrentDirectory),
				Dir_AntistasiTemplates,
				Reg_Value_Arma_PlayerName_Value,
				Dir_mpMissions,
				RuntimeTimeValue.MissionVersion
			));
#endif
			Directory.CreateDirectory(Dir_mpMissions);
			foreach (MapTemplate Item in AntistasiMapTemplates) {
				string Destination = Dir_mpMissions + Item.Name + RuntimeTimeValue.MissionVersion + "." + Item.Map;
				string TemplateFolder = Dir_AntistasiTemplates + @"\" + Item.Dir;
				string XCopyArgs = "/Q";
#if DEBUG
				//The following log option is broken, thanks XCOPY ♥.
				//XCopy(Source, mpMissions + Item.Map, "/c /s /d /i /y /exclude:" + Config.Dir + Config.TIgnoreFiles + " > " + Config.Dir + "Antistasi.xcopy.log");
				Console.WriteLine("Copying " + Item.Dir + " Base&Template assets...");
				//XCopy(Dir_AntistasiRoot, Destination, "/C /S /I /Y /Exclude:" + CompileTimeValue.TIgnoreFiles, XCopyArgs);
#endif
				XCopy(Dir_AntistasiRoot, Destination, "/C /S /I /Y", XCopyArgs);
				XCopy(TemplateFolder, Destination, "/C /S /I /Y", XCopyArgs);
				if (PBOAllFiles || PBOList.Any(MapT => MapT.Equals(Item.Dir, StringComparison.OrdinalIgnoreCase))) {
					Process.Start(FileBankPath(), '\"' + Destination + '\"');
				};
			}
#if DEBUG
			ShowMessage("Press any key to open " + GetFolder(Dir_mpMissions) + ".");
			Process.Start(Dir_mpMissions + "\\");
#else
			if (Reg_Value_ADD_ForceOpenOutput_Value) {
				Process.Start(Dir_mpMissions + "\\");
			}
#endif
		}
	}
}