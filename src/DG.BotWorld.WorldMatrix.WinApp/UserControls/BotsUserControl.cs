#region Usings
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DG.BotWorld.BotSdk;
using DG.BotWorld.WorldMatrix.WinApp.Helpers;
#endregion

namespace DG.BotWorld.WorldMatrix.WinApp.UserControls
{
    /// <summary>
    /// User control to manage bots.
    /// </summary>
    public partial class BotsUserControl : UserControl
    {
        #region Constructors
        /// <summary>
        /// Initializes the <see cref="BotsUserControl"/> class.
        /// </summary>
        static BotsUserControl()
        {
            Host.Current.EnvironmentRunning += new EventHandler<DG.BotWorld.Hosting.EnvironmentRunningEventArgs>(Current_EnvironmentRunning);
            Host.Current.EnvironmentRan += new EventHandler<DG.BotWorld.Hosting.EnvironmentRanEventArgs>(Current_EnvironmentRan);
            Host.Current.EnvironmentAborted += new EventHandler<Hosting.EnvironmentAbortedEventArgs>(Current_EnvironmentAborted);
            Host.Current.EnvironmentError += new EventHandler<Hosting.EnvironmentErrorEventArgs>(Current_EnvironmentError);
            MatrixHelper.SelectedEnvironmentChanged += new EventHandler(MatrixHelper_SelectedEnvironmentChanged);            
        }

        static void Current_EnvironmentRan(object sender, DG.BotWorld.Hosting.EnvironmentRanEventArgs e)
        {
            Instance.Unlock();
        }

        static void Current_EnvironmentRunning(object sender, DG.BotWorld.Hosting.EnvironmentRunningEventArgs e)
        {
            Instance.Lock();
        }

        static void Current_EnvironmentError(object sender, Hosting.EnvironmentErrorEventArgs e)
        {
            Instance.Unlock();
        }

        static void Current_EnvironmentAborted(object sender, Hosting.EnvironmentAbortedEventArgs e)
        {
            Instance.Unlock();
        }

        static void MatrixHelper_SelectedEnvironmentChanged(object sender, EventArgs e)
        {
            Instance.MarkBotsForEnvironment();
            Instance.CollectSelectedBots();
        }


        public BotsUserControl()
        {            
            InitializeComponent();
            Instance = this;            
        }
        #endregion

        #region Properties
        private static BotsUserControl Instance
        {
            get;
            set;
        }
        #endregion   

        public void Lock()
        {
            Instance.lsvAllBots.Enabled = false;
            Instance.lsvBotAbilities.Enabled = false;
            Instance.pgdSelectedBot.Enabled = false;
        }

        public void Unlock()
        {
            Instance.lsvAllBots.Enabled = true;
            Instance.lsvBotAbilities.Enabled = true;
            Instance.pgdSelectedBot.Enabled = true;
        }

        private void LoadAllBots()
        {
            if (!DesignMode)
            {
                lsvAllBots.Items.Clear();
                var bots = Host.Current.Bots;
                
                foreach (var b in bots)
                {
                    imlBots.Images.Add(b.Name, b.UIInformation.Avatar);
                    var item = new ListViewItem(b.Name,  b.Name);
                    item.Tag = b;
                    item.Group = lsvAllBots.Groups["lvgWithoutAbilities"];

                    
                    lsvAllBots.Items.Add(item);
                }
            }
        }

        private void LoadBotAbilities(IBot bot)
        {
            if (!DesignMode)
            {
                lsvBotAbilities.Items.Clear();
        
                var abilities = Host.Current.GetBotAbilities(bot);

                foreach (var a in abilities)
                {
                    var item = new ListViewItem();                   
                    item.Tag = a;
                    item.ImageKey = "BotAbility";

                    var s = new ListViewItem.ListViewSubItem(item, Host.Current.GetBotAbilityInterfaceType(a).FullName);//, Color.Black, Color.White, new Font("Sans Serif", 8, FontStyle.Bold));                                        
                    item.SubItems.Add(s);

                    s = new ListViewItem.ListViewSubItem(item, a.GetType().FullName);//, Color.Gray, Color.White, new Font("Sans Serif", 7));
                    item.SubItems.Add(s);

                    lsvBotAbilities.Items.Add(item);
                }
            }
        }

        private void CollectSelectedBots()
        {
            if (!DesignMode)
            {
                MatrixHelper.ClearSelectedBots();

                foreach (ListViewItem item in lsvAllBots.CheckedItems)
                {
                    if (item.Group.Name.Equals("lvgWithAbilities"))
                    {
                        MatrixHelper.AddSelectedBot((IBot)item.Tag);
                    }
                }
            }
        }

        private void MarkBotsForEnvironment()
        {
            if (!DesignMode && MatrixHelper.SelectedEnvironment != null)
            {
                LoadAllBots();

                var botsForEnvironment = Host.Current.GetBotsForEnvironment(MatrixHelper.SelectedEnvironment);
                
                foreach (ListViewItem item in lsvAllBots.Items)
                {
                    var b = (IBot)item.Tag;

                    if (botsForEnvironment.Contains(b))
                    {
                        item.Group = lsvAllBots.Groups["lvgWithAbilities"];                                                                        
                    }
                    else
                    {
                        item.Group = lsvAllBots.Groups["lvgWithoutAbilities"];
                    }
                }
            }
        }

        private void lsvAvailableBots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvAllBots.SelectedItems.Count > 0)
            {
                pgdSelectedBot.SelectedObject = lsvAllBots.SelectedItems[0].Tag;
                pgdSelectedBot.Visible = true;

                LoadBotAbilities((IBot)pgdSelectedBot.SelectedObject);
            }
        }        

        private void lsvAllBots_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
           CollectSelectedBots();                                    
        }

        private void BotsUserControl_Load(object sender, EventArgs e)
        {
            
        }
    }
}
