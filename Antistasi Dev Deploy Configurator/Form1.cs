﻿using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Forms;
using static Antistasi_Dev_Deploy_Shared.ProgramValues;
using static Antistasi_Dev_Deploy_Shared.Registary;
using static Antistasi_Dev_Deploy_Shared.GetFolderLib;
using static Antistasi_Dev_Deploy_Configurator.Registary;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Antistasi_Dev_Deploy_Configurator {
	public partial class Menu : Form {
		static bool BoolBin(int? Input) {
			if (!Input.HasValue) return false;
			return Input > 0;
		}
		static int BoolBin(bool? Input) {
			if (!Input.HasValue) return 0;
			return (bool)Input ? 1 : 0;
		}
		private static string LastPath = FetchA3DD(Reg.Value_ADD_LastPath, "");
		public Menu() {
			InitializeComponent();

			chk_OverrideSource.Checked = BoolBin((int)FetchA3DD(Reg.Value_ADD_OverrideSource_Name, (int)0));
			chk_OverrideOutput.Checked = BoolBin((int)FetchA3DD(Reg.Value_ADD_OverrideOutput_Name, (int)0));
			chk_ForceOpenOutput.Checked = BoolBin((int)FetchA3DD(Reg.Value_ADD_ForceOpenOutput_Name, (int)0));
			txt_OverrideSource.Text = FetchA3DD(Reg.Value_ADD_OverrideSourceFolder_Name, "C:\\");
			txt_OverrideOutput.Text = FetchA3DD(Reg.Value_ADD_OverrideOutputFolder_Name, "C:\\");
			txt_PBOList.Text = FetchA3DD(Reg.Value_ADD_PBOList, "*");
			chk_PBOList_Override.Checked = BoolBin((int)FetchA3DD(Reg.Value_ADD_PBOForce, (int)0));

			txt_OverrideOutput.ReadOnly = !chk_OverrideOutput.Checked;
			btn_OverrideOutput_SelectPath.Enabled = chk_OverrideOutput.Checked;

			this.helpProvider1.SetShowHelp(this, true);
			this.helpProvider1.SetHelpString(this, "Antistasi Dev Deploy Configurator Version: " + CompileTimeValue.AppVersion);
		}

		private void btn_OverrideSource_SelectPath_Click(object sender, EventArgs e) {
			CommonOpenFileDialog SelecteSourceDialog = new CommonOpenFileDialog {
				InitialDirectory = txt_OverrideSource.Text,
				IsFolderPicker = true
			};
			if (SelecteSourceDialog.ShowDialog() == CommonFileDialogResult.Ok) {
				txt_OverrideSource.Text = SelecteSourceDialog.FileName + "\\";
			}
			SelecteSourceDialog.Dispose();
		}

		private void Btn_OverrideOutput_SelectPath_Click(object sender, EventArgs e) {
			CommonOpenFileDialog SelectOutputDialog = new CommonOpenFileDialog {
				InitialDirectory = txt_OverrideOutput.Text,
				IsFolderPicker = true
			};
			if (SelectOutputDialog.ShowDialog() == CommonFileDialogResult.Ok) {
				txt_OverrideOutput.Text = SelectOutputDialog.FileName + "\\";
			}
			SelectOutputDialog.Dispose();
		}

		private void btn_PBOList_SelectPath_Click(object sender, EventArgs e) {
			CommonOpenFileDialog SelectPBOListDialog = new CommonOpenFileDialog {
				InitialDirectory = Path.GetDirectoryName(LastPath),
				IsFolderPicker = true,
				Multiselect = true
			};
			if (SelectPBOListDialog.ShowDialog() == CommonFileDialogResult.Ok) {
				List<string> FileNames = SelectPBOListDialog.FileNames.ToList();
				for (int i = 0; i < FileNames.Count; i++) {
					FileNames[i] = GetFolder(FileNames[i]);
				};
				txt_PBOList.Text = string.Join(",",FileNames);
			}
			SelectPBOListDialog.Dispose();
		}

		private void btn_PBOList_Help_Click(object sender, EventArgs e) {
			MessageBox.Show("Input Map-Template Names (comma separated) that you want PBOed. Input asterisks to PBO all Map-Templates. Alternatively you can use the file picker to select the Map-Templates (Will not change source path)");
		}

		private void chk_OverrideSource_CheckedChanged(object sender, EventArgs e) {
			txt_OverrideSource.ReadOnly = !chk_OverrideSource.Checked;
			btn_OverrideSource_SelectPath.Enabled = chk_OverrideSource.Checked;
		}

		private void Chk_OverrideOutput_CheckStateChanged(object sender, EventArgs e) {
			txt_OverrideOutput.ReadOnly = !chk_OverrideOutput.Checked;
			btn_OverrideOutput_SelectPath.Enabled = chk_OverrideOutput.Checked;
		}

		private void SaveSettings() {
			Registry.SetValue(Reg.Key_A3DD_ADD, Reg.Value_ADD_OverrideSource_Name, BoolBin(chk_OverrideSource.Checked), RegistryValueKind.DWord);
			Registry.SetValue(Reg.Key_A3DD_ADD, Reg.Value_ADD_OverrideOutput_Name, BoolBin(chk_OverrideOutput.Checked), RegistryValueKind.DWord);
			Registry.SetValue(Reg.Key_A3DD_ADD, Reg.Value_ADD_OverrideSourceFolder_Name, txt_OverrideSource.Text, RegistryValueKind.String);
			Registry.SetValue(Reg.Key_A3DD_ADD, Reg.Value_ADD_OverrideOutputFolder_Name, txt_OverrideOutput.Text, RegistryValueKind.String);
			Registry.SetValue(Reg.Key_A3DD_ADD, Reg.Value_ADD_ForceOpenOutput_Name, BoolBin(chk_ForceOpenOutput.Checked), RegistryValueKind.DWord);
			Registry.SetValue(Reg.Key_A3DD_ADD, Reg.Value_ADD_PBOList, txt_PBOList.Text, RegistryValueKind.String);
			Registry.SetValue(Reg.Key_A3DD_ADD, Reg.Value_ADD_PBOForce, BoolBin(chk_PBOList_Override.Checked), RegistryValueKind.DWord);
		}

		private void Btn_Apply_Click(object sender, EventArgs e) {
			SaveSettings();
			MessageBox.Show("Configuration Applied!");
		}

		private void Btn_EraseRegistry_Click(object sender, EventArgs e) {
			DialogResult ResetConfirmation = MessageBox.Show("Are you sure you want to erase the configurations?",
					  "Erase Configurations", MessageBoxButtons.YesNo);
			if (ResetConfirmation == DialogResult.Yes) {
				EraseAll();
				MessageBox.Show("Configurations Erased!");
			}
		}

		private void btn_RunLastPath_Click(object sender, EventArgs e) {
			SaveSettings();
			if (File.Exists(LastPath)) {
				System.Diagnostics.Process.Start(LastPath);
			} else {
				MessageBox.Show("You need to run Antistasi Dev Deploy at-least once for it to save its path.");
			};
		}
	}
}
