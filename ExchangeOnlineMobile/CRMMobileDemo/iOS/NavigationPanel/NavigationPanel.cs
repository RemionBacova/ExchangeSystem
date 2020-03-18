using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.VisualEffects;
using System.Drawing;
using CustomCRMControls;
using CRMMobileDemo.Common;

namespace CRMMobileDemo.iOS
{
    public abstract class NavigationPanel : UserControl
    {
		#region Fields (2) 

        private ScreenManager mobjManager;
        private NavigationStrip mobjNavigation;

		#endregion Fields 

		#region Constructors (1) 

        public NavigationPanel()
        {
            PreInitializeComponent();
            InitializeComponent();
            PostInitializeComponent();
            InitializeScreenManager();
        }

		#endregion Constructors 

		#region Properties (2) 

        public ScreenManager Manager
        {
            get { return mobjManager; }
            set { mobjManager = value; }
        }

        public NavigationStrip NavigationStrip
        {
            get { return mobjNavigation; }
        }

		#endregion Properties 

		#region Methods (9) 

		// Private Methods (5) 

        private void InitializeScreenManager()
        {
            mobjManager = new ScreenManager(GetScreens());
        }

        void mobjNavigation_LeftButtonClick(object sender, EventArgs e)
        {
            LeftNavigationButtonClick(sender, e);
        }

        void mobjNavigation_RightButtonClick(object sender, EventArgs e)
        {
            RightNavigationButtonClick(sender, e);
        }

        private void PostInitializeComponent()
        {
            //
            // this.mobjNavigation
            //
            this.mobjNavigation.Dock = DockStyle.Top;
            this.mobjNavigation.RightButtonClick += new EventHandler(mobjNavigation_RightButtonClick);
            this.mobjNavigation.LeftButtonClick += new EventHandler(mobjNavigation_LeftButtonClick);
            this.mobjNavigation.Size = new System.Drawing.Size(419, 44);

            this.Controls.Add(this.mobjNavigation);
        }

        private void PreInitializeComponent()
        {
            this.mobjNavigation = new NavigationStrip();
        }
		// Internal Methods (4) 

        internal abstract TranslatePanel[] GetScreens();

        internal abstract void InitializeComponent();

        internal abstract void LeftNavigationButtonClick(object sender, EventArgs e);

        internal abstract void RightNavigationButtonClick(object sender, EventArgs e);

		#endregion Methods 
    }
}