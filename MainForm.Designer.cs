namespace KeyNest
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip ribbonMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openDatabaseToolStripMenuItem;
        private ToolStripMenuItem backupDatabaseToolStripMenuItem;
        private ToolStripMenuItem restoreDatabaseToolStripMenuItem;
        private ToolStripMenuItem exportCSVToolStripMenuItem;
        private ToolStripMenuItem importCSVToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem newEntryToolStripMenuItem;
        private ToolStripMenuItem editEntryToolStripMenuItem;
        private ToolStripMenuItem deleteEntryToolStripMenuItem;
        private ToolStripMenuItem duplicateEntryToolStripMenuItem;
        private ToolStripMenuItem entryToolStripMenuItem;
        private ToolStripMenuItem copyUsernameToolStripMenuItem;
        private ToolStripMenuItem copyPasswordToolStripMenuItem;
        private ToolStripMenuItem copyAllToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem toggleThemeToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem openLogsFolderToolStripMenuItem;
        private ToolStrip toolStrip;
        private ToolStripButton btnNew;
        private ToolStripButton btnEdit;
        private ToolStripButton btnDelete;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnCopyUsername;
        private ToolStripButton btnCopyPassword;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnGeneratePassword;
        private SplitContainer mainSplitContainer;
        private Panel rightPanel;
        private SplitContainer rightSplitContainer;
        private DataGridView dgvPasswords;
        private Panel detailPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblAppName;
        private TextBox txtAppName;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private Panel passwordPanel;
        private TextBox txtPassword;
        private Button btnTogglePassword;
        private Button btnGenerate;
        private ProgressBar strengthBar;
        private Label lblStrength;
        private Label lblTags;
        private TextBox txtTags;
        private Label lblNotes;
        private TextBox txtNotes;
        private CheckBox chkFavorite;
        private Label lblSaveDate;
        private DateTimePicker dtpSaveDate;
        private Label lblLastChange;
        private DateTimePicker dtpLastChange;
        private Label lblPasswordID;
        private TextBox txtPasswordID;
        private FlowLayoutPanel buttonsPanel;
        private Button btnSave;
        private Button btnCancel;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblRecordCount;
        private ToolStripStatusLabel lblDbPath;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem copyAppNameContextMenuItem;
        private ToolStripMenuItem copyUsernameContextMenuItem;
        private ToolStripMenuItem copyPasswordContextMenuItem;
        private ToolStripMenuItem copySaveDateContextMenuItem;
        private ToolStripMenuItem copyLastChangeDateContextMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem openWebsiteContextMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem editContextMenuItem;
        private ToolStripMenuItem deleteContextMenuItem;
        private ToolStripMenuItem duplicateContextMenuItem;
        private ToolStripMenuItem showPasswordContextMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ribbonMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openDatabaseToolStripMenuItem = new ToolStripMenuItem();
            backupDatabaseToolStripMenuItem = new ToolStripMenuItem();
            restoreDatabaseToolStripMenuItem = new ToolStripMenuItem();
            exportCSVToolStripMenuItem = new ToolStripMenuItem();
            importCSVToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            newEntryToolStripMenuItem = new ToolStripMenuItem();
            editEntryToolStripMenuItem = new ToolStripMenuItem();
            deleteEntryToolStripMenuItem = new ToolStripMenuItem();
            duplicateEntryToolStripMenuItem = new ToolStripMenuItem();
            entryToolStripMenuItem = new ToolStripMenuItem();
            copyUsernameToolStripMenuItem = new ToolStripMenuItem();
            copyPasswordToolStripMenuItem = new ToolStripMenuItem();
            copyAllToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            toggleThemeToolStripMenuItem = new ToolStripMenuItem();
            generatePasswordToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            openLogsFolderToolStripMenuItem = new ToolStripMenuItem();
            toolStrip = new ToolStrip();
            btnNew = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnCopyUsername = new ToolStripButton();
            btnCopyPassword = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnGeneratePassword = new ToolStripButton();
            mainSplitContainer = new SplitContainer();
            rightPanel = new Panel();
            rightSplitContainer = new SplitContainer();
            dgvPasswords = new DataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            copyAppNameContextMenuItem = new ToolStripMenuItem();
            copyUsernameContextMenuItem = new ToolStripMenuItem();
            copyPasswordContextMenuItem = new ToolStripMenuItem();
            copySaveDateContextMenuItem = new ToolStripMenuItem();
            copyLastChangeDateContextMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            openWebsiteContextMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            editContextMenuItem = new ToolStripMenuItem();
            deleteContextMenuItem = new ToolStripMenuItem();
            duplicateContextMenuItem = new ToolStripMenuItem();
            showPasswordContextMenuItem = new ToolStripMenuItem();
            detailPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblAppName = new Label();
            txtAppName = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            passwordPanel = new Panel();
            txtPassword = new TextBox();
            btnTogglePassword = new Button();
            btnGenerate = new Button();
            strengthBar = new ProgressBar();
            lblStrength = new Label();
            lblTags = new Label();
            txtTags = new TextBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            chkFavorite = new CheckBox();
            lblSaveDate = new Label();
            dtpSaveDate = new DateTimePicker();
            lblLastChange = new Label();
            dtpLastChange = new DateTimePicker();
            lblPasswordID = new Label();
            txtPasswordID = new TextBox();
            buttonsPanel = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblRecordCount = new ToolStripStatusLabel();
            lblDbPath = new ToolStripStatusLabel();
            ribbonMenu.SuspendLayout();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).BeginInit();
            mainSplitContainer.Panel2.SuspendLayout();
            mainSplitContainer.SuspendLayout();
            rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rightSplitContainer).BeginInit();
            rightSplitContainer.Panel1.SuspendLayout();
            rightSplitContainer.Panel2.SuspendLayout();
            rightSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPasswords).BeginInit();
            contextMenuStrip.SuspendLayout();
            detailPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            passwordPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ribbonMenu
            // 
            ribbonMenu.BackColor = Color.FromArgb(43, 108, 176);
            ribbonMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, entryToolStripMenuItem, viewToolStripMenuItem, helpToolStripMenuItem });
            ribbonMenu.Location = new Point(0, 0);
            ribbonMenu.Name = "ribbonMenu";
            ribbonMenu.Size = new Size(1264, 24);
            ribbonMenu.TabIndex = 0;
            ribbonMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openDatabaseToolStripMenuItem, backupDatabaseToolStripMenuItem, restoreDatabaseToolStripMenuItem, exportCSVToolStripMenuItem, importCSVToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = Color.White;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openDatabaseToolStripMenuItem
            // 
            openDatabaseToolStripMenuItem.Image = Properties.Resources.icons8_db_96;
            openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            openDatabaseToolStripMenuItem.Size = new Size(164, 22);
            openDatabaseToolStripMenuItem.Text = "Open Database";
            openDatabaseToolStripMenuItem.Click += OpenDatabaseToolStripMenuItem_Click;
            // 
            // backupDatabaseToolStripMenuItem
            // 
            backupDatabaseToolStripMenuItem.Image = Properties.Resources.icons8_backup_96;
            backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            backupDatabaseToolStripMenuItem.Size = new Size(164, 22);
            backupDatabaseToolStripMenuItem.Text = "Backup Database";
            backupDatabaseToolStripMenuItem.Click += BackupDatabaseToolStripMenuItem_Click;
            // 
            // restoreDatabaseToolStripMenuItem
            // 
            restoreDatabaseToolStripMenuItem.Image = Properties.Resources.icons8_restore_96;
            restoreDatabaseToolStripMenuItem.Name = "restoreDatabaseToolStripMenuItem";
            restoreDatabaseToolStripMenuItem.Size = new Size(164, 22);
            restoreDatabaseToolStripMenuItem.Text = "Restore Database";
            restoreDatabaseToolStripMenuItem.Click += RestoreDatabaseToolStripMenuItem_Click;
            // 
            // exportCSVToolStripMenuItem
            // 
            exportCSVToolStripMenuItem.Image = Properties.Resources.icons8_exportcsv_96;
            exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            exportCSVToolStripMenuItem.Size = new Size(164, 22);
            exportCSVToolStripMenuItem.Text = "Export CSV";
            exportCSVToolStripMenuItem.Click += ExportCSVToolStripMenuItem_Click;
            // 
            // importCSVToolStripMenuItem
            // 
            importCSVToolStripMenuItem.Image = Properties.Resources.icons8_importcsv_96;
            importCSVToolStripMenuItem.Name = "importCSVToolStripMenuItem";
            importCSVToolStripMenuItem.Size = new Size(164, 22);
            importCSVToolStripMenuItem.Text = "Import CSV";
            importCSVToolStripMenuItem.Click += ImportCSVToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(161, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = Properties.Resources.icons8_exit_96;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(164, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newEntryToolStripMenuItem, editEntryToolStripMenuItem, deleteEntryToolStripMenuItem, duplicateEntryToolStripMenuItem });
            editToolStripMenuItem.ForeColor = Color.White;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // newEntryToolStripMenuItem
            // 
            newEntryToolStripMenuItem.Image = Properties.Resources.icons8_add_new_96;
            newEntryToolStripMenuItem.Name = "newEntryToolStripMenuItem";
            newEntryToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newEntryToolStripMenuItem.Size = new Size(171, 22);
            newEntryToolStripMenuItem.Text = "New Entry";
            newEntryToolStripMenuItem.Click += NewEntryToolStripMenuItem_Click;
            // 
            // editEntryToolStripMenuItem
            // 
            editEntryToolStripMenuItem.Image = Properties.Resources.icons8_edit_96;
            editEntryToolStripMenuItem.Name = "editEntryToolStripMenuItem";
            editEntryToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            editEntryToolStripMenuItem.Size = new Size(171, 22);
            editEntryToolStripMenuItem.Text = "Edit Entry";
            editEntryToolStripMenuItem.Click += EditEntryToolStripMenuItem_Click;
            // 
            // deleteEntryToolStripMenuItem
            // 
            deleteEntryToolStripMenuItem.Image = Properties.Resources.icons8_delete_96;
            deleteEntryToolStripMenuItem.Name = "deleteEntryToolStripMenuItem";
            deleteEntryToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteEntryToolStripMenuItem.Size = new Size(171, 22);
            deleteEntryToolStripMenuItem.Text = "Delete Entry";
            deleteEntryToolStripMenuItem.Click += DeleteEntryToolStripMenuItem_Click;
            // 
            // duplicateEntryToolStripMenuItem
            // 
            duplicateEntryToolStripMenuItem.Image = Properties.Resources.icons8_copy_machine_96;
            duplicateEntryToolStripMenuItem.Name = "duplicateEntryToolStripMenuItem";
            duplicateEntryToolStripMenuItem.Size = new Size(171, 22);
            duplicateEntryToolStripMenuItem.Text = "Duplicate Entry";
            duplicateEntryToolStripMenuItem.Click += DuplicateEntryToolStripMenuItem_Click;
            // 
            // entryToolStripMenuItem
            // 
            entryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyUsernameToolStripMenuItem, copyPasswordToolStripMenuItem, copyAllToolStripMenuItem });
            entryToolStripMenuItem.ForeColor = Color.White;
            entryToolStripMenuItem.Name = "entryToolStripMenuItem";
            entryToolStripMenuItem.Size = new Size(46, 20);
            entryToolStripMenuItem.Text = "Entry";
            // 
            // copyUsernameToolStripMenuItem
            // 
            copyUsernameToolStripMenuItem.Image = Properties.Resources.icons8_copy_96;
            copyUsernameToolStripMenuItem.Name = "copyUsernameToolStripMenuItem";
            copyUsernameToolStripMenuItem.Size = new Size(158, 22);
            copyUsernameToolStripMenuItem.Text = "Copy Username";
            copyUsernameToolStripMenuItem.Click += CopyUsernameToolStripMenuItem_Click;
            // 
            // copyPasswordToolStripMenuItem
            // 
            copyPasswordToolStripMenuItem.Image = Properties.Resources.icons8_copy_96;
            copyPasswordToolStripMenuItem.Name = "copyPasswordToolStripMenuItem";
            copyPasswordToolStripMenuItem.Size = new Size(158, 22);
            copyPasswordToolStripMenuItem.Text = "Copy Password";
            copyPasswordToolStripMenuItem.Click += CopyPasswordToolStripMenuItem_Click;
            // 
            // copyAllToolStripMenuItem
            // 
            copyAllToolStripMenuItem.Image = Properties.Resources.icons8_copy_96;
            copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            copyAllToolStripMenuItem.Size = new Size(158, 22);
            copyAllToolStripMenuItem.Text = "Copy All";
            copyAllToolStripMenuItem.Click += CopyAllToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toggleThemeToolStripMenuItem, generatePasswordToolStripMenuItem });
            viewToolStripMenuItem.ForeColor = Color.White;
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // toggleThemeToolStripMenuItem
            // 
            toggleThemeToolStripMenuItem.Image = Properties.Resources.icons8_theme_96;
            toggleThemeToolStripMenuItem.Name = "toggleThemeToolStripMenuItem";
            toggleThemeToolStripMenuItem.Size = new Size(174, 22);
            toggleThemeToolStripMenuItem.Text = "Toggle Theme";
            toggleThemeToolStripMenuItem.Click += ToggleThemeToolStripMenuItem_Click;
            // 
            // generatePasswordToolStripMenuItem
            // 
            generatePasswordToolStripMenuItem.Image = Properties.Resources.icons8_forgot_password_96;
            generatePasswordToolStripMenuItem.Name = "generatePasswordToolStripMenuItem";
            generatePasswordToolStripMenuItem.Size = new Size(174, 22);
            generatePasswordToolStripMenuItem.Text = "Generate Password";
            generatePasswordToolStripMenuItem.Click += BtnGeneratePassword_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, openLogsFolderToolStripMenuItem });
            helpToolStripMenuItem.ForeColor = Color.White;
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Image = Properties.Resources.icons8_about_96;
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(167, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // openLogsFolderToolStripMenuItem
            // 
            openLogsFolderToolStripMenuItem.Image = Properties.Resources.icons8_logs_folder_96;
            openLogsFolderToolStripMenuItem.Name = "openLogsFolderToolStripMenuItem";
            openLogsFolderToolStripMenuItem.Size = new Size(167, 22);
            openLogsFolderToolStripMenuItem.Text = "Open Logs Folder";
            openLogsFolderToolStripMenuItem.Click += OpenLogsFolderToolStripMenuItem_Click;
            // 
            // toolStrip
            // 
            toolStrip.BackColor = Color.WhiteSmoke;
            toolStrip.Items.AddRange(new ToolStripItem[] { btnNew, btnEdit, btnDelete, toolStripSeparator2, btnCopyUsername, btnCopyPassword, toolStripSeparator3, btnGeneratePassword });
            toolStrip.Location = new Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1264, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
            // 
            // btnNew
            // 
            btnNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNew.Image = Properties.Resources.icons8_add_new_96;
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(23, 22);
            btnNew.Text = "New Entry";
            btnNew.Click += BtnNew_Click;
            // 
            // btnEdit
            // 
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEdit.Image = Properties.Resources.icons8_edit_96;
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(23, 22);
            btnEdit.Text = "Edit Entry";
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDelete.Image = Properties.Resources.icons8_delete_96;
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(23, 22);
            btnDelete.Text = "Delete Entry";
            btnDelete.Click += BtnDelete_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // btnCopyUsername
            // 
            btnCopyUsername.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCopyUsername.Image = Properties.Resources.icons8_copy_96;
            btnCopyUsername.ImageTransparentColor = Color.Magenta;
            btnCopyUsername.Name = "btnCopyUsername";
            btnCopyUsername.Size = new Size(23, 22);
            btnCopyUsername.Text = "Copy Username";
            btnCopyUsername.Click += BtnCopyUsername_Click;
            // 
            // btnCopyPassword
            // 
            btnCopyPassword.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCopyPassword.Image = Properties.Resources.icons8_paste_96;
            btnCopyPassword.ImageTransparentColor = Color.Magenta;
            btnCopyPassword.Name = "btnCopyPassword";
            btnCopyPassword.Size = new Size(23, 22);
            btnCopyPassword.Text = "Copy Password";
            btnCopyPassword.Click += BtnCopyPassword_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // btnGeneratePassword
            // 
            btnGeneratePassword.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnGeneratePassword.Image = Properties.Resources.icons8_forgot_password_96;
            btnGeneratePassword.ImageTransparentColor = Color.Magenta;
            btnGeneratePassword.Name = "btnGeneratePassword";
            btnGeneratePassword.Size = new Size(23, 22);
            btnGeneratePassword.Text = "Generate Password";
            btnGeneratePassword.Click += BtnGeneratePassword_Click;
            // 
            // mainSplitContainer
            // 
            mainSplitContainer.Dock = DockStyle.Fill;
            mainSplitContainer.Location = new Point(0, 49);
            mainSplitContainer.Name = "mainSplitContainer";
            mainSplitContainer.Panel1Collapsed = true;
            // 
            // mainSplitContainer.Panel2
            // 
            mainSplitContainer.Panel2.Controls.Add(rightPanel);
            mainSplitContainer.Size = new Size(1264, 590);
            mainSplitContainer.SplitterDistance = 200;
            mainSplitContainer.TabIndex = 2;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(rightSplitContainer);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(0, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(1264, 590);
            rightPanel.TabIndex = 0;
            // 
            // rightSplitContainer
            // 
            rightSplitContainer.Dock = DockStyle.Fill;
            rightSplitContainer.Location = new Point(0, 0);
            rightSplitContainer.Name = "rightSplitContainer";
            rightSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // rightSplitContainer.Panel1
            // 
            rightSplitContainer.Panel1.Controls.Add(dgvPasswords);
            // 
            // rightSplitContainer.Panel2
            // 
            rightSplitContainer.Panel2.Controls.Add(detailPanel);
            rightSplitContainer.Size = new Size(1264, 590);
            rightSplitContainer.SplitterDistance = 348;
            rightSplitContainer.TabIndex = 0;
            // 
            // dgvPasswords
            // 
            dgvPasswords.AllowUserToAddRows = false;
            dgvPasswords.AllowUserToDeleteRows = false;
            dgvPasswords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvPasswords.BackgroundColor = SystemColors.Window;
            dgvPasswords.BorderStyle = BorderStyle.None;
            dgvPasswords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPasswords.ContextMenuStrip = contextMenuStrip;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvPasswords.DefaultCellStyle = dataGridViewCellStyle1;
            dgvPasswords.Dock = DockStyle.Fill;
            dgvPasswords.Location = new Point(0, 0);
            dgvPasswords.Name = "dgvPasswords";
            dgvPasswords.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPasswords.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPasswords.RowHeadersVisible = false;
            dgvPasswords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPasswords.Size = new Size(1264, 348);
            dgvPasswords.TabIndex = 0;
            dgvPasswords.CellDoubleClick += DgvPasswords_CellDoubleClick;
            dgvPasswords.SelectionChanged += DgvPasswords_SelectionChanged;
            dgvPasswords.KeyDown += DgvPasswords_KeyDown;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { copyAppNameContextMenuItem, copyUsernameContextMenuItem, copyPasswordContextMenuItem, copySaveDateContextMenuItem, copyLastChangeDateContextMenuItem, toolStripSeparator4, openWebsiteContextMenuItem, toolStripSeparator5, editContextMenuItem, deleteContextMenuItem, duplicateContextMenuItem, showPasswordContextMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(168, 236);
            // 
            // copyAppNameContextMenuItem
            // 
            copyAppNameContextMenuItem.Name = "copyAppNameContextMenuItem";
            copyAppNameContextMenuItem.Size = new Size(167, 22);
            copyAppNameContextMenuItem.Text = "Copy AppName";
            copyAppNameContextMenuItem.Click += CopyAppNameContextMenuItem_Click;
            // 
            // copyUsernameContextMenuItem
            // 
            copyUsernameContextMenuItem.Name = "copyUsernameContextMenuItem";
            copyUsernameContextMenuItem.Size = new Size(167, 22);
            copyUsernameContextMenuItem.Text = "Copy Username";
            copyUsernameContextMenuItem.Click += CopyUsernameContextMenuItem_Click;
            // 
            // copyPasswordContextMenuItem
            // 
            copyPasswordContextMenuItem.Name = "copyPasswordContextMenuItem";
            copyPasswordContextMenuItem.Size = new Size(167, 22);
            copyPasswordContextMenuItem.Text = "Copy Password";
            copyPasswordContextMenuItem.Click += CopyPasswordContextMenuItem_Click;
            // 
            // copySaveDateContextMenuItem
            // 
            copySaveDateContextMenuItem.Name = "copySaveDateContextMenuItem";
            copySaveDateContextMenuItem.Size = new Size(167, 22);
            copySaveDateContextMenuItem.Text = "Copy SaveDate";
            copySaveDateContextMenuItem.Click += CopySaveDateContextMenuItem_Click;
            // 
            // copyLastChangeDateContextMenuItem
            // 
            copyLastChangeDateContextMenuItem.Name = "copyLastChangeDateContextMenuItem";
            copyLastChangeDateContextMenuItem.Size = new Size(167, 22);
            copyLastChangeDateContextMenuItem.Text = "Copy LastChange";
            copyLastChangeDateContextMenuItem.Click += CopyLastChangeDateContextMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(164, 6);
            // 
            // openWebsiteContextMenuItem
            // 
            openWebsiteContextMenuItem.Name = "openWebsiteContextMenuItem";
            openWebsiteContextMenuItem.Size = new Size(167, 22);
            openWebsiteContextMenuItem.Text = "Open Website";
            openWebsiteContextMenuItem.Click += OpenWebsiteContextMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(164, 6);
            // 
            // editContextMenuItem
            // 
            editContextMenuItem.Name = "editContextMenuItem";
            editContextMenuItem.Size = new Size(167, 22);
            editContextMenuItem.Text = "Edit";
            editContextMenuItem.Click += EditContextMenuItem_Click;
            // 
            // deleteContextMenuItem
            // 
            deleteContextMenuItem.Name = "deleteContextMenuItem";
            deleteContextMenuItem.Size = new Size(167, 22);
            deleteContextMenuItem.Text = "Delete";
            deleteContextMenuItem.Click += DeleteContextMenuItem_Click;
            // 
            // duplicateContextMenuItem
            // 
            duplicateContextMenuItem.Name = "duplicateContextMenuItem";
            duplicateContextMenuItem.Size = new Size(167, 22);
            duplicateContextMenuItem.Text = "Duplicate";
            duplicateContextMenuItem.Click += DuplicateContextMenuItem_Click;
            // 
            // showPasswordContextMenuItem
            // 
            showPasswordContextMenuItem.Name = "showPasswordContextMenuItem";
            showPasswordContextMenuItem.Size = new Size(167, 22);
            showPasswordContextMenuItem.Text = "Show Password";
            showPasswordContextMenuItem.Click += ShowPasswordContextMenuItem_Click;
            // 
            // detailPanel
            // 
            detailPanel.Controls.Add(tableLayoutPanel1);
            detailPanel.Dock = DockStyle.Fill;
            detailPanel.Location = new Point(0, 0);
            detailPanel.Name = "detailPanel";
            detailPanel.Size = new Size(1264, 238);
            detailPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblAppName, 0, 0);
            tableLayoutPanel1.Controls.Add(txtAppName, 1, 0);
            tableLayoutPanel1.Controls.Add(lblUsername, 0, 1);
            tableLayoutPanel1.Controls.Add(txtUsername, 1, 1);
            tableLayoutPanel1.Controls.Add(lblPassword, 0, 2);
            tableLayoutPanel1.Controls.Add(passwordPanel, 1, 2);
            tableLayoutPanel1.Controls.Add(lblTags, 2, 0);
            tableLayoutPanel1.Controls.Add(txtTags, 3, 0);
            tableLayoutPanel1.Controls.Add(lblNotes, 2, 1);
            tableLayoutPanel1.Controls.Add(txtNotes, 3, 1);
            tableLayoutPanel1.Controls.Add(chkFavorite, 2, 2);
            tableLayoutPanel1.Controls.Add(lblSaveDate, 0, 3);
            tableLayoutPanel1.Controls.Add(dtpSaveDate, 1, 3);
            tableLayoutPanel1.Controls.Add(lblLastChange, 2, 3);
            tableLayoutPanel1.Controls.Add(dtpLastChange, 3, 3);
            tableLayoutPanel1.Controls.Add(lblPasswordID, 0, 4);
            tableLayoutPanel1.Controls.Add(txtPasswordID, 1, 4);
            tableLayoutPanel1.Controls.Add(buttonsPanel, 2, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(1264, 238);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Dock = DockStyle.Fill;
            lblAppName.Location = new Point(3, 0);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(114, 30);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "App Name:";
            lblAppName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAppName
            // 
            txtAppName.Dock = DockStyle.Fill;
            txtAppName.Location = new Point(123, 3);
            txtAppName.Name = "txtAppName";
            txtAppName.Size = new Size(506, 23);
            txtAppName.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Dock = DockStyle.Fill;
            lblUsername.Location = new Point(3, 30);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(114, 30);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            lblUsername.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtUsername
            // 
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Location = new Point(123, 33);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(506, 23);
            txtUsername.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Dock = DockStyle.Fill;
            lblPassword.Location = new Point(3, 60);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(114, 30);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            lblPassword.TextAlign = ContentAlignment.MiddleRight;
            // 
            // passwordPanel
            // 
            passwordPanel.Controls.Add(txtPassword);
            passwordPanel.Controls.Add(btnTogglePassword);
            passwordPanel.Controls.Add(btnGenerate);
            passwordPanel.Controls.Add(strengthBar);
            passwordPanel.Controls.Add(lblStrength);
            passwordPanel.Dock = DockStyle.Fill;
            passwordPanel.Location = new Point(123, 63);
            passwordPanel.Name = "passwordPanel";
            passwordPanel.Size = new Size(506, 24);
            passwordPanel.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Dock = DockStyle.Left;
            txtPassword.Location = new Point(0, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 23);
            txtPassword.TabIndex = 0;
            txtPassword.TextChanged += TxtPassword_TextChanged;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.Dock = DockStyle.Right;
            btnTogglePassword.Location = new Point(355, 0);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(75, 24);
            btnTogglePassword.TabIndex = 1;
            btnTogglePassword.Text = "Show";
            btnTogglePassword.UseVisualStyleBackColor = true;
            btnTogglePassword.Click += BtnTogglePassword_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Dock = DockStyle.Right;
            btnGenerate.Location = new Point(430, 0);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(40, 24);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Gen";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += BtnGenerate_Click;
            // 
            // strengthBar
            // 
            strengthBar.Dock = DockStyle.Bottom;
            strengthBar.Location = new Point(0, 24);
            strengthBar.Name = "strengthBar";
            strengthBar.Size = new Size(470, 0);
            strengthBar.TabIndex = 3;
            // 
            // lblStrength
            // 
            lblStrength.AutoSize = true;
            lblStrength.Dock = DockStyle.Right;
            lblStrength.Location = new Point(470, 0);
            lblStrength.Name = "lblStrength";
            lblStrength.Size = new Size(36, 15);
            lblStrength.TabIndex = 4;
            lblStrength.Text = "Weak";
            // 
            // lblTags
            // 
            lblTags.AutoSize = true;
            lblTags.Dock = DockStyle.Fill;
            lblTags.Location = new Point(635, 0);
            lblTags.Name = "lblTags";
            lblTags.Size = new Size(114, 30);
            lblTags.TabIndex = 6;
            lblTags.Text = "Tags:";
            lblTags.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTags
            // 
            txtTags.Dock = DockStyle.Fill;
            txtTags.Location = new Point(755, 3);
            txtTags.Name = "txtTags";
            txtTags.Size = new Size(506, 23);
            txtTags.TabIndex = 7;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Dock = DockStyle.Fill;
            lblNotes.Location = new Point(635, 30);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(114, 30);
            lblNotes.TabIndex = 8;
            lblNotes.Text = "Notes:";
            lblNotes.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNotes
            // 
            txtNotes.Dock = DockStyle.Fill;
            txtNotes.Location = new Point(755, 33);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(506, 24);
            txtNotes.TabIndex = 9;
            // 
            // chkFavorite
            // 
            chkFavorite.AutoSize = true;
            chkFavorite.Dock = DockStyle.Fill;
            chkFavorite.Location = new Point(635, 63);
            chkFavorite.Name = "chkFavorite";
            chkFavorite.Size = new Size(114, 24);
            chkFavorite.TabIndex = 10;
            chkFavorite.Text = "Favorite";
            chkFavorite.UseVisualStyleBackColor = true;
            // 
            // lblSaveDate
            // 
            lblSaveDate.AutoSize = true;
            lblSaveDate.Dock = DockStyle.Fill;
            lblSaveDate.Location = new Point(3, 90);
            lblSaveDate.Name = "lblSaveDate";
            lblSaveDate.Size = new Size(114, 30);
            lblSaveDate.TabIndex = 11;
            lblSaveDate.Text = "Save Date:";
            lblSaveDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpSaveDate
            // 
            dtpSaveDate.Dock = DockStyle.Fill;
            dtpSaveDate.Enabled = false;
            dtpSaveDate.Location = new Point(123, 93);
            dtpSaveDate.Name = "dtpSaveDate";
            dtpSaveDate.Size = new Size(506, 23);
            dtpSaveDate.TabIndex = 12;
            // 
            // lblLastChange
            // 
            lblLastChange.AutoSize = true;
            lblLastChange.Dock = DockStyle.Fill;
            lblLastChange.Location = new Point(635, 90);
            lblLastChange.Name = "lblLastChange";
            lblLastChange.Size = new Size(114, 30);
            lblLastChange.TabIndex = 13;
            lblLastChange.Text = "Last Change:";
            lblLastChange.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpLastChange
            // 
            dtpLastChange.Dock = DockStyle.Fill;
            dtpLastChange.Enabled = false;
            dtpLastChange.Location = new Point(755, 93);
            dtpLastChange.Name = "dtpLastChange";
            dtpLastChange.Size = new Size(506, 23);
            dtpLastChange.TabIndex = 14;
            // 
            // lblPasswordID
            // 
            lblPasswordID.AutoSize = true;
            lblPasswordID.Dock = DockStyle.Fill;
            lblPasswordID.Location = new Point(3, 120);
            lblPasswordID.Name = "lblPasswordID";
            lblPasswordID.Size = new Size(114, 118);
            lblPasswordID.TabIndex = 15;
            lblPasswordID.Text = "Password ID:";
            lblPasswordID.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPasswordID
            // 
            txtPasswordID.Dock = DockStyle.Fill;
            txtPasswordID.Enabled = false;
            txtPasswordID.Location = new Point(123, 123);
            txtPasswordID.Name = "txtPasswordID";
            txtPasswordID.Size = new Size(506, 23);
            txtPasswordID.TabIndex = 16;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(btnSave);
            buttonsPanel.Controls.Add(btnCancel);
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonsPanel.Location = new Point(635, 123);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(114, 112);
            buttonsPanel.TabIndex = 17;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(36, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 25);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(36, 34);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 25);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus, lblRecordCount, lblDbPath });
            statusStrip.Location = new Point(0, 639);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1264, 24);
            statusStrip.TabIndex = 3;
            statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 19);
            lblStatus.Text = "Ready";
            // 
            // lblRecordCount
            // 
            lblRecordCount.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(59, 19);
            lblRecordCount.Text = "0 records";
            // 
            // lblDbPath
            // 
            lblDbPath.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblDbPath.Name = "lblDbPath";
            lblDbPath.Size = new Size(1151, 19);
            lblDbPath.Spring = true;
            lblDbPath.Text = "KeyNest.db";
            lblDbPath.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 663);
            Controls.Add(mainSplitContainer);
            Controls.Add(toolStrip);
            Controls.Add(ribbonMenu);
            Controls.Add(statusStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = ribbonMenu;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KeyNest - Mohammad Taha Omidi";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ribbonMenu.ResumeLayout(false);
            ribbonMenu.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).EndInit();
            mainSplitContainer.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            rightSplitContainer.Panel1.ResumeLayout(false);
            rightSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rightSplitContainer).EndInit();
            rightSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPasswords).EndInit();
            contextMenuStrip.ResumeLayout(false);
            detailPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            passwordPanel.ResumeLayout(false);
            passwordPanel.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private ToolStripMenuItem generatePasswordToolStripMenuItem;
    }
}