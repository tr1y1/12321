namespace City_test
{
    partial class City_test
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(City_test));
            this.panel = new System.Windows.Forms.Panel();
            this.button_add = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.label_iteration = new System.Windows.Forms.Label();
            this.label_step = new System.Windows.Forms.Label();
            this.label_best = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_end = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.button_left = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button_up = new System.Windows.Forms.Button();
            this.label_speed = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(682, 682);
            this.panel.TabIndex = 0;
            // 
            // button_add
            // 
            this.button_add.Enabled = false;
            this.button_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_add.Location = new System.Drawing.Point(702, 12);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(130, 40);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Движение запрещено";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_delete
            // 
            this.button_delete.Enabled = false;
            this.button_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_delete.Location = new System.Drawing.Point(838, 12);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(130, 40);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "Удалить объект";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_info.Location = new System.Drawing.Point(700, 60);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(256, 15);
            this.label_info.TabIndex = 3;
            this.label_info.Text = "Координаты выбранной зоны: Не выбрано";
            // 
            // label_iteration
            // 
            this.label_iteration.AutoSize = true;
            this.label_iteration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_iteration.Location = new System.Drawing.Point(2, 29);
            this.label_iteration.Name = "label_iteration";
            this.label_iteration.Size = new System.Drawing.Size(78, 15);
            this.label_iteration.TabIndex = 4;
            this.label_iteration.Text = "Итерация: 0";
            // 
            // label_step
            // 
            this.label_step.AutoSize = true;
            this.label_step.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_step.Location = new System.Drawing.Point(2, 59);
            this.label_step.Name = "label_step";
            this.label_step.Size = new System.Drawing.Size(134, 15);
            this.label_step.TabIndex = 5;
            this.label_step.Text = "Шагов за итерацию: 0";
            // 
            // label_best
            // 
            this.label_best.AutoSize = true;
            this.label_best.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_best.Location = new System.Drawing.Point(2, 89);
            this.label_best.Name = "label_best";
            this.label_best.Size = new System.Drawing.Size(191, 15);
            this.label_best.TabIndex = 6;
            this.label_best.Text = "Лучший результат: Отсутствует";
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.Location = new System.Drawing.Point(2, 111);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(260, 40);
            this.button_start.TabIndex = 7;
            this.button_start.Text = "Start_learning";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_end
            // 
            this.button_end.Enabled = false;
            this.button_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_end.Location = new System.Drawing.Point(2, 157);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(260, 40);
            this.button_end.TabIndex = 8;
            this.button_end.Text = "Stop_learning";
            this.button_end.UseVisualStyleBackColor = true;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(1, 222);
            this.trackBar.Maximum = 9;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(260, 45);
            this.trackBar.TabIndex = 9;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.button_left);
            this.groupBox.Controls.Add(this.button_right);
            this.groupBox.Controls.Add(this.button_back);
            this.groupBox.Controls.Add(this.button_up);
            this.groupBox.Controls.Add(this.label_speed);
            this.groupBox.Controls.Add(this.button_start);
            this.groupBox.Controls.Add(this.trackBar);
            this.groupBox.Controls.Add(this.button_end);
            this.groupBox.Controls.Add(this.label_best);
            this.groupBox.Controls.Add(this.label_iteration);
            this.groupBox.Controls.Add(this.label_step);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox.Location = new System.Drawing.Point(702, 317);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(264, 377);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Управление";
            // 
            // button_left
            // 
            this.button_left.Location = new System.Drawing.Point(33, 325);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(60, 40);
            this.button_left.TabIndex = 14;
            this.button_left.Text = "Left";
            this.button_left.UseVisualStyleBackColor = true;
            this.button_left.Click += new System.EventHandler(this.button_left_Click);
            // 
            // button_right
            // 
            this.button_right.Location = new System.Drawing.Point(165, 325);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(60, 40);
            this.button_right.TabIndex = 13;
            this.button_right.Text = "Right";
            this.button_right.UseVisualStyleBackColor = true;
            this.button_right.Click += new System.EventHandler(this.button_right_Click);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(99, 325);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(60, 40);
            this.button_back.TabIndex = 12;
            this.button_back.Text = "Reverse";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_up
            // 
            this.button_up.Location = new System.Drawing.Point(99, 279);
            this.button_up.Name = "button_up";
            this.button_up.Size = new System.Drawing.Size(60, 40);
            this.button_up.TabIndex = 11;
            this.button_up.Text = "Forward";
            this.button_up.UseVisualStyleBackColor = true;
            this.button_up.Click += new System.EventHandler(this.button_up_Click);
            // 
            // label_speed
            // 
            this.label_speed.AutoSize = true;
            this.label_speed.Location = new System.Drawing.Point(6, 206);
            this.label_speed.Name = "label_speed";
            this.label_speed.Size = new System.Drawing.Size(181, 15);
            this.label_speed.TabIndex = 10;
            this.label_speed.Text = "Частота обновления: 1000 мс";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // City_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(976, 701);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(992, 740);
            this.MinimumSize = new System.Drawing.Size(992, 740);
            this.Name = "City_test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "City test";
            this.Load += new System.EventHandler(this.CityTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label_iteration;
        private System.Windows.Forms.Label label_step;
        private System.Windows.Forms.Label label_best;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_end;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_up;
        private System.Windows.Forms.Label label_speed;
        private System.Windows.Forms.Timer timer;
    }
}

