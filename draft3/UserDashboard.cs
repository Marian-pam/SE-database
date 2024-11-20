using System;
using System.Windows.Forms;

namespace draft3
{
    public partial class UserDashboard : Form
    {
        public UserDashboard()
        {
            InitializeComponent();
            SetupDashboard();
        }

        private void SetupDashboard()
        {
            // Form properties
            this.Text = "User Dashboard";
            this.Size = new System.Drawing.Size(800, 500);

            // Sidebar Panel
            Panel sidebar = new Panel();
            sidebar.Size = new System.Drawing.Size(200, this.Height);
            sidebar.Dock = DockStyle.Left;
            sidebar.BackColor = System.Drawing.Color.LightGray;

            // Dashboard Title
            Label titleLabel = new Label();
            titleLabel.Text = "Dashboard";
            titleLabel.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Menu Buttons
            Button btnHome = new Button { Text = "Home", Dock = DockStyle.Top, Height = 40 };
            Button btnProfile = new Button { Text = "Profile", Dock = DockStyle.Top, Height = 40 };
            Button btnSettings = new Button { Text = "Settings", Dock = DockStyle.Top, Height = 40 };
            Button btnLogout = new Button { Text = "Logout", Dock = DockStyle.Top, Height = 40 };

            // Assign click events for buttons
            btnHome.Click += (s, e) => ShowMessage("Home");
            btnProfile.Click += (s, e) => ShowMessage("Profile");
            btnSettings.Click += (s, e) => ShowMessage("Settings");
            btnLogout.Click += (s, e) => Application.Exit();

            // Adding buttons to sidebar
            sidebar.Controls.Add(btnLogout);
            sidebar.Controls.Add(btnSettings);
            sidebar.Controls.Add(btnProfile);
            sidebar.Controls.Add(btnHome);

            // Main Content Panel
            Panel mainContent = new Panel();
            mainContent.Dock = DockStyle.Fill;
            mainContent.BackColor = System.Drawing.Color.White;

            // Welcome Label in Main Content
            Label welcomeLabel = new Label();
            welcomeLabel.Text = "Welcome, User!";
            welcomeLabel.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Regular);
            welcomeLabel.Dock = DockStyle.Top;
            welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            welcomeLabel.Padding = new Padding(10);

            mainContent.Controls.Add(welcomeLabel);

            // Add controls to the Form
            this.Controls.Add(mainContent);
            this.Controls.Add(sidebar);
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show($"{message} button clicked!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
