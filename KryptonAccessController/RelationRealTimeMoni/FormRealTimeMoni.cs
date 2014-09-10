using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using KryptonAccessController.ResourcesFile;
using KryptonAccessController.WidgetThread;
using System.IO;
using MyComponents;
using KryptonAccessController.Common;

namespace KryptonAccessController.RelationRealTimeMoni
{
    public partial class FormRealTimeMoni : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private AccessDataBase.BLL.DoorUnitInfo bllDoorUnitInfo = new AccessDataBase.BLL.DoorUnitInfo();
        private AccessDataBase.Model.DoorUnitInfo modelDoorUnitInfo = new AccessDataBase.Model.DoorUnitInfo();

        private AccessDataBase.BLL.ElectronicMap bllElectronicMap = new AccessDataBase.BLL.ElectronicMap();
        private AccessDataBase.Model.ElectronicMap modelElectronicMap = new AccessDataBase.Model.ElectronicMap();

        private ModeValue modeValue = ModeValue.save;
        private RealWatchState realWatchState = RealWatchState.Close;

        private Font Var_Font = new Font("����", 11);
        private double scanle = 1;

        static FormRealTimeMoni instance = null;
        private FormPictureMovable formPictureMovable = new FormPictureMovable();

        public static FormRealTimeMoni getInstance()
        {
            if (instance == null)
                instance = new FormRealTimeMoni();
            return instance;
        }

        private FormRealTimeMoni()
        {
            InitializeComponent();
            initToolStripControlConsole();
            initPictureBoxTitle();

            this.CenterToScreen();
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            this.Icon = GetResourcesFile.getSystemIco();

            showlistViewElectronicMap();
            showlistViewAccess();
            displayFormOnPanel1(formPictureMovable);
        }
        private void displayFormOnPanel1(Form newForm)
        {
            newForm.TopLevel = false;    //����Ϊ�Ƕ�������
            newForm.FormBorderStyle = FormBorderStyle.None;       //���ô���Ϊ�Ǳ߿���ʽ
            newForm.Dock = System.Windows.Forms.DockStyle.Fill;   //������ʽ�Ƿ��������PANEL
            this.kryptonSplitContainerMap.Panel1.Controls.Add(newForm);
            newForm.Show();
        }

        private void initPictureBoxTitle()
        {
            ImageOperate.DrawStringToPictureBox(pictureBoxAccessList.Image, "�豸�б�", Var_Font);
            ImageOperate.DrawStringToPictureBox(pictureBoxMapList.Image,"��ͼ�б�", Var_Font);
        }
        /// <summary>
        /// ��ʾ���ӵ�ͼ�б�
        /// </summary>
        private void showlistViewElectronicMap()
        {
            listViewMapList.Clear();
            List<AccessDataBase.Model.ElectronicMap> listElectronicMap = bllElectronicMap.GetModelList("ElectronicMapID > 0");
            foreach (AccessDataBase.Model.ElectronicMap model in listElectronicMap)
            {
                string devpointname = model.ElectronicMapName;
                listViewMapList.Items.Add(devpointname, 0);
            }
        }
        /// <summary>
        /// ��ʾ�豸ͨ���б�
        /// </summary>
        private void showlistViewAccess()
        {
            listViewAccessList.Clear();
            List<AccessDataBase.Model.DoorUnitInfo> listElectronicMap = bllDoorUnitInfo.GetModelList("ElectronicMapID=0");
            foreach (AccessDataBase.Model.DoorUnitInfo model in listElectronicMap)
            {
                string devpointname = model.DoorUnitID.ToString();
                listViewAccessList.Items.Add(devpointname, 0);
            }
        }
        /// <summary>
        /// ��ͨ������ʾ��ָ�����ӵ�ͼ��
        /// </summary>
        /// <param name="mapid">���ӵ�ͼID</param>
        private void showAllAccessToElectronicMap(int mapid)
        {
            //�����ԭ�����ӵ�ͼ�ϵ�ͨ����
            for (int i = formPictureMovable.pictureBoxElectronicMap.Controls.Count - 1; i >= 0; i--)
            {
                if (formPictureMovable.pictureBoxElectronicMap.Controls[i] is PictureBox)
                    formPictureMovable.pictureBoxElectronicMap.Controls.RemoveAt(i);
            }

            // ��ͨ������ʾ��ָ�����ӵ�ͼ��
            List<AccessDataBase.Model.DoorUnitInfo> listDoorUnitInfo = bllDoorUnitInfo.GetModelList("ElectronicMapID = " + mapid);

            foreach (AccessDataBase.Model.DoorUnitInfo doorUintInfo in listDoorUnitInfo)
            {
                Point Location = new Point(0, 0);
                Location.X = doorUintInfo.PositionX.Value;
                Location.Y = doorUintInfo.PositionY.Value;
                Image buttonImage = MyImageOperate.getImageByByte(doorUintInfo.StateImageClose);

                ComponentDoorUnit doorUnit = new ComponentDoorUnit(formPictureMovable.pictureBoxElectronicMap, doorUintInfo.DoorUnitID.ToString(), (Bitmap)buttonImage, Location,1);
                formPictureMovable.pictureBoxElectronicMap.Controls.Add(doorUnit);
                doorUnit.editModeStripMenuItem_Click += new RealTimeMonitor().remoteControlToolStripMenuItem_Click;
                doorUnit.saveModeStripMenuItem_Click += new RealTimeMonitor().delAccessPointToolStripMenuItem_Click;

                doorUnit.SaveMode();
            }
        }
        

