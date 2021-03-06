﻿namespace Antistasi_Dev_Deploy_Configurator
{
	partial class Menu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
			this.chk_OverrideOutput = new System.Windows.Forms.CheckBox();
			this.txt_OverrideOutput = new System.Windows.Forms.TextBox();
			this.btn_OverrideOutput_SelectPath = new System.Windows.Forms.Button();
			this.btn_Apply = new System.Windows.Forms.Button();
			this.btn_EraseRegistry = new System.Windows.Forms.Button();
			this.chk_ForceOpenOutput = new System.Windows.Forms.CheckBox();
			this.txt_FilterList = new System.Windows.Forms.TextBox();
			this.btn_FilterList_SelectPath = new System.Windows.Forms.Button();
			this.btn_FilterList_Help = new System.Windows.Forms.Button();
			this.chk_ForcePBO = new System.Windows.Forms.CheckBox();
			this.btn_RunLastPath = new System.Windows.Forms.Button();
			this.chk_OverrideSource = new System.Windows.Forms.CheckBox();
			this.txt_OverrideSource = new System.Windows.Forms.TextBox();
			this.btn_OverrideSource_SelectPath = new System.Windows.Forms.Button();
			this.chk_ForceFilter = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// chk_OverrideOutput
			// 
			this.chk_OverrideOutput.AutoSize = true;
			this.chk_OverrideOutput.Location = new System.Drawing.Point(12, 36);
			this.chk_OverrideOutput.Name = "chk_OverrideOutput";
			this.chk_OverrideOutput.Size = new System.Drawing.Size(133, 17);
			this.chk_OverrideOutput.TabIndex = 3;
			this.chk_OverrideOutput.Text = "Override Output Folder";
			this.toolTip1.SetToolTip(this.chk_OverrideOutput, "Use the custom directory specified.");
			this.chk_OverrideOutput.UseVisualStyleBackColor = true;
			this.chk_OverrideOutput.CheckStateChanged += new System.EventHandler(this.Chk_OverrideOutput_CheckStateChanged);
			// 
			// txt_OverrideOutput
			// 
			this.txt_OverrideOutput.Location = new System.Drawing.Point(169, 34);
			this.txt_OverrideOutput.Name = "txt_OverrideOutput";
			this.txt_OverrideOutput.ReadOnly = true;
			this.txt_OverrideOutput.Size = new System.Drawing.Size(189, 20);
			this.txt_OverrideOutput.TabIndex = 4;
			this.txt_OverrideOutput.Text = "C:/";
			this.toolTip1.SetToolTip(this.txt_OverrideOutput, "Static Address with Postfix Forward Slash.");
			// 
			// btn_OverrideOutput_SelectPath
			// 
			this.btn_OverrideOutput_SelectPath.Enabled = false;
			this.btn_OverrideOutput_SelectPath.Location = new System.Drawing.Point(364, 33);
			this.btn_OverrideOutput_SelectPath.Name = "btn_OverrideOutput_SelectPath";
			this.btn_OverrideOutput_SelectPath.Size = new System.Drawing.Size(24, 20);
			this.btn_OverrideOutput_SelectPath.TabIndex = 5;
			this.btn_OverrideOutput_SelectPath.Text = "...";
			this.toolTip1.SetToolTip(this.btn_OverrideOutput_SelectPath, "Select output folder.");
			this.btn_OverrideOutput_SelectPath.UseVisualStyleBackColor = true;
			this.btn_OverrideOutput_SelectPath.Click += new System.EventHandler(this.Btn_OverrideOutput_SelectPath_Click);
			// 
			// btn_Apply
			// 
			this.btn_Apply.Location = new System.Drawing.Point(262, 137);
			this.btn_Apply.Name = "btn_Apply";
			this.btn_Apply.Size = new System.Drawing.Size(75, 23);
			this.btn_Apply.TabIndex = 20;
			this.btn_Apply.Text = "Apply";
			this.toolTip1.SetToolTip(this.btn_Apply, "Save Values to the registary.");
			this.btn_Apply.UseVisualStyleBackColor = true;
			this.btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
			// 
			// btn_EraseRegistry
			// 
			this.btn_EraseRegistry.BackColor = System.Drawing.SystemColors.Control;
			this.btn_EraseRegistry.ForeColor = System.Drawing.Color.Red;
			this.btn_EraseRegistry.Location = new System.Drawing.Point(12, 137);
			this.btn_EraseRegistry.Name = "btn_EraseRegistry";
			this.btn_EraseRegistry.Size = new System.Drawing.Size(122, 23);
			this.btn_EraseRegistry.TabIndex = 999;
			this.btn_EraseRegistry.TabStop = false;
			this.btn_EraseRegistry.Text = "Erase Registry Values";
			this.toolTip1.SetToolTip(this.btn_EraseRegistry, "Remove all Values added by A3DD.");
			this.btn_EraseRegistry.UseVisualStyleBackColor = true;
			this.btn_EraseRegistry.Click += new System.EventHandler(this.Btn_EraseRegistry_Click);
			// 
			// chk_ForceOpenOutput
			// 
			this.chk_ForceOpenOutput.AutoSize = true;
			this.chk_ForceOpenOutput.Location = new System.Drawing.Point(12, 82);
			this.chk_ForceOpenOutput.Name = "chk_ForceOpenOutput";
			this.chk_ForceOpenOutput.Size = new System.Drawing.Size(149, 17);
			this.chk_ForceOpenOutput.TabIndex = 10;
			this.chk_ForceOpenOutput.Text = "Force Open Output Folder";
			this.toolTip1.SetToolTip(this.chk_ForceOpenOutput, "Open the folder when the operation is complete.");
			this.chk_ForceOpenOutput.UseVisualStyleBackColor = true;
			// 
			// txt_FilterList
			// 
			this.txt_FilterList.BackColor = System.Drawing.SystemColors.Window;
			this.txt_FilterList.Location = new System.Drawing.Point(169, 57);
			this.txt_FilterList.Name = "txt_FilterList";
			this.txt_FilterList.Size = new System.Drawing.Size(189, 20);
			this.txt_FilterList.TabIndex = 7;
			this.toolTip1.SetToolTip(this.txt_FilterList, "Filter on CSV of Map-Template(s).");
			// 
			// btn_FilterList_SelectPath
			// 
			this.btn_FilterList_SelectPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btn_FilterList_SelectPath.Location = new System.Drawing.Point(364, 57);
			this.btn_FilterList_SelectPath.Name = "btn_FilterList_SelectPath";
			this.btn_FilterList_SelectPath.Size = new System.Drawing.Size(24, 20);
			this.btn_FilterList_SelectPath.TabIndex = 8;
			this.btn_FilterList_SelectPath.Text = "...";
			this.toolTip1.SetToolTip(this.btn_FilterList_SelectPath, "Select Map-Template folder(s).");
			this.btn_FilterList_SelectPath.UseVisualStyleBackColor = true;
			this.btn_FilterList_SelectPath.Click += new System.EventHandler(this.btn_FilterList_SelectPath_Click);
			// 
			// btn_FilterList_Help
			// 
			this.btn_FilterList_Help.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btn_FilterList_Help.Location = new System.Drawing.Point(394, 57);
			this.btn_FilterList_Help.Name = "btn_FilterList_Help";
			this.btn_FilterList_Help.Size = new System.Drawing.Size(24, 20);
			this.btn_FilterList_Help.TabIndex = 9;
			this.btn_FilterList_Help.Text = "?";
			this.toolTip1.SetToolTip(this.btn_FilterList_Help, "Map-Template Filter Help Button.");
			this.btn_FilterList_Help.UseVisualStyleBackColor = true;
			this.btn_FilterList_Help.Click += new System.EventHandler(this.btn_FilterList_Help_Click);
			// 
			// chk_ForcePBO
			// 
			this.chk_ForcePBO.AutoSize = true;
			this.chk_ForcePBO.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.chk_ForcePBO.Location = new System.Drawing.Point(12, 105);
			this.chk_ForcePBO.Name = "chk_ForcePBO";
			this.chk_ForcePBO.Size = new System.Drawing.Size(81, 17);
			this.chk_ForcePBO.TabIndex = 11;
			this.chk_ForcePBO.Text = "Force PBO.";
			this.toolTip1.SetToolTip(this.chk_ForcePBO, "PBO all output folders.");
			this.chk_ForcePBO.UseVisualStyleBackColor = true;
			// 
			// btn_RunLastPath
			// 
			this.btn_RunLastPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btn_RunLastPath.Location = new System.Drawing.Point(343, 137);
			this.btn_RunLastPath.Name = "btn_RunLastPath";
			this.btn_RunLastPath.Size = new System.Drawing.Size(75, 23);
			this.btn_RunLastPath.TabIndex = 21;
			this.btn_RunLastPath.Text = "Run ADD";
			this.toolTip1.SetToolTip(this.btn_RunLastPath, "Save and Runs ADD.");
			this.btn_RunLastPath.UseVisualStyleBackColor = true;
			this.btn_RunLastPath.Click += new System.EventHandler(this.btn_RunLastPath_Click);
			// 
			// chk_OverrideSource
			// 
			this.chk_OverrideSource.AutoSize = true;
			this.chk_OverrideSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.chk_OverrideSource.Location = new System.Drawing.Point(12, 14);
			this.chk_OverrideSource.Name = "chk_OverrideSource";
			this.chk_OverrideSource.Size = new System.Drawing.Size(135, 17);
			this.chk_OverrideSource.TabIndex = 0;
			this.chk_OverrideSource.Text = "Override Source Folder";
			this.toolTip1.SetToolTip(this.chk_OverrideSource, "Use the custom directory specified.");
			this.chk_OverrideSource.UseVisualStyleBackColor = true;
			this.chk_OverrideSource.CheckedChanged += new System.EventHandler(this.chk_OverrideSource_CheckedChanged);
			// 
			// txt_OverrideSource
			// 
			this.txt_OverrideSource.Location = new System.Drawing.Point(169, 11);
			this.txt_OverrideSource.Name = "txt_OverrideSource";
			this.txt_OverrideSource.ReadOnly = true;
			this.txt_OverrideSource.Size = new System.Drawing.Size(189, 20);
			this.txt_OverrideSource.TabIndex = 1;
			this.txt_OverrideSource.Text = "C:/";
			this.toolTip1.SetToolTip(this.txt_OverrideSource, "Static Address with Postfix Forward Slash. Target the root of the Repository.");
			// 
			// btn_OverrideSource_SelectPath
			// 
			this.btn_OverrideSource_SelectPath.Enabled = false;
			this.btn_OverrideSource_SelectPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btn_OverrideSource_SelectPath.Location = new System.Drawing.Point(364, 11);
			this.btn_OverrideSource_SelectPath.Name = "btn_OverrideSource_SelectPath";
			this.btn_OverrideSource_SelectPath.Size = new System.Drawing.Size(24, 20);
			this.btn_OverrideSource_SelectPath.TabIndex = 2;
			this.btn_OverrideSource_SelectPath.Text = "...";
			this.toolTip1.SetToolTip(this.btn_OverrideSource_SelectPath, "Select root of the Repository.");
			this.btn_OverrideSource_SelectPath.UseVisualStyleBackColor = true;
			this.btn_OverrideSource_SelectPath.Click += new System.EventHandler(this.btn_OverrideSource_SelectPath_Click);
			// 
			// chk_ForceFilter
			// 
			this.chk_ForceFilter.AutoSize = true;
			this.chk_ForceFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.chk_ForceFilter.Location = new System.Drawing.Point(12, 59);
			this.chk_ForceFilter.Name = "chk_ForceFilter";
			this.chk_ForceFilter.Size = new System.Drawing.Size(149, 17);
			this.chk_ForceFilter.TabIndex = 6;
			this.chk_ForceFilter.Text = "Force Map-Template Filter";
			this.toolTip1.SetToolTip(this.chk_ForceFilter, "Open the folder when the operation is complete.");
			this.chk_ForceFilter.UseVisualStyleBackColor = true;
			// 
			// Menu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(422, 174);
			this.Controls.Add(this.chk_ForceFilter);
			this.Controls.Add(this.btn_OverrideSource_SelectPath);
			this.Controls.Add(this.txt_OverrideSource);
			this.Controls.Add(this.chk_OverrideSource);
			this.Controls.Add(this.btn_RunLastPath);
			this.Controls.Add(this.chk_ForcePBO);
			this.Controls.Add(this.btn_FilterList_Help);
			this.Controls.Add(this.btn_FilterList_SelectPath);
			this.Controls.Add(this.txt_FilterList);
			this.Controls.Add(this.chk_ForceOpenOutput);
			this.Controls.Add(this.btn_EraseRegistry);
			this.Controls.Add(this.btn_Apply);
			this.Controls.Add(this.btn_OverrideOutput_SelectPath);
			this.Controls.Add(this.txt_OverrideOutput);
			this.Controls.Add(this.chk_OverrideOutput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Menu";
			this.Text = "Antistasi Dev Deploy Configurator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chk_OverrideOutput;
		private System.Windows.Forms.TextBox txt_OverrideOutput;
		private System.Windows.Forms.Button btn_OverrideOutput_SelectPath;
		private System.Windows.Forms.Button btn_Apply;
		private System.Windows.Forms.Button btn_EraseRegistry;
		private System.Windows.Forms.CheckBox chk_ForceOpenOutput;
		private System.Windows.Forms.TextBox txt_FilterList;
		private System.Windows.Forms.Button btn_FilterList_SelectPath;
		private System.Windows.Forms.Button btn_FilterList_Help;
		private System.Windows.Forms.CheckBox chk_ForcePBO;
		private System.Windows.Forms.Button btn_RunLastPath;
		private System.Windows.Forms.CheckBox chk_OverrideSource;
		private System.Windows.Forms.TextBox txt_OverrideSource;
		private System.Windows.Forms.Button btn_OverrideSource_SelectPath;
		private System.Windows.Forms.CheckBox chk_ForceFilter;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}

