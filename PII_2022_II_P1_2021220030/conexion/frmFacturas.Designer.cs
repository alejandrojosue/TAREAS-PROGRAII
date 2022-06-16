namespace conexion
{
    partial class frmFacturas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label clienteIDLabel;
            System.Windows.Forms.Label descuentoLabel;
            System.Windows.Forms.Label empleadoIDLabel;
            System.Windows.Forms.Label fechaIngresoLabel;
            System.Windows.Forms.Label iSVLabel;
            System.Windows.Forms.Label subTotalLabel;
            System.Windows.Forms.Label totalPagarLabel;
            System.Windows.Forms.Label facturaIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.detallesFacturaDataGridView = new System.Windows.Forms.DataGridView();
            this.facturaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detallesFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clienteIDTextBox = new System.Windows.Forms.TextBox();
            this.descuentoTextBox = new System.Windows.Forms.TextBox();
            this.empleadoIDTextBox = new System.Windows.Forms.TextBox();
            this.facturaIDTextBox = new System.Windows.Forms.TextBox();
            this.fechaIngresoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.iSVTextBox = new System.Windows.Forms.TextBox();
            this.subTotalTextBox = new System.Windows.Forms.TextBox();
            this.totalPagarTextBox = new System.Windows.Forms.TextBox();
            this.facturasBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.facturasBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            clienteIDLabel = new System.Windows.Forms.Label();
            descuentoLabel = new System.Windows.Forms.Label();
            empleadoIDLabel = new System.Windows.Forms.Label();
            fechaIngresoLabel = new System.Windows.Forms.Label();
            iSVLabel = new System.Windows.Forms.Label();
            subTotalLabel = new System.Windows.Forms.Label();
            totalPagarLabel = new System.Windows.Forms.Label();
            facturaIDLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detallesFacturaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallesFacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingNavigator)).BeginInit();
            this.facturasBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // clienteIDLabel
            // 
            clienteIDLabel.AutoSize = true;
            clienteIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            clienteIDLabel.ForeColor = System.Drawing.Color.White;
            clienteIDLabel.Location = new System.Drawing.Point(11, 45);
            clienteIDLabel.Name = "clienteIDLabel";
            clienteIDLabel.Size = new System.Drawing.Size(114, 26);
            clienteIDLabel.TabIndex = 0;
            clienteIDLabel.Text = "Cliente ID:";
            // 
            // descuentoLabel
            // 
            descuentoLabel.AutoSize = true;
            descuentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descuentoLabel.ForeColor = System.Drawing.Color.White;
            descuentoLabel.Location = new System.Drawing.Point(11, 77);
            descuentoLabel.Name = "descuentoLabel";
            descuentoLabel.Size = new System.Drawing.Size(122, 26);
            descuentoLabel.TabIndex = 2;
            descuentoLabel.Text = "Descuento:";
            // 
            // empleadoIDLabel
            // 
            empleadoIDLabel.AutoSize = true;
            empleadoIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            empleadoIDLabel.ForeColor = System.Drawing.Color.White;
            empleadoIDLabel.Location = new System.Drawing.Point(11, 109);
            empleadoIDLabel.Name = "empleadoIDLabel";
            empleadoIDLabel.Size = new System.Drawing.Size(145, 26);
            empleadoIDLabel.TabIndex = 4;
            empleadoIDLabel.Text = "Empleado ID:";
            // 
            // fechaIngresoLabel
            // 
            fechaIngresoLabel.AutoSize = true;
            fechaIngresoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaIngresoLabel.ForeColor = System.Drawing.Color.White;
            fechaIngresoLabel.Location = new System.Drawing.Point(407, 48);
            fechaIngresoLabel.Name = "fechaIngresoLabel";
            fechaIngresoLabel.Size = new System.Drawing.Size(156, 26);
            fechaIngresoLabel.TabIndex = 8;
            fechaIngresoLabel.Text = "Fecha Ingreso:";
            // 
            // iSVLabel
            // 
            iSVLabel.AutoSize = true;
            iSVLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            iSVLabel.ForeColor = System.Drawing.Color.White;
            iSVLabel.Location = new System.Drawing.Point(407, 79);
            iSVLabel.Name = "iSVLabel";
            iSVLabel.Size = new System.Drawing.Size(54, 26);
            iSVLabel.TabIndex = 10;
            iSVLabel.Text = "ISV:";
            // 
            // subTotalLabel
            // 
            subTotalLabel.AutoSize = true;
            subTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            subTotalLabel.ForeColor = System.Drawing.Color.White;
            subTotalLabel.Location = new System.Drawing.Point(407, 111);
            subTotalLabel.Name = "subTotalLabel";
            subTotalLabel.Size = new System.Drawing.Size(110, 26);
            subTotalLabel.TabIndex = 12;
            subTotalLabel.Text = "Sub Total:";
            // 
            // totalPagarLabel
            // 
            totalPagarLabel.AutoSize = true;
            totalPagarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            totalPagarLabel.ForeColor = System.Drawing.Color.White;
            totalPagarLabel.Location = new System.Drawing.Point(407, 143);
            totalPagarLabel.Name = "totalPagarLabel";
            totalPagarLabel.Size = new System.Drawing.Size(129, 26);
            totalPagarLabel.TabIndex = 14;
            totalPagarLabel.Text = "Total Pagar:";
            // 
            // facturaIDLabel
            // 
            facturaIDLabel.AutoSize = true;
            facturaIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            facturaIDLabel.ForeColor = System.Drawing.Color.White;
            facturaIDLabel.Location = new System.Drawing.Point(11, 141);
            facturaIDLabel.Name = "facturaIDLabel";
            facturaIDLabel.Size = new System.Drawing.Size(119, 26);
            facturaIDLabel.TabIndex = 6;
            facturaIDLabel.Text = "Factura ID:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Controls.Add(this.detallesFacturaDataGridView);
            this.panel1.Controls.Add(clienteIDLabel);
            this.panel1.Controls.Add(this.clienteIDTextBox);
            this.panel1.Controls.Add(descuentoLabel);
            this.panel1.Controls.Add(this.descuentoTextBox);
            this.panel1.Controls.Add(empleadoIDLabel);
            this.panel1.Controls.Add(this.empleadoIDTextBox);
            this.panel1.Controls.Add(facturaIDLabel);
            this.panel1.Controls.Add(this.facturaIDTextBox);
            this.panel1.Controls.Add(fechaIngresoLabel);
            this.panel1.Controls.Add(this.fechaIngresoDateTimePicker);
            this.panel1.Controls.Add(iSVLabel);
            this.panel1.Controls.Add(this.iSVTextBox);
            this.panel1.Controls.Add(subTotalLabel);
            this.panel1.Controls.Add(this.subTotalTextBox);
            this.panel1.Controls.Add(totalPagarLabel);
            this.panel1.Controls.Add(this.totalPagarTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 533);
            this.panel1.TabIndex = 0;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRegresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnRegresar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(610, 464);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(159, 57);
            this.btnRegresar.TabIndex = 17;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // detallesFacturaDataGridView
            // 
            this.detallesFacturaDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detallesFacturaDataGridView.AutoGenerateColumns = false;
            this.detallesFacturaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detallesFacturaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.facturaIDDataGridViewTextBoxColumn,
            this.productoIDDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.subTotalDataGridViewTextBoxColumn});
            this.detallesFacturaDataGridView.DataSource = this.detallesFacturaBindingSource;
            this.detallesFacturaDataGridView.Location = new System.Drawing.Point(12, 233);
            this.detallesFacturaDataGridView.Name = "detallesFacturaDataGridView";
            this.detallesFacturaDataGridView.RowHeadersWidth = 62;
            this.detallesFacturaDataGridView.RowTemplate.Height = 28;
            this.detallesFacturaDataGridView.Size = new System.Drawing.Size(757, 220);
            this.detallesFacturaDataGridView.TabIndex = 16;
            // 
            // facturaIDDataGridViewTextBoxColumn
            // 
            this.facturaIDDataGridViewTextBoxColumn.DataPropertyName = "FacturaID";
            this.facturaIDDataGridViewTextBoxColumn.HeaderText = "FacturaID";
            this.facturaIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.facturaIDDataGridViewTextBoxColumn.Name = "facturaIDDataGridViewTextBoxColumn";
            this.facturaIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // productoIDDataGridViewTextBoxColumn
            // 
            this.productoIDDataGridViewTextBoxColumn.DataPropertyName = "ProductoID";
            this.productoIDDataGridViewTextBoxColumn.HeaderText = "ProductoID";
            this.productoIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productoIDDataGridViewTextBoxColumn.Name = "productoIDDataGridViewTextBoxColumn";
            this.productoIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.Width = 150;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            this.precioDataGridViewTextBoxColumn.Width = 150;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.Width = 150;
            // 
            // subTotalDataGridViewTextBoxColumn
            // 
            this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
            this.subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
            this.subTotalDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
            this.subTotalDataGridViewTextBoxColumn.Width = 150;
            // 
            // detallesFacturaBindingSource
            // 
            this.detallesFacturaBindingSource.DataMember = "DetallesFactura";
            this.detallesFacturaBindingSource.DataSource = this.facturasBindingSource;
            // 
            // facturasBindingSource
            // 
            this.facturasBindingSource.DataSource = typeof(PII_2022_II_P1_2021220030.Facturas);
            // 
            // clienteIDTextBox
            // 
            this.clienteIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facturasBindingSource, "ClienteID", true));
            this.clienteIDTextBox.Location = new System.Drawing.Point(173, 45);
            this.clienteIDTextBox.Name = "clienteIDTextBox";
            this.clienteIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.clienteIDTextBox.TabIndex = 1;
            // 
            // descuentoTextBox
            // 
            this.descuentoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facturasBindingSource, "Descuento", true));
            this.descuentoTextBox.Location = new System.Drawing.Point(173, 77);
            this.descuentoTextBox.Name = "descuentoTextBox";
            this.descuentoTextBox.Size = new System.Drawing.Size(200, 26);
            this.descuentoTextBox.TabIndex = 3;
            // 
            // empleadoIDTextBox
            // 
            this.empleadoIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facturasBindingSource, "EmpleadoID", true));
            this.empleadoIDTextBox.Location = new System.Drawing.Point(173, 109);
            this.empleadoIDTextBox.Name = "empleadoIDTextBox";
            this.empleadoIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.empleadoIDTextBox.TabIndex = 5;
            // 
            // facturaIDTextBox
            // 
            this.facturaIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facturasBindingSource, "FacturaID", true));
            this.facturaIDTextBox.Location = new System.Drawing.Point(173, 141);
            this.facturaIDTextBox.Name = "facturaIDTextBox";
            this.facturaIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.facturaIDTextBox.TabIndex = 7;
            // 
            // fechaIngresoDateTimePicker
            // 
            this.fechaIngresoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.facturasBindingSource, "FechaIngreso", true));
            this.fechaIngresoDateTimePicker.Location = new System.Drawing.Point(569, 47);
            this.fechaIngresoDateTimePicker.Name = "fechaIngresoDateTimePicker";
            this.fechaIngresoDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.fechaIngresoDateTimePicker.TabIndex = 9;
            // 
            // iSVTextBox
            // 
            this.iSVTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facturasBindingSource, "ISV", true));
            this.iSVTextBox.Location = new System.Drawing.Point(569, 79);
            this.iSVTextBox.Name = "iSVTextBox";
            this.iSVTextBox.Size = new System.Drawing.Size(200, 26);
            this.iSVTextBox.TabIndex = 11;
            // 
            // subTotalTextBox
            // 
            this.subTotalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facturasBindingSource, "SubTotal", true));
            this.subTotalTextBox.Location = new System.Drawing.Point(569, 111);
            this.subTotalTextBox.Name = "subTotalTextBox";
            this.subTotalTextBox.Size = new System.Drawing.Size(200, 26);
            this.subTotalTextBox.TabIndex = 13;
            // 
            // totalPagarTextBox
            // 
            this.totalPagarTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facturasBindingSource, "TotalPagar", true));
            this.totalPagarTextBox.Location = new System.Drawing.Point(569, 143);
            this.totalPagarTextBox.Name = "totalPagarTextBox";
            this.totalPagarTextBox.Size = new System.Drawing.Size(200, 26);
            this.totalPagarTextBox.TabIndex = 15;
            // 
            // facturasBindingNavigator
            // 
            this.facturasBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.facturasBindingNavigator.BindingSource = this.facturasBindingSource;
            this.facturasBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.facturasBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.facturasBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.facturasBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.facturasBindingNavigatorSaveItem});
            this.facturasBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.facturasBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.facturasBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.facturasBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.facturasBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.facturasBindingNavigator.Name = "facturasBindingNavigator";
            this.facturasBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.facturasBindingNavigator.Size = new System.Drawing.Size(791, 33);
            this.facturasBindingNavigator.TabIndex = 1;
            this.facturasBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorAddNewItem.Text = "Agregar nuevo";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(57, 28);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // facturasBindingNavigatorSaveItem
            // 
            this.facturasBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.facturasBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("facturasBindingNavigatorSaveItem.Image")));
            this.facturasBindingNavigatorSaveItem.Name = "facturasBindingNavigatorSaveItem";
            this.facturasBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 28);
            this.facturasBindingNavigatorSaveItem.Text = "Guardar datos";
            this.facturasBindingNavigatorSaveItem.Click += new System.EventHandler(this.facturasBindingNavigatorSaveItem_Click);
            // 
            // frmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 533);
            this.Controls.Add(this.facturasBindingNavigator);
            this.Controls.Add(this.panel1);
            this.Name = "frmFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FACTURAS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFacturas_FormClosing);
            this.Load += new System.EventHandler(this.frmFacturas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detallesFacturaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallesFacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingNavigator)).EndInit();
            this.facturasBindingNavigator.ResumeLayout(false);
            this.facturasBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView detallesFacturaDataGridView;
        private System.Windows.Forms.BindingSource detallesFacturaBindingSource;
        private System.Windows.Forms.BindingSource facturasBindingSource;
        private System.Windows.Forms.TextBox clienteIDTextBox;
        private System.Windows.Forms.TextBox descuentoTextBox;
        private System.Windows.Forms.TextBox empleadoIDTextBox;
        private System.Windows.Forms.DateTimePicker fechaIngresoDateTimePicker;
        private System.Windows.Forms.TextBox iSVTextBox;
        private System.Windows.Forms.TextBox subTotalTextBox;
        private System.Windows.Forms.TextBox totalPagarTextBox;
        private System.Windows.Forms.BindingNavigator facturasBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton facturasBindingNavigatorSaveItem;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox facturaIDTextBox;
    }
}

