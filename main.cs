// PREMO VIETNAM 2022 - COMPUTER VISION
using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Drawing;
using System.Windows.Forms;
using Cognex.InSight;
using System.Threading.Tasks;
using System.IO;

namespace DisplayControl
{
    
    public class frmMain : System.Windows.Forms.Form
    {
        #region LKDefine
        string saveImgPath      = @"image\img.jpg";
        string jobPath          = @"job\X-12652-003.job";
        const int camIndex      = 0;
        VideoCapture LKCamera   = new VideoCapture(camIndex);
        Mat LKStreamImage       = new Mat();
        CvsInSight insight      = new CvsInSight();
        private Cognex.InSight.Controls.Display.CvsInSightDisplay CvsInSightDisplay2;
        private PictureBox pbStream;
       
        string value;

        #endregion

        #region SysDefine
        string uss = "TruongHuynh";
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.RadioButton optFill;
        internal System.Windows.Forms.RadioButton optFit;
        internal System.Windows.Forms.RadioButton optNone;
        internal System.Windows.Forms.StatusBar StatusBar1;
        internal System.Windows.Forms.StatusBarPanel lblState;
        internal System.Windows.Forms.StatusBarPanel lblStatus;
        private System.ComponentModel.IContainer components;
        internal System.Windows.Forms.GroupBox grpImageZoom;
        private Label label5;
        private Label lbFail;
        private Label lbPass;
        int stt;
        private Guna.UI.WinForms.GunaPanel controlPanel;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaCheckBox lkchkOnline;
        private Guna.UI.WinForms.GunaCheckBox lkchkGraphics;
        private Guna.UI.WinForms.GunaCheckBox lkchkImage;
        internal Label Label4;
        internal Label lblGridOpacityValue;
        internal Label lblATestMode;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI.WinForms.GunaPanel gunaPanel2;
        private Guna.UI.WinForms.GunaButton lkBtnConnect;
        private Guna.UI.WinForms.GunaCircleButton btnRun;
        private Guna.UI.WinForms.GunaHScrollBar lkHScrollOpacity;
        private Guna.UI.WinForms.GunaPanel gunaPanel3;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox3;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private ComboBox comboBox1;
        internal Label label8;
        private DateTimePicker dateTimePicker1;
        private PictureBox pbResult;
        private Button button1;
        private TextBox resetadmin;
        private Button button2;
        private Timer timer1;
        private Button Test;
        private Button PLCS71200;
        private Guna.UI.WinForms.GunaCheckBox lkchkGrid;
        #endregion


