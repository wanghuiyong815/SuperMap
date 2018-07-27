namespace DXApplication3
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.workspace1 = new SuperMap.Data.Workspace(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.mapControl1 = new SuperMap.UI.MapControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_loadmap = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.label_arrow = new System.Windows.Forms.Label();
            this.btn_zoomout = new System.Windows.Forms.Button();
            this.btn_zoomin = new System.Windows.Forms.Button();
            this.btn_area = new System.Windows.Forms.Button();
            this.btn_distance = new System.Windows.Forms.Button();
            this.btn_pan = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // workspace1
            // 
            this.workspace1.Caption = "UntitledWorkspace";
            this.workspace1.Description = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(1043, 560);
            // 
            // mapControl1
            // 
            this.mapControl1.Action = SuperMap.UI.Action.Select2;
            this.mapControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mapControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.InteractionMode = SuperMap.UI.InteractionMode.Default;
            this.mapControl1.IsCursorCustomized = false;
            this.mapControl1.IsWaitCursorEnabled = true;
            this.mapControl1.Location = new System.Drawing.Point(0, 0);
            this.mapControl1.Margin = new System.Windows.Forms.Padding(48, 22, 48, 22);
            this.mapControl1.MarginPanEnabled = true;
            this.mapControl1.MarginPanPercent = 0.5D;
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.RefreshAtTracked = true;
            this.mapControl1.RefreshInInvalidArea = false;
            this.mapControl1.RollingWheelWithoutDelay = false;
            this.mapControl1.SelectionMode = SuperMap.UI.SelectionMode.ContainInnerPoint;
            this.mapControl1.SelectionPixelTolerance = 1;
            this.mapControl1.Size = new System.Drawing.Size(1043, 610);
            this.mapControl1.TabIndex = 16;
            this.mapControl1.TrackMode = SuperMap.UI.TrackMode.Edit;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_loadmap,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(374, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(275, 42);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.MouseLeave += new System.EventHandler(this.toolStrip1_MouseLeave);
            // 
            // toolStripButton_loadmap
            // 
            this.toolStripButton_loadmap.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_loadmap.Image")));
            this.toolStripButton_loadmap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_loadmap.Name = "toolStripButton_loadmap";
            this.toolStripButton_loadmap.Size = new System.Drawing.Size(76, 39);
            this.toolStripButton_loadmap.Text = "加载地图";
            this.toolStripButton_loadmap.Click += new System.EventHandler(this.toolStripButton_loadmap_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(76, 39);
            this.toolStripButton2.Text = "添加图层";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(76, 39);
            this.toolStripButton3.Text = "删除标记";
            // 
            // label_arrow
            // 
            this.label_arrow.Image = global::DXApplication3.Properties.Resources.arrow_show;
            this.label_arrow.Location = new System.Drawing.Point(469, 42);
            this.label_arrow.Name = "label_arrow";
            this.label_arrow.Size = new System.Drawing.Size(100, 18);
            this.label_arrow.TabIndex = 23;
            this.label_arrow.Text = "   ";
            this.label_arrow.MouseEnter += new System.EventHandler(this.label_arrow_MouseEnter);
            // 
            // btn_zoomout
            // 
            this.btn_zoomout.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_zoomout.Image = global::DXApplication3.Properties.Resources.MapZoomOut;
            this.btn_zoomout.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_zoomout.Location = new System.Drawing.Point(30, 185);
            this.btn_zoomout.Name = "btn_zoomout";
            this.btn_zoomout.Size = new System.Drawing.Size(69, 65);
            this.btn_zoomout.TabIndex = 11;
            this.btn_zoomout.Text = "缩小";
            this.btn_zoomout.UseVisualStyleBackColor = true;
            this.btn_zoomout.Click += new System.EventHandler(this.btn_zoomout_Click);
            // 
            // btn_zoomin
            // 
            this.btn_zoomin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_zoomin.Image = global::DXApplication3.Properties.Resources.MapZoomIn;
            this.btn_zoomin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_zoomin.Location = new System.Drawing.Point(30, 119);
            this.btn_zoomin.Name = "btn_zoomin";
            this.btn_zoomin.Size = new System.Drawing.Size(69, 65);
            this.btn_zoomin.TabIndex = 11;
            this.btn_zoomin.Text = "放大";
            this.btn_zoomin.UseVisualStyleBackColor = true;
            this.btn_zoomin.Click += new System.EventHandler(this.btn_zoomin_Click);
            // 
            // btn_area
            // 
            this.btn_area.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_area.Image = global::DXApplication3.Properties.Resources.area;
            this.btn_area.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_area.Location = new System.Drawing.Point(30, 449);
            this.btn_area.Name = "btn_area";
            this.btn_area.Size = new System.Drawing.Size(69, 65);
            this.btn_area.TabIndex = 13;
            this.btn_area.Text = "测面积";
            this.btn_area.UseVisualStyleBackColor = true;
            this.btn_area.Click += new System.EventHandler(this.btn_area_Click);
            // 
            // btn_distance
            // 
            this.btn_distance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_distance.Image = global::DXApplication3.Properties.Resources.ruler;
            this.btn_distance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_distance.Location = new System.Drawing.Point(30, 383);
            this.btn_distance.Name = "btn_distance";
            this.btn_distance.Size = new System.Drawing.Size(69, 65);
            this.btn_distance.TabIndex = 14;
            this.btn_distance.Text = "测距";
            this.btn_distance.UseVisualStyleBackColor = true;
            this.btn_distance.Click += new System.EventHandler(this.btn_distance_Click);
            // 
            // btn_pan
            // 
            this.btn_pan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_pan.Image = global::DXApplication3.Properties.Resources.MapPan;
            this.btn_pan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_pan.Location = new System.Drawing.Point(30, 317);
            this.btn_pan.Name = "btn_pan";
            this.btn_pan.Size = new System.Drawing.Size(69, 65);
            this.btn_pan.TabIndex = 15;
            this.btn_pan.Text = "漫游";
            this.btn_pan.UseVisualStyleBackColor = true;
            this.btn_pan.Click += new System.EventHandler(this.btn_pan_Click);
            // 
            // btn_select
            // 
            this.btn_select.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_select.Image = global::DXApplication3.Properties.Resources.MapSelect;
            this.btn_select.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_select.Location = new System.Drawing.Point(30, 251);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(69, 65);
            this.btn_select.TabIndex = 10;
            this.btn_select.Text = "选择";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "area.PNG");
            this.imageCollection1.Images.SetKeyName(1, "arrow_hide.png");
            this.imageCollection1.Images.SetKeyName(2, "arrow_show.png");
            this.imageCollection1.Images.SetKeyName(3, "MapPan.png");
            this.imageCollection1.Images.SetKeyName(4, "MapSelect.png");
            this.imageCollection1.Images.SetKeyName(5, "MapZoomIn.png");
            this.imageCollection1.Images.SetKeyName(6, "MapZoomOut.png");
            this.imageCollection1.Images.SetKeyName(7, "ruler.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.labelResult});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1043, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "量算结果：";
            // 
            // labelResult
            // 
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(131, 17);
            this.labelResult.Text = "toolStripStatusLabel2";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 610);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label_arrow);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_zoomout);
            this.Controls.Add(this.btn_zoomin);
            this.Controls.Add(this.btn_area);
            this.Controls.Add(this.btn_distance);
            this.Controls.Add(this.btn_pan);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.mapControl1);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperMap GIS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_area;
        private System.Windows.Forms.Button btn_distance;
        private System.Windows.Forms.Button btn_pan;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_zoomout;
        private SuperMap.Data.Workspace workspace1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private SuperMap.UI.MapControl mapControl1;
        private System.Windows.Forms.Button btn_zoomin;
        private System.Windows.Forms.Label label_arrow;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_loadmap;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel labelResult;
    }
}