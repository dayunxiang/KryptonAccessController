using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace KryptonAccessController.RelationRealTimeMoni
{
    public partial class FormPictureMovable : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Point pt = Point.Empty; // ��¼��갴��ʱ������
        private Point def = Point.Empty; // ��¼��갴��panel���ݹ�������ֵ

        //IDevicePointGroup iDevicePointGroup = new FactoryDataBase().CreateDevicePointGroup();
        public FormPictureMovable()
        {
            InitializeComponent();
        }

        private void pictureBoxElectronicMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Cursor = Cursors.SizeAll;
            pt = this.PointToClient(pictureBoxElectronicMap.PointToScreen(e.Location)); // ����ǰ���picturebox�ϣ���Ҫת���������panel������
            def.X = this.panel1.HorizontalScroll.Value; // HScrollֵ
            def.Y = this.panel1.VerticalScroll.Value; // VScrollֵ
        }

        private void pictureBoxElectronicMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            if (Cursor != Cursors.SizeAll) return;
            Point cur = this.PointToClient(pictureBoxElectronicMap.PointToScreen(e.Location)); // ��ǰ������꣬ͬ����Ҫת���������panel������
            cur = new Point(pt.X - cur.X, pt.Y - cur.Y); // �����

            cur.X = def.X + cur.X; // �����
            cur.Y = def.Y + cur.Y;

            if (0 > cur.X)
                cur.X = 0;  // ���������Χ����Ҫ����
            if (this.panel1.HorizontalScroll.Maximum < cur.X)
                cur.X = this.panel1.HorizontalScroll.Maximum;
            if (0 > cur.Y)
                cur.Y = 0;
            if (this.panel1.VerticalScroll.Maximum < cur.Y)
                cur.Y = this.panel1.VerticalScroll.Maximum;


            if (this.panel1.HorizontalScroll.Visible)
                this.panel1.HorizontalScroll.Value = cur.X;  // ������ڶ�Ӧ�Ĺ���������ֵ

            if (this.panel1.VerticalScroll.Visible)
                this.panel1.VerticalScroll.Value = cur.Y;
        }

        private void pictureBoxElectronicMap_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}