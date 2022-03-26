﻿namespace KreuzworträtselGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.baseWordTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UIContainerPanel = new System.Windows.Forms.Panel();
            this.exportBTN = new System.Windows.Forms.Button();
            this.showMatchesBTN = new System.Windows.Forms.Button();
            this.InsertTupleBTN = new System.Windows.Forms.Button();
            this.collectionsPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableMenu = new System.Windows.Forms.ComboBox();
            this.deleteTupleBTN = new System.Windows.Forms.Button();
            this.tuplesListBox = new System.Windows.Forms.ListBox();
            this.deleteCollectionBTN = new System.Windows.Forms.Button();
            this.newCollectionBTN = new System.Windows.Forms.Button();
            this.newTupleBTN = new System.Windows.Forms.Button();
            this.baseWordPanel = new System.Windows.Forms.Panel();
            this.showMatchesBaseWordBTN = new System.Windows.Forms.Button();
            this.InsertBaseWordBTN = new System.Windows.Forms.Button();
            this.questionAnswerPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.NoDBQuestionLBL = new System.Windows.Forms.Label();
            this.AnswerTBox = new System.Windows.Forms.TextBox();
            this.QuestionTBox = new System.Windows.Forms.TextBox();
            this.gridPB = new System.Windows.Forms.PictureBox();
            this.components = new System.ComponentModel.Container();
            this.HilfswortToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NoDBErrorLBL = new System.Windows.Forms.Label();
            this.miscUIElements = new System.Windows.Forms.Panel();
            this.UIContainerPanel.SuspendLayout();
            this.collectionsPanel.SuspendLayout();
            this.baseWordPanel.SuspendLayout();
            this.questionAnswerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPB)).BeginInit();
            this.miscUIElements.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseWordTBox
            // 
            this.baseWordTBox.Location = new System.Drawing.Point(5, 32);
            this.baseWordTBox.Margin = new System.Windows.Forms.Padding(4);
            this.baseWordTBox.Name = "baseWordTBox";
            this.baseWordTBox.Size = new System.Drawing.Size(148, 23);
            this.baseWordTBox.TabIndex = 1;
            this.baseWordTBox.TextChanged += new System.EventHandler(this.BaseWordTBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hilfswort:";
            this.HilfswortToolTip.SetToolTip(this.label1, "Das Hilfswort ist immer sichtbar für den Nutzer");
            // 
            // UIContainerPanel
            // 
            this.UIContainerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UIContainerPanel.Controls.Add(this.exportBTN);
            this.UIContainerPanel.Controls.Add(this.showMatchesBTN);
            this.UIContainerPanel.Controls.Add(this.InsertTupleBTN);
            this.UIContainerPanel.Controls.Add(this.collectionsPanel);
            this.UIContainerPanel.Controls.Add(this.baseWordPanel);
            this.UIContainerPanel.Location = new System.Drawing.Point(600, 0);
            this.UIContainerPanel.Margin = new System.Windows.Forms.Padding(4);
            this.UIContainerPanel.Name = "UIContainerPanel";
            this.UIContainerPanel.Size = new System.Drawing.Size(384, 600);
            this.UIContainerPanel.TabIndex = 3;
            // 
            // exportBTN
            // 
            this.exportBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.exportBTN.Location = new System.Drawing.Point(0, 571);
            this.exportBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exportBTN.Name = "exportBTN";
            this.exportBTN.Size = new System.Drawing.Size(382, 33);
            this.exportBTN.TabIndex = 4;
            this.exportBTN.Text = "Kreuzworträtsel exportieren";
            this.exportBTN.UseVisualStyleBackColor = true;
            this.exportBTN.Click += new System.EventHandler(this.exportBTN_Click);
            // 
            // showMatchesBTN
            // 
            this.showMatchesBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.showMatchesBTN.Enabled = false;
            this.showMatchesBTN.Location = new System.Drawing.Point(0, 540);
            this.showMatchesBTN.Name = "showMatchesBTN";
            this.showMatchesBTN.Size = new System.Drawing.Size(382, 31);
            this.showMatchesBTN.TabIndex = 13;
            this.showMatchesBTN.Text = "Übereinstimmungen anzeigen";
            this.showMatchesBTN.UseVisualStyleBackColor = true;
            this.showMatchesBTN.Click += new System.EventHandler(this.ShowMatchesBTN_Click);
            // 
            // InsertTupleBTN
            // 
            this.InsertTupleBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.InsertTupleBTN.Enabled = false;
            this.InsertTupleBTN.Location = new System.Drawing.Point(0, 513);
            this.InsertTupleBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InsertTupleBTN.Name = "InsertTupleBTN";
            this.InsertTupleBTN.Size = new System.Drawing.Size(382, 27);
            this.InsertTupleBTN.TabIndex = 5;
            this.InsertTupleBTN.Text = "Auswahl einfügen";
            this.InsertTupleBTN.UseVisualStyleBackColor = true;
            this.InsertTupleBTN.Click += new System.EventHandler(this.InsertTupleBTN_Click);
            // 
            // collectionsPanel
            // 
            this.collectionsPanel.Controls.Add(this.label2);
            this.collectionsPanel.Controls.Add(this.tableMenu);
            this.collectionsPanel.Controls.Add(this.deleteTupleBTN);
            this.collectionsPanel.Controls.Add(this.tuplesListBox);
            this.collectionsPanel.Controls.Add(this.deleteCollectionBTN);
            this.collectionsPanel.Controls.Add(this.newCollectionBTN);
            this.collectionsPanel.Controls.Add(this.newTupleBTN);
            this.collectionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.collectionsPanel.Location = new System.Drawing.Point(0, 95);
            this.collectionsPanel.Name = "collectionsPanel";
            this.collectionsPanel.Size = new System.Drawing.Size(382, 418);
            this.collectionsPanel.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sammlung auswählen:";
            // 
            // tableMenu
            // 
            this.tableMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tableMenu.FormattingEnabled = true;
            this.tableMenu.Location = new System.Drawing.Point(3, 31);
            this.tableMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableMenu.Name = "tableMenu";
            this.tableMenu.Size = new System.Drawing.Size(131, 24);
            this.tableMenu.TabIndex = 5;
            this.tableMenu.SelectedIndexChanged += new System.EventHandler(this.TableMenu_SelectedIndexChanged);
            // 
            // deleteTupleBTN
            // 
            this.deleteTupleBTN.Enabled = false;
            this.deleteTupleBTN.Location = new System.Drawing.Point(284, 367);
            this.deleteTupleBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteTupleBTN.Name = "deleteTupleBTN";
            this.deleteTupleBTN.Size = new System.Drawing.Size(76, 48);
            this.deleteTupleBTN.TabIndex = 10;
            this.deleteTupleBTN.Text = "Eintrag löschen";
            this.deleteTupleBTN.UseVisualStyleBackColor = true;
            this.deleteTupleBTN.Click += new System.EventHandler(this.DeleteTupleBTN_Click);
            // 
            // tuplesListBox
            // 
            this.tuplesListBox.FormattingEnabled = true;
            this.tuplesListBox.ItemHeight = 16;
            this.tuplesListBox.Location = new System.Drawing.Point(2, 85);
            this.tuplesListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tuplesListBox.Name = "tuplesListBox";
            this.tuplesListBox.Size = new System.Drawing.Size(358, 276);
            this.tuplesListBox.TabIndex = 7;
            this.tuplesListBox.DoubleClick += new System.EventHandler(this.TuplesListBox_DoubleClick);
            // 
            // deleteCollectionBTN
            // 
            this.deleteCollectionBTN.Enabled = false;
            this.deleteCollectionBTN.Location = new System.Drawing.Point(253, 31);
            this.deleteCollectionBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteCollectionBTN.Name = "deleteCollectionBTN";
            this.deleteCollectionBTN.Size = new System.Drawing.Size(107, 46);
            this.deleteCollectionBTN.TabIndex = 9;
            this.deleteCollectionBTN.Text = "Sammlung löschen";
            this.deleteCollectionBTN.UseVisualStyleBackColor = true;
            this.deleteCollectionBTN.Click += new System.EventHandler(this.DeleteCollectionBTN_Click);
            // 
            // newCollectionBTN
            // 
            this.newCollectionBTN.Location = new System.Drawing.Point(140, 31);
            this.newCollectionBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.newCollectionBTN.Name = "newCollectionBTN";
            this.newCollectionBTN.Size = new System.Drawing.Size(107, 46);
            this.newCollectionBTN.TabIndex = 5;
            this.newCollectionBTN.Text = "Neue Sammlung";
            this.newCollectionBTN.UseVisualStyleBackColor = true;
            this.newCollectionBTN.Click += new System.EventHandler(this.NewCollectionBTN_Click);
            // 
            // newTupleBTN
            // 
            this.newTupleBTN.Enabled = false;
            this.newTupleBTN.Location = new System.Drawing.Point(200, 367);
            this.newTupleBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.newTupleBTN.Name = "newTupleBTN";
            this.newTupleBTN.Size = new System.Drawing.Size(78, 48);
            this.newTupleBTN.TabIndex = 5;
            this.newTupleBTN.Text = "Neuer Eintrag";
            this.newTupleBTN.UseVisualStyleBackColor = true;
            this.newTupleBTN.Click += new System.EventHandler(this.NewTupleBTN_Click);
            // 
            // baseWordPanel
            // 
            this.baseWordPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baseWordPanel.Controls.Add(this.label1);
            this.baseWordPanel.Controls.Add(this.showMatchesBaseWordBTN);
            this.baseWordPanel.Controls.Add(this.baseWordTBox);
            this.baseWordPanel.Controls.Add(this.InsertBaseWordBTN);
            this.baseWordPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.baseWordPanel.Location = new System.Drawing.Point(0, 0);
            this.baseWordPanel.Name = "baseWordPanel";
            this.baseWordPanel.Size = new System.Drawing.Size(382, 95);
            this.baseWordPanel.TabIndex = 18;
            // 
            // showMatchesBaseWordBTN
            // 
            this.showMatchesBaseWordBTN.Enabled = false;
            this.showMatchesBaseWordBTN.Location = new System.Drawing.Point(173, 32);
            this.showMatchesBaseWordBTN.Name = "showMatchesBaseWordBTN";
            this.showMatchesBaseWordBTN.Size = new System.Drawing.Size(191, 46);
            this.showMatchesBaseWordBTN.TabIndex = 17;
            this.showMatchesBaseWordBTN.Text = "Übereinstimmungen anzeigen";
            this.showMatchesBaseWordBTN.UseVisualStyleBackColor = true;
            this.showMatchesBaseWordBTN.Click += new System.EventHandler(this.ShowMatchesBaseWordBTN_Click);
            // 
            // InsertBaseWordBTN
            // 
            this.InsertBaseWordBTN.Enabled = false;
            this.InsertBaseWordBTN.Location = new System.Drawing.Point(5, 60);
            this.InsertBaseWordBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InsertBaseWordBTN.Name = "InsertBaseWordBTN";
            this.InsertBaseWordBTN.Size = new System.Drawing.Size(97, 26);
            this.InsertBaseWordBTN.TabIndex = 8;
            this.InsertBaseWordBTN.Text = "Einfügen";
            this.InsertBaseWordBTN.UseVisualStyleBackColor = true;
            this.InsertBaseWordBTN.Click += new System.EventHandler(this.InsertBaseWordBTN_Click);
            // 
            // questionAnswerPanel
            // 
            this.questionAnswerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionAnswerPanel.Controls.Add(this.label4);
            this.questionAnswerPanel.Controls.Add(this.NoDBQuestionLBL);
            this.questionAnswerPanel.Controls.Add(this.AnswerTBox);
            this.questionAnswerPanel.Controls.Add(this.QuestionTBox);
            this.questionAnswerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.questionAnswerPanel.Location = new System.Drawing.Point(0, 38);
            this.questionAnswerPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.questionAnswerPanel.Name = "questionAnswerPanel";
            this.questionAnswerPanel.Size = new System.Drawing.Size(382, 125);
            this.questionAnswerPanel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Antwort eingeben: ";
            // 
            // NoDBQuestionLBL
            // 
            this.NoDBQuestionLBL.AutoSize = true;
            this.NoDBQuestionLBL.Location = new System.Drawing.Point(3, 4);
            this.NoDBQuestionLBL.Name = "NoDBQuestionLBL";
            this.NoDBQuestionLBL.Size = new System.Drawing.Size(129, 16);
            this.NoDBQuestionLBL.TabIndex = 2;
            this.NoDBQuestionLBL.Text = "Frage eingeben: ";
            // 
            // AnswerTBox
            // 
            this.AnswerTBox.Location = new System.Drawing.Point(4, 88);
            this.AnswerTBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AnswerTBox.Name = "AnswerTBox";
            this.AnswerTBox.Size = new System.Drawing.Size(248, 23);
            this.AnswerTBox.TabIndex = 1;
            this.AnswerTBox.TextChanged += new System.EventHandler(this.QuestionTBox_Or_AnswerTBox_TextChanged);
            // 
            // QuestionTBox
            // 
            this.QuestionTBox.Location = new System.Drawing.Point(3, 30);
            this.QuestionTBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QuestionTBox.Name = "QuestionTBox";
            this.QuestionTBox.Size = new System.Drawing.Size(249, 23);
            this.QuestionTBox.TabIndex = 0;
            this.QuestionTBox.TextChanged += new System.EventHandler(this.QuestionTBox_Or_AnswerTBox_TextChanged);
            // 
            // gridPB
            // 
            this.gridPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridPB.Location = new System.Drawing.Point(0, 0);
            this.gridPB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridPB.Name = "gridPB";
            this.gridPB.Size = new System.Drawing.Size(600, 600);
            this.gridPB.TabIndex = 5;
            this.gridPB.TabStop = false;
            this.gridPB.Paint += new System.Windows.Forms.PaintEventHandler(this.GridPB_Paint);
            this.gridPB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridPB_MouseClick);
            this.gridPB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridPB_MouseMove);
            // 
            // NoDBErrorLBL
            // 
            this.NoDBErrorLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.NoDBErrorLBL.ForeColor = System.Drawing.Color.Red;
            this.NoDBErrorLBL.Location = new System.Drawing.Point(0, 0);
            this.NoDBErrorLBL.Name = "NoDBErrorLBL";
            this.NoDBErrorLBL.Size = new System.Drawing.Size(382, 38);
            this.NoDBErrorLBL.TabIndex = 5;
            this.NoDBErrorLBL.Text = "Verbindung zur Datenbank konnte nicht aufgebaut werden.\r\nReduzierte Benutzeroberf" +
    "läche: ";
            // 
            // miscUIElements
            // 
            this.miscUIElements.Controls.Add(this.questionAnswerPanel);
            this.miscUIElements.Controls.Add(this.NoDBErrorLBL);
            this.miscUIElements.Location = new System.Drawing.Point(80, 86);
            this.miscUIElements.Name = "miscUIElements";
            this.miscUIElements.Size = new System.Drawing.Size(382, 414);
            this.miscUIElements.TabIndex = 7;
            this.miscUIElements.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(984, 600);
            this.Controls.Add(this.miscUIElements);
            this.Controls.Add(this.gridPB);
            this.Controls.Add(this.UIContainerPanel);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "KreuzworträtselGenerator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.UIContainerPanel.ResumeLayout(false);
            this.collectionsPanel.ResumeLayout(false);
            this.collectionsPanel.PerformLayout();
            this.baseWordPanel.ResumeLayout(false);
            this.baseWordPanel.PerformLayout();
            this.questionAnswerPanel.ResumeLayout(false);
            this.questionAnswerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPB)).EndInit();
            this.miscUIElements.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TextBox baseWordTBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel UIContainerPanel;
        private System.Windows.Forms.Button exportBTN;
        private System.Windows.Forms.ComboBox tableMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox tuplesListBox;
        private System.Windows.Forms.Button newTupleBTN;
        private System.Windows.Forms.Button InsertTupleBTN;
        private System.Windows.Forms.Button newCollectionBTN;
        private System.Windows.Forms.Button InsertBaseWordBTN;
        private System.Windows.Forms.Button deleteCollectionBTN;
        private System.Windows.Forms.Button deleteTupleBTN;
        private System.Windows.Forms.PictureBox gridPB;
        private System.Windows.Forms.Panel questionAnswerPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label NoDBQuestionLBL;
        private System.Windows.Forms.TextBox AnswerTBox;
        private System.Windows.Forms.TextBox QuestionTBox;
        private System.Windows.Forms.Button showMatchesBTN;
        private System.Windows.Forms.ToolTip HilfswortToolTip;
        private System.Windows.Forms.Panel baseWordPanel;
        private System.Windows.Forms.Button showMatchesBaseWordBTN;
        private System.Windows.Forms.Label NoDBErrorLBL;
        private System.Windows.Forms.Panel collectionsPanel;
        private System.Windows.Forms.Panel miscUIElements;
    }
}