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
            lblFeedback = new Label();
            btnNextQuestion = new Button();
            btnSubmitAnswer = new Button();
            rdoOption4 = new RadioButton();
            rdoOption3 = new RadioButton();
            rdoOption2 = new RadioButton();
            rdoOption1 = new RadioButton();
            lblQuestion = new Label();
            lblQuestionNumber = new Label();
            lblScore = new Label();
            btnStartQuiz = new Button();
            tabTask = new TabPage();
            btnDeleteTask = new Button();
            btnCompleteTask = new Button();
            dgvTasks = new DataGridView();
            btnAddTask = new Button();
            dtpReminder = new DateTimePicker();
            chkReminder = new CheckBox();
            txtTaskDescription = new TextBox();
            lblTaskDescription = new Label();
            txtTaskTitle = new TextBox();
            lblTaskTitle = new Label();
            tabLog = new TabPage();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl2.SuspendLayout();
            tabChat.SuspendLayout();
            tabQuiz.SuspendLayout();
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
            tabQuiz.BackColor = Color.FromArgb(24, 20, 45);
            tabQuiz.Controls.Add(lblFeedback);
            tabQuiz.Controls.Add(btnNextQuestion);
            tabQuiz.Controls.Add(btnSubmitAnswer);
            tabQuiz.Controls.Add(rdoOption4);
            tabQuiz.Controls.Add(rdoOption3);
            tabQuiz.Controls.Add(rdoOption2);
            tabQuiz.Controls.Add(rdoOption1);
            tabQuiz.Controls.Add(lblQuestion);
            tabQuiz.Controls.Add(lblQuestionNumber);
            tabQuiz.Controls.Add(lblScore);
            tabQuiz.Controls.Add(btnStartQuiz);
            tabQuiz.ForeColor = Color.White;
            tabQuiz.Location = new Point(4, 24);
            tabQuiz.Name = "tabQuiz";
            tabQuiz.Padding = new Padding(3);
            tabQuiz.Size = new Size(792, 422);
            tabQuiz.TabIndex = 0;
            tabQuiz.Text = "Quiz";
            tabQuiz.Click += tabQuiz_Click;
            // 
            // lblFeedback
            // 
            lblFeedback.Location = new Point(20, 325);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(740, 60);
            lblFeedback.TabIndex = 10;
            // 
            // btnNextQuestion
            // 
            btnNextQuestion.BackColor = Color.FromArgb(150, 80, 190);
            btnNextQuestion.Enabled = false;
            btnNextQuestion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextQuestion.Location = new Point(190, 280);
            btnNextQuestion.Name = "btnNextQuestion";
            btnNextQuestion.Size = new Size(150, 35);
            btnNextQuestion.TabIndex = 9;
            btnNextQuestion.Text = "Next Question";
            btnNextQuestion.UseVisualStyleBackColor = false;
            btnNextQuestion.Click += btnNextQuestion_Click;
            // 
            // btnSubmitAnswer
            // 
            btnSubmitAnswer.BackColor = Color.FromArgb(150, 80, 190);
            btnSubmitAnswer.Enabled = false;
            btnSubmitAnswer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmitAnswer.ForeColor = Color.White;
            btnSubmitAnswer.Location = new Point(20, 280);
            btnSubmitAnswer.Name = "btnSubmitAnswer";
            btnSubmitAnswer.Size = new Size(150, 35);
            btnSubmitAnswer.TabIndex = 8;
            btnSubmitAnswer.Text = "Submit Answer";
            btnSubmitAnswer.UseVisualStyleBackColor = false;
            btnSubmitAnswer.Click += btnSubmitAnswer_Click;
            // 
            // rdoOption4
            // 
            rdoOption4.Location = new Point(20, 240);
            rdoOption4.Name = "rdoOption4";
            rdoOption4.Size = new Size(700, 24);
            rdoOption4.TabIndex = 7;
            rdoOption4.TabStop = true;
            rdoOption4.Text = "Option 4 ";
            rdoOption4.UseVisualStyleBackColor = true;
            rdoOption4.Visible = false;
            // 
            // rdoOption3
            // 
            rdoOption3.Location = new Point(20, 210);
            rdoOption3.Name = "rdoOption3";
            rdoOption3.Size = new Size(700, 24);
            rdoOption3.TabIndex = 6;
            rdoOption3.TabStop = true;
            rdoOption3.Text = "Option 3 ";
            rdoOption3.UseVisualStyleBackColor = true;
            rdoOption3.Visible = false;
            // 
            // rdoOption2
            // 
            rdoOption2.Location = new Point(20, 180);
            rdoOption2.Name = "rdoOption2";
            rdoOption2.Size = new Size(700, 24);
            rdoOption2.TabIndex = 5;
            rdoOption2.TabStop = true;
            rdoOption2.Text = "Option 2";
            rdoOption2.UseVisualStyleBackColor = true;
            rdoOption2.Visible = false;
            // 
            // rdoOption1
            // 
            rdoOption1.Location = new Point(20, 150);
            rdoOption1.Name = "rdoOption1";
            rdoOption1.Size = new Size(700, 24);
            rdoOption1.TabIndex = 4;
            rdoOption1.TabStop = true;
            rdoOption1.Text = "Option1";
            rdoOption1.UseVisualStyleBackColor = true;
            rdoOption1.Visible = false;
            // 
            // lblQuestion
            // 
            lblQuestion.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuestion.Location = new Point(20, 95);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(740, 50);
            lblQuestion.TabIndex = 3;
            lblQuestion.Text = "Click Start Quiz to Begin !";
            // 
            // lblQuestionNumber
            // 
            lblQuestionNumber.AutoSize = true;
            lblQuestionNumber.Location = new Point(20, 70);
            lblQuestionNumber.Name = "lblQuestionNumber";
            lblQuestionNumber.Size = new Size(55, 15);
            lblQuestionNumber.TabIndex = 2;
            lblQuestionNumber.Text = "Question";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(200, 28);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(51, 15);
            lblScore.TabIndex = 1;
            lblScore.Text = "Score: 0 ";
            // 
            // btnStartQuiz
            // 
            btnStartQuiz.BackColor = Color.FromArgb(150, 80, 190);
            btnStartQuiz.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStartQuiz.Location = new Point(20, 20);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(150, 35);
            btnStartQuiz.TabIndex = 0;
            btnStartQuiz.Text = "Start Quiz";
            btnStartQuiz.UseVisualStyleBackColor = false;
            btnStartQuiz.Click += btnStartQuiz_Click;
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
            tabQuiz.ResumeLayout(false);
            tabQuiz.PerformLayout();
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
        private Button btnStartQuiz;
        private Label lblQuestion;
        private Label lblQuestionNumber;
        private Label lblScore;
        private RadioButton rdoOption1;
        private RadioButton rdoOption4;
        private RadioButton rdoOption3;
        private RadioButton rdoOption2;
        private Button btnSubmitAnswer;
        private Button btnNextQuestion;
        private Label lblFeedback;
    }
}
