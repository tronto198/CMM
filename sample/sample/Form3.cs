using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            bt_bgm.Enabled = true;
            bt_block_set.Enabled = true;
            bt_startset.Enabled = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            tip_startset.SetToolTip(bt_startset, "좌클릭 : 시작 위치 설정 \r\n우클릭: 돌아올 위치 설정");
            tip_startset.SetToolTip(bt_move, "이 버튼만으로는 저장이 완료되지 않습니다.");
            
        }

        private void bt_startset_Click(object sender, EventArgs e)
        {

        }

        private void tip_startset_Popup(object sender, PopupEventArgs e)
        {

        }

        private void bt_close_Click(object sender, EventArgs e)
        {

        }
    }
}
