//////////////////////////////////////////////////////////////////////////////////////////////////
//---------------------------------------------------------------------------------------
//功能简介:工作空间操作、鹰眼、添加图层、地图导出BMP图片、单兵定位及状态显示
//关键技术：
//添加态势层
//跟踪层操作
//---------------------------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////////////////////////////////




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.UI;
using SuperMap.Mapping;


namespace DXApplication3.mapoperate
{
    class MapCommon
    {
        private Workspace m_workspace;
        private MapControl m_mapControl;

        private Rectangle2D m_engleRectangle;
        private Point m_pointBefore;
        private Boolean m_isMoveEngleRect;

        private Datasource m_datasource;
        //添加的各中类型数据集的名称
        private readonly String m_datasetPoint = "Capital";
        private readonly String m_datasetLine = "Grids";
        private readonly String m_datasetRegion = "World";
        private readonly String m_datasetImage = "day";
        //private readonly String m_datasetGrid = "Raster";
        System.Timers.Timer timerForSimu;//定时器

        /// <summary>
        /// 根据workspace和map构造 SampleRun对象
        /// </summary>
        public MapCommon(Workspace workspace, MapControl mapControl)
        {
            try
            {
                m_workspace = workspace;
                m_mapControl = mapControl;

                m_mapControl.Map.Workspace = workspace;

                m_mapControl.Map.Drawn += new MapDrawnEventHandler(MainMapDrawnHandler);


                Initialize();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }



        /// <summary>
        /// 打开需要的工作空间文件及地图
        /// </summary>
        private void Initialize()
        {
            try
            {
                m_datasource = m_workspace.Datasources[0];


                // 调整mapControl的状态
                m_mapControl.Action = SuperMap.UI.Action.Pan;
                m_mapControl.Map.Center = new Point2D(117.28, 39.11);
                m_mapControl.Map.ViewEntire();

                //  在主地图视图中打开地图
                m_mapControl.Map.Open(m_workspace.Maps[0]);
                m_mapControl.IsWaitCursorEnabled = false;
                m_mapControl.Map.Refresh();
            }


            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 定义地图绘制结束事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMapDrawnHandler(object sender, MapDrawnEventArgs e)
        {
            if (!m_isMoveEngleRect)
            {
                DisplayRect(m_mapControl.Map.ViewBounds);
            }
        }


        /// <summary>
        /// 定义鹰眼窗口鼠标按下事件，并将鼠标按下时的坐标保存到pointBefore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EagleEyeMapMouseDownHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_pointBefore = e.Location;
            }
        }





        /// <summary>
        /// 定义更新光标事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EagleEyeMapCursorChangedHandler(object sender, ActionCursorChangingEventArgs e)
        {
            e.FollowingCursor = Cursors.Cross;
        }