        private void initToolStripControlConsole()
        {
            string[] items = { "20%", "40%", "50%", "80%", "100%", "150%", "200%", "400%", "500%", "800%" };
            toolStripControlConsole.Items.Clear();
            ImageOperate.AddButtonItemToToolStrip(toolStripControlConsole, "update.bmp", "Update", toolStripButtonUpdateElectricMap_Click);
            ImageOperate.AddButtonItemToToolStrip(toolStripControlConsole, "MonitorOpen.bmp", "Open", toolStripButtonOpenRealWatch_Click);
            ImageOperate.AddComboBoxItemToToolStrip(toolStripControlConsole, items, "Scale", toolStripComboBoxScale_TextChanged);
        }
        private void toolStripButtonUpdateElectricMap_Click(object sender, EventArgs e)
        {
            if (modeValue == ModeValue.save)
            { 
                modeValue = ModeValue.edit;
                foreach (ComponentDoorUnit doorUint in formPictureMovable.pictureBoxElectronicMap.Controls)
                {
                    doorUint.EditMode();
                }
                ImageOperate.UpdateButtonItemToToolStrip(toolStripControlConsole, 0, "update.bmp", "Update");
            }
            else if (modeValue == ModeValue.edit)
            {
                modeValue = ModeValue.save;
                foreach (ComponentDoorUnit doorUint in formPictureMovable.pictureBoxElectronicMap.Controls)
                {
                    doorUint.SaveMode();
                    modelDoorUnitInfo.DoorUnitID = int.Parse(doorUint.Name);
                    modelDoorUnitInfo = bllDoorUnitInfo.GetModel(modelDoorUnitInfo.DoorUnitID);
                    modelElectronicMap = bllElectronicMap.GetModelList("ElectronicMapName = '" + formPictureMovable.pictureBoxElectronicMap.Name + "'")[0];
                    modelDoorUnitInfo.PositionX = doorUint.Location.X;
                    modelDoorUnitInfo.PositionY = doorUint.Location.Y;
                    modelDoorUnitInfo.ElectronicMapID = modelElectronicMap.ElectronicMapID;
                    bllDoorUnitInfo.Update(modelDoorUnitInfo);
                }
                ImageOperate.UpdateButtonItemToToolStrip(toolStripControlConsole, 0, "save.bmp", "Save");
            }
        }
        private void toolStripButtonOpenRealWatch_Click(object sender, EventArgs e)
        {
            if (realWatchState == RealWatchState.Close)
            { 
               realWatchState = RealWatchState.Open;
               ImageOperate.UpdateButtonItemToToolStrip(toolStripControlConsole, 1, "MonitorOpen.bmp","Open");
            }
            else if (realWatchState == RealWatchState.Open)
            {
                realWatchState = RealWatchState.Close;
                ImageOperate.UpdateButtonItemToToolStrip(toolStripControlConsole, 1, "MonitorPause.bmp", "Pause");
            }
        }
        private void saveElectricMap()
        {
            modeValue = ModeValue.save;

            toolStripControlConsole.Items[0].Text = "Update";
            //toolStripControlConsole.Items[0].Image = Publiclass.getToolStrip("Update.BMP");
            ImageOperate.UpdateButtonItemToToolStrip(toolStripControlConsole, 0, "update.bmp","Update");

            //toolStripStatusLabelElectronicMapMode.Text = ClassMessageBox.getStringFromRes("disTextMapMode1");


            List<KryptonAccessController.AccessDataBase.Model.ElectronicMap> listElectronicMap = bllElectronicMap.GetModelList("ElectronicMapName = '" + formPictureMovable.pictureBoxElectronicMap.Name + "'");


            
        }
        private void toolStripComboBoxScale_TextChanged(object sender, EventArgs e)
        {
            ToolStripComboBox cb = (ToolStripComboBox)(sender as ToolStripComboBox);
            saveElectricMap();

            string stringScanle = cb.SelectedItem.ToString();
            scanle = Convert.ToDouble(stringScanle.TrimEnd('%')) / 100;
            //if (electronicmapid > 0)
            //    showElectricMap(electronicmapid);
            saveElectricMap();
        }

