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
using System.Media;
using NAudio.Wave;
using System.Drawing.Imaging;
using System.Threading;

namespace sample
{
    public partial class Form1 : Form
    {
        Form2 subform = new Form2(); //시작화면
        Form3 menu = null; // 제작 메뉴
        Form4 blockset = null; //블럭 셋
        Form5 backimageset = null; // 배경 셋
        Form6 itemset = null; // 아이템 셋
        Form7 mobset = null; // 몹셋
        

        Bitmap spike_up = new Bitmap(@"image\spike.png");
        Bitmap spike_up_opac = null;
        Bitmap spike_down = new Bitmap(@"image\spike2.png");
        Bitmap spike_down_opac = null;

        public System.Windows.Forms.Timer tm = null;
        public System.Windows.Forms.Timer create_tm = null;
        public System.Windows.Forms.Timer dm = null;
        public System.Windows.Forms.Timer ddm = null, ddm_1 = null;

        //여서부터 소리 //여부터 효과음


        SoundPlayer deathsound = new SoundPlayer(@"sound\death.wav");
        SoundPlayer jumpsound = new SoundPlayer(@"sound\jump.wav");
        SoundPlayer jumpblock = new SoundPlayer(@"sound\jumpblock.wav");
        SoundPlayer allclear = new SoundPlayer(@"sound\allclear.wav");
        SoundPlayer coin = new SoundPlayer(@"sound\coin.wav");
        SoundPlayer blockbreak = new SoundPlayer(@"sound\brockbreak.wav");
        SoundPlayer blockcoin = new SoundPlayer(@"sound\brockcoin.wav");
        SoundPlayer blockin = new SoundPlayer(@"sound\brockkinoko.wav");
        SoundPlayer goal = new SoundPlayer(@"sound\goal.wav");
        SoundPlayer powerup = new SoundPlayer(@"sound\powerup.wav");
        SoundPlayer fire = new SoundPlayer(@"sound\tekifire.wav");
        SoundPlayer humi = new SoundPlayer(@"sound\humi.wav");

        WaveOut out1 = new WaveOut();//여부턴 브금
        WaveOut out2 = new WaveOut();
        WaveOut out3 = new WaveOut();
        WaveOut out4 = new WaveOut();

        LoopStream loop1 = new LoopStream(new NAudio.Wave.WaveFileReader(@"sound\field.wav"));
        LoopStream loop2 = new LoopStream(new NAudio.Wave.WaveFileReader(@"sound\castle.wav"));
        LoopStream loop3 = new LoopStream(new NAudio.Wave.WaveFileReader(@"sound\dungeon.wav"));
        LoopStream loop4 = new LoopStream(new NAudio.Wave.WaveFileReader(@"sound\star4.wav"));//여까지 소리


        public Bitmap[] Block = new Bitmap[40];
        public Bitmap[] Block_opac = new Bitmap[40];
        public Bitmap[] backimage = new Bitmap[17];
        public Bitmap[] backimage_opac = new Bitmap[17];
        public Bitmap[] Item = new Bitmap[11];
        public Bitmap[] Item_opac = new Bitmap[11];
        public Bitmap[] Mob = new Bitmap[11];
        public Bitmap[] Mob_r = new Bitmap[11];
        public Bitmap[] Mob_opac = new Bitmap[11];


        public int[] deco_space_x = new int[17];
        public int[] deco_space_y = new int[17];
        public int[] item_space_x = new int[11];
        public int[] item_space_y = new int[11];
        public int[] mob_space_x = new int[11];
        public int[] mob_space_y = new int[11];

        public int x, y; //캐릭터 좌표

        public int[,] mk_box = new int[20, 17]; //블럭 약식 좌표
        public int[,] mk_box_info = new int[20, 17]; //블럭 상태
        public int[,] mark_block = new int[600, 510]; //장애물 xy 좌표
        public int[,] mark_block_info = new int[600, 510]; // 블럭 안내
        public int[,] mark_deco = new int[600, 510];
        public int[,] mark_item = new int[600, 510];
        public int[,] mark_mob = new int[600, 510]; //각각 xy좌표

        List<int> mk_deco = new List<int>();



        public int x_left = 0, x_right = 29; //왼쪽 크기 1 오른쪽까지 30
        public int jump = 0; //점프상태(횟수)
        public int v = 5; //최대 이동속도
        public double movepoint = 0; //처음 이동속도
        public double move_a = 0.5;  //이동 가속도
        public int moving = 0;      //이동거리?
        public int map = 1; //맵 갯수
        public string filename = "map.txt";
        public int startmap = 0, startmap_x = 90, startmap_y = 90;
        public int currentmap = 0; //현재 맵 위치
        public int create = 0;  //제작모드 (0이 게임중, 1이 블럭, 2가 캐릭터 좌표, 3 : 맵 이동, 4 : 장식배치 99 : 그냥 제작상태 )
                                //(5 : 아이템 6: 몹 )
        public int start_x, start_y; //캐릭터 시작좌표
        public int savemap = 0, save_x, save_y; //저장된 맵과 좌표

        public int mapcolor = 0, bgm_infor = 0;     //맵 컬러, 브금
        public int saveno = 0;      //세이브된 맵수
        public int jumpsize = 14;  //점프력
        public double a; // 낙하속도
        public double aa = 0.75; //중력가속도
        public int Mariosize = 1; //마리오 크기 배율
        public int key = 40, body = 30; //마리오 키 , 옆크기
        public int mariostate = 0; //마리오 상태
        public int bgmno = 0;  //브금 넘버
        public int jumpcan = 1;  //점프가능 수
        public int ahffk = 3 , lastmap = -1;       //ahffk는 방향(기본 바닥버튼도 같이씀) lastmap은 전맵
        public int create_no = 11;               // 맵 제작시 블럭 번호
        public int qbox_no = 0; //qbox

        List<int[]> map_block_info = new List<int[]>(); // 블럭 상태        //0000 4자리중 앞 두자리가 여기

        List<int[]> map_block = new List<int[]>(); // 블럭 정보             //뒤 2자리는 여기

        List<string> maplist = new List<string>();


        List<Bitmap> 화살표 = new List<Bitmap>();
         List<List<int>> all_info = new List<List<int>>();    //맵 안내
        //(몹, 아이템, 장식, 이벤트) (맵컬러,브금,0,0) (0,0,0,0)
        //(맵아웃 방향, 목표맵,x,y) X 방향수 

        List<List<string>> item_data = new List<List<string>>();        //아이템 정보(아이템 종류 c 아이템 상태 c 좌 c 표)
        List<List<int>> deco_data = new List<List<int>>();              // 장식 정보(장식 종류, 장식 좌,표)
        List<List<string>> mob_data = new List<List<string>>();         //몹 정보 (몹 종류 c 몹 상태 c 좌c표)

        List<string> map_item = new List<string>();  //아이템 
        List<string> map_mob = new List<string>();
        List<int[]> all_mapout = new List<int[]>();
        // 맵 방향 따라 가는 맵 저장

        List<WaveOut> map_bgm_waveout= new List<WaveOut>(); //맵 브금
        List<LoopStream> map_bgm_stream = new List<LoopStream>();

        
        List<string> filesave = new List<string>();
        //맵 정보(몹 갯수, 함정갯수, 장식갯수) 시작좌표 2개(맵 위치,x,y), 몹 갯수만큼의 좌표(몹 종류,x,y), 함정 갯수만큼의 좌표(함정 종류, x, y)

        List<Bitmap> character = new List<Bitmap>(); //마리오 상태(0,1은 평시, 2는 점프 3은 죽을때  +4는 왼쪽)


        public class LoopStream : WaveStream
        {
            WaveStream sourceStream;

            /// <summary>
            /// Creates a new Loop stream
            /// </summary>
            /// <param name="sourceStream">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
            /// or else we will not loop to the start again.</param>
            public LoopStream(WaveStream sourceStream)
            {
                this.sourceStream = sourceStream;
                this.EnableLooping = true;
            }

            /// <summary>
            /// Use this to turn looping on or off
            /// </summary>
            public bool EnableLooping { get; set; }

            /// <summary>
            /// Return source stream's wave format
            /// </summary>
            public override WaveFormat WaveFormat
            {
                get { return sourceStream.WaveFormat; }
            }

            /// <summary>
            /// LoopStream simply returns
            /// </summary>
            public override long Length
            {
                get { return sourceStream.Length; }
            }

            /// <summary>
            /// LoopStream simply passes on positioning to source stream
            /// </summary>
            public override long Position
            {
                get { return sourceStream.Position; }
                set { sourceStream.Position = value; }
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                int totalBytesRead = 0;

                while (totalBytesRead < count)
                {
                    int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                    if (bytesRead == 0)
                    {
                        if (sourceStream.Position == 0 || !EnableLooping)
                        {
                            // something wrong with the source stream
                            break;
                        }
                        // loop
                        sourceStream.Position = 0;
                    }
                    totalBytesRead += bytesRead;
                }
                return totalBytesRead;
            }
        }       //소리 반복재생
        public Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();
            return bmp;
        }       //사진 투명하게


        public void load_createmap()
        {
            blockset = new Form4();
            backimageset = new Form5();
            itemset = new Form6();
            mobset = new Form7();

            Thread cb = new Thread(new ThreadStart(thread_create_form_load));
            cb.Start();

            화살표.Add(null);
            for (int i = 1; i < 5; i++)
            {
                Image g = Image.FromFile(@"image\goto" + i + ".png");

                화살표.Add(ChangeOpacity(g, 0.4f));
            }
            Image gm = Image.FromFile(@"image\mario1.png");
            character.Add(ChangeOpacity(gm, 0.4f));

            create_menu_set();

            spike_down_opac = ChangeOpacity(Image.FromFile(@"image\spike2.png"), 0.4f);
            spike_up_opac = ChangeOpacity(Image.FromFile(@"image\spike.png"), 0.4f);
            mobset.DesktopLocation = new Point(DesktopLocation.X + 600, DesktopLocation.Y);

            itemset.DesktopLocation = new Point(this.DesktopLocation.X + 600, this.DesktopLocation.Y);

        }

        private void thread_create_form_load()
        {

            blockset.FormClosing += new FormClosingEventHandler(create_form_formclosing);

            backimageset.FormClosing += new FormClosingEventHandler(create_form_formclosing);

            itemset.FormClosing += new FormClosingEventHandler(create_form_formclosing);


            create_block_load();
            create_backimage_Load();
            create_item_Load();
            create_mob_Load();
        }

