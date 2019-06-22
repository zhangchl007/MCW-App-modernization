using Contoso.Apps.Insurance.Data.ViewModels;
using PolicyConnect;
using PolicyConnect.Domain;
using PolicyConnectDesktop.DataMethods;
using System;
using System.Windows.Forms;

namespace PolicyConnectDesktop
{
    public partial class Main : Form
    {
        private readonly BindingSource _policyHolderBindingSource = new BindingSource();
        private readonly IServiceCalls _serviceCalls;

        public Main()
        {
            InitializeComponent();
            policyGrid.DataSource = _policyHolderBindingSource;
            policyGrid.AutoGenerateColumns = false;

            // Set the Service Calls to WPF or WebApi:
            if (ApplicationSettings.UseWebApi)
            {
                _serviceCalls = new WebApiCalls();
                BindPolicyGrid();
            }
            else
            {
                _serviceCalls = new WcfCalls();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindPolicyGrid();
        }

        private void FrmAuthOnFormClosed(object sender, FormClosedEventArgs formClosedEventArgs)
        {
        }

        private async void BindPolicyGrid()
        {
            var policyHolders = await _serviceCalls.GetPolicyHolders();
            _policyHolderBindingSource.DataSource = policyHolders;
            policyGrid.Refresh();
        }

        private void policyGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataItem = (PolicyHolderViewModel)policyGrid.Rows[e.RowIndex].DataBoundItem;
            var frm = new PolicyHoldersForm
            {
                PolicyHolderId = dataItem.Id,
                Operation = CrudOperation.Update,
                ServiceCalls = _serviceCalls
            };

            frm.FormClosed += FrmOnFormClosed;

            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void FrmOnFormClosed(object sender, FormClosedEventArgs formClosedEventArgs)
        {
            if (sender == null || sender.GetType() != typeof(PolicyHoldersForm)) return;
            if (((PolicyHoldersForm) sender).RefreshGrid)
            {
                BindPolicyGrid();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new PolicyHoldersForm {Operation = CrudOperation.Add, ServiceCalls = _serviceCalls};

            frm.FormClosed += FrmOnFormClosed;

            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}