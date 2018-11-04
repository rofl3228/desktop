namespace DesktopApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.StatusLable = new System.Windows.Forms.Label();
            this.Consist = new System.Windows.Forms.Label();
            this.Debug = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.authPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Authication = new System.Windows.Forms.TextBox();
            this.loginPanel.SuspendLayout();
            this.authPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginBox
            // 
            resources.ApplyResources(this.LoginBox, "LoginBox");
            this.LoginBox.Name = "LoginBox";
            // 
            // PassBox
            // 
            resources.ApplyResources(this.PassBox, "PassBox");
            this.PassBox.Name = "PassBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StatusLable
            // 
            resources.ApplyResources(this.StatusLable, "StatusLable");
            this.StatusLable.Name = "StatusLable";
            // 
            // Consist
            // 
            resources.ApplyResources(this.Consist, "Consist");
            this.Consist.ForeColor = System.Drawing.Color.Red;
            this.Consist.Name = "Consist";
            // 
            // Debug
            // 
            resources.ApplyResources(this.Debug, "Debug");
            this.Debug.Name = "Debug";
            // 
            // loginPanel
            // 
            resources.ApplyResources(this.loginPanel, "loginPanel");
            this.loginPanel.Controls.Add(this.label1);
            this.loginPanel.Controls.Add(this.button1);
            this.loginPanel.Controls.Add(this.Consist);
            this.loginPanel.Controls.Add(this.LoginBox);
            this.loginPanel.Controls.Add(this.PassBox);
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Name = "loginPanel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // authPanel
            // 
            resources.ApplyResources(this.authPanel, "authPanel");
            this.authPanel.Controls.Add(this.label3);
            this.authPanel.Controls.Add(this.Authication);
            this.authPanel.Controls.Add(this.Debug);
            this.authPanel.Controls.Add(this.StatusLable);
            this.authPanel.Name = "authPanel";
            this.authPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.authPanel_Paint);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Authication
            // 
            resources.ApplyResources(this.Authication, "Authication");
            this.Authication.Name = "Authication";
            this.Authication.TextChanged += new System.EventHandler(this.Authication_TextChanged);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BackgroundImage = global::DesktopApp.Properties.Resources.login_back;
            this.Controls.Add(this.authPanel);
            this.Controls.Add(this.loginPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.authPanel.ResumeLayout(false);
            this.authPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label StatusLable;
        private System.Windows.Forms.Label Consist;
        private System.Windows.Forms.Label Debug;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel authPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Authication;
    }
}

