namespace QLSV
{
    partial class Form2
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
            dgvSV = new DataGridView();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSV).BeginInit();
            SuspendLayout();
            // 
            // dgvSV
            // 
            dgvSV.AllowUserToAddRows = false;
            dgvSV.AllowUserToDeleteRows = false;
            dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSV.Location = new Point(97, 67);
            dgvSV.MultiSelect = false;
            dgvSV.Name = "dgvSV";
            dgvSV.ReadOnly = true;
            dgvSV.RowHeadersWidth = 51;
            dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSV.Size = new Size(579, 188);
            dgvSV.TabIndex = 0;
            dgvSV.CellContentClick += dgvSV_CellContentClick;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(389, 285);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 17;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(289, 285);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(189, 285);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 15;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvSV);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSV;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
    }
}