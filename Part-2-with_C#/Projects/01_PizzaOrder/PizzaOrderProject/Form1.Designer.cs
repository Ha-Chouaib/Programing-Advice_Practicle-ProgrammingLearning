namespace PizzaOrderProject
{
    partial class PiizzaMainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.gbPizzaSize = new System.Windows.Forms.GroupBox();
            this.rbLargePizza = new System.Windows.Forms.RadioButton();
            this.rbMeduimPizza = new System.Windows.Forms.RadioButton();
            this.rbSmallPizza = new System.Windows.Forms.RadioButton();
            this.gbToppings = new System.Windows.Forms.GroupBox();
            this.chkToppGrnPappers = new System.Windows.Forms.CheckBox();
            this.chkToppOlives = new System.Windows.Forms.CheckBox();
            this.chkToppOnion = new System.Windows.Forms.CheckBox();
            this.chkToppTomato = new System.Windows.Forms.CheckBox();
            this.chkToppMushr = new System.Windows.Forms.CheckBox();
            this.chkToppExtraChees = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSetPrice = new System.Windows.Forms.Label();
            this.lblSetWhereToEat = new System.Windows.Forms.Label();
            this.lblSetCrustType = new System.Windows.Forms.Label();
            this.lblSetToppings = new System.Windows.Forms.Label();
            this.lblSetSize = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblWhereToEat = new System.Windows.Forms.Label();
            this.lblCrustType = new System.Windows.Forms.Label();
            this.lblToppings = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.gbCrustType = new System.Windows.Forms.GroupBox();
            this.rbCrustThick = new System.Windows.Forms.RadioButton();
            this.rbCrustThin = new System.Windows.Forms.RadioButton();
            this.gbWhereToEat = new System.Windows.Forms.GroupBox();
            this.rbTakeOut = new System.Windows.Forms.RadioButton();
            this.rbEat_In = new System.Windows.Forms.RadioButton();
            this.btnOrderNow = new System.Windows.Forms.Button();
            this.btnResetOrder = new System.Windows.Forms.Button();
            this.gbPizzaSize.SuspendLayout();
            this.gbToppings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbCrustType.SuspendLayout();
            this.gbWhereToEat.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Gabriola", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(413, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Make Your Pizza";
            // 
            // gbPizzaSize
            // 
            this.gbPizzaSize.BackColor = System.Drawing.Color.Transparent;
            this.gbPizzaSize.Controls.Add(this.rbLargePizza);
            this.gbPizzaSize.Controls.Add(this.rbMeduimPizza);
            this.gbPizzaSize.Controls.Add(this.rbSmallPizza);
            this.gbPizzaSize.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPizzaSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gbPizzaSize.Location = new System.Drawing.Point(26, 102);
            this.gbPizzaSize.Name = "gbPizzaSize";
            this.gbPizzaSize.Size = new System.Drawing.Size(200, 153);
            this.gbPizzaSize.TabIndex = 1;
            this.gbPizzaSize.TabStop = false;
            this.gbPizzaSize.Text = "Pizza Size:";
            // 
            // rbLargePizza
            // 
            this.rbLargePizza.AutoSize = true;
            this.rbLargePizza.BackColor = System.Drawing.Color.Transparent;
            this.rbLargePizza.ForeColor = System.Drawing.Color.Gray;
            this.rbLargePizza.Location = new System.Drawing.Point(15, 101);
            this.rbLargePizza.Name = "rbLargePizza";
            this.rbLargePizza.Size = new System.Drawing.Size(70, 25);
            this.rbLargePizza.TabIndex = 2;
            this.rbLargePizza.TabStop = true;
            this.rbLargePizza.Tag = "40";
            this.rbLargePizza.Text = "Large";
            this.rbLargePizza.UseVisualStyleBackColor = false;
            this.rbLargePizza.CheckedChanged += new System.EventHandler(this.rbLargePizza_CheckedChanged);
            // 
            // rbMeduimPizza
            // 
            this.rbMeduimPizza.AutoSize = true;
            this.rbMeduimPizza.BackColor = System.Drawing.Color.Transparent;
            this.rbMeduimPizza.ForeColor = System.Drawing.Color.Gray;
            this.rbMeduimPizza.Location = new System.Drawing.Point(15, 63);
            this.rbMeduimPizza.Name = "rbMeduimPizza";
            this.rbMeduimPizza.Size = new System.Drawing.Size(88, 25);
            this.rbMeduimPizza.TabIndex = 1;
            this.rbMeduimPizza.TabStop = true;
            this.rbMeduimPizza.Tag = "30";
            this.rbMeduimPizza.Text = "Meduim";
            this.rbMeduimPizza.UseVisualStyleBackColor = false;
            this.rbMeduimPizza.CheckedChanged += new System.EventHandler(this.rbMeduimPizza_CheckedChanged);
            // 
            // rbSmallPizza
            // 
            this.rbSmallPizza.AutoSize = true;
            this.rbSmallPizza.BackColor = System.Drawing.Color.Transparent;
            this.rbSmallPizza.ForeColor = System.Drawing.Color.Gray;
            this.rbSmallPizza.Location = new System.Drawing.Point(15, 25);
            this.rbSmallPizza.Name = "rbSmallPizza";
            this.rbSmallPizza.Size = new System.Drawing.Size(70, 25);
            this.rbSmallPizza.TabIndex = 0;
            this.rbSmallPizza.TabStop = true;
            this.rbSmallPizza.Tag = "20";
            this.rbSmallPizza.Text = "Small";
            this.rbSmallPizza.UseVisualStyleBackColor = false;
            this.rbSmallPizza.CheckedChanged += new System.EventHandler(this.rbSmallPizza_CheckedChanged);
            // 
            // gbToppings
            // 
            this.gbToppings.BackColor = System.Drawing.Color.Transparent;
            this.gbToppings.Controls.Add(this.chkToppGrnPappers);
            this.gbToppings.Controls.Add(this.chkToppOlives);
            this.gbToppings.Controls.Add(this.chkToppOnion);
            this.gbToppings.Controls.Add(this.chkToppTomato);
            this.gbToppings.Controls.Add(this.chkToppMushr);
            this.gbToppings.Controls.Add(this.chkToppExtraChees);
            this.gbToppings.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbToppings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gbToppings.Location = new System.Drawing.Point(286, 102);
            this.gbToppings.Name = "gbToppings";
            this.gbToppings.Size = new System.Drawing.Size(356, 153);
            this.gbToppings.TabIndex = 3;
            this.gbToppings.TabStop = false;
            this.gbToppings.Text = "Toppings:";
            // 
            // chkToppGrnPappers
            // 
            this.chkToppGrnPappers.AutoSize = true;
            this.chkToppGrnPappers.ForeColor = System.Drawing.Color.DimGray;
            this.chkToppGrnPappers.Location = new System.Drawing.Point(198, 104);
            this.chkToppGrnPappers.Name = "chkToppGrnPappers";
            this.chkToppGrnPappers.Size = new System.Drawing.Size(136, 25);
            this.chkToppGrnPappers.TabIndex = 8;
            this.chkToppGrnPappers.Tag = "1";
            this.chkToppGrnPappers.Text = "Green Pappers";
            this.chkToppGrnPappers.UseVisualStyleBackColor = true;
            this.chkToppGrnPappers.CheckedChanged += new System.EventHandler(this.chkToppGrnPappers_CheckedChanged);
            // 
            // chkToppOlives
            // 
            this.chkToppOlives.AutoSize = true;
            this.chkToppOlives.ForeColor = System.Drawing.Color.DimGray;
            this.chkToppOlives.Location = new System.Drawing.Point(198, 73);
            this.chkToppOlives.Name = "chkToppOlives";
            this.chkToppOlives.Size = new System.Drawing.Size(75, 25);
            this.chkToppOlives.TabIndex = 7;
            this.chkToppOlives.Tag = "4";
            this.chkToppOlives.Text = "Olives";
            this.chkToppOlives.UseVisualStyleBackColor = true;
            this.chkToppOlives.CheckedChanged += new System.EventHandler(this.chkToppOlives_CheckedChanged);
            // 
            // chkToppOnion
            // 
            this.chkToppOnion.AutoSize = true;
            this.chkToppOnion.ForeColor = System.Drawing.Color.DimGray;
            this.chkToppOnion.Location = new System.Drawing.Point(198, 42);
            this.chkToppOnion.Name = "chkToppOnion";
            this.chkToppOnion.Size = new System.Drawing.Size(74, 25);
            this.chkToppOnion.TabIndex = 6;
            this.chkToppOnion.Tag = "1";
            this.chkToppOnion.Text = "Onion";
            this.chkToppOnion.UseVisualStyleBackColor = true;
            this.chkToppOnion.CheckedChanged += new System.EventHandler(this.chkToppOnion_CheckedChanged);
            // 
            // chkToppTomato
            // 
            this.chkToppTomato.AutoSize = true;
            this.chkToppTomato.ForeColor = System.Drawing.Color.DimGray;
            this.chkToppTomato.Location = new System.Drawing.Point(21, 104);
            this.chkToppTomato.Name = "chkToppTomato";
            this.chkToppTomato.Size = new System.Drawing.Size(101, 25);
            this.chkToppTomato.TabIndex = 5;
            this.chkToppTomato.Tag = "2";
            this.chkToppTomato.Text = "Tomatoes";
            this.chkToppTomato.UseVisualStyleBackColor = true;
            this.chkToppTomato.CheckedChanged += new System.EventHandler(this.chkToppTomato_CheckedChanged);
            // 
            // chkToppMushr
            // 
            this.chkToppMushr.AutoSize = true;
            this.chkToppMushr.ForeColor = System.Drawing.Color.DimGray;
            this.chkToppMushr.Location = new System.Drawing.Point(21, 73);
            this.chkToppMushr.Name = "chkToppMushr";
            this.chkToppMushr.Size = new System.Drawing.Size(118, 25);
            this.chkToppMushr.TabIndex = 4;
            this.chkToppMushr.Tag = "3";
            this.chkToppMushr.Text = "Mushrooms";
            this.chkToppMushr.UseVisualStyleBackColor = true;
            this.chkToppMushr.CheckedChanged += new System.EventHandler(this.chkToppMushr_CheckedChanged);
            // 
            // chkToppExtraChees
            // 
            this.chkToppExtraChees.AutoSize = true;
            this.chkToppExtraChees.ForeColor = System.Drawing.Color.DimGray;
            this.chkToppExtraChees.Location = new System.Drawing.Point(21, 42);
            this.chkToppExtraChees.Name = "chkToppExtraChees";
            this.chkToppExtraChees.Size = new System.Drawing.Size(118, 25);
            this.chkToppExtraChees.TabIndex = 3;
            this.chkToppExtraChees.Tag = "2";
            this.chkToppExtraChees.Text = "Extra Chees";
            this.chkToppExtraChees.UseVisualStyleBackColor = true;
            this.chkToppExtraChees.CheckedChanged += new System.EventHandler(this.chkToppExtraChees_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Bisque;
            this.groupBox2.Controls.Add(this.lblSetPrice);
            this.groupBox2.Controls.Add(this.lblSetWhereToEat);
            this.groupBox2.Controls.Add(this.lblSetCrustType);
            this.groupBox2.Controls.Add(this.lblSetToppings);
            this.groupBox2.Controls.Add(this.lblSetSize);
            this.groupBox2.Controls.Add(this.lblTotalPrice);
            this.groupBox2.Controls.Add(this.lblWhereToEat);
            this.groupBox2.Controls.Add(this.lblCrustType);
            this.groupBox2.Controls.Add(this.lblToppings);
            this.groupBox2.Controls.Add(this.lblSize);
            this.groupBox2.Font = new System.Drawing.Font("Sitka Text", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(707, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 448);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order Summary";
            // 
            // lblSetPrice
            // 
            this.lblSetPrice.AutoSize = true;
            this.lblSetPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblSetPrice.Enabled = false;
            this.lblSetPrice.Font = new System.Drawing.Font("MV Boli", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetPrice.ForeColor = System.Drawing.Color.Green;
            this.lblSetPrice.Location = new System.Drawing.Point(130, 410);
            this.lblSetPrice.Name = "lblSetPrice";
            this.lblSetPrice.Size = new System.Drawing.Size(46, 31);
            this.lblSetPrice.TabIndex = 0;
            this.lblSetPrice.Text = "0$";
            // 
            // lblSetWhereToEat
            // 
            this.lblSetWhereToEat.AutoSize = true;
            this.lblSetWhereToEat.BackColor = System.Drawing.Color.Transparent;
            this.lblSetWhereToEat.Enabled = false;
            this.lblSetWhereToEat.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetWhereToEat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblSetWhereToEat.Location = new System.Drawing.Point(173, 330);
            this.lblSetWhereToEat.Name = "lblSetWhereToEat";
            this.lblSetWhereToEat.Size = new System.Drawing.Size(0, 17);
            this.lblSetWhereToEat.TabIndex = 0;
            // 
            // lblSetCrustType
            // 
            this.lblSetCrustType.AutoSize = true;
            this.lblSetCrustType.BackColor = System.Drawing.Color.Transparent;
            this.lblSetCrustType.Enabled = false;
            this.lblSetCrustType.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetCrustType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblSetCrustType.Location = new System.Drawing.Point(150, 276);
            this.lblSetCrustType.Name = "lblSetCrustType";
            this.lblSetCrustType.Size = new System.Drawing.Size(0, 17);
            this.lblSetCrustType.TabIndex = 0;
            // 
            // lblSetToppings
            // 
            this.lblSetToppings.AutoSize = true;
            this.lblSetToppings.BackColor = System.Drawing.Color.Transparent;
            this.lblSetToppings.Enabled = false;
            this.lblSetToppings.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetToppings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblSetToppings.Location = new System.Drawing.Point(38, 162);
            this.lblSetToppings.Name = "lblSetToppings";
            this.lblSetToppings.Size = new System.Drawing.Size(0, 17);
            this.lblSetToppings.TabIndex = 0;
            // 
            // lblSetSize
            // 
            this.lblSetSize.AutoSize = true;
            this.lblSetSize.BackColor = System.Drawing.Color.Transparent;
            this.lblSetSize.Enabled = false;
            this.lblSetSize.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblSetSize.Location = new System.Drawing.Point(135, 71);
            this.lblSetSize.Name = "lblSetSize";
            this.lblSetSize.Size = new System.Drawing.Size(0, 17);
            this.lblSetSize.TabIndex = 0;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(128, 374);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(93, 21);
            this.lblTotalPrice.TabIndex = 4;
            this.lblTotalPrice.Text = "Total Price";
            // 
            // lblWhereToEat
            // 
            this.lblWhereToEat.AutoSize = true;
            this.lblWhereToEat.Font = new System.Drawing.Font("Sitka Text", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhereToEat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblWhereToEat.Location = new System.Drawing.Point(5, 330);
            this.lblWhereToEat.Name = "lblWhereToEat";
            this.lblWhereToEat.Size = new System.Drawing.Size(122, 23);
            this.lblWhereToEat.TabIndex = 3;
            this.lblWhereToEat.Text = "Where To Eat:";
            // 
            // lblCrustType
            // 
            this.lblCrustType.AutoSize = true;
            this.lblCrustType.Font = new System.Drawing.Font("Sitka Text", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrustType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblCrustType.Location = new System.Drawing.Point(5, 272);
            this.lblCrustType.Name = "lblCrustType";
            this.lblCrustType.Size = new System.Drawing.Size(102, 23);
            this.lblCrustType.TabIndex = 2;
            this.lblCrustType.Text = "Crust Type:";
            // 
            // lblToppings
            // 
            this.lblToppings.AutoSize = true;
            this.lblToppings.Font = new System.Drawing.Font("Sitka Text", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToppings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblToppings.Location = new System.Drawing.Point(6, 120);
            this.lblToppings.Name = "lblToppings";
            this.lblToppings.Size = new System.Drawing.Size(89, 23);
            this.lblToppings.TabIndex = 1;
            this.lblToppings.Text = "Toppings:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Enabled = false;
            this.lblSize.Font = new System.Drawing.Font("Sitka Text", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSize.Location = new System.Drawing.Point(6, 63);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(48, 23);
            this.lblSize.TabIndex = 0;
            this.lblSize.Text = "Size:";
            // 
            // gbCrustType
            // 
            this.gbCrustType.BackColor = System.Drawing.Color.Transparent;
            this.gbCrustType.Controls.Add(this.rbCrustThick);
            this.gbCrustType.Controls.Add(this.rbCrustThin);
            this.gbCrustType.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCrustType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gbCrustType.Location = new System.Drawing.Point(26, 274);
            this.gbCrustType.Name = "gbCrustType";
            this.gbCrustType.Size = new System.Drawing.Size(200, 75);
            this.gbCrustType.TabIndex = 3;
            this.gbCrustType.TabStop = false;
            this.gbCrustType.Text = "Crust Type:";
            // 
            // rbCrustThick
            // 
            this.rbCrustThick.AutoSize = true;
            this.rbCrustThick.BackColor = System.Drawing.Color.Transparent;
            this.rbCrustThick.ForeColor = System.Drawing.Color.Gray;
            this.rbCrustThick.Location = new System.Drawing.Point(112, 25);
            this.rbCrustThick.Name = "rbCrustThick";
            this.rbCrustThick.Size = new System.Drawing.Size(69, 25);
            this.rbCrustThick.TabIndex = 10;
            this.rbCrustThick.TabStop = true;
            this.rbCrustThick.Tag = "5";
            this.rbCrustThick.Text = "Thick";
            this.rbCrustThick.UseVisualStyleBackColor = false;
            this.rbCrustThick.CheckedChanged += new System.EventHandler(this.rbCrustThick_CheckedChanged);
            // 
            // rbCrustThin
            // 
            this.rbCrustThin.AutoSize = true;
            this.rbCrustThin.BackColor = System.Drawing.Color.Transparent;
            this.rbCrustThin.ForeColor = System.Drawing.Color.Gray;
            this.rbCrustThin.Location = new System.Drawing.Point(15, 25);
            this.rbCrustThin.Name = "rbCrustThin";
            this.rbCrustThin.Size = new System.Drawing.Size(63, 25);
            this.rbCrustThin.TabIndex = 9;
            this.rbCrustThin.TabStop = true;
            this.rbCrustThin.Tag = "0";
            this.rbCrustThin.Text = "Thin";
            this.rbCrustThin.UseVisualStyleBackColor = false;
            this.rbCrustThin.CheckedChanged += new System.EventHandler(this.rbCrustThin_CheckedChanged);
            // 
            // gbWhereToEat
            // 
            this.gbWhereToEat.BackColor = System.Drawing.Color.Transparent;
            this.gbWhereToEat.Controls.Add(this.rbTakeOut);
            this.gbWhereToEat.Controls.Add(this.rbEat_In);
            this.gbWhereToEat.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbWhereToEat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gbWhereToEat.Location = new System.Drawing.Point(286, 274);
            this.gbWhereToEat.Name = "gbWhereToEat";
            this.gbWhereToEat.Size = new System.Drawing.Size(356, 75);
            this.gbWhereToEat.TabIndex = 4;
            this.gbWhereToEat.TabStop = false;
            this.gbWhereToEat.Text = "Where To Eat:";
            // 
            // rbTakeOut
            // 
            this.rbTakeOut.AutoSize = true;
            this.rbTakeOut.BackColor = System.Drawing.Color.Transparent;
            this.rbTakeOut.ForeColor = System.Drawing.Color.Gray;
            this.rbTakeOut.Location = new System.Drawing.Point(256, 25);
            this.rbTakeOut.Name = "rbTakeOut";
            this.rbTakeOut.Size = new System.Drawing.Size(94, 25);
            this.rbTakeOut.TabIndex = 12;
            this.rbTakeOut.TabStop = true;
            this.rbTakeOut.Text = "Take Out";
            this.rbTakeOut.UseVisualStyleBackColor = false;
            this.rbTakeOut.CheckedChanged += new System.EventHandler(this.rbTakeOut_CheckedChanged);
            // 
            // rbEat_In
            // 
            this.rbEat_In.AutoSize = true;
            this.rbEat_In.BackColor = System.Drawing.Color.Transparent;
            this.rbEat_In.ForeColor = System.Drawing.Color.Gray;
            this.rbEat_In.Location = new System.Drawing.Point(15, 25);
            this.rbEat_In.Name = "rbEat_In";
            this.rbEat_In.Size = new System.Drawing.Size(73, 25);
            this.rbEat_In.TabIndex = 11;
            this.rbEat_In.TabStop = true;
            this.rbEat_In.Text = "Eat In";
            this.rbEat_In.UseVisualStyleBackColor = false;
            this.rbEat_In.CheckedChanged += new System.EventHandler(this.rbEat_In_CheckedChanged);
            // 
            // btnOrderNow
            // 
            this.btnOrderNow.BackColor = System.Drawing.Color.Black;
            this.btnOrderNow.Font = new System.Drawing.Font("MV Boli", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOrderNow.Location = new System.Drawing.Point(439, 432);
            this.btnOrderNow.Name = "btnOrderNow";
            this.btnOrderNow.Size = new System.Drawing.Size(120, 34);
            this.btnOrderNow.TabIndex = 14;
            this.btnOrderNow.Text = "Order Now";
            this.btnOrderNow.UseVisualStyleBackColor = false;
            this.btnOrderNow.Click += new System.EventHandler(this.btnOrderNow_Click);
            // 
            // btnResetOrder
            // 
            this.btnResetOrder.BackColor = System.Drawing.Color.Black;
            this.btnResetOrder.Font = new System.Drawing.Font("MV Boli", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnResetOrder.Location = new System.Drawing.Point(164, 432);
            this.btnResetOrder.Name = "btnResetOrder";
            this.btnResetOrder.Size = new System.Drawing.Size(123, 34);
            this.btnResetOrder.TabIndex = 13;
            this.btnResetOrder.Text = "Reset Order";
            this.btnResetOrder.UseVisualStyleBackColor = false;
            this.btnResetOrder.Click += new System.EventHandler(this.btnResetOrder_Click);
            // 
            // PiizzaMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1047, 552);
            this.Controls.Add(this.btnResetOrder);
            this.Controls.Add(this.btnOrderNow);
            this.Controls.Add(this.gbWhereToEat);
            this.Controls.Add(this.gbCrustType);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbToppings);
            this.Controls.Add(this.gbPizzaSize);
            this.Controls.Add(this.label1);
            this.Name = "PiizzaMainForm";
            this.Text = "Pizza Order";
            this.Load += new System.EventHandler(this.PiizzaMainForm_Load);
            this.gbPizzaSize.ResumeLayout(false);
            this.gbPizzaSize.PerformLayout();
            this.gbToppings.ResumeLayout(false);
            this.gbToppings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbCrustType.ResumeLayout(false);
            this.gbCrustType.PerformLayout();
            this.gbWhereToEat.ResumeLayout(false);
            this.gbWhereToEat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbPizzaSize;
        private System.Windows.Forms.RadioButton rbSmallPizza;
        private System.Windows.Forms.RadioButton rbLargePizza;
        private System.Windows.Forms.RadioButton rbMeduimPizza;
        private System.Windows.Forms.GroupBox gbToppings;
        private System.Windows.Forms.CheckBox chkToppMushr;
        private System.Windows.Forms.CheckBox chkToppExtraChees;
        private System.Windows.Forms.CheckBox chkToppGrnPappers;
        private System.Windows.Forms.CheckBox chkToppOlives;
        private System.Windows.Forms.CheckBox chkToppOnion;
        private System.Windows.Forms.CheckBox chkToppTomato;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblToppings;
        private System.Windows.Forms.Label lblWhereToEat;
        private System.Windows.Forms.Label lblCrustType;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.GroupBox gbCrustType;
        private System.Windows.Forms.RadioButton rbCrustThick;
        private System.Windows.Forms.RadioButton rbCrustThin;
        private System.Windows.Forms.GroupBox gbWhereToEat;
        private System.Windows.Forms.RadioButton rbTakeOut;
        private System.Windows.Forms.RadioButton rbEat_In;
        private System.Windows.Forms.Button btnOrderNow;
        private System.Windows.Forms.Button btnResetOrder;
        private System.Windows.Forms.Label lblSetSize;
        private System.Windows.Forms.Label lblSetToppings;
        private System.Windows.Forms.Label lblSetCrustType;
        private System.Windows.Forms.Label lblSetPrice;
        private System.Windows.Forms.Label lblSetWhereToEat;
    }
}

