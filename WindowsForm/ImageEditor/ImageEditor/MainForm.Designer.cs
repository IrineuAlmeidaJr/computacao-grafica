namespace ImageEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tollRestoreImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCloseProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelR = new System.Windows.Forms.Label();
            this.labelG = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelTextR = new System.Windows.Forms.Label();
            this.labelTextG = new System.Windows.Forms.Label();
            this.labelTextB = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.labelM = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelTextC = new System.Windows.Forms.Label();
            this.labelTextM = new System.Windows.Forms.Label();
            this.labelTextY = new System.Windows.Forms.Label();
            this.labelH = new System.Windows.Forms.Label();
            this.labelS = new System.Windows.Forms.Label();
            this.labelI = new System.Windows.Forms.Label();
            this.labelTextH = new System.Windows.Forms.Label();
            this.labelTextS = new System.Windows.Forms.Label();
            this.labelTextI = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLessH = new System.Windows.Forms.Button();
            this.btnMoreH = new System.Windows.Forms.Button();
            this.labelHue = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLessB = new System.Windows.Forms.Button();
            this.btnMoreB = new System.Windows.Forms.Button();
            this.labelBrightness = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLuminance = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1044, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpenImage,
            this.tollRestoreImage,
            this.toolStripSeparator1,
            this.toolCloseProgram});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // toolOpenImage
            // 
            this.toolOpenImage.Name = "toolOpenImage";
            this.toolOpenImage.Size = new System.Drawing.Size(170, 22);
            this.toolOpenImage.Text = "Abrir ";
            this.toolOpenImage.Click += new System.EventHandler(this.toolOpenImage_Click);
            // 
            // tollRestoreImage
            // 
            this.tollRestoreImage.Name = "tollRestoreImage";
            this.tollRestoreImage.Size = new System.Drawing.Size(170, 22);
            this.tollRestoreImage.Text = "Restaurar Imagem";
            this.tollRestoreImage.Click += new System.EventHandler(this.tollRestoreImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // toolCloseProgram
            // 
            this.toolCloseProgram.Name = "toolCloseProgram";
            this.toolCloseProgram.Size = new System.Drawing.Size(170, 22);
            this.toolCloseProgram.Text = "Fechar";
            this.toolCloseProgram.Click += new System.EventHandler(this.toolCloseProgram_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.67094F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.32906F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.68562F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.31439F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1044, 579);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.pictureBoxMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 449);
            this.panel1.TabIndex = 0;
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(10, 4);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.41294F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.79602F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.731343F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.079602F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.77612F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.238806F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.21393F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.62687F));
            this.tableLayoutPanel2.Controls.Add(this.labelR, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelG, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelB, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelTextR, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelTextG, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelTextB, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelC, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelM, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelY, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelTextC, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelTextM, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelTextY, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelH, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelS, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelI, 6, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelTextH, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelTextS, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelTextI, 7, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 458);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(804, 118);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelR
            // 
            this.labelR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelR.AutoSize = true;
            this.labelR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR.Location = new System.Drawing.Point(110, 9);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(27, 20);
            this.labelR.TabIndex = 0;
            this.labelR.Text = "R:";
            // 
            // labelG
            // 
            this.labelG.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelG.AutoSize = true;
            this.labelG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelG.Location = new System.Drawing.Point(109, 48);
            this.labelG.Name = "labelG";
            this.labelG.Size = new System.Drawing.Size(28, 20);
            this.labelG.TabIndex = 1;
            this.labelG.Text = "G:";
            // 
            // labelB
            // 
            this.labelB.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelB.AutoSize = true;
            this.labelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelB.Location = new System.Drawing.Point(111, 88);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(26, 20);
            this.labelB.TabIndex = 2;
            this.labelB.Text = "B:";
            // 
            // labelTextR
            // 
            this.labelTextR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextR.AutoSize = true;
            this.labelTextR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextR.Location = new System.Drawing.Point(146, 9);
            this.labelTextR.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTextR.Name = "labelTextR";
            this.labelTextR.Size = new System.Drawing.Size(118, 20);
            this.labelTextR.TabIndex = 3;
            this.labelTextR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTextG
            // 
            this.labelTextG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextG.AutoSize = true;
            this.labelTextG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextG.Location = new System.Drawing.Point(146, 48);
            this.labelTextG.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTextG.Name = "labelTextG";
            this.labelTextG.Size = new System.Drawing.Size(118, 20);
            this.labelTextG.TabIndex = 4;
            this.labelTextG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTextB
            // 
            this.labelTextB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextB.AutoSize = true;
            this.labelTextB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextB.Location = new System.Drawing.Point(146, 88);
            this.labelTextB.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTextB.Name = "labelTextB";
            this.labelTextB.Size = new System.Drawing.Size(118, 20);
            this.labelTextB.TabIndex = 5;
            this.labelTextB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelC
            // 
            this.labelC.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelC.AutoSize = true;
            this.labelC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelC.Location = new System.Drawing.Point(341, 9);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(26, 20);
            this.labelC.TabIndex = 6;
            this.labelC.Text = "C:";
            // 
            // labelM
            // 
            this.labelM.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelM.AutoSize = true;
            this.labelM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelM.Location = new System.Drawing.Point(339, 48);
            this.labelM.Name = "labelM";
            this.labelM.Size = new System.Drawing.Size(28, 20);
            this.labelM.TabIndex = 7;
            this.labelM.Text = "M:";
            // 
            // labelY
            // 
            this.labelY.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelY.Location = new System.Drawing.Point(341, 88);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(26, 20);
            this.labelY.TabIndex = 8;
            this.labelY.Text = "Y:";
            // 
            // labelTextC
            // 
            this.labelTextC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextC.AutoSize = true;
            this.labelTextC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextC.Location = new System.Drawing.Point(376, 9);
            this.labelTextC.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTextC.Name = "labelTextC";
            this.labelTextC.Size = new System.Drawing.Size(150, 20);
            this.labelTextC.TabIndex = 9;
            this.labelTextC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTextM
            // 
            this.labelTextM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextM.AutoSize = true;
            this.labelTextM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextM.Location = new System.Drawing.Point(376, 48);
            this.labelTextM.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTextM.Name = "labelTextM";
            this.labelTextM.Size = new System.Drawing.Size(150, 20);
            this.labelTextM.TabIndex = 10;
            this.labelTextM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTextY
            // 
            this.labelTextY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextY.AutoSize = true;
            this.labelTextY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextY.Location = new System.Drawing.Point(376, 88);
            this.labelTextY.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTextY.Name = "labelTextY";
            this.labelTextY.Size = new System.Drawing.Size(150, 20);
            this.labelTextY.TabIndex = 11;
            this.labelTextY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelH
            // 
            this.labelH.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelH.AutoSize = true;
            this.labelH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelH.Location = new System.Drawing.Point(575, 9);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(27, 20);
            this.labelH.TabIndex = 12;
            this.labelH.Text = "H:";
            // 
            // labelS
            // 
            this.labelS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelS.AutoSize = true;
            this.labelS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS.Location = new System.Drawing.Point(576, 48);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(26, 20);
            this.labelS.TabIndex = 13;
            this.labelS.Text = "S:";
            // 
            // labelI
            // 
            this.labelI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelI.AutoSize = true;
            this.labelI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelI.Location = new System.Drawing.Point(582, 88);
            this.labelI.Name = "labelI";
            this.labelI.Size = new System.Drawing.Size(20, 20);
            this.labelI.TabIndex = 14;
            this.labelI.Text = "I:";
            // 
            // labelTextH
            // 
            this.labelTextH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextH.AutoSize = true;
            this.labelTextH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextH.Location = new System.Drawing.Point(611, 9);
            this.labelTextH.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTextH.Name = "labelTextH";
            this.labelTextH.Size = new System.Drawing.Size(190, 20);
            this.labelTextH.TabIndex = 15;
            this.labelTextH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTextS
            // 
            this.labelTextS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextS.AutoSize = true;
            this.labelTextS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextS.Location = new System.Drawing.Point(611, 48);
            this.labelTextS.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTextS.Name = "labelTextS";
            this.labelTextS.Size = new System.Drawing.Size(190, 20);
            this.labelTextS.TabIndex = 16;
            this.labelTextS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTextI
            // 
            this.labelTextI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextI.AutoSize = true;
            this.labelTextI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextI.Location = new System.Drawing.Point(611, 88);
            this.labelTextI.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTextI.Name = "labelTextI";
            this.labelTextI.Size = new System.Drawing.Size(190, 20);
            this.labelTextI.TabIndex = 17;
            this.labelTextI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel8, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(813, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(228, 449);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.labelHue, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 152);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(222, 143);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.btnLessH, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnMoreH, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 74);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(216, 66);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // btnLessH
            // 
            this.btnLessH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLessH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLessH.Location = new System.Drawing.Point(34, 13);
            this.btnLessH.Name = "btnLessH";
            this.btnLessH.Size = new System.Drawing.Size(40, 40);
            this.btnLessH.TabIndex = 1;
            this.btnLessH.Text = "-";
            this.btnLessH.UseVisualStyleBackColor = true;
            this.btnLessH.Click += new System.EventHandler(this.btnLessH_Click);
            // 
            // btnMoreH
            // 
            this.btnMoreH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoreH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoreH.Location = new System.Drawing.Point(142, 13);
            this.btnMoreH.Name = "btnMoreH";
            this.btnMoreH.Size = new System.Drawing.Size(40, 40);
            this.btnMoreH.TabIndex = 0;
            this.btnMoreH.Text = "+";
            this.btnMoreH.UseVisualStyleBackColor = true;
            this.btnMoreH.Click += new System.EventHandler(this.btnMoreH_Click);
            // 
            // labelHue
            // 
            this.labelHue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHue.AutoSize = true;
            this.labelHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHue.Location = new System.Drawing.Point(3, 51);
            this.labelHue.Name = "labelHue";
            this.labelHue.Size = new System.Drawing.Size(216, 20);
            this.labelHue.TabIndex = 1;
            this.labelHue.Text = "Matiz";
            this.labelHue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelBrightness, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(222, 143);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.btnLessB, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnMoreB, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 74);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(216, 66);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btnLessB
            // 
            this.btnLessB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLessB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLessB.Location = new System.Drawing.Point(34, 13);
            this.btnLessB.Name = "btnLessB";
            this.btnLessB.Size = new System.Drawing.Size(40, 40);
            this.btnLessB.TabIndex = 1;
            this.btnLessB.Text = "-";
            this.btnLessB.UseVisualStyleBackColor = true;
            this.btnLessB.Click += new System.EventHandler(this.btnLessB_Click);
            // 
            // btnMoreB
            // 
            this.btnMoreB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoreB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoreB.Location = new System.Drawing.Point(142, 13);
            this.btnMoreB.Name = "btnMoreB";
            this.btnMoreB.Size = new System.Drawing.Size(40, 40);
            this.btnMoreB.TabIndex = 0;
            this.btnMoreB.Text = "+";
            this.btnMoreB.UseVisualStyleBackColor = true;
            this.btnMoreB.Click += new System.EventHandler(this.btnMoreB_Click);
            // 
            // labelBrightness
            // 
            this.labelBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBrightness.AutoSize = true;
            this.labelBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBrightness.Location = new System.Drawing.Point(3, 51);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(216, 20);
            this.labelBrightness.TabIndex = 1;
            this.labelBrightness.Text = "Brilho";
            this.labelBrightness.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.btnLuminance, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnUndo, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 301);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(222, 145);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // btnLuminance
            // 
            this.btnLuminance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLuminance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuminance.Location = new System.Drawing.Point(26, 20);
            this.btnLuminance.Name = "btnLuminance";
            this.btnLuminance.Size = new System.Drawing.Size(169, 32);
            this.btnLuminance.TabIndex = 0;
            this.btnLuminance.Text = "Luminancia";
            this.btnLuminance.UseVisualStyleBackColor = true;
            this.btnLuminance.Click += new System.EventHandler(this.btnLuminance_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Location = new System.Drawing.Point(25, 92);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(171, 32);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.Text = "Desfazer Mudanças";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 603);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor Imagem";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolOpenImage;
        private System.Windows.Forms.ToolStripMenuItem tollRestoreImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolCloseProgram;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Label labelG;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelTextR;
        private System.Windows.Forms.Label labelTextG;
        private System.Windows.Forms.Label labelTextB;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Label labelM;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelTextC;
        private System.Windows.Forms.Label labelTextM;
        private System.Windows.Forms.Label labelTextY;
        private System.Windows.Forms.Label labelTextH;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.Label labelI;
        private System.Windows.Forms.Label labelTextS;
        private System.Windows.Forms.Label labelTextI;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnLessB;
        private System.Windows.Forms.Button btnMoreB;
        private System.Windows.Forms.Label labelBrightness;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button btnLessH;
        private System.Windows.Forms.Button btnMoreH;
        private System.Windows.Forms.Label labelHue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button btnLuminance;
        private System.Windows.Forms.Button btnUndo;
    }
}