        /// <summary>
        /// 按照指定风格显示矩形框
        /// </summary>
        /// <param name="rectDisplay"></param>
        private void DisplayRect(Rectangle2D rectangleDisplay)
        {
            try
            {
                m_engleRectangle = rectangleDisplay;

                Double rectangleWidth = rectangleDisplay.Width;
                Double rectangleHeight = rectangleDisplay.Height;
                Double pntLeftTopX = rectangleDisplay.Left;
                Double pntLeftTopY = rectangleDisplay.Top;
                //设置图框四点坐标
                Point2Ds points = new Point2Ds();

                Point2D pntLeftTop = new Point2D(pntLeftTopX, pntLeftTopY);
                points.Add(pntLeftTop);
                Point2D pntLeftBottom = new Point2D(pntLeftTopX, pntLeftTopY - rectangleHeight);
                points.Add(pntLeftBottom);
                Point2D pntRightBottom = new Point2D(pntLeftTopX + rectangleWidth, pntLeftTopY - rectangleHeight);
                points.Add(pntRightBottom);
                Point2D pntRightTop = new Point2D(pntLeftTopX + rectangleWidth, pntLeftTopY);
                points.Add(pntRightTop);
                points.Add(pntLeftTop);
                //将点连成线，并设置样式

                GeoLine rectangleBoundary = new GeoLine();
                rectangleBoundary.AddPart(points);

                GeoStyle rectangleStyle = new GeoStyle();
                rectangleStyle.LineColor = Color.FromArgb(255, 0, 0);
                rectangleStyle.LineWidth = 0.5;

                rectangleBoundary.Style = rectangleStyle;

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 构造OffsetPoint点对象
        /// </summary>
        /// <param name="point"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        private Point2D OffsetPoint(Point2D point, Double dx, Double dy)
        {
            Point2D temp = point;
            temp.Offset(dx, dy);

            return temp;
        }


        /// <summary>
        /// 清空图层
        /// </summary>
        public void ClearLayers()
        {
            try
            {
                m_mapControl.Map.Layers.Clear();
                m_mapControl.Map.Refresh();



            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 向地图中添加点数据集
        /// </summary>
        /// <param name="isWithStyle">是否自定义风格</param>
        public void AddPoint(Boolean isWithStyle)
        {
            try
            {
                DatasetVector dataset = m_datasource.Datasets[m_datasetPoint] as DatasetVector;
                //设置风格并添加数据集
                Layer layer = null;
                if (isWithStyle)
                {

                    LayerSettingVector setting = new LayerSettingVector();
                    setting.Style.LineColor = Color.SeaGreen;
                    setting.Style.MarkerSize = new Size2D(4, 4);
                    setting.Style.MarkerSymbolID = 12;
                    layer = m_mapControl.Map.Layers.Add(dataset, setting, true);

                }
                else
                {
                    layer = m_mapControl.Map.Layers.Add(dataset, true);

                }
                //全幅显示添加的图层
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 向地图中添加线数据集
        /// </summary>
        /// <param name="isWithStyle">是否自定义风格</param>
        public void AddLine(Boolean isWithStyle)
        {
            try
            {
                DatasetVector dataset = m_datasource.Datasets[m_datasetLine] as DatasetVector;
                //设置风格并添加数据集
                Layer layer = null;
                if (isWithStyle)
                {
                    LayerSettingVector setting = new LayerSettingVector();
                    setting.Style.LineColor = Color.Gray;
                    setting.Style.LineSymbolID = 2;
                    setting.Style.LineWidth = 0.3;
                    layer = m_mapControl.Map.Layers.Add(dataset, setting, true);

                }
                else
                {
                    layer = m_mapControl.Map.Layers.Add(dataset, true);

                }

                //全幅显示添加的图层
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();


            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 向地图中添加面数据集
        /// </summary>
        /// <param name="isWithStyle">是否自定义风格</param>
        public void AddRegion(Boolean isWithStyle)
        {
            try
            {
                DatasetVector dataset = m_datasource.Datasets[m_datasetRegion] as DatasetVector;
                //设置风格并添加数据集
                Layer layer = null;
                if (isWithStyle)
                {
                    LayerSettingVector setting = new LayerSettingVector();
                    setting.Style.LineColor = Color.Teal;
                    setting.Style.LineSymbolID = 11;
                    setting.Style.LineWidth = 0.5;
                    setting.Style.FillForeColor = Color.FromArgb(2, 138, 226);
                    setting.Style.FillBackColor = Color.FromArgb(232, 245, 254);
                    setting.Style.FillGradientMode = FillGradientMode.Radial;
                    layer = m_mapControl.Map.Layers.Add(dataset, setting, true);

                }
                else
                {
                    layer = m_mapControl.Map.Layers.Add(dataset, true);

                }
                //全幅显示添加的图层
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();


            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 向地图中添加影像数据集
        /// </summary>
        /// <param name="isWithStyle">是否自定义风格</param>
        public void AddImage(Boolean isWithStyle)
        {
            try
            {
                DatasetImage dataset = m_datasource.Datasets[m_datasetImage] as DatasetImage;
                //设置风格并添加数据集
                Layer layer = null;
                if (isWithStyle)
                {
                    LayerSettingImage setting = new LayerSettingImage();
                    setting.OpaqueRate = 50;
                    layer = m_mapControl.Map.Layers.Add(dataset, setting, true);

                }
                else
                {
                    layer = m_mapControl.Map.Layers.Add(dataset, true);

                }
                //全幅显示添加的图层
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 根据文件后缀名选择要保存的文件路径和格式，并返回选择的路径
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns></returns>
        private String GetFilePath(String postfix)
        {
            String result = String.Empty;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "请选择要保存的文件路径";
            dialog.Filter = String.Format("{0}格式(*.{0})|*.{0}", postfix);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                result = dialog.FileName;
            }
            return result;
        }


        /// <summary>
        /// 出BMP图
        /// </summary>
        public void OutputBMP()
        {
            try
            {
                String fileName = GetFilePath("bmp");
                m_mapControl.Map.OutputMapToBMP(fileName);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

    }
}