        private void buttonFindDevicePoint_Click(object sender, EventArgs e)
        {
            
        }

        private void listViewMapList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.listViewMapList.SelectedItems.Count > 0)
            {
                //this.contextMenuStripElectronicMap.Show(listViewElectronicMap, e.Location);
                contextMenuStripElectronicMap.Items[1].Enabled = true;
                contextMenuStripElectronicMap.Items[2].Enabled = true;

            }
        }

        private void listViewMapList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e == null)
                return;

            string name = ((ListView)sender).FocusedItem.Text;
            if (name == null)
                return;

            List<KryptonAccessController.AccessDataBase.Model.ElectronicMap> listElectronicMap = bllElectronicMap.GetModelList("ElectronicMapName = '" + name + "'");

           //int electronicmapid = listElectronicMap[0].ElectronicMapID;
           if (listElectronicMap[0].Map == null)
               return;
            // ����ͼƬ֮ǰ�ȱ���ԭͼƬ
            
            MemoryStream ms = new MemoryStream(listElectronicMap[0].Map);
            Bitmap bmp = new Bitmap(ms);
            formPictureMovable.pictureBoxElectronicMap.Image = new Bitmap(ms);
            formPictureMovable.pictureBoxElectronicMap.Name = listElectronicMap[0].ElectronicMapName;
            formPictureMovable.BringToFront();
            toolStripStatusLabelElectronicMapName.Text = name;

            showAllAccessToElectronicMap(listElectronicMap[0].ElectronicMapID);
        
        }

        private void listViewMapList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripElectronicMap.Items[1].Enabled = false;
                contextMenuStripElectronicMap.Items[2].Enabled = false;
            }
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            FormElectronicMap addelectronicmap = new FormElectronicMap(null, OpenMode.Add);
            addelectronicmap.ShowDialog();

            showlistViewElectronicMap();
        }

        private void toolStripMenuItemUpdate_Click(object sender, EventArgs e)
        {
            string ElectronicMapName = listViewMapList.FocusedItem.Text;
            List<KryptonAccessController.AccessDataBase.Model.ElectronicMap> listElectronicMap = bllElectronicMap.GetModelList("ElectronicMapName = '" + ElectronicMapName + "'");


            FormElectronicMap addelectronicmap = new FormElectronicMap(listElectronicMap[0], OpenMode.Update);
            addelectronicmap.ShowDialog();

            showlistViewElectronicMap();
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void listViewAccessList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (modeValue == ModeValue.edit)
            {
                listViewAccessList.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void listViewAccessList_DragLeave(object sender, EventArgs e)
        {
            Point p1 = Cursor.Position;
            Point loca = formPictureMovable.pictureBoxElectronicMap.PointToClient(p1);
            if (loca.X > -5)
            {
                if (loca.X < 0) loca.X = 0;
                //ȡ��ͨ�����ʵ��λ��
                loca.X = Convert.ToInt32(loca.X / scanle);
                loca.Y = Convert.ToInt32(loca.Y / scanle);

                string devpointname = listViewAccessList.SelectedItems[0].Text;
                listViewAccessList.SelectedItems[0].Remove();



                ComponentDoorUnit doorUnit = new ComponentDoorUnit(formPictureMovable.pictureBoxElectronicMap, devpointname, null, loca,scanle);
                formPictureMovable.pictureBoxElectronicMap.Controls.Add(doorUnit);
                doorUnit.editModeStripMenuItem_Click += new RealTimeMonitor().remoteControlToolStripMenuItem_Click;
                doorUnit.saveModeStripMenuItem_Click += new RealTimeMonitor().delAccessPointToolStripMenuItem_Click;

                doorUnit.EditMode();

                //ģ��һ����갴���¼������ڴ�ͨ�����б����ϳ����ֱ���ƶ�ͨ����
                doorUnit.simulateDeviceMouseDown(formPictureMovable.pictureBoxElectronicMap.PointToScreen(doorUnit.Location));
                // ��ͨ������Ϣ���浽���ݿ���
                //accesspoint.saveDevicePoint(electronicmapid);
            }  
        }

        
    }
}