using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseholdAccountBook_Mock.User_Control
{
    public partial class UCAssets : UserControl
    {
        public UCAssets()
        {
            InitializeComponent();
        }

        private void UCAssets_Load(object sender, EventArgs e)
        {
            panelAssets.BackColor = AppConst.FormStyle.FormColor;
        }
    }
}
