using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte_Carlo
{
    public struct Node
    {
        public Node(double x_node, double y_node, double z_node, NodeType type)
        {
            this.x_node = x_node;
            this.y_node = y_node;
            this.z_node = z_node;
            this.type = type;
        }
        public double x_node { get; set; }
        public double y_node { get; set; }
        public double z_node { get; set; }
        public NodeType type { get; set; }
    }

    public partial class Form1 : Form
    {
        private delegate void Edge();
        private Edge _isEdge;
        private int _valAutoStop = 0;
        private Bitmap _bmp, _bmp2;
        private Graphics _draw;

        private Brush atoms = new SolidBrush(Color.Red);
        private Pen line_pen = new Pen(Brushes.LightGray);
        private Pen window_pen = new Pen(Brushes.Black);

        private int Max_MKSH;
        private int time_del_1, time_del_2, chart_counter;
        private int _node_count_y, _node_count_x;
        private double _width_translate_step;
        private double _height_translate_step;

        private double[,] count_nodes;

        double windowNodes;
        int MonteCarloStep;

        double angleZ, angleY, mult;

        Drawer3D drw;

        private Node[,] _nodes;
        private double[,] _nodes3D;

        public Form1()
        {
            InitializeComponent();

            NodeCountY.SelectedIndex = 0;
            NodeCountX.SelectedIndex = 0;
            _bmp = new Bitmap(PIC.Width, PIC.Height);
            _draw = Graphics.FromImage(_bmp);
            _draw.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            _node_count_x = Convert.ToInt32(NodeCountX.Text);
            _node_count_y = Convert.ToInt32(NodeCountY.Text);
            _width_translate_step = PIC.Width / (_node_count_x + 1);
            _height_translate_step = PIC.Height / (_node_count_y + 1);

            MonteCarloStep = 0;
            _isEdge += StopTimer;
           // _bmp2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);

           // pictureBox1.Image = _bmp2;
            Init();
        }
        private void AddNewAtoms(Node[,] nodes) 
        {
            
            if(!WindowCheck.Checked)
            {
                for (int i = 0; i < _node_count_x; i++)
                {
                    for (int k = 0; k < _node_count_y; k++)
                    {
                        if (i == 0)
                        {
                            nodes[i, k].type = NodeType.Full;
                        }
                        else
                        {
                            nodes[i, k].type = NodeType.Empty;
                        }
                    }
                }
            }
            else
            {
                for(int i = 0; i<_node_count_x; i++)
                {
                    for(int k = 0; k < _node_count_y; k++)
                    {
                        if (i == 0 )
                        {
                            if(windowNodes <= k && k < 2 * windowNodes)
                            {
                                nodes[i, k].type = NodeType.Full;
                            }
                            else
                            {
                                nodes[i, k].type = NodeType.Window;
                            }
                        }
                        else
                        {
                            nodes[i, k].type = NodeType.Empty;
                        }
                    }
                }
            }
        }
        public void Init()
        {
            _draw.Clear(Color.White);
            _draw.ResetTransform(); 
            _nodes = new Node[_node_count_x, _node_count_y];

            AddNewAtoms(_nodes);
            CreateGrid();
            RePaintBitmap(_nodes);
           
        }
        public void CreateGrid() 
        {
            _draw.TranslateTransform((float)_width_translate_step / 2, ((float)_height_translate_step / 2));
            _draw.ScaleTransform((float)(PIC.Width / ((_node_count_x + 1) * _width_translate_step)), (float)(PIC.Height / ((_node_count_y + 1) * _height_translate_step)));

            double windowNodes = (_node_count_y) / 3;

            for (int y = 0; y < _node_count_y; y++)
            {
                _draw.DrawLine(line_pen, 0, (float)(y * _height_translate_step), (float)((_node_count_x - 1) * _width_translate_step), (float)(y * _height_translate_step));
            }

            for (int x = 0; x < _node_count_x; x++)
            {
                _draw.DrawLine(line_pen, (float)(x * _width_translate_step), 0, (float)(x * _width_translate_step), (float)((_node_count_y - 1) * _height_translate_step));
            }

            if(WindowCheck.Checked)
            {
                _draw.DrawLine(window_pen, 0, 0, 0, (float)(windowNodes * _height_translate_step - 2));
                _draw.DrawLine(window_pen, 0, (float)(2* windowNodes * _height_translate_step - 2), 0, (float)((_node_count_y - 1) * _height_translate_step ));
            }
        }
        public void RePaintBitmap(Node[,] main) 
        {
            for (int i = 0; i < _node_count_x; i++)
            {
                for (int k = 0; k < _node_count_y; k++)
                {
                    if (main[i, k].type == NodeType.Full)
                    {
                        DrawEllipse(i * _width_translate_step - _width_translate_step / 4, k * _height_translate_step - _height_translate_step / 4, _width_translate_step / 2, _height_translate_step / 2);
                    }
                }
            }
            PIC.Image = _bmp;
        }
        public void DrawEllipse(double x, double y, double width, double height)
        {
            _draw.FillEllipse(atoms, (float)x, (float)y, (float)width, (float)height);
        }
        private void GENERATE_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            chart_counter = 0;

            MonteCarloStep = 0;
            _node_count_x = Convert.ToInt32(NodeCountX.Text);
            _node_count_y = Convert.ToInt32(NodeCountY.Text);
            Max_MKSH = Convert.ToInt32(Maximum_MKSH.Text);

            _width_translate_step = PIC.Width / (_node_count_x + 1);
            _height_translate_step = PIC.Height / (_node_count_y + 1);
            timer_main.Stop();
            windowNodes = (_node_count_y) / 3;
            Init();
        }
        private void Start_Click(object sender, EventArgs e)
        {
            if (timer_main.Enabled == false)
            {
                Start.Text = "Stop";
                timer_main.Start();
                Init();
            }
            else
            {
                Start.Text = "Start";
                timer_main.Stop();
            }
        }
        private void StopTimer()
        {
            Start.Text = "Start";
            timer_main.Stop();
        }

        private void Angle_Z_Scroll(object sender, EventArgs e)
        {
            angleZ = Angle_Z.Value * 5;
            drw.Draw(_nodes3D, angleZ, angleY, mult);
        }

        private void Angle_Y_Scroll(object sender, EventArgs e)
        {
            angleY = Angle_Y.Value * 5;
            drw.Draw(_nodes3D, angleZ, angleY, mult);
        }

        private void isAutoStop_CheckedChanged(object sender, EventArgs e)
        {
            if (isAutoStop.Checked)
            {
                _valAutoStop = 0;
            }
            else 
            {
                _valAutoStop = -1;
            }
        }

        private void timer_main_Tick(object sender, EventArgs e)
        {
            Next();
            MonteCarloStep++;
            label3.Text = Convert.ToString("Шаг Монте-Карло:" + MonteCarloStep);
            if(MonteCarloStep == Max_MKSH + 1)
            {
                timer_main.Stop();
            }
        }

        private void Next()
        {
            Random random = new Random();
            Node[,] nodes_new = new Node[_node_count_x, _node_count_y];
            AddNewAtoms(nodes_new);
            for (int i = 0; i < _node_count_x + _valAutoStop; i++)
            {
                for (int k = 0; k < _node_count_y; k++)
                {
                    if (_nodes[i, k].type == NodeType.Full)
                    {
                        int rand = random.Next(4);
                        switch (rand)
                        {
                                
                            case 0://шаг вправо
                                if ((i + 1) < _node_count_x)
                                        
                                {
                                           
                                    if (_nodes[i + 1, k].type == NodeType.Empty && nodes_new[i + 1, k].type == NodeType.Empty)
                                           
                                    {
                                              
                                        nodes_new[i + 1, k].type = NodeType.Full;
                                              
                                        break;
                                           
                                    }
                                        
                                }  
                                else
                                {
                                    _isEdge?.Invoke();
                                }
                                nodes_new[i, k].type = NodeType.Full;
                                break;
                                
                            case 1: // шаг влево
                                   
                                if ((i - 1) > 0)
                                {
                                    if (i != 0 && _nodes[i - 1, k].type == NodeType.Empty && nodes_new[i - 1, k].type == NodeType.Empty)
                                    {
                                        nodes_new[i - 1, k].type = NodeType.Full;
                                        break;
                                    }
                                }
                                nodes_new[i, k].type = NodeType.Full;
                                break;

                            case 2: //шаг вверх
                                if ((k - 1) >= 0)
                                {
                                    if (i != 0 && _nodes[i, k - 1].type == NodeType.Empty && nodes_new[i, k - 1].type == NodeType.Empty)
                                    {
                                        nodes_new[i, k - 1].type = NodeType.Full;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (i != 0 && _nodes[i, k + _node_count_y - 1].type == NodeType.Empty && nodes_new[i, k + _node_count_y - 1].type == NodeType.Empty)
                                    {

                                        nodes_new[i, +_node_count_y - 1].type = NodeType.Full;
                                        break;
                                    }
                                }

                                nodes_new[i, k].type = NodeType.Full;
                                break;

                            case 3: //шаг вниз
                                if ((k + 1) < _node_count_y)
                                {
                                    if (i != 0 && _nodes[i, k + 1].type == NodeType.Empty && nodes_new[i, k + 1].type == NodeType.Empty)  
                                    {
                                        nodes_new[i, k + 1].type = NodeType.Full;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (i != 0 && _nodes[i, k - (_node_count_y- 1)].type == NodeType.Empty && nodes_new[i, k - (_node_count_y - 1)].type == NodeType.Empty)
                                    {
                                        nodes_new[i, k - (_node_count_y - 1)].type = NodeType.Full;
                                        break;
                                    }
                                }
                                nodes_new[i, k].type = NodeType.Full;
                                break;
                        }
                    }
                    if (i == 0)
                    {
                        if (windowNodes <= k && k < 2 * windowNodes)
                            nodes_new[i, k].type = NodeType.Full;

                    }
                }
            }
            int middle_x = _node_count_x / 2;
            int middle_y = _node_count_y / 2;

            _nodes = nodes_new;
            if (WindowCheck.Checked)
            {
                if(MonteCarloStep==Max_MKSH)
                {
                    _nodes3D = new double[middle_x, middle_y];
                    count_nodes = new double[middle_x, middle_y];
                    for (int i = 0; i<_node_count_x; i++)
                    {

                        if (i < middle_x)
                        {
                            for (int k = 0; k < _node_count_x; k++)
                            {
                                int atoms_counter = 0;
                                if (k < middle_y)
                                {
                                    for(int m = i - 1; m <= i + 1; m++)
                                    {
                                        if (m >= 0)
                                        {
                                            for (int l = k - 1; l <= k + 1; l++)
                                            {
                                                if (l >= 0)
                                                {
                                                    if (_nodes[i, k].type == NodeType.Full)
                                                    {
                                                        atoms_counter++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    count_nodes[i, k] = atoms_counter;
                                }
                            }
                            
                        }
                    }
                    _nodes3D = flat(middle_x, middle_y, count_nodes);

                    drw = new Drawer3D(pictureBox1);
                  //  drw.resize(new double[] { -2, 2, -2, 2, 0, 1 });
                    mult = 1;
                    drw.Draw(_nodes3D, angleZ, angleY, mult);

                }
            }
            else
            {
                if (MonteCarloStep == Max_MKSH / 4 || MonteCarloStep == Max_MKSH * 4 / 9 || MonteCarloStep == Max_MKSH && !WindowCheck.Checked)
                {
                    for (int i = 0; i < _node_count_x; i++)
                    {
                        int atoms_counter = 0;
                        for (int k = 0; k < _node_count_y; k++)
                        {
                            if (_nodes[i, k].type == NodeType.Full)
                            {
                                atoms_counter++;
                            }
                        }
                        chart1.Series[chart_counter].Points.AddXY(i, atoms_counter);
                    }
                    chart_counter++;
                }
            }
                       
            this._draw.Clear(Color.White);
            this._draw.ResetTransform();

            

            CreateGrid();
            RePaintBitmap(_nodes);            
        }
        double[,] flat(int N, int M, double[,] to_flat)
        {
            double[,] flatten = new double[N, M];
            double max = 0;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                {
                    if (to_flat[i, j] > max) max = to_flat[i, j];
                }
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                {
                    flatten[i, j] = to_flat[i, j] / max;
                }

            return flatten;
        }

    }
}
