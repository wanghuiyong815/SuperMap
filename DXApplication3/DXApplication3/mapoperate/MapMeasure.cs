
//////////////////////////////////////////////////////////////////////////////////////////////////
//---------------------------------------------------------------------------------------
//1、功能简介：量算距离、面积和角度
//2、关键类型/成员: 

//      Workspace.Open 方法
//      MapControl.Action 属性
//      MapControl.Tracking 事件
//      MapControl.Tracked 事件
//      Action.CreatePolyline 属性
//      Action.CreatePolygon 属性
//      TrackingEventArgs.CurrentLength 属性
//      TrackingEventArgs.TotalLength 属性
//      TrackingEventArgs.TotalArea 属性
//      TrackingEventArgs.CurrentAngle 属性
//      TrackingEventArgs.CurrentAzimuth 属性
//      TrackedEventArgs.Length 属性
//      TrackedEventArgs.Area 属性
//      TrackedEventArgs.Azimuth 属性
//      TrackedEventArgs.Angle 属性
//      
//3、使用步骤：
//   (1)点击工具栏上面相应的按钮，进行相应的量算操作。
//   (2)在量算的过程中右键点击结束量算。
//---------------------------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.Mapping;
using SuperMap.UI;


namespace DXApplication3.mapoperate
{
    public class MapMeasure
    {
        private Workspace m_workspace;
        private MapControl m_mapControl;


        private ToolStripStatusLabel m_labelResult;

        private Point2D pointMove;
        private MeasureAction m_myAction;

        //定义存储字符串的变量
        private readonly String m_meter = "米";
        private readonly String m_squareMeter = "平方米";
        private readonly String m_length = "总长度：";
        private readonly String m_lengthcurrent = "当前长度:";
        private readonly String m_area = "面积：";
        private readonly String m_degree = "度";
        private readonly String m_azimuth = "方位角:";
        private readonly String m_angle = "当前角度:";


        /// <summary>
        /// 根据workspace和map构造 MapMeasure对象
        /// </summary>
        public MapMeasure(Workspace workspace, MapControl mapControl, ToolStripStatusLabel lableResult)
        {
            m_workspace = workspace;
            m_mapControl = mapControl;
            m_labelResult = lableResult;
            m_mapControl.Map.Workspace = workspace;

            Initialize();
        }

        /// <summary>
        /// 打开需要的工作空间文件及地图
        /// </summary>
        private void Initialize()
        {
            try
            {

                // 调整mapControl的状态
                m_mapControl.IsWaitCursorEnabled = false;
                m_mapControl.TrackMode = TrackMode.Track;

                m_myAction = MeasureAction.None;
                //注册事件
                m_mapControl.MouseMove += new MouseEventHandler(MouseMoveHandler);
                m_mapControl.Tracking += new TrackingEventHandler(TrackingHandler);
                m_mapControl.Tracked += new TrackedEventHandler(TrackedHandler);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

        }


        /// <summary>
        /// 在跟踪绘制结束事件中根据选择显示最后结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackedHandler(object sender, TrackedEventArgs e)
        {
            try
            {
                switch (m_myAction)
                {
                    case MeasureAction.Distance:
                        {
                            String totalLength = String.Format("{0}{1}{2}", m_length, Math.Round(Convert.ToDecimal(e.Length), 2), m_meter);
                            m_labelResult.Text = totalLength;
                        }
                        break;
                    case MeasureAction.Area:
                        {
                            String totalArea = String.Format("{0}{1}{2}", m_area, Math.Round(Convert.ToDecimal(e.Area), 2), m_squareMeter);
                            m_labelResult.Text = totalArea;
                        }
                        break;
                    case MeasureAction.Angle:
                        {
                            String currentAzimuth = String.Format("{0}{1}{2}", m_azimuth, Math.Round(Convert.ToDecimal(e.Azimuth), 2), m_degree);
                            String currentAngle = String.Format("{0}{1}{2}", m_angle, Math.Round(Convert.ToDecimal(e.Angle), 2), m_degree);
                            m_labelResult.Text = currentAzimuth + ",  " + currentAngle;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 在跟踪绘制事件中根据选择显示计算中间结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackingHandler(object sender, TrackingEventArgs e)
        {
            try
            {
                switch (m_myAction)
                {
                    case MeasureAction.Distance:
                        {
                            String totalLength = String.Format("{0}{1}{2}", m_length, Math.Round(Convert.ToDecimal(e.TotalLength), 2), m_meter);
                            String currentLength = String.Format("{0}{1}{2}", m_lengthcurrent, Math.Round(Convert.ToDecimal(e.CurrentLength), 2), m_meter);
                            m_labelResult.Text = totalLength + "," + currentLength;
                        }
                        break;
                    case MeasureAction.Area:
                        {
                            String totalArea = String.Format("{0}{1}{2}", m_area, Math.Round(Convert.ToDecimal(e.TotalArea), 2), m_squareMeter);
                            m_labelResult.Text = totalArea;
                        }
                        break;
                    case MeasureAction.Angle:
                        {
                            String currentAzimuth = String.Format("{0}{1}{2}", m_azimuth, Math.Round(Convert.ToDecimal(e.CurrentAzimuth), 2), m_degree);
                            String currentAngle = String.Format("{0}{1}{2}", m_angle, Math.Round(Convert.ToDecimal(e.CurrentAngle), 2), m_degree);
                            m_labelResult.Text = currentAzimuth + "," + currentAngle;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 跟踪显示鼠标点坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            pointMove = m_mapControl.Map.PixelToMap(e.Location);
            String textXY = String.Format("X:{0},  Y:{1}", Math.Round(pointMove.X, 4), Math.Round(pointMove.Y, 4));
        }

        /// <summary>
        /// 选择不同的绘制状态
        /// </summary>
        public void DrawMeasure(MeasureAction myAction)
        {
            m_myAction = myAction;

            switch (m_myAction)
            {
                case MeasureAction.Distance:
                    {
                        m_mapControl.Action = SuperMap.UI.Action.CreatePolyline;
                    }
                    break;
                case MeasureAction.Area:
                    {
                        m_mapControl.Action = SuperMap.UI.Action.CreatePolygon;
                    }
                    break;
                case MeasureAction.Angle:
                    {
                        m_mapControl.Action = SuperMap.UI.Action.CreatePolyline;
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
        }
    }
}