        public void create_block_load()
        {
            for (int i = 0; i < Block_opac.Length; i++)
            {
                if (System.IO.File.Exists(@"image\block\" + i + ".png"))
                {
                    Image g = Image.FromFile(@"image\block\" + i + ".png");
                    Block_opac[i] = ChangeOpacity(g, 0.4f);
                }
            }

            blockset.b_11.Click += new EventHandler(b_11_Click);
            blockset.b_12.Click += new EventHandler(b_12_Click);
            blockset.b_13.Click += new EventHandler(b_13_Click);
            blockset.b_14.Click += new EventHandler(b_14_Click);
            blockset.b_15.Click += new EventHandler(b_15_Click);
            blockset.b_16.Click += new EventHandler(b_16_Click);
            blockset.b_17.Click += new EventHandler(b_17_Click);
            blockset.b_21.Click += new EventHandler(b_21_Click);
            blockset.b_22.Click += new EventHandler(b_22_Click);
            blockset.b_23.Click += new EventHandler(b_23_Click);
            blockset.b_24.Click += new EventHandler(b_24_Click);
            blockset.b_25.Click += new EventHandler(b_25_Click);
            blockset.b_26.Click += new EventHandler(b_26_Click);
            blockset.b_27.Click += new EventHandler(b_27_Click);
            blockset.b_31.Click += new EventHandler(b_31_Click);
            blockset.b_32.Click += new EventHandler(b_32_Click);
            blockset.b_33.Click += new EventHandler(b_33_Click);
            blockset.b_34.Click += new EventHandler(b_34_Click);
            blockset.b_35.Click += new EventHandler(b_35_Click);
            blockset.b_36.Click += new EventHandler(b_36_Click);
            blockset.b_37.Click += new EventHandler(b_37_Click);
            blockset.b_38.Click += new EventHandler(b_38_Click);
        }
        private void create_backimage_Load()
        {
            for(int i = 0; i < backimage.Length; i++)
            {
                if (File.Exists(@"image\backimage\" + i + ".png") == true)
                {
                    Image g = Image.FromFile(@"image\backimage\" + i + ".png");
                    backimage_opac[i] = ChangeOpacity(g, 0.4f);
                }
            }


            backimageset.p_1.Click += new EventHandler(p_01_Click);
            backimageset.p_2.Click += new EventHandler(p_02_Click);
            backimageset.p_3.Click += new EventHandler(p_03_Click);
            backimageset.p_4.Click += new EventHandler(p_04_Click);
            backimageset.p_11.Click += new EventHandler(b_11_Click);
            backimageset.p_12.Click += new EventHandler(p_12_Click);
            backimageset.p_13.Click += new EventHandler(b_13_Click);
            backimageset.p_14.Click += new EventHandler(b_14_Click);
            backimageset.p_15.Click += new EventHandler(b_15_Click);
            backimageset.p_16.Click += new EventHandler(b_16_Click);

        }
        private void create_item_Load()
        {
            for (int i = 0; i < Item_opac.Length; i++)
            {
                if (File.Exists(@"image\item\" + i + ".png") == true)
                {
                    Image g = Image.FromFile(@"image\item\" + i + ".png");
                    Item_opac[i] = ChangeOpacity(g, 0.4f);
                }
            }


            itemset.i_0.Click += new EventHandler(p_00_Click);
            itemset.i_1.Click += new EventHandler(p_01_Click);
            itemset.i_2.Click += new EventHandler(p_02_Click);
            itemset.i_3.Click += new EventHandler(p_03_Click);
            itemset.i_4.Click += new EventHandler(p_04_Click);
            itemset.i_5.Click += new EventHandler(p_05_Click);
            itemset.i_6.Click += new EventHandler(p_06_Click);
            itemset.i_7.Click += new EventHandler(p_07_Click);
            itemset.i_8.Click += new EventHandler(p_08_Click);
            itemset.i_9.Click += new EventHandler(p_09_Click);
            itemset.i_10.Click += new EventHandler(p_10_Click);

        }
        private void create_mob_Load()
        {
            for (int i = 0; i < Mob_opac.Length; i++)
            {
                if (File.Exists(@"image\mob\" + i + ".png") == true)
                {
                    Image g = Image.FromFile(@"image\mob\" + i + ".png");
                    Mob_opac[i] = ChangeOpacity(g, 0.4f);
                }
            }

            mobset.m_1.Click += new EventHandler(p_01_Click);
            mobset.m_2.Click += new EventHandler(p_02_Click);
            mobset.m_3.Click += new EventHandler(p_03_Click);
            mobset.m_4.Click += new EventHandler(p_04_Click);
            mobset.m_6.Click += new EventHandler(p_06_Click);
            mobset.m_10.Click += new EventHandler(p_10_Click);

        }

        private void create_form_formclosing(object sender, FormClosingEventArgs e)
        {
            create = 99;
        }



        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            subform.Show();

            bgm_in();
            block_in();
            backimage_in();
            item_in();
            mob_in();

            Thread formload = new Thread(new ThreadStart(thread_main_formlaod));
            formload.Start();
            


            GDIBuffer.Instance(ClientRectangle.Width, ClientRectangle.Height);
            GDIBuffer.Instance().getGraphics.Clear(Color.LightBlue);

            character.Add(new Bitmap(@"image\mario1.png"));
            character.Add(new Bitmap(@"image\mario2.png"));
            character.Add(new Bitmap(@"image\mario3.png"));
            character.Add(new Bitmap(@"image\mario4.png"));
            character.Add(new Bitmap(@"image\mario5.png"));
            character.Add(new Bitmap(@"image\mario6.png"));
            character.Add(new Bitmap(@"image\mario7.png"));
            character.Add(new Bitmap(@"image\mario8.png"));


            FrameRender();

        }
        private void thread_main_formlaod()
        {



            subform.bt_createmap.Click += new EventHandler(Bt_createmap_Click);
            subform.bt_start.Click += new EventHandler(bt_gamestart_click);
            subform.FormClosing += new FormClosingEventHandler(subform_close);
            subform.bt_modify.Click += new EventHandler(bt_modify_click);
            subform.maplistbox.DoubleClick += new EventHandler(bt_gamestart_click);




            filesave.Add(null);

            tm = new System.Windows.Forms.Timer();
            tm.Interval = 10;
            tm.Tick += new EventHandler(tm_Frame);

            ddm = new System.Windows.Forms.Timer();
            ddm.Interval = 10;
            ddm.Tick += new EventHandler(tm_Frame);
            ddm.Tick += new EventHandler(ddm_gravity);

            ddm_1 = new System.Windows.Forms.Timer();
            ddm_1.Interval = 2800;
            ddm_1.Tick += new EventHandler(ddm_1_tick);

            dm = new System.Windows.Forms.Timer();
            dm.Interval = 10;
            dm.Tick += new EventHandler(dm_Frame);

        }

        private void bgm_in ()
        {
            
            out1.Init(loop1);
            

            map_bgm_waveout.Add(out1);
            map_bgm_stream.Add(loop1);

            out2.Init(loop2);
            out2.Volume = (float)0.6;
            map_bgm_waveout.Add(out2);
            map_bgm_stream.Add(loop2);

            
            out3.Init(loop3);
            out3.Volume = (float)0.5;
            map_bgm_waveout.Add(out3);
            map_bgm_stream.Add(loop3);

            out4.Init(loop4);
            map_bgm_waveout.Add(out4);
            map_bgm_stream.Add(loop4);


        }                                   //브금인
        private void block_in()
        {
            for (int i = 0; i < Block.Length; i++)
            {
                if (System.IO.File.Exists(@"image\block\" + i + ".png"))
                {
                    Block[i] = new Bitmap(@"image\block\" + i + ".png");
                }
            }
        }
        private void backimage_in()
        {
            for(int i = 0; i < backimage.Length; i++)
            {
                if (System.IO.File.Exists(@"image\backimage\" + i + ".png"))
                {
                    backimage[i] = new Bitmap(@"image\backimage\" + i + ".png");
                    deco_space_y[i] = backimage[i].Height;
                    deco_space_x[i] = backimage[i].Width;
                }
            }
        }
        private void item_in()
        {
            for(int i = 0; i < Item.Length; i++)
            {
                if (File.Exists(@"image\item\" + i + ".png"))
                {
                    Item[i] = new Bitmap(@"image\item\" + i + ".png");
                    item_space_x[i] = Item[i].Width;
                    item_space_y[i] = Item[i].Height;
                }
            }   
        }
        private void mob_in()
        {
            for (int i = 0; i < Mob.Length; i++)
            {
                if (System.IO.File.Exists(@"image\mob\" + i + ".png"))
                {
                    Mob[i] = new Bitmap(@"image\mob\" + i + ".png");
                    mob_space_y[i] = Mob[i].Height;
                    mob_space_x[i] = Mob[i].Width;
                }

                if (File.Exists(@"image\mob\-" + i + ".png"))
                {
                    Mob_r[i] = new Bitmap(@"image\mob\-" + i + ".png"); 
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (create != 0)
            {
                save_map();
                WriteMap();
            }
            write_file();
            if(File.Exists(@"map_list\.save_file.txt") == true)
            {
                File.Delete(@"map_list\save_file.txt");
            }

            loop1.Dispose();
            loop2.Dispose();
            loop3.Dispose();
            loop4.Dispose();

            out1.Dispose();
            out2.Dispose();
            out3.Dispose();
            out4.Dispose();

            deathsound.Dispose();
            jumpsound.Dispose();
            jumpblock.Dispose();
            allclear.Dispose();
        }

         


        private void subform_close(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Move(object sender, EventArgs e)
        {
            /*Point mm = this.DesktopLocation;
            mm.X += 603;
            menu.DesktopLocation = mm;*/
            Point yy = this.DesktopLocation;
            if (menu != null && blockset != null && backimageset != null && itemset != null)
            {
                menu.DesktopLocation = new Point(yy.X, yy.Y + 548);
                blockset.DesktopLocation = new Point(yy.X + 600, yy.Y);
                backimageset.DesktopLocation = new Point(yy.X + 600, yy.Y);
                itemset.DesktopLocation = new Point(DesktopLocation.X + 600, DesktopLocation.Y);
                mobset.DesktopLocation = new Point(DesktopLocation.X + 600, DesktopLocation.Y);

                if (create == 1)
                {
                    itemset.DesktopLocation = new Point(this.DesktopLocation.X + 600, this.DesktopLocation.Y + 180);
                }
                else
                    itemset.DesktopLocation = new Point(this.DesktopLocation.X + 600, this.DesktopLocation.Y);

            }
        }

        private void Bt_createmap_Click(object sender, EventArgs e)
        {
            int pp=0;
            foreach (string i in subform.maplist)
            {
                if (subform.mapname.Text == i)
                {
                    pp = 1;
                }
            }
            if (subform.mapname.Text == null)
            {
                MessageBox.Show("맵 이름을 입력해주세요.");
            }
            else if (pp == 1)
            {
                MessageBox.Show("이미 있는 맵 이름입니다.");
            }
            else
            {
                menu = new Form3();
                this.Text = "고양이 마리오 메이커 : " + subform.mapname.Text;
                create = 99;
                load_createmap();
                Thread fm = new Thread(new ThreadStart(subformclose));
                fm.Start();
                subform.Opacity = 0;
                this.DesktopLocation = new Point(0, 0);

                menu.Show();
                bgmno = 0;

                subform.tm.Stop();
                this.Opacity = 100;
                create_tm = new System.Windows.Forms.Timer();
                create_tm.Interval = 10;
                create_tm.Enabled = true;
                create_tm.Tick += new EventHandler(tm_Frame);

                menu.DesktopLocation = new Point(DesktopLocation.X, DesktopLocation.Y + 548);

                click();
                currentmapinfor.Visible = true;
                currentmapinfor.Enabled = true;
                currentmapinfor.Text = "map " + (currentmap + 1);
                map = 1;
                mapcreate_start();
            }
        }
        private void bt_gamestart_click(object sender, EventArgs e)
        {
            this.DesktopLocation = subform.DesktopLocation;
            subform.tm.Stop();

            this.Opacity = 100;
            this.Text = "고양이 마리오 : " + (string)subform.maplistbox.SelectedItem;
            filename = @"map_list\" + (string)subform.maplistbox.SelectedItem + ".txt";
            ReadMap(filename);
            click();
            gamestart();
        }
        private void gamestart()
        {
            deadscreen();
            countdead.Enabled = true;
            countdead.Visible = true;
            visualx.Enabled = true;
            visualx.Visible = true;
            int b = int.Parse(countdead.Text);
            dead.Enabled = true;
            ItemReset();
        }
        private void bt_modify_click(object sender, EventArgs e)
        {


            menu = new Form3();
            create = 99;
            load_createmap();

            this.DesktopLocation = subform.DesktopLocation;
            subform.tm.Stop();
            subform.Opacity = 0;

            maplist = subform.maplist;
            this.Text = "고양이 마리오 메이커 : " + (string)subform.maplistbox.SelectedItem;
            filename = @"map_list\" + (string)subform.maplistbox.SelectedItem + ".txt";

            if (File.Exists(@"map_list\.save_file.txt") == true)
            {
                File.Delete(@"map_list\.save_file.txt");
            }
            System.IO.File.Copy(filename, @"map_list\.save_file.txt");


            this.Opacity = 100;
            map_modify();
            this.DesktopLocation = new Point(0, 0);

            ReadMap(@"map_list\.save_file.txt");

            LoadMap();

            click();
        }       //겜 첫화면 버튼들

        private void create_menu_set()
        {
            menu.bt_move.Click += new EventHandler(bt_move_click);

            menu.bt_bgm.Click += new EventHandler(bt_bgm_click);
            menu.bt_block_set.Click += new EventHandler(bt_block_set_click);
            menu.bt_startset.Click += new EventHandler(bt_startset_click);
            menu.bt_close.Click += new EventHandler(bt_close_click);
            menu.bt_deco.Click += new EventHandler(bt_deco_set_click);
            menu.bt_item.Click += new EventHandler(bt_item_set_click);
            menu.bt_mob.Click += new EventHandler(bt_mob_set_click);
            menu.bt_mapcolor.Click += new EventHandler(bt_mapcolor_click);
            menu.bt_clear.Click += new EventHandler(bt_clear_click);

            blockset.bt_base.Click += new EventHandler(bt_base_click);
        }


        private void bt_base_click(object sender, EventArgs e)
        {
            if (ahffk < 3)
                ahffk++;
            else
                ahffk = 0;
            for(int i = 0; i < 20; i++)
            {
                if (ahffk < 2)
                {
                    mk_box[i, 15] = ahffk * 10 + 15;
                    mk_box[i, 16] = ahffk * 10 + 16;
                    mk_box_info[i, 15] = 10;
                    mk_box_info[i, 16] = 10;
                }
                else if(ahffk ==2)
                {
                    mk_box[i, 15] = 38;
                    mk_box[i, 16] = 38;
                    mk_box_info[i, 15] = 10;
                    mk_box_info[i, 16] = 10;
                }
                else
                {
                    mk_box[i, 15] = 0;
                    mk_box[i, 16] = 0;
                    mk_box_info[i, 15] = 10;
                    mk_box_info[i, 16] = 10;
                }
            }
        }

        private void map_modify()
        {

            menu.Show();

            subform.tm.Stop();
            this.Opacity = 100;
            create_tm = new System.Windows.Forms.Timer();
            create_tm.Interval = 10;
            create_tm.Enabled = true;
            create_tm.Tick += new EventHandler(tm_Frame);

            menu.DesktopLocation = new Point(DesktopLocation.X, DesktopLocation.Y + 548);


            create = 99;

            System.IO.File.Delete(filename);
        }
        private void mapcreate_start()
        {
            all_mapout.Add(new int[4] {-1,-1,-1,-1 });
            all_info.Add(new List<int>());
            deco_data.Add(new List<int>());
            item_data.Add(new List<string>());
            mob_data.Add(new List<string>());
            map_block.Add(new int[340]);
            map_block_info.Add(new int[340]);
            mk_deco.Add(-1);
            map_item.Clear();
            map_mob.Clear();

            all_mapout[map - 1][ahffk] = lastmap;

            ahffk = 3;
            for (int i = 0; i < 12; i++)
            {
                all_info[map - 1].Add(0);
            }




            create = 99;
            xy_block_reset();
            Blockreset();
            currentmap = map - 1;
            for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 17; j++)
                {
                    mk_box_info[i, j] = 10;
                }
            }

            currentmapinfor.Text = "map " + (currentmap + 1);
            save_map();
            WriteMap();
            map_bgm_waveout[bgmno].Play();
        }

        private void bt_close_click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bt_startset_click(object sender, EventArgs e)
        {
            blockset.Hide();
            backimageset.Hide();
            itemset.Hide();
            mobset.Hide();

            if (create == 2)
            {
                startmap = savemap;
                menu.bt_startset.Text = "시작 맵으로\r\n설정 및\r\n시작 좌표 설정";
                create = 99;
            }
            else
            {
                savemap = startmap;
                startmap = currentmap;
                menu.bt_startset.Text = "취소";
                create = 2;
                menu.bt_move.Enabled = false;
            }

        }
        private void bt_block_set_click(object sender, EventArgs e)
        {
            backimageset.Hide();
            itemset.Hide();
            mobset.Hide();

            create_no = 11;
            blockset.Show();
            create = 1;
            Point p = this.DesktopLocation;
            blockset.DesktopLocation = new Point(p.X + 600, p.Y) ;
        }
        private void bt_deco_set_click(object sender, EventArgs e)
        {
            blockset.Hide();
            itemset.Hide();
            mobset.Hide();

            create_no = 1;
            backimageset.Show();
            create = 4;
            Point p = this.DesktopLocation;
            backimageset.DesktopLocation = new Point(p.X + 600, p.Y + 180);
        }
        private void bt_item_set_click(object sender, EventArgs e)
        {
            backimageset.Hide();
            blockset.Hide();
            mobset.Hide();

            create_no = 0;

            itemset.i_6.Enabled = true;
            itemset.i_7.Enabled = true;
            itemset.i_8.Enabled = true;
            itemset.i_9.Enabled = true;
            itemset.i_10.Enabled = true;
            Point p = this.DesktopLocation;
            itemset.DesktopLocation = new Point(p.X + 600, p.Y + 180); itemset.Show();

            itemset.Show();
            create = 5;
        }
        private void bt_mob_set_click(object sender, EventArgs e)
        {
            create_no = 1;

            Point p = this.DesktopLocation;
            mobset.DesktopLocation = new Point(p.X + 600, p.Y + 180);
            blockset.Hide();
            backimageset.Hide();
            itemset.Hide();
            mobset.Show();


            create = 6;
        }
        private void bt_bgm_click(object sender, EventArgs e)
        {
            map_bgm_waveout[bgmno].Stop();
            if (bgmno < 2)
                bgmno++;
            else
                bgmno = 0;
            switch (bgmno)
            {
                case 0:
                    menu.lb_bgm.Text = "BGM : field";
                    break;
                case 1:
                    menu.lb_bgm.Text = "BGM : castle";
                    break;
                case 2:
                    menu.lb_bgm.Text = "BGM : dungeon";
                    break;
            }

            map_bgm_stream[bgmno].Position = 0;
            map_bgm_stream[bgmno].CurrentTime = TimeSpan.Zero;
            map_bgm_waveout[bgmno].Play();
        }
        private void bt_mapcolor_click(object sender, EventArgs e)
        {
            if (mapcolor == 0)
            {
                mapcolor = 1;
                currentmapinfor.BackColor = Color.Black;
                currentmapinfor.ForeColor = Color.White;
                menu.lb_color.Text = "MapColor\r\nBlack";
            }
            else
            {
                mapcolor = 0;
                currentmapinfor.BackColor = Color.LightBlue;
                currentmapinfor.ForeColor = Color.Black;
                menu.lb_color.Text = "MapColor\r\nLightBlue";
            }
        }
        private void bt_move_click(object sender, EventArgs e)
        {
            blockset.Hide();
            backimageset.Hide();
            itemset.Hide();
            mobset.Hide();
            create = 3;
        }
        private void bt_clear_click(object sender, EventArgs e)
        {
            mob_data[currentmap].Clear();
            item_data[currentmap].Clear();
            deco_data[currentmap].Clear();
            all_info[currentmap][0] = 0;
            all_info[currentmap][1] = 0;
            all_info[currentmap][2] = 0;
            LoadMap();
        }         //맵 만드는 폼 버튼


        private void MarioDead()
        {

            ItemReset();
            MobReset();

            mariostate = 3;
            tm_left.Stop();
            tm_right.Stop();
            tm_jump.Stop();

            tm.Tick -= tm_gravity;
            tm.Tick -= tm_Item_move;
            tm.Tick -= tm_mob_move;

            map_bgm_waveout[bgmno].Stop();
            deathsound.Play();
            movepoint = 0;
            tm_move.Stop();


            map_bgm_stream[bgmno].Position = 0;
            map_bgm_stream[bgmno].CurrentTime = TimeSpan.Zero;
            tm_death.Start();
        }
        private void dead_Tick(object sender, EventArgs e)
        {
            MarioRestart();
            countdead.Enabled = false;
            countdead.Visible = false;
            visualx.Enabled = false;
            visualx.Visible = false;
            currentmapinfor.Visible = true;
            dead.Enabled = false;
            dm.Enabled = false;
        }
        private void ddm_1_tick(object sender, EventArgs e)
        {
            ddm.Enabled = false;
            ddm_1.Enabled = false;
            tm.Enabled = false;
            deadscreen();
        }
        private void ddm_gravity(object sender, EventArgs e)
        {

            a += aa;   //중력가속도

            if (y < 515)
                y += (int)a;

        }
        private void tm_death_Tick(object sender, EventArgs e)
        {
            tm_death.Enabled = false;
            ddm_1.Enabled = true;
            ddm.Enabled = true;
            a = -12.5;
        }
        private void deadscreen()
        {
            x = 20;
            y = 20;
            countdead.Enabled = true;
            countdead.Visible = true;
            visualx.Enabled = true;
            visualx.Visible = true;
            currentmapinfor.Visible = false;

            int b = int.Parse(countdead.Text);
            countdead.Text = --b + "";
            mariostate = 0;

            dm.Enabled = true;

            dead.Enabled = true;
        }
        private void dm_Frame(object sender, EventArgs e)
        {
            GDIBuffer.Instance().getGraphics.Clear(Color.Black);
            DrawMario(233 - (key * Mariosize / 2), 265 - (key * Mariosize / 2));
            FrameRender();
        } 
        private void MarioRestart()
        {
            tm.Enabled = true;
            currentmap = savemap;
            x = save_x;
            y = save_y;
            a = 0.0;
            jump = 0;
            LoadMap();

            tm_move.Start();

            tm.Tick += new EventHandler(tm_gravity);

            tm.Tick += new EventHandler(tm_Item_move);
            tm.Tick += new EventHandler(tm_mob_move);

            tm_jump.Stop();
            tm_right.Stop();
            tm_left.Stop();
            jump = 1;

        }                                   //마리오 죽을때



        private void ReadMap(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            List<int> allmapinfor = new List<int>();


            string[] allinfor = sr.ReadLine().Split(';');   //첫줄 처리
            
            foreach(string i in allinfor)
            {
                string[] infor = i.Split('a');
                foreach(string a in infor)
                {
                    allmapinfor.Add(int.Parse(a));
                }
            }

            startmap = allmapinfor[0];
            startmap_x = allmapinfor[2];
            startmap_y = allmapinfor[3];
            map = allmapinfor[1];

            savemap = startmap;             //새로시작할때 일단
            save_x = startmap_x;
            save_y = startmap_y;
            saveno = map ;


            while (sr.Peek() != -1)             //2줄부터 처리
            {
                List<int> map_info = new List<int>();
                List<int> map_deco = new List<int>();
                List<string> map_item = new List<string>();
                List<string> map_mob = new List<string>();
                

                int[] mapch = new int[4];
                string[] blockarray = sr.ReadLine().Split(';'); //0번은 블럭, 1번은 맵 정보, 2번은 다른 정보
                string[] blockinfor = blockarray[0].Split(' ');

                
                int[] blockinfo = new int[340];
                int[] blockdata = new int[340];
                

                for(int i = 0; i < 340; i++)
                {
                    char[] blockinformation = blockinfor[i].ToCharArray();
                    blockinfo[i] = (blockinformation[0] - 48) * 10 + (blockinformation[1] - 48);
                    blockdata[i] = (blockinformation[2] - 48) * 10 + (blockinformation[3] - 48);
                }

                map_block_info.Add(blockinfo);
                map_block.Add(blockdata);                //블럭 정보 저장

                string[] mapinfor = blockarray[1].Split(' ');
                for (int i = 0; i < 3; i++)
                {
                    string[] infor = mapinfor[i].Split('b');
                    for (int j = 0; j < 4; j++)
                    {
                        map_info.Add(int.Parse(infor[j]));
                    }
                }

                string[] mapchange = mapinfor[3].Split('b');

                for(int i = 0; i < 4; i++)
                {
                    mapch[i] = int.Parse(mapchange[i]);
                }

                all_info.Add(map_info);

                all_mapout.Add(mapch);                      //맵 정보 저장


                
                string[] mapdata = null;
                if (blockarray[2] != "")
                {
                    mapdata = blockarray[2].Split(' ');
                    int data_no = 0;

                    for(int i = 0; i<all_info[all_info.Count - 1 ][0]; i++, data_no++)
                    {
                        map_mob.Add(mapdata[data_no]);
                    }

                    for (int i = 0 ;  i < all_info[all_info.Count - 1][1]; i++ , data_no++)
                    {
                        map_item.Add(mapdata[data_no]);
                    }
                    for (int i = 0; i < all_info[all_info.Count - 1][2] ; i ++ , data_no++)
                    {
                        string[] deco = mapdata[data_no].Split('c');
                        for(int j = 0; j < 3; j++)
                        {
                            map_deco.Add(int.Parse(deco[j]));
                        }
                    }

                    
                }


                deco_data.Add(map_deco);
                item_data.Add(map_item);
                mob_data.Add(map_mob);                      // 몹 등 옵젝 저장

            }
            sr.Close();
        }
        private void LoadMap()
        {
            int[] blockdata = map_block[currentmap];
            int[] blockinfo = map_block_info[currentmap];
            int mapbgmno;
            mk_deco.Clear();
            mk_deco.Add(-1);
            map_item.Clear();
            map_mob.Clear();




            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    mk_box[i, j] = blockdata[i * 17 + j];
                    mk_box_info[i, j] = blockinfo[i * 17 + j];
                }
            }
            mapcolor = all_info[currentmap][4];
            mapbgmno = all_info[currentmap][5];
            //8 , 9, 10, 11은 빈칸

            for(int i = 0; i < all_info[currentmap][0]; i++)
            {
                map_mob.Add(mob_data[currentmap][i]);
            }

            for(int i = 0; i<all_info[currentmap][1]; i++)
            {
                map_item.Add(item_data[currentmap][i]);
            }

            for(int i = 0; i < all_info[currentmap][2]; i++)
            {
                int ii = deco_data[currentmap][i * 3];
                if (ii == 12 || ii == 14 )
                {
                    mk_deco.Add(i*3);
                }

            }

            currentmapinfor.Text = "map " + (currentmap + 1);
            DecoMarking();
            BlockMarking();

            if (bgmno != mapbgmno)
            {
                map_bgm_waveout[bgmno].Stop();
                bgmno = mapbgmno;
                map_bgm_stream[bgmno].Position = 0;
                map_bgm_stream[bgmno].CurrentTime = TimeSpan.Zero;
                map_bgm_waveout[bgmno].Play();
            }
            else
                map_bgm_waveout[mapbgmno].Play();


            if (mapcolor == 0)
            {
                currentmapinfor.BackColor = Color.LightBlue;
                currentmapinfor.ForeColor = Color.Black;
            }
            else
            {
                currentmapinfor.BackColor = Color.Black;
                currentmapinfor.ForeColor = Color.White;
            }


        }                                       //파일 읽기

        private void save_map()
        {
            string[] data1 = new string[map_item.Count];
            map_item.CopyTo(data1);
            string[] data2 = new string[map_mob.Count];
            map_mob.CopyTo(data2);

            List<string> d1 = new List<string>();
            List<string> d2 = new List<string>();
            foreach(string dd in data1)
            {
                d1.Add(dd);
            }
            foreach(string dd in data2)
            {
                d2.Add(dd);
            }
            item_data[currentmap] = d1;

            mob_data[currentmap] = d2;
            mob_data[currentmap].Count();

            create = 99;
            int[] blockdata = new int[340];
            int[] blockinfo = new int[340];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    blockdata[i * 17 + j] = mk_box[i, j];
                    blockinfo[i * 17 + j] = mk_box_info[i, j];
                }
            }

            map_block_info[currentmap] = blockinfo;

            map_block[currentmap] = blockdata;

            all_info[currentmap][4] = mapcolor;
            all_info[currentmap][5] = bgmno;
        }

        private void WriteMap()
        {
            filesave.Clear();
            filesave.Add(null);
            for (int mapcount = 0; mapcount < map; mapcount++)
            {

                string save = "";
                for (int i = 0; i < 340; i++)
                {
                    if (i == 339)
                    {
                        save += (map_block_info[mapcount][i] * 100 + map_block[mapcount][i]) + ";";
                    }

                    else
                    {
                        save += (map_block_info[mapcount][i] * 100 + map_block[mapcount][i]) + " ";
                    }

                }             //블럭 세이브

                save += all_info[mapcount][0] + "b" + all_info[mapcount][1] + "b" + all_info[mapcount][2] + "b" + all_info[mapcount][3] + " ";
                save += all_info[mapcount][4] + "b" + all_info[mapcount][5] + "b0b0 ";
                save += "0b0b0b0 ";



                for (int i = 0; i < 3; i++)
                {
                    save += all_mapout[mapcount][i] + "b";
                }
                save += all_mapout[mapcount][3] + ";";


                for (int i = 0; i < all_info[mapcount][0]; i++)
                {
                    save += mob_data[mapcount][i] + " ";
                }
                for (int i = 0; i < all_info[mapcount][1]; i++)
                {
                    int dd = item_data[mapcount].Count();
                    save += item_data[mapcount][i] + " ";
                }

                for (int i = 0; i < all_info[mapcount][2]; i++)
                {
                    save += deco_data[mapcount][i * 3] + "c" + deco_data[mapcount][i * 3 + 1] + "c";
                    save += deco_data[mapcount][i * 3 + 2] + " ";
                }


                filesave.Add(save);
            }
        }
        private void write_file()
        {
            
            if (create != 0)
            {
                filesave[0] = startmap + "a" + map + "a" + startmap_x + "a" + startmap_y;
                if (System.IO.File.Exists(filename) == true)
                    System.IO.File.Delete(filename);
                System.IO.File.WriteAllLines(filename, filesave);
            }

            if(System.IO.File.Exists(".save_file.txt") == true)
            {
                File.Delete(".save_file.txt");
            }
        }                           //파일 쓰기


        private void tm_Frame(object sender, EventArgs e)
        {
            FrameUpdate();
            FrameRender();
        }
        private void tm_Item_move(object sender, EventArgs e)
        {
                ItemReset();
                Itemmove();
                ItemMarking();
        }
        private void tm_mob_move(object sender, EventArgs e)
        {
            Mob_move();
            MobReset();
            MobMarking();
        }
        private void FrameUpdate()
        {

            Color back = Color.LightBlue;

            if (mapcolor == 1)
                back = Color.Black;

            GDIBuffer.Instance().getGraphics.Clear(back);

            Drawdeco();
            Drawitem();
            DrawBlock();
            Drawmob();
            DrawMario(x, y);

            Drawgo();
        }
        private void FrameRender()
        {
            Graphics g = CreateGraphics();
            g.DrawImage(GDIBuffer.Instance().GetImages, new Point(0, 0));
            g.Dispose();
        }
        private void Drawgo()
        {
            
            if (create == 1 || create == 99)
            {
                for (int i = 0; i < 4; i++)
                {

                    if (all_mapout[currentmap][i] != -1)
                    {
                        int j = 0;
                        int p = 0, q = 0;
                        switch (i)
                        {
                            case 0:
                                j = i;
                                p = 10;
                                q = 230;
                                break;
                            case 1:
                                j = i;
                                p = 270;
                                q = 10;
                                break;
                            case 2:
                                j = i;
                                p = 550;
                                q = 230;
                                break;
                            case 3:
                                j = i;
                                p = 270;
                                q = 450;
                                break;
                        }
                        GDIBuffer.Instance().getGraphics.DrawImage(화살표[j +1], p, q, 50, 50);
                    }

                }
            }
            else if(create == 3)
            {
                for (int i = 1; i < 5; i++) 
                {
                    int j = 0;
                    int p = 0, q = 0;
                    switch (i)
                    {
                        case 1:
                            j = i;
                            p = 10;
                            q = 220;
                            break;
                        case 2:
                            j = i;
                            p = 265;
                            q = 10;
                            break;
                        case 3:
                            j = i;
                            p = 530;
                            q = 220;
                            break;
                        case 4:
                            j = i;
                            p = 265;
                            q = 440;
                            break;
                    }
                    GDIBuffer.Instance().getGraphics.DrawImage(화살표[j], p, q, 65, 65);
                }
            }
        }
        private void DrawMario(int x, int y)
        {
            if (create == 0)
            {
                if(dm.Enabled == true)
                {
                    mariostate = 0;
                }
                else if (jump == 1 && mariostate < 2)
                {
                    mariostate = 2;
                }
                else if (jump == 1 && mariostate > 3)
                {
                    mariostate = 6;
                }
                GDIBuffer.Instance().getGraphics.DrawImage(character[mariostate], x, y, 30 * Mariosize, key * Mariosize);
            }
            if(create == 1)
            {

                GDIBuffer.Instance().getGraphics.DrawImage(Block_opac[create_no], x / 30 * 30, y / 30 * 30, 30, 30);
            }
            else if(create == 2)
            {
                GDIBuffer.Instance().getGraphics.DrawImage(character[8], x, y, 30, key);
            }
            if(create != 0 && startmap == currentmap)
            {
                GDIBuffer.Instance().getGraphics.DrawImage(character[0], startmap_x, startmap_y, 30, key);

            }
        }
        private void DrawBlock()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    if (mk_box[i, j] != 0)
                    {
                        int info_first = mk_box_info[i, j] / 10;
                        int info_last = mk_box_info[i, j] % 10;

                        if (info_first < 5 || info_first == 8)
                        {
                            int test = mk_box[i, j];
                            Bitmap text = Block[test];
                            GDIBuffer.Instance().getGraphics.DrawImage(Block[mk_box[i, j]], i * 30, j * 30, 30, 30);
                            if (info_last > 7)
                            {
                                if ( info_first== 3)
                                {
                                    GDIBuffer.Instance().getGraphics.DrawImage(spike_up, i * 30, j * 30 - 8, 30, 9);
                                }
                                else if (info_first== 4)
                                {
                                    GDIBuffer.Instance().getGraphics.DrawImage(spike_down, i * 30, j * 30 + 29, 30, 9);
                                }
                                else if (info_first == 8)
                                {
                                    GDIBuffer.Instance().getGraphics.DrawImage(spike_up, i * 30, j * 30 - 8, 30, 9);
                                    GDIBuffer.Instance().getGraphics.DrawImage(spike_down, i * 30, j * 30 +29, 30, 9);
                                }
                            }
                            else if (create != 0)
                            { 
                                if(info_first == 2)
                                {

                                    GDIBuffer.Instance().getGraphics.DrawLine(new Pen(Color.Black, 3), new Point(i * 30, j * 30), new Point(i * 30+30, j * 30 + 30));
                                }
                                if (info_first == 3)
                                {
                                    if (info_last > 7)
                                        GDIBuffer.Instance().getGraphics.DrawImage(spike_up, i * 30, j * 30 - 8, 30, 9);
                                    else
                                        GDIBuffer.Instance().getGraphics.DrawImage(spike_up_opac, i * 30, j * 30 - 8, 30, 9);

                                }
                                else if (info_first == 4)
                                {
                                    if (info_last > 7)
                                        GDIBuffer.Instance().getGraphics.DrawImage(spike_down, i * 30, j * 30 - 8, 30, 9);
                                    else
                                        GDIBuffer.Instance().getGraphics.DrawImage(spike_down_opac, i * 30, j * 30 +29, 30, 9);
                                }
                                else if (info_first == 8)
                                {
                                    if (info_last > 7)
                                    {
                                        GDIBuffer.Instance().getGraphics.DrawImage(spike_up, i * 30, j * 30 - 8, 30, 9);
                                        GDIBuffer.Instance().getGraphics.DrawImage(spike_down, i * 30, j * 30 + 29, 30, 9);

                                    }
                                    else
                                    {
                                        GDIBuffer.Instance().getGraphics.DrawImage(spike_up_opac, i * 30, j * 30 - 8, 30, 9);
                                        GDIBuffer.Instance().getGraphics.DrawImage(spike_down_opac, i * 30, j * 30 + 29, 30, 9);
                                    }
                                }
                            }
                        }
                        else if(create != 0)
                        {
                            if(info_first == 7)
                            {
                                GDIBuffer.Instance().getGraphics.DrawImage(spike_up_opac, i * 30, j * 30 - 8, 30, 9);
                                GDIBuffer.Instance().getGraphics.DrawImage(Block_opac[mk_box[i, j]], i * 30, j * 30, 30, 30);
                                GDIBuffer.Instance().getGraphics.DrawLine(new Pen(Color.Yellow, 3), new Point(i * 30, j * 30 + 30), new Point(i * 30 + 30, j * 30 + 30));

                            }
                            else if(info_first == 6)
                            {
                                GDIBuffer.Instance().getGraphics.DrawImage(Block_opac[mk_box[i, j]], i * 30, j * 30, 30, 30);
                                GDIBuffer.Instance().getGraphics.DrawLine(new Pen(Color.Yellow, 3), new Point(i * 30, j * 30 + 30), new Point(i * 30 + 30, j * 30 + 30));
                            }
                            else
                                GDIBuffer.Instance().getGraphics.DrawImage(Block_opac[mk_box[i, j]], i * 30, j * 30, 30, 30);
                        }
                        if (create != 0 && mk_box[i, j] % 10 == 2)
                        {
                            GDIBuffer.Instance().getGraphics.DrawImage(Item_opac[info_last], i * 30 + (15 - (int)(item_space_x[info_last] / 2)), j * 30, item_space_x[info_last], item_space_y[info_last]);
                        }
                    }
                }
            }
        }
        private void Drawdeco()
        {
            for(int i = 0; i < all_info[currentmap][2]; i++)
            {
                int deconum = deco_data[currentmap][i * 3];

                if (deconum != 14 && deconum != 0)
                {
                    GDIBuffer.Instance().getGraphics.DrawImage(backimage[deconum], deco_data[currentmap][i * 3 + 1], deco_data[currentmap][i * 3 + 2], deco_space_x[deconum], deco_space_y[deconum]);
                    if (create != 0 && deconum == 12)
                        GDIBuffer.Instance().getGraphics.DrawImage(backimage_opac[13], deco_data[currentmap][i * 3 + 1], deco_data[currentmap][i * 3 + 2], deco_space_x[deconum], deco_space_y[deconum]);

                }
                else if (create != 0)
                    GDIBuffer.Instance().getGraphics.DrawImage(backimage_opac[deconum], deco_data[currentmap][i * 3 + 1], deco_data[currentmap][i * 3 + 2], deco_space_x[deconum], deco_space_y[deconum]);
                
            }
            if (create == 4)
            {
                
                GDIBuffer.Instance().getGraphics.DrawImage(backimage[create_no], x, y, deco_space_x[create_no], deco_space_y[create_no]);
            }

            if (mk_deco[0] != -1 )
            {
                int dd = deco_data[currentmap][mk_deco[0]];
                if (dd == 12)
                    dd = 13;
                else if (dd == 14)
                    dd = 10;
                GDIBuffer.Instance().getGraphics.DrawImage(backimage[dd], deco_data[currentmap][mk_deco[0] + 1], deco_data[currentmap][mk_deco[0] + 2], deco_space_x[dd], deco_space_y[dd]);
            }
        }
        private void Drawitem()
        {
            string[] data = new string[map_item.Count];
            map_item.CopyTo(data);
            {
                foreach (string i in data)
                {
                    string[] ii = i.Split('c');
                    int[] jj = new int[4];
                    for (int j = 0; j < 4; j++)
                    {
                        jj[j] = int.Parse(ii[j]);
                    }
                    if (jj[1] != 0)
                    {
                        GDIBuffer.Instance().getGraphics.DrawImage(Item[jj[0]], jj[2], jj[3], item_space_x[jj[0]], item_space_y[jj[0]]);
                    }
                }
                if (create == 5)
                {
                    GDIBuffer.Instance().getGraphics.DrawImage(Item_opac[create_no], x, y, item_space_x[create_no], item_space_y[create_no]);
                }
            }
        }
        private void Drawmob()
        {
            string[] mob = new string[map_mob.Count];
            map_mob.CopyTo(mob);

            foreach(string i in mob)
            {
                string[] ii = i.Split('c');
                int[] jj = new int[4];
                for(int j = 0; j < 4; j++)
                {
                    jj[j] = int.Parse(ii[j]);
                }

                if(jj[1] > 0)
                {
                    Bitmap here = null;
                    if (jj[1] == 3)
                        here = Mob_r[jj[0]];
                    else
                        here = Mob[jj[0]];
                    GDIBuffer.Instance().getGraphics.DrawImage(here, jj[2], jj[3], mob_space_x[jj[0]], mob_space_y[jj[0]]);
                }

                if(create == 6)
                {
                    GDIBuffer.Instance().getGraphics.DrawImage(Mob_opac[create_no], x, y);
                }
            }
        }                           // 그리기

        private void xy_block_reset()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    mk_box[i, j] = 0;
                }
            }
        }
        private void Blockreset()
        {
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 510; j++)
                {
                    mark_block[i, j] = 0;
                }
            }
        }
        private void BlockMarking()
        {
            Blockreset();
            for (int p = 0; p < 20; p++)
            {
                for (int q = 0; q < 17; q++)
                {
                    if (mk_box[p, q] != 0)
                    {
                        for (int i = 0; i < 29; i++)
                        {
                            for (int j = 0; j < 29; j++)
                            {
                                mark_block_info[p * 30 + i, q * 30 + j] = mk_box_info[p, q];
                                ; if ((mk_box_info[p, q] / 10) != 2)
                                {
                                    mark_block[p * 30 + i, q * 30 + j] = mk_box[p, q];
                                }

                            }
                        }
                        if (mk_box_info[p, q] / 10 == 3)
                        {
                            for (int i = 0; i < 14; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    mark_block[p * 30 + 8 + i, q * 30 - 8 + j] = 99;
                                }
                            }
                        }
                        else if (mk_box_info[p, q] / 10 == 4)
                        {
                            for (int i = 0; i < 14; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    mark_block[p * 30 + 8 + i, q * 30 + 30 + j] = 99;

                                }
                            }
                        }
                        else if (mk_box_info[p, q] / 10 == 8)
                        {
                            for (int i = 0; i < 14; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    mark_block[p * 30 + 8 + i, q * 30 - 8 + j] = 99;
                                    mark_block[p * 30 + 8 + i, q * 31 + j] = 99;
                                }
                            }
                        }



                    }
                }
            }



        }

        private void BlockMark(int i, int j)
        {
            for (int p = 0; p < 30; p++)
            {
                for (int q = 0; q < 30; q++)
                {
                    mark_block[i * 30 + p, j * 30 + q] = mk_box[i, j];
                }
            }
        }
        private void Deco_Reset()
        {
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 510; j++)
                {
                    mark_deco[i, j] = 0;
                }
            }
        }
        private void DecoMarking()
        {
            Deco_Reset();
            for (int i = 0; i < all_info[currentmap][2]; i++)
            {
                if ((deco_data[currentmap][i * 3] > 5 && deco_data[currentmap][i * 3] < 10) || deco_data[currentmap][i * 3] == 16)
                {
                    switch (deco_data[currentmap][i * 3])
                    {
                        case 6:
                            int s = 64;
                            for (int q = deco_data[currentmap][i * 3 + 2]; q < deco_data[currentmap][i * 3 + 2] + deco_space_y[1]; q++)
                            {

                                for (int p = deco_data[currentmap][i * 3 + 1] + s; p < deco_data[currentmap][i * 3 + 1] + deco_space_x[1] - 2 * s; p++)
                                {
                                    if (p < 0)
                                        p = 0;
                                    else if (p > 599)
                                        p = 599;
                                    if (q < 0)
                                        q = 0;
                                    else if (q > 509)
                                        q = 509;
                                    mark_block[p, q] = 98;
                                }

                                s--;
                            }

                            break;



                        default:
                            for (int p = deco_data[currentmap][i * 3 + 1] + 5; p < deco_data[currentmap][i * 3 + 1] + deco_space_x[deco_data[currentmap][i * 3]] - 5; p++)
                            {
                                for (int q = deco_data[currentmap][i * 3 + 2] + 5; q < deco_data[currentmap][i * 3 + 2] + deco_space_y[deco_data[currentmap][i * 3]]; q++)
                                {
                                    if (p < 0)
                                        p = 0;
                                    else if (p > 599)
                                        p = 599;
                                    if (q < 0)
                                        q = 0;
                                    else if (q > 509)
                                        q = 509;
                                    mark_block[p, q] = 98;
                                }
                            }
                            break;


                    }
                }
                else if ((deco_data[currentmap][i * 3] > 11 && deco_data[currentmap][i * 3] < 15))
                {
                    for (int p = deco_data[currentmap][i * 3 + 1] + 5; p < deco_data[currentmap][i * 3 + 1] + deco_space_x[deco_data[currentmap][i * 3]] - 5; p++)
                    {
                        for (int q = deco_data[currentmap][i * 3 + 2] + 5; q < deco_data[currentmap][i * 3 + 2] + deco_space_y[deco_data[currentmap][i * 3]] - 5; q++)
                        {
                            if (p < 0)
                                p = 0;
                            else if (p > 599)
                                p = 599;
                            if (q < 0)
                                q = 0;
                            else if (q > 509)
                                q = 509;
                            mark_deco[p, q] = mk_deco.IndexOf(i * 3);
                        }
                    }
                }

            }
        }
        private void ItemReset()
        {
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 510; j++)
                {
                    mark_item[i, j] = -1;
                }
            }
        }
        private void ItemMarking()
        {
            string[] data = new string[map_item.Count];
            map_item.CopyTo(data);
            foreach (string i in data)
            {
                string[] ii = i.Split('c');
                int[] jj = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    jj[j] = int.Parse(ii[j]);
                }
                if (jj[1] > 0 && jj[1] < 4)
                {
                    for (int p = jj[2] + 3; p < jj[2] + item_space_x[jj[0]] - 3; p++)
                    {
                        for (int q = jj[3] + 3; q < jj[3] + item_space_y[jj[0]] - 3; q++)
                        {
                            mark_item[p, q] = map_item.IndexOf(i);
                        }
                    }
                }
            }
        }
        private void MobReset()
        {
            for(int i = 0; i < 600; i++)
            {
                for(int j =0; j < 510; j++)
                {
                    mark_mob[i, j] = 0;
                }
            }

        }
        private void MobMarking()
        {
            string[] data = new string[map_mob.Count];
            map_mob.CopyTo(data);

            foreach (string i in data)
            {
                string[] ii = i.Split('c');
                int[] jj = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    jj[j] = int.Parse(ii[j]);
                }
                if (jj[1] > 0)
                {
                    for (int p = jj[2] + 3; p < jj[2] + mob_space_x[jj[0]] - 3; p++)
                    {
                        for (int q = jj[3] + 3; q < jj[3] + mob_space_y[jj[0]] - 3; q++)
                        {
                            mark_mob[p, q] = map_mob.IndexOf(i);
                        }
                    }
                }
            }
        }                           //좌표 계산

        private void Itemmove()
        {
            List<string> thisitem = new List<string>();
            int pp = -1;
            string[] data = new string[map_item.Count];
            map_item.CopyTo(data);

            foreach (string i in data)
            {
                pp++;
                string[] ii = i.Split('c');
                int[] jj = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    jj[j] = int.Parse(ii[j]);
                }
                if (jj[3] + item_space_y[jj[0]] > 505)
                    jj[1] = 0;
                else if (jj[2] < 3)
                    jj[1] = 0;
                else if (jj[2] + item_space_x[jj[0]] > 596)
                    jj[1] = 0;
                if (jj[1]> 0 && jj[1] <4 && jj[0]!=0)
                {
                    if (jj[1] == 2)
                    {
                        if (mark_block[jj[2] - 2, jj[3]] != 0)
                        {
                            while (mark_block[jj[2] - 1, jj[3]] == 0)
                                jj[2]--;

                            jj[1] = 3;
                        }
                        else
                            jj[2] -= 2;
                    }
                    else if (jj[1] == 3)
                    {
                        if (mark_block[jj[2] + item_space_x[jj[0]] + 2, jj[3]] != 0)
                        {
                            while (mark_block[jj[2] + item_space_x[jj[0]] + 1, jj[3]] == 0)
                                jj[2]++;
                            jj[1] = 2;
                        }
                        else
                            jj[2] += 2;
                    }
                    if (mark_block[jj[2] + 10, jj[3] + item_space_y[jj[0]] + 1] == 0 && mark_block[jj[2] + 20, jj[3] + item_space_y[jj[0]] + 1] == 0)
                    {
                        if (mark_block[jj[2] + item_space_x[jj[0]] / 2, jj[3] + item_space_y[jj[0]] + 4] != 0)
                        {
                            while (mark_block[jj[2] + item_space_x[jj[0]] + 1, jj[3] + item_space_y[jj[0]] + 1] == 0)
                            {
                                jj[3]++;
                            }
                        }
                        else
                            jj[3] += 4;
                    }


                }
                else if(jj[1] ==4)
                {
                    jj[1] = 9;
                    Thread cointh = new Thread(delegate ()
                    {
                        thread_blockincoin(pp);
                    });
                    cointh.Start();
                }
                else if(jj[1] == 5)
                {
                    jj[1] = 9;
                    Thread itemth = new Thread(delegate ()
                    {
                        thread_blockinitem(pp);
                    });
                    itemth.Start();
                }
                string it = jj[0] + "c" + jj[1] + "c" + jj[2] + "c" + jj[3];

                thisitem.Add(it);
                
            }
            map_item = thisitem;
        }
        private void thread_blockincoin(int index)
        {
            string[] tem = map_item[index].Split('c');
            int[] tes = new int[4];
            for(int i = 0; i < 4; i++)
            {
                tes[i] = int.Parse(tem[i]);
            }
            for(int i = 0; i < 80; i ++)
            {
                tes[3]--;
                map_item[index] = tem[0] + "c" + tem[1] + "c" + tem[2] + "c" + tes[3];
                Thread.Sleep(10);
            }
            map_item[index] = tem[0] + "c0c" + tem[2] + "c" + tes[3];
        }
        private void thread_blockinitem(int index)
        {
            string[] tem = map_item[index].Split('c');
            int[] tes = new int[4];
            for (int i = 0; i < 4; i++)
            {
                tes[i] = int.Parse(tem[i]);
            }
            for(int i = 0; i < 30; i++)
            {
                tes[3]--;

                map_item[index] = tem[0] + "c" + tem[1] + "c" + tem[2] + "c" + tes[3];
                Thread.Sleep(15);
            }
            int stat = 3;
            if (tes[0] == 1)
                stat = 1;
            map_item[index] = tem[0] + "c" + stat + "c" + tem[2] +"c"+ tes[3];
        }
        private void Mob_move()
        {
            List<string> thismob = new List<string>();

            string[] mob = new string[map_mob.Count];
            map_mob.CopyTo(mob);

            foreach(string i in mob)
            {
                string[] ii = i.Split('c');
                int[] jj = new int[4];
                for(int j = 0; j < 4; j++)
                {
                    jj[j] = int.Parse(ii[j]);
                }

                if (jj[3] + mob_space_y[jj[0]] > 505)
                    jj[1] = 0;
                else if (jj[2] < 7)
                    jj[1] = 0;
                else if (jj[2] + mob_space_x[jj[0]] > 592)
                    jj[1] = 0;

                if (jj[1] > 0 )
                {

                    if (jj[1] == 2)
                    {
                        int movep = 2;
                        if (jj[0] == 4)
                            movep = 7;
                        if (mark_block[jj[2] - movep, jj[3] + mob_space_y[jj[0]] - 10] != 0 && mark_block[jj[2] - movep, jj[3] + mob_space_y[jj[0]] - 10] != 99)
                        {
                            while (mark_block[jj[2] - 1, jj[3] + mob_space_y[jj[0]] - 10] == 0)
                                jj[2]--;

                            jj[1] = 3;
                        }
                        else
                            jj[2] -= movep;
                    }
                    else if (jj[1] == 3)
                    {
                        int movep = 2;
                        if (jj[0] == 4)
                            movep = 7;
                        if (mark_block[jj[2] + mob_space_x[jj[0]] + movep, jj[3] + mob_space_y[jj[0]] - 10] != 0 && mark_block[jj[2] + mob_space_x[jj[0]] + movep, jj[3] + mob_space_y[jj[0]] - 10] != 99)
                        {
                            while (mark_block[jj[2] + mob_space_x[jj[0]] + 1, jj[3] + mob_space_y[jj[0]] - 10] == 0)
                                jj[2]++;
                            jj[1] = 2;
                        }
                        else
                            jj[2] += movep;
                    }
                    if (mark_block[jj[2] + 10, jj[3] + mob_space_y[jj[0]] + 1] == 0 && mark_block[jj[2] + 20, jj[3] + mob_space_y[jj[0]] + 1] == 0 )
                    {
                        if (jj[0] != 6)
                        {
                            if (mark_block[jj[2] + mob_space_x[jj[0]] / 2, jj[3] + mob_space_y[jj[0]] + 4] != 0)
                            {
                                while (mark_block[jj[2] + mob_space_x[jj[0]] + 1, jj[3] + mob_space_y[jj[0]] + 1] == 0)
                                {
                                    jj[3]++;
                                }
                            }
                            else
                                jj[3] += 4;
                        }
                    }


                }
                string it = jj[0] + "c" + jj[1] + "c" + jj[2] + "c" + jj[3];
                thismob.Add(it);
            }

            map_mob = thismob;
        }
        private void thread_mob(int index)
        {

        }                       //움직이는 오브젝트

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (create == 1)
            {
                Point p = PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                int i = (int)((p.X ) / 30);
                int j = (int)((p.Y ) / 30);
                   

                if (i < 0)
                    i = 0;
                if (j < 0)
                    j = 0;

                if (e.Button == MouseButtons.Left)
                {
                    mk_box[i,j] = create_no;
                    box_info_change(i,j);
                    if (mk_box[i, j] % 10 == 2)
                    {
                        box_info_qbox(i, j);
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    mk_box[i, j] = 0;
                    mk_box_info[i, j] = 10;
                }

                
            }
            else if (create == 2)
            {
                Point p = PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                startmap_x = p.X - 30 * Mariosize / 2;
                if (startmap_x < 0)
                    startmap_x = 0;
                startmap_y = p.Y - (int)(key * Mariosize / 2);
                if (startmap_y < 0)
                    startmap_y = 0;
                create = 99;
                menu.bt_startset.Text = "시작 맵으로\r\n설정 및\r\n시작 좌표 설정";
                menu.bt_move.Enabled = true;


            }
            else if (create == 3)
            {
                Point p = PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                if (p.X < 75)
                {
                    if (p.Y > 220 && p.Y < 285)
                        mapcreate(0);
                }
                else if (p.X > 530)
                {
                    if (p.Y > 220 && p.Y < 285)
                    {
                        mapcreate(2);
                    }
                }
                else if (p.Y < 75)
                {
                    if (p.X > 265 && p.X < 330)
                        mapcreate(1);

                }
                else if (p.Y > 440)
                {
                    if (p.X > 265 && p.X < 330)
                        mapcreate(3);

                }
                

            }
            else if(create == 4)
            {
                all_info[currentmap][2]++;
                int num = create_no;
                if (num < 6 && backimageset.cb_dead.Checked == true)
                    num += 5;
                deco_data[currentmap].Add(num);
                deco_data[currentmap].Add(x);
                deco_data[currentmap].Add(y);
            }
            else if(create == 5)
            {
                all_info[currentmap][1]++;
                int state = 1;
                if(create_no>0 && create_no < 6)
                {
                    state = 3;
                }

                map_item.Add(create_no + "c" + state + "c" + x + "c" + y);
            }
            else if(create == 6)
            {
                all_info[currentmap][0]++;
                int state = 2;
                map_mob.Add(create_no + "c" + state + "c" + x + "c" + y);
            }
        }
        private void box_info_change(int i, int j)
        {
            int info_no = 10;
            if(blockset.cb_true.Checked == true)
            {
                if (blockset.cb_fake.Checked == true)
                {
                    info_no = 20;
                }
                else if (blockset.cb_up_spike.Checked == true && blockset.cb_down_spike.Checked == true)
                {
                    info_no = 88;
                    if (blockset.cb_spike_false.Checked == true)
                    {
                        info_no -= 8;

                    }
                }
                else if (blockset.cb_up_spike.Checked == true)
                {
                    info_no = 38;
                    if (blockset.cb_spike_false.Checked == true)
                    {
                        info_no -= 8;

                    }
                }
                else if (blockset.cb_down_spike.Checked == true)
                {
                    info_no = 48;
                    if (blockset.cb_spike_false.Checked == true)
                    {
                        info_no -= 8;

                    }
                }
                else
                    info_no = 10;
            }
            else
            {

                if (blockset.cb_trap.Checked == true && blockset.cb_up_spike.Checked == true)
                {
                    info_no = 78;
                    if (blockset.cb_spike_false.Checked == true)
                    {
                        info_no -= 8;

                    }
                }
                else if (blockset.cb_trap.Checked == true)
                {
                    info_no = 60;
                }
                else
                    info_no = 50;
            }


                mk_box_info[i, j] = info_no;
        }
        private void box_info_qbox(int i, int j)
        {
            mk_box_info[i, j] += qbox_no;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(create == 1)
            {
                Point p = PointToClient(new Point(Control.MousePosition.X,Control.MousePosition.Y));
                x = p.X;
                y = p.Y;

            }
            else if (create == 2)
            {
                x = e.X - 15;
                y = e.Y - (int)(key/2);
            }
            else if(create == 4)
            {
                int xx = e.X - deco_space_x[create_no] / 2;
                int yy = e.Y + deco_space_y[create_no] / 2;

                if(create_no < 10)
                {
                    x = xx;
                    y = yy / 30 * 30 - deco_space_y[create_no];
                }
                else if(create_no != 16)
                {
                    x = xx;
                    y = yy - deco_space_y[create_no] ;
                }
                else
                {
                    x = xx / 30 * 30;
                    y = yy / 30 * 30 - deco_space_y[16];
                }
            }
            else if(create == 5)
            {
                int yy = e.Y + 30;

                x = e.X - item_space_x[create_no] / 2;
                y = yy /30 * 30 - item_space_y[create_no]; 
            }
            else if(create == 6)
            {
                int yy = e.Y + 30;

                x = e.X - mob_space_x[create_no] / 2;
                y = yy / 30 * 30 - mob_space_y[create_no];
            }
        }
        private void mapcreate(int mapmove)
        {
            if (all_mapout[currentmap][mapmove] == -1)
            {
                all_mapout[currentmap][mapmove] = map;
                lastmap = currentmap;

                switch (mapmove)
                {
                    case 0:
                        ahffk = 2;
                        break;
                    case 1:
                        ahffk = 3;
                        break;
                    case 2:
                        ahffk = 0;
                        break;
                    case 3:
                        ahffk = 1;
                        break;
                }

                save_map();
                WriteMap();
                map++;
                currentmap = map - 1;
                mapcreate_start();


            }
            else
            {
                save_map();
                WriteMap();
                currentmap = all_mapout[currentmap][mapmove];
            }

            LoadMap();
        }                               // 맵 만드는 곳

        private void click()
        {
            subform.FormClosing -= subform_close;
            subform.Hide();

        }
        private void subformclose()
        {
            maplist = subform.maplist;
            string nm = subform.mapname.Text;
            filename = @"map_list\" + nm + ".txt";
            File.WriteAllLines(@"map_list\maplist.txt", maplist);
            File.AppendAllText(@"map_list\maplist.txt", nm + "\r\n");

        }
        private void mapout()            //여기 수정
        {
            ItemReset();
            MobReset();

            if (x < 10)
            {
                currentmap = all_mapout[currentmap][0];
                LoadMap();
                x = 560 ;
            }
            else if(x  > 560)
            {
                currentmap = all_mapout[currentmap][2];
                LoadMap();
                x = 10;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:

                    tm_right.Stop();
                    tm_left.Start();
                    break;
                case Keys.Right:

                    tm_left.Stop();
                    tm_right.Start();
                    break;
                case Keys.Up:
                    if (jump < jumpcan && mariostate !=3)
                    {
                        y--;
                        jump++;
                        jumpsound.Play();
                        tm_jump.Start();
                    }
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:

                    tm_left.Stop();
                    break;
                case Keys.Right:
                    tm_right.Stop();
                    break;
            }
        }       //키보드 입력
        private void tm_gravity(object sender, EventArgs e)
        {
            int p = 0; //걸리는 위치
            int g = 0; //확인

            a += aa;   //중력가속도
            int b;

            if (y + 30 < 0)
            {
                if (all_mapout[currentmap][1] != -1)
                {
                    
                    currentmap = all_mapout[currentmap][1];
                    LoadMap();
                    y = 503;
                }
            }
            else if (y + key * Mariosize + a > 509) 
            {                                            //떨어져 죽을때 여기(일단 이렇게)
                if(all_mapout[currentmap][3] == -1)
                {
                    MarioDead();
                }
                else
                {
                    currentmap = all_mapout[currentmap][3];
                    LoadMap();
                    y = -25;
                }
            }

            if (tm_jump.Enabled ==true && a < jumpsize)
            {
                b = jumpsize; //점프후 땅닿기 직전 순간이동 방지
            }
            else
                b = 0;

            if (a > aa*3 )
                jump = 1; //떨어지는중 점프방지

            int tem_no = -1;

            for (int i = x_left + 2; i < x_right *Mariosize - x_left - 4; i += 3)
            {
                int pp = y + key * Mariosize + (int)a - b;

                if (pp < 0)
                    pp = 0;
                else if (pp > 509)
                    pp = 509;

                int ppp = x + i;
                if (ppp < 0)
                    ppp = 0;
                else if (ppp > 599)
                    ppp = 599;

                if (mark_block[ppp, pp] != 0 && mark_block_info[ppp,pp]/10 !=6 && mark_block_info[ppp,pp] / 10 != 7)
                {
                    p = ppp;
                    g = mark_block[ppp, pp] ;
                    break;
                }

                if (mark_deco[ppp, pp] != 0)
                {

                        mk_deco[0] = mk_deco[mark_deco[ppp, pp]];
                        MarioDead();
                    
                    break;
                }

                if(mark_item[ppp,pp] != -1)
                    tem_no = mark_item[ppp, pp];

                if(mark_mob[ppp,pp] != 0)
                {
                    jump_mob(mark_mob[ppp, pp]);
                }

            }
            if (y +(int)a < -(key * Mariosize - 28) && y + (int)a > -(int)(key * Mariosize ) +14)
                g = -1;

            if (y +(int)a < -(int)(key * Mariosize - 15))         //화면에 안보이게 높을때
                g = 0;
            //else if (y < -(int)(key * Mariosize - 15))
              //  g = 0;

            switch (g)
            {
                case -1:        // 화면 맨위 한칸
                        this.y += (int)a;

                    break;
                case 0:
                    y += (int)a;
                    break;

                case 92:
                    while (mark_block[p, y + key * Mariosize] == 0)
                        y++;
                    
                    MarioDead();
                    break;

                case 98:
                    while (mark_block[p, y + key * Mariosize] == 0)
                        y++;
                    MarioDead();
                    break;

                case 99:                                          //가시찔릴때
                    while (mark_block[p, y +  key * Mariosize] == 0) 
                        y++;
                    mk_box_info[p / 30, ((y + key*Mariosize)) / 30 + 1] = (mk_box_info[p / 30, (y +key*Mariosize + (int)a + 10) / 30] / 10) * 10 + 8;
                    DrawBlock();
                    FrameRender();
                    MarioDead();
                    break;
                default:
                    if(mark_block[p, y + (key * Mariosize - 28)] == 0)
                    {
                        a = 0.0;
                        if (jump == 1 && mariostate == 2)
                            mariostate = 1;
                        else if (jump == 1 && mariostate == 6)
                            mariostate = 5;

                        jump = 0;
                        tm_jump.Stop();
                        while (mark_block[p, y + key * Mariosize] == 0)
                            y++;
                        this.y = --y;
                    }
                    break;
            }

            item_get(tem_no);
        }


        private void tm_move_Tick(object sender, EventArgs e)
        {
            int g = 0; //확인
            int p = 0; // 걸리는 위치


            if (tm_left.Enabled == false && tm_right.Enabled == false)
            {
                if (movepoint < 0)
                    movepoint += move_a;
                else if (movepoint > 0)
                    movepoint -= move_a;
            } //미끄러지는 효과
            if (x + x_right*Mariosize > 595 && movepoint>0)
            {
                tm_jump.Stop();
                if (currentmap != map - 1)
                {
                    mapout();
                }
                else
                {
                    win();
                }
            } 
            else if(x +x_left < 5 && movepoint<0)
            {
                tm_jump.Stop();
                if (currentmap != 0)
                {
                    mapout();
                }
                else MarioDead();

            }// 맵 벗어낫는지


            if (tm_right.Enabled == true)
            {
                if (movepoint < v)
                movepoint += move_a;
            }   //가속도
            else if(tm_left.Enabled == true)
            {
                if (movepoint > -v)
                    movepoint -= move_a;
            }      //가속도


            int ggg = x + x_right + (int)movepoint;  //오른쪽

            int xx = x + x_left + (int)movepoint;       //왼쪽

            if (ggg < 0)
            {
                ggg = 0;
            }
            else if (ggg > 599)
            {
                ggg = 599;
            }

            int q = 0;              //어느쪽에서 부딪혓는지

            int mark_tem = -1;

            for (int i = 3; i < key * Mariosize - 3; i += 4)
            {
                int pp = y + i;
                if (pp < 0)
                {
                    pp = 0;
                }
                else if( pp > 505)
                {
                    pp = 505;
                }

                if (mark_block[ggg, pp] != 0 && mark_block_info[ggg, pp]/10!= 6 && mark_block_info[ggg, pp]/10 != 7)
                {
                    g = mark_block[ggg, pp];
                    p = i;
                    q = 1;
                    break;
                }
                else if (mark_block[xx, pp] != 0 && mark_block_info[xx, pp]/10 != 6 && mark_block_info[xx, pp]/10 !=7)
                {
                    g = mark_block[xx, pp];
                    p = i;
                    q = -1;
                    break;
                }
                else
                    g = 0;

                if(mark_item[xx,pp] != -1)
                {
                    mark_tem = mark_item[xx, pp];
                    break;
                }
                else if (mark_item[ggg, pp] != -1)
                {
                    mark_tem = mark_item[ggg, pp];
                    break;
                }


                if (mark_deco[xx,pp] != 0)
                {
                    mk_deco[0] = mk_deco[mark_deco[xx, pp]];
                   // while (mark_deco[x - 1, pp] == 0)
                     //   x--;
                    MarioDead();
                    break;
                }
                else if(mark_deco[ggg,pp] != 0)
                {
                    mk_deco[0] = mk_deco[mark_deco[ggg, pp]];
                    //while (mark_deco[x + 1, pp] == 0)
                      //  x++;
                    MarioDead();
                    break;
                }



            } // 블럭잇는지 판별

            for (int i = 3; i < key * Mariosize - 18; i += 4)
            {
                int pp = y + i;
                if (pp < 0)
                {
                    pp = 0;
                }
                else if( pp > 509)
                {
                    pp = 509;
                }
                
                if (mark_mob[xx, pp] != 0)
                {
                    move_mob(mark_mob[xx, pp]);
                    break;
                }
                else if (mark_mob[ggg, pp] != 0)
                {
                    move_mob(mark_mob[ggg, pp]);
                    break;
                }
            }   //몹 관련

                int gg = y + p;
            if (gg < 0)
                gg = 0;
            
            switch (g)
            {
                case 0:
                    
                    break;
                case 98:
                    if (q > 0)
                    {
                        if (mark_block[x + x_right + (int)movepoint, y + key * Mariosize - p] != 0)
                            while (mark_block[x + x_right + 1, gg] == 0)
                                x++;

                    }
                    else if (q < 0)
                    {
                        if (mark_block[x + x_left + (int)movepoint, y + key * Mariosize - p] != 0)
                            while (mark_block[x + x_left - 1, gg] == 0)
                                x--;

                    }
                    MarioDead();

                    break;
                case 99:
                    if (q > 0)
                    {
                        if (mark_block[x + x_right + (int)movepoint, y + key * Mariosize - p] != 0)
                             while (mark_block[x + x_right + 1, gg] == 0)
                                x++;

                        mk_box_info[(x + x_right + (int)movepoint + 3) / 30, (y + key * Mariosize + 10) / 30] = mk_box_info[(x + x_right + (int)movepoint + 3)/30, (y + key * Mariosize + 10)/30] / 10 * 10 + 8;
                    }
                    else if (q < 0)
                    {
                        if (mark_block[x + x_left + (int)movepoint, y + key * Mariosize - p] != 0)
                            while (mark_block[x + x_left - 1, gg] == 0)
                                x--;
                        mk_box_info[(x + x_left + (int)movepoint + 3) / 30, (y + key * Mariosize + 10) / 30] = mk_box_info[(x + x_left + (int)movepoint + 3) / 30,( y + key * Mariosize + 10)/ 30] / 10 * 10 + 8;

                    }
                    MarioDead();

                    break;
                default:
                    if (q > 0)
                    {
                        while (mark_block[x + x_right +1 , gg] == 0)
                            x++;
                    }
                    else if (q < 0)
                    {
                        while (mark_block[x + x_left - 1, gg] == 0)
                            x--;
                    }

                    movepoint = 0;
                    break;
                    
            }  //블럭따라 반응
            if (mark_tem != -1)
            {
                item_get(mark_tem);
            }

            if (movepoint > 0)                              //여서부터
            {
                moving += (int)movepoint;
            }
            else if (movepoint < 0)
            {
                moving -= (int)movepoint;
            }

            if (movepoint < 0 && tm_left.Enabled==true)
                mariostate = 4;
            else if (movepoint > 0 && tm_right.Enabled==true)
                mariostate = 0;

            if(moving > 8)
            {
                if (mariostate == 0 || mariostate == 4)
                    mariostate++;
                else if (mariostate == 1 || mariostate == 5)
                    mariostate--;
                moving = 0;
            }                                               //여까지 걷는 모션

            x += (int)movepoint;
            
        }       
        private void tm_jump_Tick(object sender, EventArgs e)
        {
            int h = y;
            int b_no = 0;
            int b_info = 1;
            int p = 0;
            if (y < jumpsize)
                h = jumpsize;
            else if (y > 460)
                h = 460;
            else
                h = y;

            if (a > jumpsize)
            {
                a -= jumpsize;
                tm_jump.Stop();
            }

            int tem_no = -1;

            for (int i = x_left ; i < (x_right - x_left) * Mariosize ; i += 3)
            {
                if (mark_block[x + i, h - jumpsize] != 0)
                {
                    b_no = mark_block[x + i, h - jumpsize ] ;
                    b_info = mark_block_info[x + i, h - jumpsize ] / 10;
                    p = i;
                    break;
                }
                else
                    b_no = 0;

                if (mark_deco[x+i, h-jumpsize] != 0)
                {
                   mk_deco[0] = mk_deco[mark_deco[x+i, h - jumpsize]];
                    MarioDead();
                    break;
                }

                if(mark_mob[x+i , h-jumpsize] != 0)
                {
                    MarioDead();
                    break;
                }

                tem_no = mark_item[x + i, h - jumpsize];

            }

            item_get(tem_no);

            switch (b_no)
            {
                case 0:
                    y -= jumpsize;
                    break;

                case 11:
                    jumpstop(p);
                    brokeblock((x + p) / 30, (y - jumpsize - 8) / 30);
                    break;
                case 21:
                    jumpstop(p);
                    brokeblock((x + p) / 30, (y - jumpsize - 8) / 30);
                    break;

                case 31:
                    jumpstop(p);
                    brokeblock((x + p) / 30, (y - jumpsize - 8) / 30);
                    break;

                case 12:
                    qbox((x + p) / 30, (y - jumpsize - 8) / 30);
                    jumpstop(p);

                    break;
                case 22:
                    qbox((x + p) / 30, (y - jumpsize - 8) / 30);
                    jumpstop(p);

                    break;
                case 32:
                    qbox((x + p) / 30, (y - jumpsize - 8) / 30);
                    jumpstop(p);

                    break;
                    

                case 99:                //가시 찔릴때
                    mk_box_info[(x + p) / 30, (y - jumpsize - 8) / 30] = mk_box_info[(x + p) / 30, (y - jumpsize - 8) / 30] / 10 * 10 + 8;
                    while (mark_block[x + p, y + 1] == 0)
                    {
                        y--;
                    }

                    MarioDead();
                    break;
                default:            //부딪힐때
                    jumpstop(p);

                    break;
            }
            switch (b_info)
            {
                case 1:
                    break;
                case 6:
                    mk_box_info[(x + p) / 30, (h - jumpsize) / 30] = mark_block[x + p, h - jumpsize] % 10 + 10;
                    BlockMarking();
                    break;

                case 7:
                    mk_box_info[(x + p) / 30, (h - jumpsize) / 30] = mark_block[x + p, h - jumpsize] % 10 + 30;
                    BlockMarking();
                    break;
                default:
                    break;
            }


        }       //모든 이동 관련
        private void jumpstop(int p)
        {
            while (mark_block[x + p, y - 1] == 0)
                y--;
            a = 0.9;
            tm_jump.Stop();

        }
        private void qbox(int i, int j)
        {
            if (mk_box_info[i, j] % 10 == 0)
            {
                blockcoin.Play();
            }
            else
                blockin.Play();
            mk_box[i, j] = mk_box[i, j] / 10 * 10 + 3;
            BlockMark(i, j);

            qbox_item(mk_box_info[i, j] % 10 , i ,j);
        }
        private void brokeblock(int i, int j)
        {
            blockbreak.Play();
            mk_box[i, j] = 0;
            BlockMarking();
        }                       //점프관련

        private void move_mob(int index)
        {
            int[] jj = new int[4];
            string ad = string.Copy(map_mob[index]);
            string[] ii = ad.Split('c');
            for (int i = 0; i < 4; i++)
            {
                jj[i] = int.Parse(ii[i]);
            }

            if (jj[0] == 4)
            {
                if (movepoint > 0)
                {
                    jj[1] = 3;
                }
                else
                {
                    jj[1] = 2;
                }
                map_mob[index] = jj[0] + "c" + jj[1] + "c" + jj[2] + "c" + jj[3];
            }
            else
                MarioDead();
        }
        private void jump_mob(int index)
        {
            string[] data = map_mob[index].Split('c');
            int[] newdata = new int[4];

            for(int i = 0; i < 4; i++)
            {
                newdata[i] = int.Parse(data[i]);

            }

            if(newdata[0] == 1)
            {
                humi.Play();
                a = 0;
                tm_jump.Start();
                map_mob[index] = newdata[0] + "c0c" + newdata[2] + "c" + newdata[3];

            }
            else if(newdata[0] == 3)
            {
                humi.Play();
                a = 0;
                tm_jump.Start();
                map_mob[index] = "4c1c" + newdata[2] + "c" + newdata[3];

            }
            else if(newdata[0] == 4)
            {
                humi.Play();
                a = 0;
                tm_jump.Start();
                map_mob[index] = "4c3c" + newdata[2] + "c" + newdata[3];
            }
            else if(newdata[0] == 6)
            {
                humi.Play();
                humi.Play();
                a = 0;
                tm_jump.Start();
                map_mob[index] = newdata[0] + "c0c" + newdata[2] + "c" + newdata[3];
            }
            else
            {
                MarioDead();
            }
        }

        private void item_get(int t)
        {
            if (t != -1)
            {
                string[] tem = map_item[t].Split('c');

                int[] jj = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    jj[j] = int.Parse(tem[j]);
                }

                switch (jj[0])
                {

                    case -1:
                        break;
                    case 0:
                        coin.Play();
                        break;

                    case 10:
                        savemap = currentmap;
                        save_x = jj[2];
                        save_y = jj[3];
                        break;
                    default:
                        MarioDead();
                        break;
                }
                jj[1] = 0;

                map_item[t] = jj[0] + "c" + jj[1] + "c" + jj[2] + "c" + jj[3];
            }
        }

        private void qbox_item(int no, int i, int j)
        {
            if(no == 0)
            {
                blockcoin.Play();
                map_item.Add("0c4c" + (i * 30 + (15 - item_space_x[0]/2)) + "c" + j * 30);
            }
            else
            {
                blockin.Play();
                map_item.Add(no+ "c5c" + (i * 30 + (15 - item_space_x[no]/2)) + "c" + j * 30);               
            }
        }
        private void create_qbox_item()
        {
            itemset.i_6.Enabled = false;
            itemset.i_7.Enabled = false;
            itemset.i_8.Enabled = false;
            itemset.i_9.Enabled = false;
            itemset.i_10.Enabled = false;

            itemset.Show();
            itemset.DesktopLocation = new Point(this.DesktopLocation.X + 600, this.DesktopLocation.Y + 180);
        }


        private void win()
        {
            map_bgm_waveout[bgmno].Stop();

            int c = int.Parse( countdead.Text);
            lb_win.Text = "남은 목숨 : " + c + "개\r\n클리어!";

            tm.Enabled = false;
            tm_move.Stop();
            lb_win.Enabled = true;
            lb_win.Visible = true;

            tm_win.Enabled = true;
            currentmapinfor.Visible = false;
            currentmapinfor.Enabled = false;
            GDIBuffer.Instance().getGraphics.Clear(Color.Black);
            DrawMario(300, 50);
            FrameRender();

            allclear.Play();
        }
        private void tm_win_Tick(object sender, EventArgs e)
        {
            this.Close();
        }       //승리 이벤트


        private void p_00_Click(object sender, EventArgs e)
        {
            if(create == 1)
            qbox_no = 0;
            else
            create_no = 0;
        }
        private void p_01_Click(object sender, EventArgs e)
        {
            if(create == 1)
            qbox_no = 1;
            else
            create_no = 1;
        }
        private void p_02_Click(object sender, EventArgs e)
        {
            if(create == 1)
            qbox_no = 2;
            else
            create_no = 2;
        }


        private void p_03_Click(object sender, EventArgs e)
        {
            if(create==1)
            qbox_no = 3;
            else
            create_no = 3;
        }
        private void p_04_Click(object sender, EventArgs e)
        {
            if(create == 1)
            qbox_no = 4;
            else
            create_no = 4;
        }
        private void p_05_Click(object sender, EventArgs e)
        {
            if(create == 1)
            qbox_no = 5;
            else
            create_no = 5;
        }
        private void p_06_Click(object sender, EventArgs e)
        {
            if(create == 1)
            qbox_no = 6;
            else
            create_no = 6;
        }
        private void p_07_Click(object sender, EventArgs e)
        {
            qbox_no = 7;
            create_no = 7;
        }
        private void p_08_Click(object sender, EventArgs e)
        {
            create_no = 8;
        }
        private void p_09_Click(object sender, EventArgs e)
        {
            create_no = 9;
        }
        private void p_10_Click(object sender, EventArgs e)
        {
            create_no = 10;
        }

        private void b_11_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 11;
        }
        private void b_12_Click(object sender, EventArgs e)
        {
            create_no = 12;
            create_qbox_item();
        }
        private void p_12_Click(object sender, EventArgs e)
        {
            create_no = 12;
        }

        private void b_13_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 13;
        }
        private void b_14_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 14;
        }
        private void b_15_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 15;
        }
        private void b_16_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 16;
        }
        private void b_17_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 17;
        }
        private void b_21_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 21;
        }
        private void b_22_Click(object sender, EventArgs e)
        {
            create_no = 22;
            create_qbox_item();
        }

        private void b_23_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 23;
        }
        private void b_24_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 24;
        }
        private void b_25_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 25;
        }
        private void b_26_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 26;
        }
        private void b_27_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 27;
        }
        private void b_31_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 31;
        }
        private void b_32_Click(object sender, EventArgs e)
        {
            create_no = 32;
            create_qbox_item();
        }

        private void b_33_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 33;
        }
        private void b_34_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 34;
        }
        private void b_35_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 35;
        }
        private void b_36_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 36;
        }
        private void b_37_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 37;
        }
        private void b_38_Click(object sender, EventArgs e)
        {
            itemset.Hide();
            create_no = 38;
        }

    }
}