        public frmMain()
        {
            Cognex.InSight.CvsInSightSoftwareDevelopmentKit.Initialize();
            InitializeComponent();
            this.lkHScrollOpacity.Maximum += this.lkHScrollOpacity.LargeChange - 1;
            CvsInSightDisplay2.LoadStandardTheme();
            LKCamera.ImageGrabbed += Grabar;
            LKCamera.Start();
            LKCamera.SetCaptureProperty(CapProp.FrameWidth, 1780000);
            LKCamera.SetCaptureProperty(CapProp.FrameHeight, 1000000);
            txtAddress.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            timer1.Enabled = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.grpImageZoom = new System.Windows.Forms.GroupBox();
            this.optFill = new System.Windows.Forms.RadioButton();
            this.optFit = new System.Windows.Forms.RadioButton();
            this.optNone = new System.Windows.Forms.RadioButton();
            this.lbFail = new System.Windows.Forms.Label();
            this.lbPass = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CvsInSightDisplay2 = new Cognex.InSight.Controls.Display.CvsInSightDisplay();
            this.pbStream = new System.Windows.Forms.PictureBox();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.lblState = new System.Windows.Forms.StatusBarPanel();
            this.lblStatus = new System.Windows.Forms.StatusBarPanel();
            this.controlPanel = new Guna.UI.WinForms.GunaPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lkBtnConnect = new Guna.UI.WinForms.GunaButton();
            this.lblATestMode = new System.Windows.Forms.Label();
            this.lkchkOnline = new Guna.UI.WinForms.GunaCheckBox();
            this.lkchkGraphics = new Guna.UI.WinForms.GunaCheckBox();
            this.lkchkImage = new Guna.UI.WinForms.GunaCheckBox();
            this.lkchkGrid = new Guna.UI.WinForms.GunaCheckBox();
            this.lkHScrollOpacity = new Guna.UI.WinForms.GunaHScrollBar();
            this.lblGridOpacityValue = new System.Windows.Forms.Label();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.resetadmin = new System.Windows.Forms.TextBox();
            this.btnRun = new Guna.UI.WinForms.GunaCircleButton();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.PLCS71200 = new System.Windows.Forms.Button();
            this.Test = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.gunaPictureBox3 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.gunaPanel2 = new Guna.UI.WinForms.GunaPanel();
            this.gunaPanel3 = new Guna.UI.WinForms.GunaPanel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpImageZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.gunaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).BeginInit();
            this.gunaPanel2.SuspendLayout();
            this.gunaPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(86, 233);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '#';
            this.txtPassword.Size = new System.Drawing.Size(101, 27);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(86, 209);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(101, 27);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "admin";
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(86, 185);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(101, 27);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "127.0.0.1";
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Label3.Location = new System.Drawing.Point(3, 229);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(77, 27);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "Password:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Label2.Location = new System.Drawing.Point(-4, 208);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(89, 24);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "User Name:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Label1.Location = new System.Drawing.Point(3, 185);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(68, 24);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "Address:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpImageZoom
            // 
            this.grpImageZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImageZoom.Controls.Add(this.optFill);
            this.grpImageZoom.Controls.Add(this.optFit);
            this.grpImageZoom.Controls.Add(this.optNone);
            this.grpImageZoom.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpImageZoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.grpImageZoom.Location = new System.Drawing.Point(24, 487);
            this.grpImageZoom.Name = "grpImageZoom";
            this.grpImageZoom.Size = new System.Drawing.Size(109, 116);
            this.grpImageZoom.TabIndex = 19;
            this.grpImageZoom.TabStop = false;
            this.grpImageZoom.Text = "Image Zoom Mode";
            // 
            // optFill
            // 
            this.optFill.Location = new System.Drawing.Point(28, 48);
            this.optFill.Name = "optFill";
            this.optFill.Size = new System.Drawing.Size(56, 28);
            this.optFill.TabIndex = 2;
            this.optFill.Text = "Fill";
            this.optFill.CheckedChanged += new System.EventHandler(this.optFill_CheckedChanged);
            // 
            // optFit
            // 
            this.optFit.Location = new System.Drawing.Point(28, 72);
            this.optFit.Name = "optFit";
            this.optFit.Size = new System.Drawing.Size(53, 34);
            this.optFit.TabIndex = 1;
            this.optFit.Text = "Fit";
            this.optFit.CheckedChanged += new System.EventHandler(this.optFit_CheckedChanged);
            // 
            // optNone
            // 
            this.optNone.Location = new System.Drawing.Point(28, 20);
            this.optNone.Name = "optNone";
            this.optNone.Size = new System.Drawing.Size(64, 29);
            this.optNone.TabIndex = 0;
            this.optNone.Text = "None";
            this.optNone.CheckedChanged += new System.EventHandler(this.optNone_CheckedChanged);
            // 
            // lbFail
            // 
            this.lbFail.AutoSize = true;
            this.lbFail.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFail.ForeColor = System.Drawing.Color.Coral;
            this.lbFail.Location = new System.Drawing.Point(411, 21);
            this.lbFail.Name = "lbFail";
            this.lbFail.Size = new System.Drawing.Size(24, 29);
            this.lbFail.TabIndex = 4;
            this.lbFail.Text = "?";
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.lbPass.ForeColor = System.Drawing.Color.Coral;
            this.lbPass.Location = new System.Drawing.Point(267, 21);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(24, 29);
            this.lbPass.TabIndex = 3;
            this.lbPass.Text = "?";
            this.lbPass.Click += new System.EventHandler(this.lbPass_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1235, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 21);
            this.label5.TabIndex = 27;
            this.label5.Text = "StreamCamera";
            // 
            // CvsInSightDisplay2
            // 
            this.CvsInSightDisplay2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CvsInSightDisplay2.DefaultTextScaleMode = Cognex.InSight.Controls.Display.CvsInSightDisplay.TextScaleModeType.Proportional;
            this.CvsInSightDisplay2.DialogIcon = null;
            this.CvsInSightDisplay2.Location = new System.Drawing.Point(-3, 26);
            this.CvsInSightDisplay2.Name = "CvsInSightDisplay2";
            this.CvsInSightDisplay2.PreferredCropScaleMode = Cognex.InSight.Controls.Display.CvsInSightDisplayCropScaleMode.Default;
            this.CvsInSightDisplay2.Size = new System.Drawing.Size(930, 557);
            this.CvsInSightDisplay2.TabIndex = 0;
            this.CvsInSightDisplay2.ConnectedChanged += new System.EventHandler(this.CvsInSightDisplay2_ConnectedChanged);
            this.CvsInSightDisplay2.StateChanged += new Cognex.InSight.Controls.Display.CvsDisplayStateChangedEventHandler(this.CvsInSightDisplay2_StateChanged);
            this.CvsInSightDisplay2.StatusInformationChanged += new System.EventHandler(this.CvsInSightDisplay2_StatusInformationChanged);
            this.CvsInSightDisplay2.ConnectCompleted += new Cognex.InSight.CvsConnectCompletedEventHandler(this.CvsInSightDisplay2_ConnectCompleted);
            this.CvsInSightDisplay2.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbStream
            // 
            this.pbStream.ErrorImage = global::PremoComputerVision.Properties.Resources.pass;
            this.pbStream.Image = global::PremoComputerVision.Properties.Resources.pass;
            this.pbStream.Location = new System.Drawing.Point(974, 52);
            this.pbStream.Name = "pbStream";
            this.pbStream.Size = new System.Drawing.Size(372, 233);
            this.pbStream.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStream.TabIndex = 22;
            this.pbStream.TabStop = false;
            this.pbStream.Click += new System.EventHandler(this.pbStream_Click);
            // 
            // StatusBar1
            // 
            this.StatusBar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar1.Location = new System.Drawing.Point(0, 829);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.lblState,
            this.lblStatus});
            this.StatusBar1.ShowPanels = true;
            this.StatusBar1.Size = new System.Drawing.Size(1663, 17);
            this.StatusBar1.TabIndex = 21;
            // 
            // lblState
            // 
            this.lblState.Name = "lblState";
            this.lblState.Width = 200;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Width = 1442;
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.White;
            this.controlPanel.Controls.Add(this.label8);
            this.controlPanel.Controls.Add(this.comboBox1);
            this.controlPanel.Controls.Add(this.lkBtnConnect);
            this.controlPanel.Controls.Add(this.lblATestMode);
            this.controlPanel.Controls.Add(this.lkchkOnline);
            this.controlPanel.Controls.Add(this.lkchkGraphics);
            this.controlPanel.Controls.Add(this.lkchkImage);
            this.controlPanel.Controls.Add(this.lkchkGrid);
            this.controlPanel.Controls.Add(this.lkHScrollOpacity);
            this.controlPanel.Controls.Add(this.lblGridOpacityValue);
            this.controlPanel.Controls.Add(this.gunaPictureBox1);
            this.controlPanel.Controls.Add(this.txtAddress);
            this.controlPanel.Controls.Add(this.txtUserName);
            this.controlPanel.Controls.Add(this.Label4);
            this.controlPanel.Controls.Add(this.txtPassword);
            this.controlPanel.Controls.Add(this.Label3);
            this.controlPanel.Controls.Add(this.grpImageZoom);
            this.controlPanel.Controls.Add(this.Label1);
            this.controlPanel.Controls.Add(this.Label2);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(200, 829);
            this.controlPanel.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label8.Location = new System.Drawing.Point(50, 348);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 27);
            this.label8.TabIndex = 35;
            this.label8.Text = "PART NO";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "X-12652-003"});
            this.comboBox1.Location = new System.Drawing.Point(24, 375);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 25);
            this.comboBox1.TabIndex = 34;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lkBtnConnect
            // 
            this.lkBtnConnect.AnimationHoverSpeed = 0.07F;
            this.lkBtnConnect.AnimationSpeed = 0.03F;
            this.lkBtnConnect.BackColor = System.Drawing.Color.Transparent;
            this.lkBtnConnect.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.lkBtnConnect.BorderColor = System.Drawing.Color.Black;
            this.lkBtnConnect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.lkBtnConnect.FocusedColor = System.Drawing.Color.Empty;
            this.lkBtnConnect.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkBtnConnect.ForeColor = System.Drawing.Color.White;
            this.lkBtnConnect.Image = ((System.Drawing.Image)(resources.GetObject("lkBtnConnect.Image")));
            this.lkBtnConnect.ImageSize = new System.Drawing.Size(30, 30);
            this.lkBtnConnect.Location = new System.Drawing.Point(23, 275);
            this.lkBtnConnect.Name = "lkBtnConnect";
            this.lkBtnConnect.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.lkBtnConnect.OnHoverBorderColor = System.Drawing.Color.Black;
            this.lkBtnConnect.OnHoverForeColor = System.Drawing.Color.White;
            this.lkBtnConnect.OnHoverImage = null;
            this.lkBtnConnect.OnPressedColor = System.Drawing.Color.Black;
            this.lkBtnConnect.Radius = 20;
            this.lkBtnConnect.Size = new System.Drawing.Size(150, 42);
            this.lkBtnConnect.TabIndex = 32;
            this.lkBtnConnect.Text = "Connect";
            this.lkBtnConnect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lkBtnConnect.Click += new System.EventHandler(this.lkBtnConnect_Click);
            // 
            // lblATestMode
            // 
            this.lblATestMode.Location = new System.Drawing.Point(83, 375);
            this.lblATestMode.Name = "lblATestMode";
            this.lblATestMode.Size = new System.Drawing.Size(75, 16);
            this.lblATestMode.TabIndex = 31;
            this.lblATestMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblATestMode.Click += new System.EventHandler(this.lblATestMode_Click);
            // 
            // lkchkOnline
            // 
            this.lkchkOnline.BaseColor = System.Drawing.Color.White;
            this.lkchkOnline.CheckedOffColor = System.Drawing.Color.Gray;
            this.lkchkOnline.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.lkchkOnline.FillColor = System.Drawing.Color.White;
            this.lkchkOnline.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkchkOnline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lkchkOnline.Location = new System.Drawing.Point(88, 450);
            this.lkchkOnline.Name = "lkchkOnline";
            this.lkchkOnline.Size = new System.Drawing.Size(94, 20);
            this.lkchkOnline.TabIndex = 29;
            this.lkchkOnline.Text = "Open JOB";
            this.lkchkOnline.CheckedChanged += new System.EventHandler(this.chkOnline_CheckedChanged);
            // 
            // lkchkGraphics
            // 
            this.lkchkGraphics.BaseColor = System.Drawing.Color.White;
            this.lkchkGraphics.CheckedOffColor = System.Drawing.Color.Gray;
            this.lkchkGraphics.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.lkchkGraphics.FillColor = System.Drawing.Color.White;
            this.lkchkGraphics.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkchkGraphics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lkchkGraphics.Location = new System.Drawing.Point(88, 417);
            this.lkchkGraphics.Name = "lkchkGraphics";
            this.lkchkGraphics.Size = new System.Drawing.Size(89, 20);
            this.lkchkGraphics.TabIndex = 27;
            this.lkchkGraphics.Text = "Graphics";
            this.lkchkGraphics.CheckedChanged += new System.EventHandler(this.chkGraphics_CheckedChanged);
            // 
            // lkchkImage
            // 
            this.lkchkImage.BaseColor = System.Drawing.Color.White;
            this.lkchkImage.CheckedOffColor = System.Drawing.Color.Gray;
            this.lkchkImage.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.lkchkImage.FillColor = System.Drawing.Color.White;
            this.lkchkImage.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkchkImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lkchkImage.Location = new System.Drawing.Point(18, 450);
            this.lkchkImage.Name = "lkchkImage";
            this.lkchkImage.Size = new System.Drawing.Size(71, 20);
            this.lkchkImage.TabIndex = 26;
            this.lkchkImage.Text = "Image";
            this.lkchkImage.CheckedChanged += new System.EventHandler(this.chkImage_CheckedChanged);
            // 
            // lkchkGrid
            // 
            this.lkchkGrid.BaseColor = System.Drawing.Color.White;
            this.lkchkGrid.CheckedOffColor = System.Drawing.Color.Gray;
            this.lkchkGrid.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.lkchkGrid.FillColor = System.Drawing.Color.White;
            this.lkchkGrid.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkchkGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lkchkGrid.Location = new System.Drawing.Point(19, 417);
            this.lkchkGrid.Name = "lkchkGrid";
            this.lkchkGrid.Size = new System.Drawing.Size(58, 20);
            this.lkchkGrid.TabIndex = 23;
            this.lkchkGrid.Text = "Grid";
            this.lkchkGrid.CheckedChanged += new System.EventHandler(this.chkGrid_CheckedChanged);
            // 
            // lkHScrollOpacity
            // 
            this.lkHScrollOpacity.BackColor = System.Drawing.Color.Transparent;
            this.lkHScrollOpacity.LargeChange = 10;
            this.lkHScrollOpacity.Location = new System.Drawing.Point(24, 621);
            this.lkHScrollOpacity.Maximum = 100;
            this.lkHScrollOpacity.Name = "lkHScrollOpacity";
            this.lkHScrollOpacity.ScrollbarSize = 20;
            this.lkHScrollOpacity.ScrollIdleColor = System.Drawing.Color.Silver;
            this.lkHScrollOpacity.Size = new System.Drawing.Size(103, 28);
            this.lkHScrollOpacity.TabIndex = 29;
            this.lkHScrollOpacity.ThumbColor = System.Drawing.Color.Gray;
            this.lkHScrollOpacity.ThumbHoverColor = System.Drawing.Color.Gray;
            this.lkHScrollOpacity.ThumbPressedColor = System.Drawing.Color.IndianRed;
            this.lkHScrollOpacity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollOpacity_ValueChanged);
            // 
            // lblGridOpacityValue
            // 
            this.lblGridOpacityValue.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridOpacityValue.Location = new System.Drawing.Point(102, 597);
            this.lblGridOpacityValue.Name = "lblGridOpacityValue";
            this.lblGridOpacityValue.Size = new System.Drawing.Size(40, 21);
            this.lblGridOpacityValue.TabIndex = 30;
            this.lblGridOpacityValue.Text = "75%";
            this.lblGridOpacityValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(23, 8);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(150, 150);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 23;
            this.gunaPictureBox1.TabStop = false;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Label4.Location = new System.Drawing.Point(21, 597);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(75, 21);
            this.Label4.TabIndex = 29;
            this.Label4.Text = "Grid Opacity:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OrangeRed;
            this.button1.Location = new System.Drawing.Point(1244, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 28);
            this.button1.TabIndex = 37;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // resetadmin
            // 
            this.resetadmin.Location = new System.Drawing.Point(1235, 3);
            this.resetadmin.Name = "resetadmin";
            this.resetadmin.PasswordChar = '*';
            this.resetadmin.Size = new System.Drawing.Size(81, 24);
            this.resetadmin.TabIndex = 36;
            this.resetadmin.TextChanged += new System.EventHandler(this.resetadmin_TextChanged);
            // 
            // btnRun
            // 
            this.btnRun.AnimationHoverSpeed = 0.07F;
            this.btnRun.AnimationSpeed = 0.03F;
            this.btnRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRun.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnRun.BorderColor = System.Drawing.Color.Black;
            this.btnRun.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRun.FocusedColor = System.Drawing.Color.Empty;
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.ImageSize = new System.Drawing.Size(40, 40);
            this.btnRun.Location = new System.Drawing.Point(695, 3);
            this.btnRun.Margin = new System.Windows.Forms.Padding(0);
            this.btnRun.Name = "btnRun";
            this.btnRun.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnRun.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnRun.OnHoverForeColor = System.Drawing.Color.White;
            this.btnRun.OnHoverImage = null;
            this.btnRun.OnPressedColor = System.Drawing.Color.Black;
            this.btnRun.Size = new System.Drawing.Size(64, 58);
            this.btnRun.TabIndex = 33;
            this.btnRun.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.White;
            this.gunaPanel1.Controls.Add(this.PLCS71200);
            this.gunaPanel1.Controls.Add(this.Test);
            this.gunaPanel1.Controls.Add(this.button1);
            this.gunaPanel1.Controls.Add(this.button2);
            this.gunaPanel1.Controls.Add(this.pbResult);
            this.gunaPanel1.Controls.Add(this.resetadmin);
            this.gunaPanel1.Controls.Add(this.gunaPictureBox3);
            this.gunaPanel1.Controls.Add(this.gunaPictureBox2);
            this.gunaPanel1.Controls.Add(this.lbFail);
            this.gunaPanel1.Controls.Add(this.lbPass);
            this.gunaPanel1.Controls.Add(this.btnRun);
            this.gunaPanel1.Location = new System.Drawing.Point(192, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(1510, 69);
            this.gunaPanel1.TabIndex = 23;
            // 
            // PLCS71200
            // 
            this.PLCS71200.BackColor = System.Drawing.Color.Aquamarine;
            this.PLCS71200.Location = new System.Drawing.Point(462, 32);
            this.PLCS71200.Name = "PLCS71200";
            this.PLCS71200.Size = new System.Drawing.Size(189, 29);
            this.PLCS71200.TabIndex = 47;
            this.PLCS71200.Text = "Connect PLC";
            this.PLCS71200.UseVisualStyleBackColor = false;
            this.PLCS71200.Click += new System.EventHandler(this.PLCS71200_Click);
            // 
            // Test
            // 
            this.Test.BackColor = System.Drawing.Color.Aquamarine;
            this.Test.Location = new System.Drawing.Point(462, 0);
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(189, 29);
            this.Test.TabIndex = 46;
            this.Test.Text = "Connect Robot XARM";
            this.Test.UseVisualStyleBackColor = false;
            this.Test.Click += new System.EventHandler(this.Test_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gold;
            this.button2.Location = new System.Drawing.Point(899, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 30);
            this.button2.TabIndex = 45;
            this.button2.Text = "X-12652-003";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pbResult
            // 
            this.pbResult.Location = new System.Drawing.Point(14, 3);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(189, 55);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResult.TabIndex = 44;
            this.pbResult.TabStop = false;
            this.pbResult.Click += new System.EventHandler(this.pbResult_Click);
            // 
            // gunaPictureBox3
            // 
            this.gunaPictureBox3.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox3.Image")));
            this.gunaPictureBox3.Location = new System.Drawing.Point(209, 13);
            this.gunaPictureBox3.Name = "gunaPictureBox3";
            this.gunaPictureBox3.Size = new System.Drawing.Size(41, 40);
            this.gunaPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox3.TabIndex = 39;
            this.gunaPictureBox3.TabStop = false;
            this.gunaPictureBox3.Click += new System.EventHandler(this.gunaPictureBox3_Click);
            // 
            // gunaPictureBox2
            // 
            this.gunaPictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox2.Image")));
            this.gunaPictureBox2.Location = new System.Drawing.Point(347, 13);
            this.gunaPictureBox2.Name = "gunaPictureBox2";
            this.gunaPictureBox2.Size = new System.Drawing.Size(43, 40);
            this.gunaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox2.TabIndex = 38;
            this.gunaPictureBox2.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1373, 738);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(114, 24);
            this.dateTimePicker1.TabIndex = 45;
            // 
            // gunaPanel2
            // 
            this.gunaPanel2.Controls.Add(this.dateTimePicker1);
            this.gunaPanel2.Controls.Add(this.label5);
            this.gunaPanel2.Controls.Add(this.pbStream);
            this.gunaPanel2.Location = new System.Drawing.Point(200, 70);
            this.gunaPanel2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.gunaPanel2.Name = "gunaPanel2";
            this.gunaPanel2.Size = new System.Drawing.Size(1454, 756);
            this.gunaPanel2.TabIndex = 24;
            this.gunaPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaPanel2_Paint);
            // 
            // gunaPanel3
            // 
            this.gunaPanel3.Controls.Add(this.gunaLabel1);
            this.gunaPanel3.Controls.Add(this.CvsInSightDisplay2);
            this.gunaPanel3.Location = new System.Drawing.Point(203, 75);
            this.gunaPanel3.Name = "gunaPanel3";
            this.gunaPanel3.Size = new System.Drawing.Size(930, 586);
            this.gunaPanel3.TabIndex = 29;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.SystemColors.Info;
            this.gunaLabel1.Location = new System.Drawing.Point(-1, 0);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(158, 29);
            this.gunaLabel1.TabIndex = 1;
            this.gunaLabel1.Text = "Communication";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(57)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1663, 846);
            this.Controls.Add(this.gunaPanel3);
            this.Controls.Add(this.gunaPanel2);
            this.Controls.Add(this.gunaPanel1);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.StatusBar1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computer Vision";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpImageZoom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).EndInit();
            this.gunaPanel2.ResumeLayout(false);
            this.gunaPanel2.PerformLayout();
            this.gunaPanel3.ResumeLayout(false);
            this.gunaPanel3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        [STAThread]
        static void Main()
        {
             Application.Run(new frmMain());
        }

        #region General Functions

        ////////////////////////Sets all checkboxes to be unchecked////////////////////////
        private void ClearCheckboxes()
        {

            lkchkOnline.Checked = true;
            lkchkGraphics.Checked = false;
            lkchkGrid.Checked = true;
            lkchkImage.Checked = true;
     
        }

        ////////////////////////Updates the text of the status bar based on the changed state of the display control////////////////////////
        private void UpdateStateMsg()
        {
            switch (CvsInSightDisplay2.State)
            {
                case Cognex.InSight.Controls.Display.CvsDisplayState.Connecting:
                    StatusBar1.Panels[0].Text = "Connecting...";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.Dialog:
                    StatusBar1.Panels[0].Text = "Dialog";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.DialogEditingReferenceRanges:
                    StatusBar1.Panels[0].Text = "Dialog Reference";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.EditingCellExpression:
                    StatusBar1.Panels[0].Text = "Editing Expression";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.EditingCellValue:
                    StatusBar1.Panels[0].Text = "Editing Value";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.EditingGraphics:
                    StatusBar1.Panels[0].Text = "Editing Graphics";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.EditingReferenceRanges:
                    StatusBar1.Panels[0].Text = "Editing Reference";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.Normal:
                    StatusBar1.Panels[0].Text = "Normal";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.Waiting:
                    StatusBar1.Panels[0].Text = "Waiting...";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.Wizard:
                    StatusBar1.Panels[0].Text = "Wizard";
                    break;
                default:
                    StatusBar1.Panels[0].Text = "Unknown";
                    break;
            }
        }

        #endregion

        #region CvsInSightDisplay2 Events

        //The connected state changed within the display control.  Event raised.
        private void CvsInSightDisplay2_ConnectedChanged(object sender, System.EventArgs e)
        {
            if (CvsInSightDisplay2.Connected)
            {
                for(int i =0; i < 3; i++)
                {
                    Console.Beep(400, 100);
                    
                }
                lkchkGrid.Checked = false;
                Console.WriteLine("Connected");
                lkBtnConnect.Text = "Disconnect";
  
            }
            else
            {
                lkBtnConnect.Text = "Connect";
                Console.Beep(1000, 1000);
                Console.WriteLine("Disconnected");
            }
               
             
        }

        //The state changed within the display control.  Event raised.
        private void CvsInSightDisplay2_StateChanged(object sender, System.EventArgs e)
        {
            UpdateStateMsg();
        }

        //The display control is now connected.  Event raised.
        private void CvsInSightDisplay2_ConnectCompleted(object sender, Cognex.InSight.CvsConnectCompletedEventArgs e)
        {
            lkchkImage.Checked = CvsInSightDisplay2.ShowImage;

            if (CvsInSightDisplay2.ImageZoomMode == Cognex.InSight.Controls.Display.CvsDisplayZoom.Fit)
                optFit.Checked = true;
            else if (CvsInSightDisplay2.ImageZoomMode == Cognex.InSight.Controls.Display.CvsDisplayZoom.None)
                optNone.Checked = true;
            else if (CvsInSightDisplay2.ImageZoomMode == Cognex.InSight.Controls.Display.CvsDisplayZoom.Fill)
                optFill.Checked = true;
            lkBtnConnect.Enabled = true;
        }

        //The status changed within the display control.  Event raised.
        private void CvsInSightDisplay2_StatusInformationChanged(object sender, System.EventArgs e)
        {
            StatusBar1.Panels[1].Text = CvsInSightDisplay2.StatusInformation;
        }
        #endregion


        #region Radio Image Zoom Button Events
        private void optFill_CheckedChanged(object sender, System.EventArgs e)
        {
            if (optFill.Checked)
            {
                CvsInSightDisplay2.ImageZoomMode = Cognex.InSight.Controls.Display.CvsDisplayZoom.Fill;
                TestZoomMode();  //Interal Test
            }
        }

        private void optFit_CheckedChanged(object sender, System.EventArgs e)
        {
            if (optFit.Checked)
            {
                CvsInSightDisplay2.ImageZoomMode = Cognex.InSight.Controls.Display.CvsDisplayZoom.Fit;
                TestZoomMode();  //Interal Test
            }
        }

        private void optNone_CheckedChanged(object sender, System.EventArgs e)
        {
            if (optNone.Checked)
            {
                CvsInSightDisplay2.ImageZoomMode = Cognex.InSight.Controls.Display.CvsDisplayZoom.Fit;
                TestZoomMode();  //Interal Test
            }
        }
        #endregion

        #region Form
        //Main initializations done here...
       
        #endregion

        #region Opacity ScrollBar Handler
        //The opacity scrollbar is changed
        private void hScrollOpacity_ValueChanged(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            CvsInSightDisplay2.GridOpacity = (double)e.NewValue / 100;
            lblGridOpacityValue.Text = System.Convert.ToString(CvsInSightDisplay2.GridOpacity * 100) + '%';
        }
        #endregion

        #region Controls GroupBox Checkbox Handlers



        #endregion

        //internal test code
        #region AutomatedTestHelper

        private bool ATEST_MODE = false;
        private object io0;

        private void lblATestMode_Click(object sender, EventArgs e)
        {
            if (!ATEST_MODE)
            {
                ATEST_MODE = true;
                lblATestMode.BackColor = Color.Green;
            }
            else
            {
                Application.Exit();
            }
        }

        private void UpdateTestStatus(string message)
        {
            StatusBar1.Panels[0].Text = message;
        }

        private void chkGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (ATEST_MODE)
                UpdateTestStatus("Show Grid = " + CvsInSightDisplay2.ShowGrid);
        }

        private void chkGraphics_CheckedChanged(object sender, EventArgs e)
        {
            if (ATEST_MODE)
                UpdateTestStatus("Show Graphics = " + CvsInSightDisplay2.ShowGraphics);
        }

        private void chkOnline_CheckedChanged(object sender, EventArgs e)
        {

            if (ATEST_MODE)
                UpdateTestStatus("Online = " + CvsInSightDisplay2.SoftOnline);
        }
        //The "Show Image" checkbox is clicked
        //Toggles whether or not the background image is shown behind the grid
        private void chkImage_CheckedChanged(object sender, System.EventArgs e)
        {
            CvsInSightDisplay2.ShowImage = lkchkImage.Checked;
            if (ATEST_MODE)
                UpdateTestStatus("Show Image = " + CvsInSightDisplay2.ShowImage);
        }

        private void TestZoomMode()
        {
            if (ATEST_MODE)
                UpdateTestStatus("Zoom Mode = " + CvsInSightDisplay2.ImageZoomMode);
        }

        private void chkLive_CheckedChanged(object sender, EventArgs e)
        {
            if (ATEST_MODE)
                UpdateTestStatus("Live Mode = " + !CvsInSightDisplay2.Edit.LiveAcquire.Activated);
        }

        #endregion


        #region OpenCV


        private delegate void SetImagenDelegado(PictureBox pictureBox, Bitmap imagen);
        private void SetImagen(PictureBox pictureBox, Bitmap imagen)
        {
            try
            {
                if (pictureBox.InvokeRequired)
                {
                    SetImagenDelegado delegado = SetImagen;
                    Object[] parametros = new Object[2];
                    parametros[0] = pictureBox;
                    parametros[1] = imagen;
                    this.Invoke(delegado, parametros);
                }
                else
                {
                    if (pictureBox.Image != null)
                    {
                        pictureBox.Image.Dispose();
                    }
                    pictureBox.Image = imagen;
                }
            }
            catch { }
        }




        private void Grabar(object sender, EventArgs arg)
        {
            LKCamera.Retrieve(LKStreamImage , 0);
            SetImagen(pbStream, LKStreamImage.Bitmap);
        }

        private void button1_Click(object sender, EventArgs e)
        {   /*
            if (LKStreamImage != null)
            {
                pbStream.Image.Save(@"C:\Users\TruongHuynh\Desktop\1_v2.job", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                Console.WriteLine("imagen2 null");
            } 
            CvsInSightDisplay2.Edit.OpenImageFromFile(@"C:\Users\TruongHuynh\Desktop\Code ok\Line-3.job");
            */
        }
        #endregion

        #region LK
        #region FormLoad
        private void frmMain_Load(object sender, System.EventArgs e)
        {
           
            this.ClearCheckboxes();
            lkHScrollOpacity.Value = System.Convert.ToInt32(CvsInSightDisplay2.GridOpacity * 100.0);
            CvsInSightDisplay2.Edit.SoftOnline.Bind(lkchkOnline);
            CvsInSightDisplay2.Edit.ShowGraphics.Bind(lkchkGraphics);
            CvsInSightDisplay2.Edit.ShowGrid.Bind(lkchkGrid);
        }
        #endregion

        #region LKFunc
        private void checkStt(string status)
        {
            if (status == "1")
            {
                setPassImg();
            }
            if (status == "0")
            {
                setFailImg();
            }
        }
        private void setPassImg()
        {
            pbResult.Image = PremoComputerVision.Properties.Resources.pass;
            this.BackColor = System.Drawing.Color.White;
            Console.WriteLine("set pass IMG");
        }
        private void setFailImg()
        {
            this.BackColor = System.Drawing.Color.Red;
           pbResult.Image = PremoComputerVision.Properties.Resources.fail;
            Console.WriteLine("set fail IMG");
        }
      
        private void saveImg()
        {
            if (pbStream != null)
            {
                pbStream.Image.Save(saveImgPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                Console.WriteLine("imagen null");
            }
        }
        private void saveFile()
        {
            if (value == "1")
            {
                stt++;
                string fileToCopy           = @"image\img.jpg";
                string destinationDirectory = @"storage\pass\";
                File.Copy(fileToCopy, destinationDirectory + Path.GetFileName("Pass" + DateTime.Now.ToString("%dMMyyyy_hmmss_") +stt.ToString()+ ".jpg"));

            }
            if (value == "0")
            {
                stt++;
                DateTime time               = DateTime.Now;
                string fileToCopy           = @"image\img.jpg";
                string destinationDirectory = @"storage\fail\";
               File.Copy(fileToCopy, destinationDirectory + Path.GetFileName("Fail" + DateTime.Now.ToString("%dMMyyyy_hmmss_") + stt.ToString() + ".jpg"));
            }
        }



     /*
         private void clearMemory()
            {
                if (LKStreamImage != null) { LKStreamImage.Dispose(); }
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }

          private void saveToDB()
            {
               // imgPath = fileName;
                idProd = "10000";
                string querry = $"INSERT INTO Product VALUES ('{this.idProd}','{this.value}','{this.imgPath}','{this.isPass}')";
                DbConnector.Instance.Insert(querry);
            }
     */

        #endregion

        #region LKEvent
        private async void btnOpen_Click(object sender, EventArgs e)
        {
          
            if (CvsInSightDisplay2.Connected)
            {
                Result result1 = await this.GetResultAsync();
                value          = result1.result;
                lbFail.Text    = result1.failValue;
                lbPass.Text    = result1.passValue;
                //lbSum.Text     = result1.sum;
                Console.WriteLine(result1.result);
                checkStt(result1.result);
                saveFile();
            }

            else

            {
                MessageBox.Show("Please Connect First");
            }

        }

        public async Task<Result> GetResultAsync() 
        {
            saveImg();
            CvsInSightDisplay2.Edit.OpenImageFromFile(saveImgPath);
            await Task.Delay(500);
            string pass  =  CvsInSightDisplay2.Results.Cells.GetCell(5, 20).ToString();
            string fail  =  CvsInSightDisplay2.Results.Cells.GetCell(5, 19).ToString();
            string value =  CvsInSightDisplay2.Results.Cells.GetCell(1, 18).ToString();
            string sum   =  CvsInSightDisplay2.Results.Cells.GetCell(5, 22).ToString();
           
            return new Result(pass, fail, value, sum);
        } 

        private void lkBtnConnect_Click(object sender, EventArgs e)
        {
            if (!(CvsInSightDisplay2.Connected))
            {
                CvsInSightDisplay2.Connect(txtAddress.Text, txtUserName.Text, txtPassword.Text, false);
                lkBtnConnect.Enabled = false;
            }
            else
            {
                CvsInSightDisplay2.Disconnect();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CvsInSightDisplay2.Edit.OpenImageFromFile(jobPath);
            Console.Beep(1000, 1000);
        }
        #endregion

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lbPass_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string user = "PREMO-VIETNAM-2022";
            if (user.Equals(resetadmin.Text))
            {
                MessageBox.Show("Unlock");
                txtAddress.Enabled = true;
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
            }
            else
                MessageBox.Show("Vui lòng liên hệ >>>");
        }

        private void gunaPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbResult_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             CvsInSightDisplay2.Edit.OpenImageFromFile(jobPath);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Test_Click(object sender, EventArgs e)
        {

        }

        private void resetadmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbStream_Click(object sender, EventArgs e)
        {

        }

        private void PLCS71200_Click(object sender, EventArgs e)
        {

        }
    }
    #endregion
}
