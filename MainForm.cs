using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace KeyNest
{
    public partial class MainForm : Form
    {
        private readonly string appDataPath;
        private readonly string dbPath;
        private readonly string logsPath;
        private readonly string settingsPath;
        private StreamWriter logWriter;
        private SqliteConnection dbConnection;
        private BindingList<PasswordEntry> passwordEntries;
        private BindingSource bindingSource;
        private bool isDarkTheme = false;
        private AppSettings settings;

        public MainForm()
        {
            InitializeComponent();

            // Initialize paths - use application directory instead of LocalAppData
            appDataPath = Application.StartupPath;
            dbPath = Path.Combine(appDataPath, "KeyNest.db");
            logsPath = Path.Combine(appDataPath, "Logs");
            settingsPath = Path.Combine(appDataPath, "settings.json");

            InitializeApplication();
        }

        #region Initialization
        private void InitializeApplication()
        {
            CreateFolders();
            InitializeLogging();
            InitializeDatabase();
            LoadSettings();
            InitializeDataBinding();
            ApplyTheme();
            RefreshData();

            LogInfo("App Opened.");
        }

        private void CreateFolders()
        {
            try
            {
                if (!Directory.Exists(logsPath))
                    Directory.CreateDirectory(logsPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating application folders: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeLogging()
        {
            try
            {
                string logFile = Path.Combine(logsPath,
                    $"{DateTime.Now:yyyyMMdd-HHmmss}.log");
                logWriter = new StreamWriter(logFile, true, Encoding.UTF8);

                // Test write
                LogInfo("Logging initialized successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing logging: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDatabase()
        {
            try
            {
                bool isNewDatabase = !File.Exists(dbPath);

                dbConnection = new SqliteConnection($"Data Source={dbPath}");
                dbConnection.Open();

                if (isNewDatabase)
                {
                    CreateDatabaseSchema();
                    LogInfo($"Not Any Database In Directory {appDataPath} Found, Creating New Database");
                }

                // Verify schema and migrate if needed
                VerifyAndMigrateSchema();
            }
            catch (Exception ex)
            {
                LogError($"Database initialization failed: {ex.Message}");
                MessageBox.Show($"Error initializing database: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDatabaseSchema()
        {
            using var command = dbConnection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Passwords (
                    PasswordID INTEGER PRIMARY KEY AUTOINCREMENT,
                    AppName NVARCHAR(512) NOT NULL,
                    Username NVARCHAR(512) NULL,
                    Password NVARCHAR(2048) NULL,
                    SaveDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    LastChangeDate DATETIME NULL,
                    Tags NVARCHAR(512) NULL,
                    Notes NVARCHAR(2000) NULL,
                    IsFavorite INTEGER DEFAULT 0,
                    UNIQUE(AppName, Username)
                );
                
                CREATE INDEX IF NOT EXISTS idx_passwords_appname ON Passwords(AppName);
                CREATE INDEX IF NOT EXISTS idx_passwords_username ON Passwords(Username);
                
                CREATE TABLE IF NOT EXISTS PasswordHistory (
                    HistoryID INTEGER PRIMARY KEY AUTOINCREMENT,
                    PasswordID INTEGER NOT NULL,
                    OldPassword NVARCHAR(2048) NOT NULL,
                    ChangedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (PasswordID) REFERENCES Passwords (PasswordID) ON DELETE CASCADE
                );
                
                CREATE INDEX IF NOT EXISTS idx_passwordhistory_passwordid ON PasswordHistory(PasswordID);
            ";
            command.ExecuteNonQuery();
        }

        private void VerifyAndMigrateSchema()
        {
            // Basic schema verification - can be extended for migrations
            try
            {
                using var command = dbConnection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Passwords";
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                LogError($"Schema verification failed: {ex.Message}");
                // Implement migration logic here if needed
            }
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(settingsPath))
                {
                    string json = File.ReadAllText(settingsPath);
                    settings = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
                }
                else
                {
                    settings = new AppSettings();
                }

                // Apply settings
                isDarkTheme = settings.IsDarkTheme;
                if (settings.WindowSize != null)
                {
                    this.Size = settings.WindowSize.Value;
                }
                if (settings.WindowLocation != null)
                {
                    this.Location = settings.WindowLocation.Value;
                }
            }
            catch (Exception ex)
            {
                LogError($"Error loading settings: {ex.Message}");
                settings = new AppSettings();
            }
        }

        private void SaveSettings()
        {
            try
            {
                settings.WindowSize = this.Size;
                settings.WindowLocation = this.Location;
                settings.IsDarkTheme = isDarkTheme;

                string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(settingsPath, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                LogError($"Error saving settings: {ex.Message}");
            }
        }

        private void InitializeDataBinding()
        {
            passwordEntries = new BindingList<PasswordEntry>();
            bindingSource = new BindingSource(passwordEntries, null);
            dgvPasswords.DataSource = bindingSource;

            // Configure grid columns
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dgvPasswords.AutoGenerateColumns = false;
            dgvPasswords.Columns.Clear();

            // Add columns manually for better control
            var columns = new[]
            {
                new { Name = "PasswordID", Header = "ID", Width = 50 },
                new { Name = "AppName", Header = "Application/Website", Width = 200 },
                new { Name = "Username", Header = "Username", Width = 150 },
                new { Name = "Password", Header = "Password", Width = 150 },
                new { Name = "SaveDate", Header = "Created", Width = 120 },
                new { Name = "LastChangeDate", Header = "Modified", Width = 120 },
                new { Name = "Tags", Header = "Tags", Width = 100 },
                new { Name = "Notes", Header = "Notes", Width = 150 },
                new { Name = "IsFavorite", Header = "★", Width = 30 }
            };

            foreach (var col in columns)
            {
                dgvPasswords.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = col.Name,
                    HeaderText = col.Header,
                    Width = col.Width
                });
            }
        }
        #endregion

        #region Database Operations
        private void RefreshData()
        {
            try
            {
                passwordEntries.Clear();

                using var command = dbConnection.CreateCommand();
                command.CommandText = @"
                    SELECT PasswordID, AppName, Username, Password, SaveDate, 
                           LastChangeDate, Tags, Notes, IsFavorite
                    FROM Passwords 
                    ORDER BY IsFavorite DESC, AppName, Username";

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    passwordEntries.Add(new PasswordEntry
                    {
                        PasswordID = reader.GetInt32("PasswordID"),
                        AppName = reader.GetString("AppName"),
                        Username = reader.IsDBNull("Username") ? null : reader.GetString("Username"),
                        Password = reader.IsDBNull("Password") ? null : reader.GetString("Password"),
                        SaveDate = reader.GetDateTime("SaveDate"),
                        LastChangeDate = reader.IsDBNull("LastChangeDate") ? null : reader.GetDateTime("LastChangeDate"),
                        Tags = reader.IsDBNull("Tags") ? null : reader.GetString("Tags"),
                        Notes = reader.IsDBNull("Notes") ? null : reader.GetString("Notes"),
                        IsFavorite = reader.GetBoolean("IsFavorite")
                    });
                }

                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                LogError($"Error refreshing data: {ex.Message}");
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int InsertPasswordEntry(PasswordEntry entry)
        {
            using var command = dbConnection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Passwords (AppName, Username, Password, Tags, Notes, IsFavorite)
                VALUES (@AppName, @Username, @Password, @Tags, @Notes, @IsFavorite);
                SELECT last_insert_rowid();";

            command.Parameters.AddWithValue("@AppName", entry.AppName);
            command.Parameters.AddWithValue("@Username", (object?)entry.Username ?? DBNull.Value);
            command.Parameters.AddWithValue("@Password", (object?)entry.Password ?? DBNull.Value);
            command.Parameters.AddWithValue("@Tags", (object?)entry.Tags ?? DBNull.Value);
            command.Parameters.AddWithValue("@Notes", (object?)entry.Notes ?? DBNull.Value);
            command.Parameters.AddWithValue("@IsFavorite", entry.IsFavorite);

            var result = command.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        private void UpdatePasswordEntry(PasswordEntry entry)
        {
            // Save old password to history if changed
            var oldEntry = GetPasswordEntry(entry.PasswordID);
            if (oldEntry?.Password != entry.Password)
            {
                SavePasswordToHistory(entry.PasswordID, oldEntry?.Password);
            }

            using var command = dbConnection.CreateCommand();
            command.CommandText = @"
                UPDATE Passwords 
                SET AppName = @AppName, Username = @Username, Password = @Password,
                    LastChangeDate = CURRENT_TIMESTAMP, Tags = @Tags, Notes = @Notes, IsFavorite = @IsFavorite
                WHERE PasswordID = @PasswordID";

            command.Parameters.AddWithValue("@AppName", entry.AppName);
            command.Parameters.AddWithValue("@Username", (object?)entry.Username ?? DBNull.Value);
            command.Parameters.AddWithValue("@Password", (object?)entry.Password ?? DBNull.Value);
            command.Parameters.AddWithValue("@Tags", (object?)entry.Tags ?? DBNull.Value);
            command.Parameters.AddWithValue("@Notes", (object?)entry.Notes ?? DBNull.Value);
            command.Parameters.AddWithValue("@IsFavorite", entry.IsFavorite);
            command.Parameters.AddWithValue("@PasswordID", entry.PasswordID);

            command.ExecuteNonQuery();
        }

        private void DeletePasswordEntry(int passwordId)
        {
            using var command = dbConnection.CreateCommand();
            command.CommandText = "DELETE FROM Passwords WHERE PasswordID = @PasswordID";
            command.Parameters.AddWithValue("@PasswordID", passwordId);
            command.ExecuteNonQuery();
        }

        private PasswordEntry GetPasswordEntry(int passwordId)
        {
            using var command = dbConnection.CreateCommand();
            command.CommandText = @"
                SELECT PasswordID, AppName, Username, Password, SaveDate, 
                       LastChangeDate, Tags, Notes, IsFavorite
                FROM Passwords 
                WHERE PasswordID = @PasswordID";
            command.Parameters.AddWithValue("@PasswordID", passwordId);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new PasswordEntry
                {
                    PasswordID = reader.GetInt32("PasswordID"),
                    AppName = reader.GetString("AppName"),
                    Username = reader.IsDBNull("Username") ? null : reader.GetString("Username"),
                    Password = reader.IsDBNull("Password") ? null : reader.GetString("Password"),
                    SaveDate = reader.GetDateTime("SaveDate"),
                    LastChangeDate = reader.IsDBNull("LastChangeDate") ? null : reader.GetDateTime("LastChangeDate"),
                    Tags = reader.IsDBNull("Tags") ? null : reader.GetString("Tags"),
                    Notes = reader.IsDBNull("Notes") ? null : reader.GetString("Notes"),
                    IsFavorite = reader.GetBoolean("IsFavorite")
                };
            }
            return null;
        }

        private void SavePasswordToHistory(int passwordId, string oldPassword)
        {
            if (string.IsNullOrEmpty(oldPassword)) return;

            using var command = dbConnection.CreateCommand();
            command.CommandText = @"
                INSERT INTO PasswordHistory (PasswordID, OldPassword)
                VALUES (@PasswordID, @OldPassword)";

            command.Parameters.AddWithValue("@PasswordID", passwordId);
            command.Parameters.AddWithValue("@OldPassword", oldPassword);
            command.ExecuteNonQuery();
        }
        #endregion

        #region UI Event Handlers
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblDbPath.Text = "KeyNest.db";
            UpdateStatusBar();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            LogInfo("Closing Application With Code 0 (User Closed App)");
            logWriter?.WriteLine("EOF");
            logWriter?.Close();
            dbConnection?.Close();
        }

        private void OpenDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbConnection.Close();
            using var dialog = new OpenFileDialog();
            dialog.Filter = "SQLite Database (*.db)|*.db|All files (*.*)|*.*";
            dialog.Title = "Open Database File";
            if (MessageBox.Show(
                "Open database? Current data will be replaced.",
                "Open Database",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        
                        File.Copy(dialog.FileName, dbPath, true);
                        InitializeDatabase();
                        RefreshData();
                        LogInfo($"Database opened from: {dialog.FileName}");
                        return;
                    }
                    catch (Exception ex)
                    {
                        LogError($"Error opening database: {ex.Message}");
                        MessageBox.Show($"Error opening database: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            dbConnection.Open();
        }

        private void BackupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog();
            dialog.Filter = "SQLite Database (*.db)|*.db|All files (*.*)|*.*";
            dialog.FileName = $"KeyNest_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.db";
            dialog.Title = "Backup Database";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(dbPath, dialog.FileName, true);
                    LogInfo($"Database backed up to: {dialog.FileName}");
                    MessageBox.Show("Database backup completed successfully.", "Backup Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    LogError($"Error backing up database: {ex.Message}");
                    MessageBox.Show($"Error backing up database: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RestoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Restore database? Current data will be replaced.", "Restore Database",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using var dialog = new OpenFileDialog();
                dialog.Filter = "SQLite Database (*.db)|*.db|All files (*.*)|*.*";
                dialog.Title = "Restore Database File";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        dbConnection?.Close();
                        File.Copy(dialog.FileName, dbPath, true);
                        InitializeDatabase();
                        RefreshData();
                        LogInfo($"Database restored from: {dialog.FileName}");
                        MessageBox.Show("Database restored successfully.", "Restore Complete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        LogError($"Error restoring database: {ex.Message}");
                        MessageBox.Show($"Error restoring database: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
            dialog.FileName = $"KeyNest_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            dialog.Title = "Export to CSV";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToCsv(dialog.FileName);
                    LogInfo($"Exported {passwordEntries.Count} records to {dialog.FileName}");
                    MessageBox.Show($"Exported {passwordEntries.Count} records successfully.", "Export Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    LogError($"Export failed: {ex.Message}");
                    MessageBox.Show($"Error exporting data: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ImportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
            dialog.Title = "Import from CSV";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int importedCount = ImportFromCsv(dialog.FileName);
                    RefreshData();
                    LogInfo($"Imported {importedCount} records from {dialog.FileName}");
                    MessageBox.Show($"Imported {importedCount} records successfully.", "Import Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    LogError($"Import failed: {ex.Message}");
                    MessageBox.Show($"Error importing data: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewEntry();
        }

        private void EditEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedEntry();
        }

        private void DeleteEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedEntries();
        }

        private void DuplicateEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DuplicateSelectedEntry();
        }

        private void CopyUsernameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyUsernameToClipboard();
        }

        private void CopyPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyPasswordToClipboard();
        }

        private void CopyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyAllToClipboard();
        }

        private void GeneratePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPasswordGenerator();
        }

        private void ToggleThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleTheme();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        private void OpenLogsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", logsPath);
            }
            catch (Exception ex)
            {
                LogError($"Error opening logs folder: {ex.Message}");
                MessageBox.Show($"Error opening logs folder: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNew_Click(object sender, EventArgs e) => CreateNewEntry();
        private void BtnEdit_Click(object sender, EventArgs e) => EditSelectedEntry();
        private void BtnDelete_Click(object sender, EventArgs e) => DeleteSelectedEntries();
        private void BtnCopyUsername_Click(object sender, EventArgs e) => CopyUsernameToClipboard();
        private void BtnCopyPassword_Click(object sender, EventArgs e) => CopyPasswordToClipboard();
        private void BtnGeneratePassword_Click(object sender, EventArgs e) => ShowPasswordGenerator();

        private void DgvPasswords_SelectionChanged(object sender, EventArgs e)
        {
            ShowSelectedEntryDetails();
        }

        private void DgvPasswords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditSelectedEntry();
            }
        }

        private void DgvPasswords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedEntries();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                EditSelectedEntry();
            }
        }

        private void CopyAppNameContextMenuItem_Click(object sender, EventArgs e) => CopyAppNameToClipboard();
        private void CopyUsernameContextMenuItem_Click(object sender, EventArgs e) => CopyUsernameToClipboard();
        private void CopyPasswordContextMenuItem_Click(object sender, EventArgs e) => CopyPasswordToClipboard();
        private void CopySaveDateContextMenuItem_Click(object sender, EventArgs e) => CopySaveDateToClipboard();
        private void CopyLastChangeDateContextMenuItem_Click(object sender, EventArgs e) => CopyLastChangeDateToClipboard();

        private void OpenWebsiteContextMenuItem_Click(object sender, EventArgs e)
        {
            OpenSelectedWebsite();
        }

        private void EditContextMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedEntry();
        }

        private void DeleteContextMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedEntries();
        }

        private void DuplicateContextMenuItem_Click(object sender, EventArgs e)
        {
            DuplicateSelectedEntry();
        }

        private void ShowPasswordContextMenuItem_Click(object sender, EventArgs e)
        {
            ShowPasswordTemporarily();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveEntry();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelEdit();
        }

        private void BtnTogglePassword_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            GenerateAndSetPassword();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            UpdatePasswordStrength();
        }
        #endregion

        #region Core Business Logic
        private void CreateNewEntry()
        {
            ClearDetailForm();
            txtPasswordID.Text = "0";
            dtpSaveDate.Value = DateTime.Now;
            dtpLastChange.Value = DateTime.Now;
            detailPanel.Enabled = true;
            LogInfo("Creating new entry");
        }

        private void EditSelectedEntry()
        {
            if (dgvPasswords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an entry to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedEntry = dgvPasswords.SelectedRows[0].DataBoundItem as PasswordEntry;
            if (selectedEntry != null)
            {
                LoadEntryToDetailForm(selectedEntry);
                detailPanel.Enabled = true;
            }
        }

        private void DeleteSelectedEntries()
        {
            if (dgvPasswords.SelectedRows.Count == 0)
            {
                LogError("You are Not Selected Any Row For Delete");
                MessageBox.Show("Please select at least one entry to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Delete {dgvPasswords.SelectedRows.Count} selected entries?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvPasswords.SelectedRows)
                    {
                        if (row.DataBoundItem is PasswordEntry entry)
                        {
                            DeletePasswordEntry(entry.PasswordID);
                            LogInfo($"Deleted entry PasswordID {entry.PasswordID}.");
                        }
                    }
                    RefreshData();
                }
                catch (Exception ex)
                {
                    LogError($"Error deleting entries: {ex.Message}");
                    MessageBox.Show($"Error deleting entries: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DuplicateSelectedEntry()
        {
            if (dgvPasswords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an entry to duplicate.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedEntry = dgvPasswords.SelectedRows[0].DataBoundItem as PasswordEntry;
            if (selectedEntry != null)
            {
                var newEntry = new PasswordEntry
                {
                    AppName = selectedEntry.AppName + " (Copy)",
                    Username = selectedEntry.Username,
                    Password = selectedEntry.Password,
                    Tags = selectedEntry.Tags,
                    Notes = selectedEntry.Notes,
                    IsFavorite = false
                };

                try
                {
                    int newId = InsertPasswordEntry(newEntry);
                    RefreshData();
                    LogInfo($"Duplicated entry: {newEntry.AppName} (PasswordID: {newId}).");
                }
                catch (Exception ex)
                {
                    LogError($"Error duplicating entry: {ex.Message}");
                    MessageBox.Show($"Error duplicating entry: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveEntry()
        {
            if (!ValidateEntry()) return;

            try
            {
                // Fix for parsing issue - handle empty PasswordID
                int passwordId;
                if (string.IsNullOrEmpty(txtPasswordID.Text) || !int.TryParse(txtPasswordID.Text, out passwordId))
                {
                    passwordId = 0;
                }

                var entry = new PasswordEntry
                {
                    PasswordID = passwordId,
                    AppName = txtAppName.Text.Trim(),
                    Username = string.IsNullOrWhiteSpace(txtUsername.Text) ? null : txtUsername.Text.Trim(),
                    Password = string.IsNullOrWhiteSpace(txtPassword.Text) ? null : txtPassword.Text,
                    Tags = string.IsNullOrWhiteSpace(txtTags.Text) ? null : txtTags.Text.Trim(),
                    Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim(),
                    IsFavorite = chkFavorite.Checked,
                    SaveDate = dtpSaveDate.Value,
                    LastChangeDate = dtpLastChange.Value
                };

                if (entry.PasswordID == 0)
                {
                    int newId = InsertPasswordEntry(entry);
                    LogInfo($"Created new entry: {entry.AppName} (PasswordID: {newId}).");
                }
                else
                {
                    UpdatePasswordEntry(entry);
                    LogInfo($"Updated entry PasswordID {entry.PasswordID}.");
                }

                RefreshData();
                ClearDetailForm();
                detailPanel.Enabled = false;
            }
            catch (Exception ex)
            {
                LogError($"Error saving entry: {ex.Message}");
                MessageBox.Show($"Error saving entry: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelEdit()
        {
            ClearDetailForm();
            detailPanel.Enabled = false;
        }

        private bool ValidateEntry()
        {
            if (string.IsNullOrWhiteSpace(txtAppName.Text))
            {
                MessageBox.Show("Application/Website name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAppName.Focus();
                return false;
            }
            return true;
        }

        private void ClearDetailForm()
        {
            txtPasswordID.Text = "0";
            txtAppName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtTags.Clear();
            txtNotes.Clear();
            chkFavorite.Checked = false;
            dtpSaveDate.Value = DateTime.Now;
            dtpLastChange.Value = DateTime.Now;
            strengthBar.Value = 0;
            lblStrength.Text = "Weak";
            txtPassword.UseSystemPasswordChar = true;
            btnTogglePassword.Text = "Show";
        }

        private void LoadEntryToDetailForm(PasswordEntry entry)
        {
            txtPasswordID.Text = entry.PasswordID.ToString();
            txtAppName.Text = entry.AppName;
            txtUsername.Text = entry.Username ?? "";
            txtPassword.Text = entry.Password ?? "";
            txtTags.Text = entry.Tags ?? "";
            txtNotes.Text = entry.Notes ?? "";
            chkFavorite.Checked = entry.IsFavorite;
            dtpSaveDate.Value = entry.SaveDate;
            dtpLastChange.Value = entry.LastChangeDate ?? DateTime.Now;
            UpdatePasswordStrength();
            txtPassword.UseSystemPasswordChar = true;
            btnTogglePassword.Text = "Show";
        }

        private void ShowSelectedEntryDetails()
        {
            if (dgvPasswords.SelectedRows.Count > 0 && dgvPasswords.SelectedRows[0].DataBoundItem is PasswordEntry entry)
            {
                LoadEntryToDetailForm(entry);
            }
        }
        #endregion

        #region Clipboard Operations
        private void CopyAppNameToClipboard()
        {
            if (dgvPasswords.SelectedRows.Count > 0 && dgvPasswords.SelectedRows[0].DataBoundItem is PasswordEntry entry)
            {
                Clipboard.SetText(entry.AppName);
                LogInfo($"Copied AppName: {entry.AppName}");
            }
        }

        private void CopyUsernameToClipboard()
        {
            if (dgvPasswords.SelectedRows.Count > 0 && dgvPasswords.SelectedRows[0].DataBoundItem is PasswordEntry entry)
            {
                Clipboard.SetText(entry.Username ?? "");
                LogInfo($"Copied Username for: {entry.AppName}");
            }
        }

        private void CopyPasswordToClipboard()
        {
            if (dgvPasswords.SelectedRows.Count > 0 && dgvPasswords.SelectedRows[0].DataBoundItem is PasswordEntry entry)
            {
                Clipboard.SetText(entry.Password ?? "");
                LogInfo($"Copied Password for: {entry.AppName}");
            }
        }

        private void CopySaveDateToClipboard()
        {
            if (dgvPasswords.SelectedRows.Count > 0 && dgvPasswords.SelectedRows[0].DataBoundItem is PasswordEntry entry)
            {
                Clipboard.SetText(entry.SaveDate.ToString());
                LogInfo($"Copied SaveDate for: {entry.AppName}");
            }
        }

        private void CopyLastChangeDateToClipboard()
        {
            if (dgvPasswords.SelectedRows.Count > 0 && dgvPasswords.SelectedRows[0].DataBoundItem is PasswordEntry entry)
            {
                Clipboard.SetText(entry.LastChangeDate?.ToString() ?? "");
                LogInfo($"Copied LastChangeDate for: {entry.AppName}");
            }
        }

        private void CopyAllToClipboard()
        {
            if (dgvPasswords.SelectedRows.Count > 0 && dgvPasswords.SelectedRows[0].DataBoundItem is PasswordEntry entry)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Application: {entry.AppName}");
                sb.AppendLine($"Username: {entry.Username}");
                sb.AppendLine($"Password: {entry.Password}");
                sb.AppendLine($"Created: {entry.SaveDate}");
                sb.AppendLine($"Modified: {entry.LastChangeDate}");
                sb.AppendLine($"Tags: {entry.Tags}");
                sb.AppendLine($"Notes: {entry.Notes}");

                Clipboard.SetText(sb.ToString());
                LogInfo($"Copied all details for: {entry.AppName}");
            }
        }
        #endregion

        #region Password Management
        private void TogglePasswordVisibility()
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnTogglePassword.Text = txtPassword.UseSystemPasswordChar ? "Show" : "Hide";
        }

        private void ShowPasswordTemporarily()
        {
            if (dgvPasswords.SelectedRows.Count > 0 && dgvPasswords.SelectedRows[0].DataBoundItem is PasswordEntry entry)
            {
                var tempForm = new Form
                {
                    Text = "Password Preview",
                    Size = new Size(300, 100),
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    StartPosition = FormStartPosition.CenterParent,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                var textBox = new TextBox
                {
                    Text = entry.Password ?? "",
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    UseSystemPasswordChar = false,
                    TextAlign = HorizontalAlignment.Center,
                    Font = new Font("Consolas", 10)
                };

                tempForm.Controls.Add(textBox);
                tempForm.ShowDialog();
            }
        }

        private void GenerateAndSetPassword()
        {
            var password = GeneratePassword(12, true, true, true, true, false);
            txtPassword.Text = password;
            UpdatePasswordStrength();
        }

        private string GeneratePassword(int length, bool includeUppercase, bool includeLowercase,
                                      bool includeNumbers, bool includeSymbols, bool excludeAmbiguous)
        {
            const string uppercase = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string lowercase = "abcdefghijkmnopqrstuvwxyz";
            const string numbers = "23456789";
            const string symbols = "!@#$%^&*";
            const string ambiguous = "O0Il1";

            var charSet = new StringBuilder();
            if (includeUppercase) charSet.Append(uppercase);
            if (includeLowercase) charSet.Append(lowercase);
            if (includeNumbers) charSet.Append(numbers);
            if (includeSymbols) charSet.Append(symbols);

            if (excludeAmbiguous)
            {
                foreach (char c in ambiguous)
                {
                    charSet.Replace(c.ToString(), "");
                }
            }

            if (charSet.Length == 0)
                return string.Empty;

            var password = new StringBuilder();
            var random = new Random();

            // Ensure at least one character from each selected set
            if (includeUppercase) password.Append(uppercase[random.Next(uppercase.Length)]);
            if (includeLowercase) password.Append(lowercase[random.Next(lowercase.Length)]);
            if (includeNumbers) password.Append(numbers[random.Next(numbers.Length)]);
            if (includeSymbols) password.Append(symbols[random.Next(symbols.Length)]);

            // Fill the rest
            while (password.Length < length)
            {
                password.Append(charSet[random.Next(charSet.Length)]);
            }

            // Shuffle the password
            return new string(password.ToString().ToCharArray().OrderBy(x => random.Next()).ToArray());
        }

        private void UpdatePasswordStrength()
        {
            string password = txtPassword.Text;
            int score = CalculatePasswordStrength(password);

            strengthBar.Value = score;
            lblStrength.Text = score switch
            {
                >= 80 => "Strong",
                >= 60 => "Good",
                >= 40 => "Fair",
                >= 20 => "Weak",
                _ => "Very Weak"
            };
        }

        private int CalculatePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password)) return 0;

            int score = 0;

            // Length score
            score += Math.Min(password.Length * 4, 20);

            // Character variety
            if (password.Any(char.IsUpper)) score += 10;
            if (password.Any(char.IsLower)) score += 10;
            if (password.Any(char.IsDigit)) score += 10;
            if (password.Any(c => !char.IsLetterOrDigit(c))) score += 10;

            // Bonus for mixed case
            if (password.Any(char.IsUpper) && password.Any(char.IsLower)) score += 10;

            return Math.Min(score, 100);
        }

        private void ShowPasswordGenerator()
        {
            var generatorForm = new Form
            {
                Text = "Password Generator",
                Size = new Size(400, 300),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 7,
                Padding = new Padding(10)
            };

            // Length
            var lblLength = new Label { Text = "Length:", Anchor = AnchorStyles.Left };
            var numLength = new NumericUpDown { Value = 12, Minimum = 8, Maximum = 64, Dock = DockStyle.Fill };

            // Options
            var chkUppercase = new CheckBox { Text = "Uppercase Letters", Checked = true, Dock = DockStyle.Fill };
            var chkLowercase = new CheckBox { Text = "Lowercase Letters", Checked = true, Dock = DockStyle.Fill };
            var chkNumbers = new CheckBox { Text = "Numbers", Checked = true, Dock = DockStyle.Fill };
            var chkSymbols = new CheckBox { Text = "Symbols", Checked = true, Dock = DockStyle.Fill };
            var chkExcludeAmbiguous = new CheckBox { Text = "Exclude Ambiguous Characters", Checked = false, Dock = DockStyle.Fill };

            // Generated password
            var txtGenerated = new TextBox { Dock = DockStyle.Fill, ReadOnly = true };
            var btnGenerate = new Button { Text = "Generate", Dock = DockStyle.Fill };
            var btnUse = new Button { Text = "Use Password", Dock = DockStyle.Fill };

            btnGenerate.Click += (s, e) =>
            {
                txtGenerated.Text = GeneratePassword(
                    (int)numLength.Value,
                    chkUppercase.Checked,
                    chkLowercase.Checked,
                    chkNumbers.Checked,
                    chkSymbols.Checked,
                    chkExcludeAmbiguous.Checked
                );
            };

            btnUse.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(txtGenerated.Text))
                {
                    txtPassword.Text = txtGenerated.Text;
                    UpdatePasswordStrength();
                }
                generatorForm.Close();
            };

            // Add controls to table
            tableLayout.Controls.Add(lblLength, 0, 0);
            tableLayout.Controls.Add(numLength, 1, 0);
            tableLayout.Controls.Add(chkUppercase, 0, 1);
            tableLayout.Controls.Add(chkLowercase, 1, 1);
            tableLayout.Controls.Add(chkNumbers, 0, 2);
            tableLayout.Controls.Add(chkSymbols, 1, 2);
            tableLayout.Controls.Add(chkExcludeAmbiguous, 0, 3);
            tableLayout.SetColumnSpan(chkExcludeAmbiguous, 2);
            tableLayout.Controls.Add(txtGenerated, 0, 4);
            tableLayout.SetColumnSpan(txtGenerated, 2);
            tableLayout.Controls.Add(btnGenerate, 0, 5);
            tableLayout.Controls.Add(btnUse, 1, 5);

            generatorForm.Controls.Add(tableLayout);
            generatorForm.ShowDialog();
        }
        #endregion

        #region Theme and UI
        private void ToggleTheme()
        {
            isDarkTheme = !isDarkTheme;
            ApplyTheme();
            SaveSettings();
        }

        private void ApplyTheme()
        {
            if (isDarkTheme)
            {
                ApplyDarkTheme();
            }
            else
            {
                ApplyLightTheme();
            }
        }

        private void ApplyLightTheme()
        {
            this.BackColor = Color.FromArgb(248, 250, 252);
            rightPanel.BackColor = Color.FromArgb(248, 250, 252);
            detailPanel.BackColor = Color.White;

            foreach (Control control in GetAllControls(this))
            {
                if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.FromArgb(31, 41, 55);
                }
                else if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.White;
                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
                }
            }
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(15, 23, 42);
            rightPanel.BackColor = Color.FromArgb(15, 23, 42);
            detailPanel.BackColor = Color.FromArgb(30, 41, 59);

            foreach (Control control in GetAllControls(this))
            {
                if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.FromArgb(51, 65, 85);
                    textBox.ForeColor = Color.White;
                }
                else if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.FromArgb(30, 41, 59);
                    dgv.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
                    dgv.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (Control child in GetAllControls(control))
                    yield return child;
            }
        }

        private void UpdateStatusBar()
        {
            int totalCount = passwordEntries.Count;
            int filteredCount = bindingSource.Count;

            lblRecordCount.Text = filteredCount == totalCount ?
                $"{totalCount} records" :
                $"{filteredCount} of {totalCount} records";
        }

        private void OpenSelectedWebsite()
        {
            if (dgvPasswords.SelectedRows.Count > 0 && dgvPasswords.SelectedRows[0].DataBoundItem is PasswordEntry entry)
            {
                string url = entry.AppName.Trim();
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }

                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                    LogInfo($"Opened website: {url}");
                }
                catch (Exception ex)
                {
                    LogError($"Error opening website: {ex.Message}");
                    MessageBox.Show($"Error opening website: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowAboutDialog()
        {
            MessageBox.Show(
                "KeyNest - Password Manager\n\n" +
                "A secure password management application.\n" +
                "Built with C# and WinForms targeting .NET 9.0\n\n" +
                "Features:\n" +
                "• Local SQLite database storage\n" +
                "• Password generation and strength analysis\n" +
                "• Import/Export capabilities\n" +
                "• Dark/Light theme support\n" +
                "Created By: Mohammad Taha Omidi\n" +
                "www.github.com/ActiveGamers",
                "About KeyNest",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        #endregion

        #region Import/Export
        private void ExportToCsv(string filePath)
        {
            using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

            // Write UTF-8 BOM
            writer.Write('\uFEFF');

            // Write header
            writer.WriteLine("AppName,Username,Password,Tags,Notes,IsFavorite,SaveDate,LastChangeDate");

            // Write data
            foreach (PasswordEntry entry in passwordEntries)
            {
                writer.WriteLine(
                    $"\"{EscapeCsvField(entry.AppName)}\"," +
                    $"\"{EscapeCsvField(entry.Username ?? "")}\"," +
                    $"\"{EscapeCsvField(entry.Password ?? "")}\"," +
                    $"\"{EscapeCsvField(entry.Tags ?? "")}\"," +
                    $"\"{EscapeCsvField(entry.Notes ?? "")}\"," +
                    $"{(entry.IsFavorite ? "1" : "0")}," +
                    $"\"{entry.SaveDate:yyyy-MM-dd HH:mm:ss}\"," +
                    $"\"{(entry.LastChangeDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? "")}\""
                );
            }
        }

        private int ImportFromCsv(string filePath)
        {
            int importedCount = 0;

            using var reader = new StreamReader(filePath, Encoding.UTF8);
            string line;
            bool isFirstLine = true;

            while ((line = reader.ReadLine()) != null)
            {
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue; // Skip header
                }

                var fields = ParseCsvLine(line);
                if (fields.Length >= 5)
                {
                    try
                    {
                        var entry = new PasswordEntry
                        {
                            AppName = fields[0],
                            Username = string.IsNullOrEmpty(fields[1]) ? null : fields[1],
                            Password = string.IsNullOrEmpty(fields[2]) ? null : fields[2],
                            Tags = string.IsNullOrEmpty(fields[3]) ? null : fields[3],
                            Notes = string.IsNullOrEmpty(fields[4]) ? null : fields[4],
                            IsFavorite = fields.Length > 5 && fields[5] == "1"
                        };

                        InsertPasswordEntry(entry);
                        importedCount++;
                    }
                    catch (Exception ex)
                    {
                        LogError($"Error importing CSV row: {ex.Message}");
                        // Continue with next row
                    }
                }
            }

            return importedCount;
        }

        private string EscapeCsvField(string field)
        {
            if (field.Contains('"') || field.Contains(',') || field.Contains('\n') || field.Contains('\r'))
            {
                return field.Replace("\"", "\"\"");
            }
            return field;
        }

        private string[] ParseCsvLine(string line)
        {
            var fields = new List<string>();
            var currentField = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        // Escaped quote
                        currentField.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    fields.Add(currentField.ToString());
                    currentField.Clear();
                }
                else
                {
                    currentField.Append(c);
                }
            }

            fields.Add(currentField.ToString());
            return fields.ToArray();
        }
        #endregion

        #region Logging
        private void LogInfo(string message)
        {
            LogMessage("Info", message);
        }

        private void LogWarning(string message)
        {
            LogMessage("Warning", message);
        }

        private void LogError(string message)
        {
            LogMessage("Error", message);
        }

        private void LogMessage(string level, string message)
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyy/MM/dd-HH:mm:ss");
                string logEntry = $"{timestamp} [{level}] {message}";

                logWriter?.WriteLine(logEntry);
                logWriter?.Flush();

                // Also output to debug console
                Debug.WriteLine(logEntry);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Logging failed: {ex.Message}");
            }
        }
        #endregion
    }

    #region Data Models
    public class PasswordEntry
    {
        public int PasswordID { get; set; }
        public string AppName { get; set; } = string.Empty;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime SaveDate { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public string? Tags { get; set; }
        public string? Notes { get; set; }
        public bool IsFavorite { get; set; }
    }

    public class PasswordHistoryEntry
    {
        public int HistoryID { get; set; }
        public int PasswordID { get; set; }
        public string OldPassword { get; set; } = string.Empty;
        public DateTime ChangedAt { get; set; }
    }

    public class AppSettings
    {
        public Size? WindowSize { get; set; }
        public Point? WindowLocation { get; set; }
        public bool IsDarkTheme { get; set; }
        public Dictionary<string, int> ColumnWidths { get; set; } = [];
    }
    #endregion
}