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
    public partial class Form1 : Form
    {
        public Timer tm = null;
        public Bitmap Block = new Bitmap(@"C:\picture\block2.png");
        public Bitmap character = new Bitmap(@"C:\picture\mario2.png");
        public int x= 150, y=0;
        public double a= 0.0;
        public int[,] mk_block = new int[20,17];
        public int[,] mk_xy = new int[600, 510];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GDIBuffer.Instance(ClientRectangle.Width, ClientRectangle.Height);
            tm = new Timer();
            tm.Enabled = true;
            tm.Interval = 10;
            tm.Tick += new EventHandler(tm_tick);
            tm.Tick += new EventHandler(tm_gravity);
            tm.Tick += new EventHandler(tm_mapout);
            for(int i=0;i<20;i++)
            {
                mk_block[i, 16] = 1;
            }
            mk_block[6, 13] = 1;
            mk_block[7, 13] = 1;
            mk_block[8, 13] = 1;
            mk_block[6, 12] = 1;
            mk_block[7, 12] = 1;
            mk_block[8, 12] = 1;
            mk_block[6, 11] = 1;
            mk_block[7, 11] = 1;
            mk_block[8, 11] = 1;
        }

        private void b_mk()
        {
            for (int q = 0; q < 20; q++)
            {
                for (int p = 0; p < 17; p++)
                {
                    if (mk_block[q, p] == 1)
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            for (int j = 0; j < 30; j++)
                            {
                                mk_xy[q * 30 + i, p * 30 + j] = 1;
                            }
                        }

                    }
                }
            }
        }

        private void tm_gravity(object sender, EventArgs e)
        {
            int[] status = new int[4]; //up down left right
            status[0] = (int)(y / 30);
            status[1] = (int)(y + 45)/30;
            status[2] = (int)x / 30;
            status[3] = (int)(x + 30)/30;
            int j;

     
            y += (int)a;
            a += 0.6;


            for(int i = 0; i < 4; i++)
            {
                if (status[i] < 0)
                    status[i] = 0;
            }
            if (status[1] > 19)
                status[1] = 19;
            if (status[3] > 16)
                status[3] = 16;

            if (mk_block[status[2], status[1]] == 1||mk_block[status[3],status[1]]==1)
            {
                y = status[1] * 30 - 45;
                a = 0.0;
                tm_jump.Stop();
            }
            else if (mk_block[status[2],status[0]]==1 || mk_block[status[3],status[0]]==1)
            {
                y = status[1] * 30 - 15;
                a = 0.0;
                tm_jump.Stop();
            }
            if(mk_block[status[2],status[0]]==1)
            {
                x = status[2] * 30 + 30;
            }
            if(mk_block[status[3],status[0]]==1)
            {
                x = status[3] * 30;
            }
        }

        private void tm_tick(object sender, EventArgs e)
        {
            FrameUpdate();
            FrameRender();
        }

        private void tm_mapout(object sender, EventArgs e)
        {
            if (x < 0)
                x = 565;
            if (x > 565)
                x = 5;
        }
        private void FrameUpdate()
        {
            GDIBuffer.Instance().getGraphics.Clear(Color.LightBlue);
            Draw();
        }

        private void FrameRender()
        {
            Graphics g = CreateGraphics();
            g.DrawImage(GDIBuffer.Instance().GetImages, new Point(0, 0));
            g.Dispose();
        }

        private void Draw()
        {
            GDIBuffer.Instance().getGraphics.DrawImage(character, x, y, 30, 45);
            DrawBlock();
        }

        private void DrawBlock()
        {
           for (int i = 0;i<20;i++)
            {
                for (int j=0;j<17;j++)
                {
                    if(mk_block[i,j] == 1)
                    {
                        GDIBuffer.Instance().getGraphics.DrawImage(Block, i * 30 , j * 30 , 30, 30);
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    x--;
                    tm_left.Start();
                    tm_right.Stop();
                    break;
                case Keys.D:
                    x++;
                    tm_right.Start();
                    tm_left.Stop();
                    break;
                case Keys.W:
                    y--;
                    tm_jump.Start();
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    tm_left.Stop();
                    break;
                case Keys.D:
                    tm_right.Stop();
                    break;
            }
        }

        private void tm_left_Tick(object sender, EventArgs e)
        {
            x -= 7;
        }

        private void tm_right_Tick(object sender, EventArgs e)
        {
            x += 7;
        }

        private void tm_jump_Tick(object sender, EventArgs e)
        {
            y -= 10;
        }

    }
}
