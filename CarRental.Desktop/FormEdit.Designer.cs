namespace CarRental.Desktop
{
    partial class FormEdit
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
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            textBoxCarMake = new TextBox();
            textBoxStateNumber = new TextBox();
            label3 = new Label();
            label4 = new Label();
            numericMileage = new NumericUpDown();
            numericAvgFuelConumption = new NumericUpDown();
            label5 = new Label();
            numericFuelVolume = new NumericUpDown();
            label6 = new Label();
            numericRentalCost = new NumericUpDown();
            label7 = new Label();
            buttonOK = new Button();
            buttonCansel = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericMileage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAvgFuelConumption).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericFuelVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericRentalCost).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.BackgroundImage = Properties.Resources.soft_evening_light_captures_moving_vehicles_from_cars_view;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(515, 170);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(13, 57);
            label1.Name = "label1";
            label1.Size = new Size(319, 41);
            label1.TabIndex = 0;
            label1.Text = "Данные автомобиля";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(2, 208);
            label2.Name = "label2";
            label2.Size = new Size(189, 28);
            label2.TabIndex = 1;
            label2.Text = "Марка автомобиля";
            // 
            // textBoxCarMake
            // 
            textBoxCarMake.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxCarMake.Location = new Point(216, 208);
            textBoxCarMake.Name = "textBoxCarMake";
            textBoxCarMake.Size = new Size(296, 34);
            textBoxCarMake.TabIndex = 2;
            textBoxCarMake.TextChanged += textBoxCarMake_TextChanged;
            // 
            // textBoxStateNumber
            // 
            textBoxStateNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxStateNumber.Location = new Point(216, 250);
            textBoxStateNumber.Name = "textBoxStateNumber";
            textBoxStateNumber.Size = new Size(296, 34);
            textBoxStateNumber.TabIndex = 4;
            textBoxStateNumber.TextChanged += textBoxStateNumber_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(2, 250);
            label3.Name = "label3";
            label3.Size = new Size(107, 28);
            label3.TabIndex = 3;
            label3.Text = "Гос номер";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(2, 289);
            label4.Name = "label4";
            label4.Size = new Size(80, 28);
            label4.TabIndex = 5;
            label4.Text = "Пробег";
            // 
            // numericMileage
            // 
            numericMileage.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numericMileage.Location = new Point(216, 293);
            numericMileage.Maximum = new decimal(new int[] { 450000, 0, 0, 0 });
            numericMileage.Name = "numericMileage";
            numericMileage.Size = new Size(150, 27);
            numericMileage.TabIndex = 7;
            numericMileage.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericMileage.ValueChanged += numericMileage_ValueChanged;
            // 
            // numericAvgFuelConumption
            // 
            numericAvgFuelConumption.Location = new Point(216, 330);
            numericAvgFuelConumption.Name = "numericAvgFuelConumption";
            numericAvgFuelConumption.Size = new Size(150, 27);
            numericAvgFuelConumption.TabIndex = 9;
            numericAvgFuelConumption.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericAvgFuelConumption.ValueChanged += numericAvgFuelConumption_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(2, 326);
            label5.Name = "label5";
            label5.Size = new Size(183, 28);
            label5.TabIndex = 8;
            label5.Text = "Расход топлива (ч)";
            // 
            // numericFuelVolume
            // 
            numericFuelVolume.Location = new Point(216, 368);
            numericFuelVolume.Name = "numericFuelVolume";
            numericFuelVolume.Size = new Size(150, 27);
            numericFuelVolume.TabIndex = 11;
            numericFuelVolume.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericFuelVolume.ValueChanged += numericFuelVolume_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(2, 364);
            label6.Name = "label6";
            label6.Size = new Size(156, 28);
            label6.TabIndex = 10;
            label6.Text = "Объем топлива";
            // 
            // numericRentalCost
            // 
            numericRentalCost.Location = new Point(216, 408);
            numericRentalCost.Name = "numericRentalCost";
            numericRentalCost.Size = new Size(150, 27);
            numericRentalCost.TabIndex = 13;
            numericRentalCost.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericRentalCost.ValueChanged += numericRentalCost_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(2, 404);
            label7.Name = "label7";
            label7.Size = new Size(214, 28);
            label7.TabIndex = 12;
            label7.Text = "Стоимость аренды (м)";
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(76, 467);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(94, 29);
            buttonOK.TabIndex = 14;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCansel
            // 
            buttonCansel.DialogResult = DialogResult.Cancel;
            buttonCansel.Location = new Point(298, 467);
            buttonCansel.Name = "buttonCansel";
            buttonCansel.Size = new Size(94, 29);
            buttonCansel.TabIndex = 15;
            buttonCansel.Text = "Cansel";
            buttonCansel.UseVisualStyleBackColor = true;
            // 
            // FormEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 509);
            Controls.Add(buttonCansel);
            Controls.Add(buttonOK);
            Controls.Add(numericRentalCost);
            Controls.Add(label7);
            Controls.Add(numericFuelVolume);
            Controls.Add(label6);
            Controls.Add(numericAvgFuelConumption);
            Controls.Add(label5);
            Controls.Add(numericMileage);
            Controls.Add(label4);
            Controls.Add(textBoxStateNumber);
            Controls.Add(label3);
            Controls.Add(textBoxCarMake);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormEdit";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericMileage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAvgFuelConumption).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericFuelVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericRentalCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox textBoxCarMake;
        private TextBox textBoxStateNumber;
        private Label label3;
        private Label label4;
        private NumericUpDown numericMileage;
        private NumericUpDown numericAvgFuelConumption;
        private Label label5;
        private NumericUpDown numericFuelVolume;
        private Label label6;
        private NumericUpDown numericRentalCost;
        private Label label7;
        private Button buttonOK;
        private Button buttonCansel;
    }
}