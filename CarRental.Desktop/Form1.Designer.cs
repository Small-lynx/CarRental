﻿namespace CarRental.Desktop
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStripCar = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton3 = new ToolStripButton();
            statusStripCar = new StatusStrip();
            toolStripStatusAllCar = new ToolStripStatusLabel();
            toolStripStatusLowFuel = new ToolStripStatusLabel();
            DataGridCar = new DataGridView();
            ColumnMake = new DataGridViewTextBoxColumn();
            ColumnNumber = new DataGridViewTextBoxColumn();
            ColumnMileage = new DataGridViewTextBoxColumn();
            ColumnAvgFuel = new DataGridViewTextBoxColumn();
            ColumnFuel = new DataGridViewTextBoxColumn();
            ColumnCost = new DataGridViewTextBoxColumn();
            ColumnRangeFuel = new DataGridViewTextBoxColumn();
            ColumnRentalAmount = new DataGridViewTextBoxColumn();
            toolStripCar.SuspendLayout();
            statusStripCar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridCar).BeginInit();
            SuspendLayout();
            // 
            // toolStripCar
            // 
            toolStripCar.ImageScalingSize = new Size(20, 20);
            toolStripCar.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripSeparator1, toolStripButton3 });
            toolStripCar.Location = new Point(0, 0);
            toolStripCar.Name = "toolStripCar";
            toolStripCar.Size = new Size(800, 27);
            toolStripCar.TabIndex = 0;
            toolStripCar.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(29, 24);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(29, 24);
            toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(29, 24);
            toolStripButton3.Text = "toolStripButton3";
            // 
            // statusStripCar
            // 
            statusStripCar.ImageScalingSize = new Size(20, 20);
            statusStripCar.Items.AddRange(new ToolStripItem[] { toolStripStatusAllCar, toolStripStatusLowFuel });
            statusStripCar.Location = new Point(0, 424);
            statusStripCar.Name = "statusStripCar";
            statusStripCar.Size = new Size(800, 26);
            statusStripCar.TabIndex = 1;
            statusStripCar.Text = "statusStrip1";
            // 
            // toolStripStatusAllCar
            // 
            toolStripStatusAllCar.Name = "toolStripStatusAllCar";
            toolStripStatusAllCar.Size = new Size(33, 20);
            toolStripStatusAllCar.Text = "123";
            // 
            // toolStripStatusLowFuel
            // 
            toolStripStatusLowFuel.Name = "toolStripStatusLowFuel";
            toolStripStatusLowFuel.Size = new Size(25, 20);
            toolStripStatusLowFuel.Text = "45";
            // 
            // DataGridCar
            // 
            DataGridCar.AllowUserToAddRows = false;
            DataGridCar.AllowUserToDeleteRows = false;
            DataGridCar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridCar.Columns.AddRange(new DataGridViewColumn[] { ColumnMake, ColumnNumber, ColumnMileage, ColumnAvgFuel, ColumnFuel, ColumnCost, ColumnRangeFuel, ColumnRentalAmount });
            DataGridCar.Dock = DockStyle.Fill;
            DataGridCar.Location = new Point(0, 27);
            DataGridCar.Name = "DataGridCar";
            DataGridCar.ReadOnly = true;
            DataGridCar.RowHeadersWidth = 51;
            DataGridCar.Size = new Size(800, 397);
            DataGridCar.TabIndex = 2;
            DataGridCar.CellFormatting += DataGridCar_CellFormatting;
            DataGridCar.CellPainting += DataGridCar_CellPainting;
            // 
            // ColumnMake
            // 
            ColumnMake.DataPropertyName = "CarMake";
            ColumnMake.HeaderText = "Марка автомобиля";
            ColumnMake.MinimumWidth = 6;
            ColumnMake.Name = "ColumnMake";
            ColumnMake.ReadOnly = true;
            ColumnMake.Width = 125;
            // 
            // ColumnNumber
            // 
            ColumnNumber.DataPropertyName = "StateNumber";
            ColumnNumber.HeaderText = "Гос номер";
            ColumnNumber.MinimumWidth = 6;
            ColumnNumber.Name = "ColumnNumber";
            ColumnNumber.ReadOnly = true;
            ColumnNumber.Width = 75;
            // 
            // ColumnMileage
            // 
            ColumnMileage.DataPropertyName = "Mileage";
            ColumnMileage.HeaderText = "Пробег";
            ColumnMileage.MinimumWidth = 6;
            ColumnMileage.Name = "ColumnMileage";
            ColumnMileage.ReadOnly = true;
            ColumnMileage.Width = 75;
            // 
            // ColumnAvgFuel
            // 
            ColumnAvgFuel.DataPropertyName = "AvgFuelConsumption";
            ColumnAvgFuel.HeaderText = "Средний расход топлива";
            ColumnAvgFuel.MinimumWidth = 6;
            ColumnAvgFuel.Name = "ColumnAvgFuel";
            ColumnAvgFuel.ReadOnly = true;
            ColumnAvgFuel.Width = 75;
            // 
            // ColumnFuel
            // 
            ColumnFuel.DataPropertyName = "FuelVolume";
            ColumnFuel.HeaderText = "Объем топлива";
            ColumnFuel.MinimumWidth = 6;
            ColumnFuel.Name = "ColumnFuel";
            ColumnFuel.ReadOnly = true;
            ColumnFuel.Width = 75;
            // 
            // ColumnCost
            // 
            ColumnCost.DataPropertyName = "RentalCost";
            ColumnCost.HeaderText = "Стоимость аренды";
            ColumnCost.MinimumWidth = 6;
            ColumnCost.Name = "ColumnCost";
            ColumnCost.ReadOnly = true;
            ColumnCost.Width = 75;
            // 
            // ColumnRangeFuel
            // 
            ColumnRangeFuel.HeaderText = "Запас хода топлива (ч)";
            ColumnRangeFuel.MinimumWidth = 6;
            ColumnRangeFuel.Name = "ColumnRangeFuel";
            ColumnRangeFuel.ReadOnly = true;
            ColumnRangeFuel.Width = 125;
            // 
            // ColumnRentalAmount
            // 
            ColumnRentalAmount.HeaderText = "Сумма аренды";
            ColumnRentalAmount.MinimumWidth = 6;
            ColumnRentalAmount.Name = "ColumnRentalAmount";
            ColumnRentalAmount.ReadOnly = true;
            ColumnRentalAmount.Width = 125;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DataGridCar);
            Controls.Add(statusStripCar);
            Controls.Add(toolStripCar);
            Name = "MainForm";
            Text = "Прокат автомобилей";
            toolStripCar.ResumeLayout(false);
            toolStripCar.PerformLayout();
            statusStripCar.ResumeLayout(false);
            statusStripCar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridCar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStripCar;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton3;
        private StatusStrip statusStripCar;
        private ToolStripStatusLabel toolStripStatusAllCar;
        private ToolStripStatusLabel toolStripStatusLowFuel;
        private DataGridView DataGridCar;
        private DataGridViewTextBoxColumn ColumnMake;
        private DataGridViewTextBoxColumn ColumnNumber;
        private DataGridViewTextBoxColumn ColumnMileage;
        private DataGridViewTextBoxColumn ColumnAvgFuel;
        private DataGridViewTextBoxColumn ColumnFuel;
        private DataGridViewTextBoxColumn ColumnCost;
        private DataGridViewTextBoxColumn ColumnRangeFuel;
        private DataGridViewTextBoxColumn ColumnRentalAmount;
    }
}