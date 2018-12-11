namespace shokuba_no_mondai_karuta
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSetVoice = new System.Windows.Forms.Button();
            this.labelVoicePath = new System.Windows.Forms.Label();
            this.labelVoicePathText = new System.Windows.Forms.Label();
            this.listBoxVoice = new System.Windows.Forms.ListBox();
            this.listBoxChoiceVoice = new System.Windows.Forms.ListBox();
            this.buttonRandomChoice = new System.Windows.Forms.Button();
            this.btonReset = new System.Windows.Forms.Button();
            this.labelListBoxVoiceCount = new System.Windows.Forms.Label();
            this.labelListBoxChoiceVoiceCount = new System.Windows.Forms.Label();
            this.progressBarPlayTime = new System.Windows.Forms.ProgressBar();
            this.labelPlayTime = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelFileName = new System.Windows.Forms.Panel();
            this.labelNowFileName = new System.Windows.Forms.Label();
            this.btnReplay = new System.Windows.Forms.Button();
            this.checkBoxAutoPlay = new System.Windows.Forms.CheckBox();
            this.textBoxAutoPlayDelaySec = new System.Windows.Forms.Label();
            this.numericUpDownAutoPlayDelay = new System.Windows.Forms.NumericUpDown();
            this.panelFileName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoPlayDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetVoice
            // 
            this.btnSetVoice.Location = new System.Drawing.Point(32, 37);
            this.btnSetVoice.Name = "btnSetVoice";
            this.btnSetVoice.Size = new System.Drawing.Size(122, 41);
            this.btnSetVoice.TabIndex = 0;
            this.btnSetVoice.Text = "Voice情報セット";
            this.btnSetVoice.UseVisualStyleBackColor = true;
            this.btnSetVoice.Click += new System.EventHandler(this.btnSetVoice_Click);
            // 
            // labelVoicePath
            // 
            this.labelVoicePath.AutoSize = true;
            this.labelVoicePath.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelVoicePath.Location = new System.Drawing.Point(171, 52);
            this.labelVoicePath.Name = "labelVoicePath";
            this.labelVoicePath.Size = new System.Drawing.Size(31, 15);
            this.labelVoicePath.TabIndex = 1;
            this.labelVoicePath.Text = "なし";
            // 
            // labelVoicePathText
            // 
            this.labelVoicePathText.AutoSize = true;
            this.labelVoicePathText.Location = new System.Drawing.Point(160, 37);
            this.labelVoicePathText.Name = "labelVoicePathText";
            this.labelVoicePathText.Size = new System.Drawing.Size(205, 15);
            this.labelVoicePathText.TabIndex = 2;
            this.labelVoicePathText.Text = "■現在登録されているVoicePath";
            // 
            // listBoxVoice
            // 
            this.listBoxVoice.FormattingEnabled = true;
            this.listBoxVoice.ItemHeight = 15;
            this.listBoxVoice.Location = new System.Drawing.Point(34, 104);
            this.listBoxVoice.Name = "listBoxVoice";
            this.listBoxVoice.Size = new System.Drawing.Size(151, 229);
            this.listBoxVoice.TabIndex = 3;
            this.listBoxVoice.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxVoice_MouseDoubleClick);
            // 
            // listBoxChoiceVoice
            // 
            this.listBoxChoiceVoice.FormattingEnabled = true;
            this.listBoxChoiceVoice.ItemHeight = 15;
            this.listBoxChoiceVoice.Location = new System.Drawing.Point(391, 104);
            this.listBoxChoiceVoice.Name = "listBoxChoiceVoice";
            this.listBoxChoiceVoice.Size = new System.Drawing.Size(151, 229);
            this.listBoxChoiceVoice.TabIndex = 4;
            this.listBoxChoiceVoice.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxChoiceVoice_MouseDoubleClick);
            // 
            // buttonRandomChoice
            // 
            this.buttonRandomChoice.Location = new System.Drawing.Point(191, 137);
            this.buttonRandomChoice.Name = "buttonRandomChoice";
            this.buttonRandomChoice.Size = new System.Drawing.Size(194, 152);
            this.buttonRandomChoice.TabIndex = 5;
            this.buttonRandomChoice.Text = "→ランダム再生抜出→";
            this.buttonRandomChoice.UseVisualStyleBackColor = true;
            this.buttonRandomChoice.Click += new System.EventHandler(this.buttonRandomChoice_Click);
            // 
            // btonReset
            // 
            this.btonReset.Location = new System.Drawing.Point(249, 305);
            this.btonReset.Name = "btonReset";
            this.btonReset.Size = new System.Drawing.Size(75, 28);
            this.btonReset.TabIndex = 6;
            this.btonReset.Text = "リセット";
            this.btonReset.UseVisualStyleBackColor = true;
            this.btonReset.Click += new System.EventHandler(this.btonReset_Click);
            // 
            // labelListBoxVoiceCount
            // 
            this.labelListBoxVoiceCount.AutoSize = true;
            this.labelListBoxVoiceCount.Location = new System.Drawing.Point(31, 86);
            this.labelListBoxVoiceCount.Name = "labelListBoxVoiceCount";
            this.labelListBoxVoiceCount.Size = new System.Drawing.Size(140, 15);
            this.labelListBoxVoiceCount.TabIndex = 7;
            this.labelListBoxVoiceCount.Text = "再生リスト（ 個数: 0 ）";
            // 
            // labelListBoxChoiceVoiceCount
            // 
            this.labelListBoxChoiceVoiceCount.AutoSize = true;
            this.labelListBoxChoiceVoiceCount.Location = new System.Drawing.Point(388, 86);
            this.labelListBoxChoiceVoiceCount.Name = "labelListBoxChoiceVoiceCount";
            this.labelListBoxChoiceVoiceCount.Size = new System.Drawing.Size(155, 15);
            this.labelListBoxChoiceVoiceCount.TabIndex = 8;
            this.labelListBoxChoiceVoiceCount.Text = "再生済リスト（ 個数: 0 ）";
            // 
            // progressBarPlayTime
            // 
            this.progressBarPlayTime.Location = new System.Drawing.Point(32, 360);
            this.progressBarPlayTime.Name = "progressBarPlayTime";
            this.progressBarPlayTime.Size = new System.Drawing.Size(517, 23);
            this.progressBarPlayTime.TabIndex = 9;
            // 
            // labelPlayTime
            // 
            this.labelPlayTime.AutoSize = true;
            this.labelPlayTime.Location = new System.Drawing.Point(29, 386);
            this.labelPlayTime.Name = "labelPlayTime";
            this.labelPlayTime.Size = new System.Drawing.Size(67, 15);
            this.labelPlayTime.TabIndex = 10;
            this.labelPlayTime.Text = "再生状況";
            // 
            // panelFileName
            // 
            this.panelFileName.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelFileName.Controls.Add(this.labelNowFileName);
            this.panelFileName.Location = new System.Drawing.Point(403, 12);
            this.panelFileName.Name = "panelFileName";
            this.panelFileName.Size = new System.Drawing.Size(139, 46);
            this.panelFileName.TabIndex = 11;
            this.panelFileName.Visible = false;
            // 
            // labelNowFileName
            // 
            this.labelNowFileName.Location = new System.Drawing.Point(1, 12);
            this.labelNowFileName.Name = "labelNowFileName";
            this.labelNowFileName.Size = new System.Drawing.Size(100, 23);
            this.labelNowFileName.TabIndex = 0;
            this.labelNowFileName.Text = "label1";
            this.labelNowFileName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelNowFileName_MouseDoubleClick);
            // 
            // btnReplay
            // 
            this.btnReplay.Location = new System.Drawing.Point(474, 389);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(75, 23);
            this.btnReplay.TabIndex = 12;
            this.btnReplay.Text = "Replay";
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // checkBoxAutoPlay
            // 
            this.checkBoxAutoPlay.AutoSize = true;
            this.checkBoxAutoPlay.Checked = true;
            this.checkBoxAutoPlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoPlay.Location = new System.Drawing.Point(202, 117);
            this.checkBoxAutoPlay.Name = "checkBoxAutoPlay";
            this.checkBoxAutoPlay.Size = new System.Drawing.Size(89, 19);
            this.checkBoxAutoPlay.TabIndex = 13;
            this.checkBoxAutoPlay.Text = "自動再生";
            this.checkBoxAutoPlay.UseVisualStyleBackColor = true;
            this.checkBoxAutoPlay.CheckStateChanged += new System.EventHandler(this.checkBoxAutoPlay_CheckStateChanged);
            // 
            // textBoxAutoPlayDelaySec
            // 
            this.textBoxAutoPlayDelaySec.AutoSize = true;
            this.textBoxAutoPlayDelaySec.Location = new System.Drawing.Point(363, 119);
            this.textBoxAutoPlayDelaySec.Name = "textBoxAutoPlayDelaySec";
            this.textBoxAutoPlayDelaySec.Size = new System.Drawing.Size(22, 15);
            this.textBoxAutoPlayDelaySec.TabIndex = 15;
            this.textBoxAutoPlayDelaySec.Text = "秒";
            // 
            // numericUpDownAutoPlayDelay
            // 
            this.numericUpDownAutoPlayDelay.Location = new System.Drawing.Point(297, 114);
            this.numericUpDownAutoPlayDelay.Name = "numericUpDownAutoPlayDelay";
            this.numericUpDownAutoPlayDelay.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownAutoPlayDelay.TabIndex = 16;
            this.numericUpDownAutoPlayDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAutoPlayDelay.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 442);
            this.Controls.Add(this.panelFileName);
            this.Controls.Add(this.numericUpDownAutoPlayDelay);
            this.Controls.Add(this.textBoxAutoPlayDelaySec);
            this.Controls.Add(this.checkBoxAutoPlay);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.labelPlayTime);
            this.Controls.Add(this.progressBarPlayTime);
            this.Controls.Add(this.labelListBoxChoiceVoiceCount);
            this.Controls.Add(this.labelListBoxVoiceCount);
            this.Controls.Add(this.btonReset);
            this.Controls.Add(this.buttonRandomChoice);
            this.Controls.Add(this.listBoxChoiceVoice);
            this.Controls.Add(this.listBoxVoice);
            this.Controls.Add(this.labelVoicePathText);
            this.Controls.Add(this.labelVoicePath);
            this.Controls.Add(this.btnSetVoice);
            this.Name = "Form1";
            this.Text = "職場の問題かるた";
            this.panelFileName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoPlayDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetVoice;
        private System.Windows.Forms.Label labelVoicePath;
        private System.Windows.Forms.Label labelVoicePathText;
        private System.Windows.Forms.ListBox listBoxVoice;
        private System.Windows.Forms.ListBox listBoxChoiceVoice;
        private System.Windows.Forms.Button buttonRandomChoice;
        private System.Windows.Forms.Button btonReset;
        private System.Windows.Forms.Label labelListBoxVoiceCount;
        private System.Windows.Forms.Label labelListBoxChoiceVoiceCount;
        private System.Windows.Forms.ProgressBar progressBarPlayTime;
        private System.Windows.Forms.Label labelPlayTime;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelFileName;
        private System.Windows.Forms.Label labelNowFileName;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.CheckBox checkBoxAutoPlay;
        private System.Windows.Forms.Label textBoxAutoPlayDelaySec;
        private System.Windows.Forms.NumericUpDown numericUpDownAutoPlayDelay;
    }
}

