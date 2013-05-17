using System;
using System.Windows.Forms;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.WorldMatrix.WinApp.Helpers;

namespace DG.BotWorld.WorldMatrix.WinApp.UserControls
{
    public partial class EnvironmentsUserControl : UserControl
    {
        static EnvironmentsUserControl()
        {
        }

        public EnvironmentsUserControl()
        {
            Instance = this;
            InitializeComponent();
        }

        #region Properties
        private static EnvironmentsUserControl Instance
        {
            get;
            set;
        }
        #endregion

        private IEnvironment GetSelectedEnvironment()
        {
            if (lsvEnvironments.SelectedItems.Count > 0)
            {
                return (IEnvironment)lsvEnvironments.SelectedItems[0].Tag;
            }

            return null;
        }

        private void EnvironmentsUserControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                var environments = Host.Current.Environments;
                imlEnvironments.Images.Clear();

                foreach (var env in environments)
                {
                    imlEnvironments.Images.Add(env.UIInformation.Avatar);
                    var item = new ListViewItem(env.Name, imlEnvironments.Images.Count - 1);
                    item.Tag = env;

                    lsvEnvironments.Items.Add(item);
                }
            }
        }

        private void lsvEnvironments_SelectedIndexChanged(object sender, EventArgs e)
        {
            var environment = GetSelectedEnvironment();

            if (environment != null)
            {
                MatrixHelper.SelectedEnvironment = environment;
                FormHelper.StatusMessage = environment.Description;
                pgdSelectedEnvironment.SelectedObject = environment;
            }
        }        
    }
}
