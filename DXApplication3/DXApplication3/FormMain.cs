using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.Mapping;
using SuperMap.UI;
using DXApplication3.mapoperate;
using System.Diagnostics;



namespace DXApplication3
{
    /// <summary>
    /// 定义枚举值，分别代表不同量算
    /// </summary>
    public enum MeasureAction
    {
        None,
        Distance,
        Area,
        Angle
    }


    public partial class FormMain : Form
    {


        //地图操作对象定义
        private MapCommon m_MapCommon;
        private MapMeasure m_MapMeasure;


        public FormMain()
        {

            try
            {
                InitializeComponent();
                SetTopPanelStyle();

                //隐藏悬浮工具栏
                label_arrow.Location = new Point(468, 0);
                label_arrow.Image = imageCollection1.Images[2];
                toolStrip1.Visible = false;

                workspace1 = new SuperMap.Data.Workspace(this.components);
            }

            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }



        private void SetTopPanelStyle()
        {


            btn_zoomin.FlatStyle = FlatStyle.Flat;//样式
            this.btn_zoomin.BackColor = Color.FromArgb(50, 100, 130, 150);
            this.btn_zoomin.ForeColor = Color.FromArgb(50, 100, 130, 150);
            btn_zoomin.Parent = mapControl1;

            btn_zoomout.FlatStyle = FlatStyle.Flat;//样式
            this.btn_zoomout.BackColor = Color.FromArgb(50, 100, 130, 150);
            this.btn_zoomout.ForeColor = Color.FromArgb(50, 100, 130, 150);
            btn_zoomout.Parent = mapControl1;

            btn_select.FlatStyle = FlatStyle.Flat;//样式
            this.btn_select.BackColor = Color.FromArgb(50, 100, 130, 150);
            this.btn_select.ForeColor = Color.FromArgb(50, 100, 130, 150);
            btn_select.Parent = mapControl1;


            btn_pan.FlatStyle = FlatStyle.Flat;//样式
            this.btn_pan.BackColor = Color.FromArgb(50, 100, 130, 150);
            this.btn_pan.ForeColor = Color.FromArgb(50, 100, 130, 150);
            btn_pan.Parent = mapControl1;

            btn_distance.FlatStyle = FlatStyle.Flat;//样式
            this.btn_distance.BackColor = Color.FromArgb(50, 100, 130, 150);
            this.btn_distance.ForeColor = Color.FromArgb(50, 100, 130, 150);
            btn_distance.Parent = mapControl1;

            btn_area.FlatStyle = FlatStyle.Flat;//样式
            this.btn_area.BackColor = Color.FromArgb(50, 100, 130, 150);
            this.btn_area.ForeColor = Color.FromArgb(50, 100, 130, 150);
            btn_area.Parent = mapControl1;

            //this.toolStrip1.BackColor = Color.FromArgb(0, 100, 130, 150);
            //this.toolStrip1.ForeColor = Color.FromArgb(0, 100, 130, 150);
            //toolStrip1.Parent = mapControl1;

        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            mapControl1.Dispose();
            workspace1.Close();
            workspace1.Dispose();

        }



        private void toolStripButton_loadmap_Click(object sender, EventArgs e)
        {
            //设置公用打开对话框
            openFileDialog1.Filter = "SuperMap 工作空间文件(*.smwu)|*.smwu";
            //判断打开的结果，如果打开就执行下列操作
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //避免连续打开工作空间导致程序异常     
                mapControl1.Map.Close();
                workspace1.Close();
                mapControl1.Map.Refresh();
                //定义打开工作空间文件名
                String fileName = openFileDialog1.FileName;
                //打开工作空间文件
                WorkspaceConnectionInfo connectionInfo = new WorkspaceConnectionInfo(fileName);
                //打开工作空间
                workspace1.Open(connectionInfo);
                //建立MapControl与Workspace的连接
                mapControl1.Map.Workspace = workspace1;
                //判断工作空间中是否有地图
                if (workspace1.Maps.Count == 0)
                {
                    MessageBox.Show("当前工作空间中不存在地图!");
                    return;
                }

                //通过名称打开工作空间中的地图
                mapControl1.Map.Open(workspace1.Maps[0]);

                //刷新地图窗口
                mapControl1.Map.Refresh();


                ////////////////////////////////////实例化地图操作对象////////////////////////////////////////


                //实例化m_MapCommon
                m_MapCommon = new MapCommon(workspace1, mapControl1);

                //实例化m_MapMeasure
                m_MapMeasure = new MapMeasure(workspace1, mapControl1, labelResult);


                ////////////////////////////////////////////////////////////////////////////////////////////
            }
        }




        //隐藏悬浮工具栏
        private void toolStrip1_MouseLeave(object sender, EventArgs e)
        {
            label_arrow.Location = new Point(468, 0);
            label_arrow.Image = imageCollection1.Images[2];
            toolStrip1.Visible = false;
        }


        //显示悬浮工具栏
        private void label_arrow_MouseEnter(object sender, EventArgs e)
        {
            //控件位置调整
            label_arrow.Location = new Point(468, 42);
            label_arrow.Image = imageCollection1.Images[1];

            toolStrip1.Location = new Point(374, 0);

            toolStrip1.Visible = true;

        }



        private void btn_zoomin_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.ZoomIn;

        }

        private void btn_zoomout_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.ZoomOut;

        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            mapControl1.IsWaitCursorEnabled = true;
            mapControl1.Action = SuperMap.UI.Action.Select;

        }

        private void btn_pan_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.Pan;

        }



        /// <summary>
        /// 量算距离操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btn_distance_Click(object sender, EventArgs e)
        {
            try
            {
                labelResult.Text="";
                m_MapMeasure.DrawMeasure(MeasureAction.Distance);
            }

            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 量算面积操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_area_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.CreatePolygon;

            try
            {
                labelResult.Text = "";
                m_MapMeasure.DrawMeasure(MeasureAction.Area);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }



    }
}
