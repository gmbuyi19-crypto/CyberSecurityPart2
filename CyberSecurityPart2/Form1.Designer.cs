namespace CyberSecurityPart2
{
    partial class Form1
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
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            ChatInput = new TextBox();
            ChatInput2 = new TextBox();
            tabControl2 = new TabControl();
            tabChat = new TabPage();
            tabQuiz = new TabPage();
            tabTask = new TabPage();
            btnAddTask = new Button();
            dtpReminder = new DateTimePicker();
            chkReminder = new CheckBox();
            txtTaskDescription = new TextBox();
            lblTaskDescription = new Label();
            txtTaskTitle = new TextBox();
            lblTaskTitle = new Label();
            tabLog = new TabPage();
            dgvTasks = new DataGridView();
            btnCompleteTask = new Button();
            btnDeleteTask = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl2.SuspendLayout();
            tabChat.SuspendLayout();
            tabTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(326, 367);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "send";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(116, 68);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // ChatInput
            // 
            ChatInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChatInput.Location = new Point(217, 125);
            ChatInput.Multiline = true;
            ChatInput.Name = "ChatInput";
            ChatInput.ReadOnly = true;
            ChatInput.ScrollBars = ScrollBars.Vertical;
            ChatInput.Size = new Size(349, 151);
            ChatInput.TabIndex = 3;
            ChatInput.TextChanged += ChatInput_TextChanged;
            ChatInput.KeyDown += ChatInput_KeyDown;
            // 
            // ChatInput2
            // 
            ChatInput2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChatInput2.Location = new Point(315, 309);
            ChatInput2.Name = "ChatInput2";
            ChatInput2.Size = new Size(100, 23);
            ChatInput2.TabIndex = 4;
            ChatInput2.TextChanged += ChatInput2_TextChanged;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabChat);
            tabControl2.Controls.Add(tabQuiz);
            tabControl2.Controls.Add(tabTask);
            tabControl2.Controls.Add(tabLog);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Location = new Point(0, 0);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(800, 450);
            tabControl2.TabIndex = 6;
            // 
            // tabChat
            // 
            tabChat.BackColor = Color.FromArgb(24, 20, 45);
            tabChat.Controls.Add(ChatInput2);
            tabChat.Controls.Add(button2);
            tabChat.Controls.Add(pictureBox1);
            tabChat.Controls.Add(ChatInput);
            tabChat.ForeColor = Color.FromArgb(214, 130, 220);
            tabChat.Location = new Point(4, 24);
            tabChat.Name = "tabChat";
            tabChat.Padding = new Padding(3);
            tabChat.Size = new Size(792, 422);
            tabChat.TabIndex = 1;
            tabChat.Text = "Chat";
            tabChat.Click += tabChat_Click;
            // 
            // tabQuiz
            // 
            tabQuiz.Location = new Point(4, 24);
            tabQuiz.Name = "tabQuiz";
            tabQuiz.Padding = new Padding(3);
            tabQuiz.Size = new Size(792, 422);
            tabQuiz.TabIndex = 0;
            tabQuiz.Text = "Quiz";
            tabQuiz.UseVisualStyleBackColor = true;
            tabQuiz.Click += tabQuiz_Click;
            // 
            // tabTask
            // 
            tabTask.BackColor = Color.FromArgb(24, 20, 45);
            tabTask.Controls.Add(btnDeleteTask);
            tabTask.Controls.Add(btnCompleteTask);
            tabTask.Controls.Add(dgvTasks);
            tabTask.Controls.Add(btnAddTask);
            tabTask.Controls.Add(dtpReminder);
            tabTask.Controls.Add(chkReminder);
            tabTask.Controls.Add(txtTaskDescription);
            tabTask.Controls.Add(lblTaskDescription);
            tabTask.Controls.Add(txtTaskTitle);
            tabTask.Controls.Add(lblTaskTitle);
            tabTask.Location = new Point(4, 24);
            tabTask.Name = "tabTask";
            tabTask.Size = new Size(792, 422);
            tabTask.TabIndex = 2;
            tabTask.Text = "Task Assistant";
            tabTask.Click += tabTask_Click;
            tabTask.Enter += tabTask_Enter;
            // 
            // btnAddTask
            // 
            btnAddTask.BackColor = Color.FromArgb(150, 80, 190);
            btnAddTask.FlatStyle = FlatStyle.Flat;
            btnAddTask.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTask.ForeColor = Color.White;
            btnAddTask.Location = new Point(20, 280);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(280, 35);
            btnAddTask.TabIndex = 7;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = false;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // dtpReminder
            // 
            dtpReminder.Location = new Point(20, 240);
            dtpReminder.Name = "dtpReminder";
            dtpReminder.Size = new Size(280, 23);
            dtpReminder.TabIndex = 6;
            // 
            // chkReminder
            // 
            chkReminder.AutoSize = true;
            chkReminder.ForeColor = Color.White;
            chkReminder.Location = new Point(20, 210);
            chkReminder.Name = "chkReminder";
            chkReminder.Size = new Size(105, 19);
            chkReminder.TabIndex = 5;
            chkReminder.Text = "Set a reminder ";
            chkReminder.UseVisualStyleBackColor = true;
            // 
            // txtTaskDescription
            // 
            txtTaskDescription.Location = new Point(20, 105);
            txtTaskDescription.Multiline = true;
            txtTaskDescription.Name = "txtTaskDescription";
            txtTaskDescription.Size = new Size(280, 90);
            txtTaskDescription.TabIndex = 4;
            // 
            // lblTaskDescription
            // 
            lblTaskDescription.AutoSize = true;
            lblTaskDescription.ForeColor = Color.White;
            lblTaskDescription.Location = new Point(20, 80);
            lblTaskDescription.Name = "lblTaskDescription";
            lblTaskDescription.Size = new Size(67, 15);
            lblTaskDescription.TabIndex = 3;
            lblTaskDescription.Text = "Description";
            // 
            // txtTaskTitle
            // 
            txtTaskTitle.Location = new Point(20, 45);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.ShortcutsEnabled = false;
            txtTaskTitle.Size = new Size(280, 23);
            txtTaskTitle.TabIndex = 1;
            // 
            // lblTaskTitle
            // 
            lblTaskTitle.AutoSize = true;
            lblTaskTitle.ForeColor = Color.White;
            lblTaskTitle.Location = new Point(20, 20);
            lblTaskTitle.Name = "lblTaskTitle";
            lblTaskTitle.Size = new Size(56, 15);
            lblTaskTitle.TabIndex = 0;
            lblTaskTitle.Text = "Task Title";
            // 
            // tabLog
            // 
            tabLog.Location = new Point(4, 24);
            tabLog.Name = "tabLog";
            tabLog.Size = new Size(792, 422);
            tabLog.TabIndex = 3;
            tabLog.Text = "Activity Log";
            tabLog.UseVisualStyleBackColor = true;
            // 
            // dgvTasks
            // 
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(320, 20);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.ReadOnly = true;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.Size = new Size(450, 250);
            dgvTasks.TabIndex = 8;
            // 
            // btnCompleteTask
            // 
            btnCompleteTask.BackColor = Color.FromArgb(150, 80, 190);
            btnCompleteTask.ForeColor = Color.White;
            btnCompleteTask.Location = new Point(320, 280);
            btnCompleteTask.Name = "btnCompleteTask";
            btnCompleteTask.Size = new Size(140, 35);
            btnCompleteTask.TabIndex = 9;
            btnCompleteTask.Text = "Mark Complete";
            btnCompleteTask.UseVisualStyleBackColor = false;
            btnCompleteTask.Click += btnCompleteTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.BackColor = Color.FromArgb(150, 80, 190);
            btnDeleteTask.ForeColor = Color.White;
            btnDeleteTask.Location = new Point(470, 280);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(140, 35);
            btnDeleteTask.TabIndex = 10;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = false;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "CHATBOT";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl2.ResumeLayout(false);
            tabChat.ResumeLayout(false);
            tabChat.PerformLayout();
            tabTask.ResumeLayout(false);
            tabTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private TextBox ChatInput;
        private TextBox ChatInput2;
        private TabControl tabControl2;
        private TabPage tabQuiz;
        private TabPage tabChat;
        private TabPage tabTask;
        private TabPage tabLog;
        private TextBox txtTaskTitle;
        private Label lblTaskTitle;
        private Label lblTaskDescription;
        private TextBox txtTaskDescription;
        private CheckBox chkReminder;
        private Button btnAddTask;
        private DateTimePicker dtpReminder;
        private Button btnCompleteTask;
        private DataGridView dgvTasks;
        private Button btnDeleteTask;
    }
}
