using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;

namespace sample
{
    public partial class Form2 : Form
    {

        public Timer tm = null;
        List<Bitmap> Block = new List<Bitmap>();
        List<Bitmap> character = new List<Bitmap>();
        public List<string> maplist = new List<string>();
        public int[,] mk_box = new int[20, 17]; //블럭 약식 좌표

        int x = 100, y = 345;

        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadMaplist();
            GDIBuffer.Instance(ClientRectangle.Width, ClientRectangle.Height);
            Block.Add(null);
            Block.Add(new Bitmap(@"image\block23.png"));
            Block.Add( new Bitmap(@"image\qbox.jpg"));
            Block.Add(new Bitmap(@"image\b.jpg"));
            character.Add(new Bitmap(@"image\mario2.png"));
            tm = new Timer();
            tm.Interval = 10;
            tm.Enabled = true;
            tm.Tick += new EventHandler(tm_Frame);
            mainblock();
        }

        private void mainblock()
        {
            mk_box[3, 13] = 1;
            mk_box[4, 13] = 1;
            mk_box[5, 13] = 1;
            mk_box[6, 13] = 1;
            mk_box[7, 13] = 1;
            mk_box[5, 12] = 1;
            mk_box[6, 12] = 1;
            mk_box[7, 12] = 1;
            mk_box[4, 8] = 2;
        }

        private void tm_Frame(object sender, EventArgs e)
        {
            FrameUpdate();
            FrameRender();
        }
        private void FrameUpdate()
        {

            GDIBuffer.Instance().getGraphics.Clear(Color.LightBlue);

                DrawMario(x, y);
            DrawBlock();
            
        }
        private void FrameRender()
        {
            Graphics g = CreateGraphics();
            g.DrawImage(GDIBuffer.Instance().GetImages, new Point(0, 0));
            g.Dispose();
        }
        private void DrawMario(int x, int y)
        {
            GDIBuffer.Instance().getGraphics.DrawImage(character[0], x, y, 30, 45);
        }
        private void DrawBlock()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    if (mk_box[i, j] != 0)
                    {
                        GDIBuffer.Instance().getGraphics.DrawImage(Block[mk_box[i, j]], i * 30, j * 30, 30, 30);
                    }
                }
            }
        }
        private void LoadMaplist()
        {

            string[] maplist = System.IO.File.ReadAllLines(@"map_list\maplist.txt");
            foreach (string i in maplist)
            {
                if(System.IO.File.Exists(@"map_list\" + i + ".txt") == true)
                {
                    
                    this.maplist.Add(i);
                    maplistbox.Items.Add(i);
                }

            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            tm.Stop();
            Block.Clear();
            character.Clear();
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            File.Delete(@"map_list\" + (string)maplistbox.SelectedItem + ".txt");
            maplistbox.Items.Remove(maplistbox.SelectedItem);
        }

        private void mapname_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void maplistbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mapname_TextChanged(object sender, EventArgs e)
        {

        }

        private void maplistbox_Click(object sender, EventArgs e)
        {
            bt_start.Enabled = true;
            bt_modify.Enabled = true;
            bt_delete.Enabled = true;
        }

        private void bt_createmap_Click(object sender, EventArgs e)
        {
            
        }
    }
}
