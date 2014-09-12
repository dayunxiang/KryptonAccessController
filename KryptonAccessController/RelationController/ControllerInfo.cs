using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using KryptonAccessController.WidgetThread;
using KryptonAccessController.Common;

namespace KryptonAccessController.RelationController
{
    public partial class ControllerInfo : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        AccessDataBase.BLL.ControllerInfo bllControllerInfo = new AccessDataBase.BLL.ControllerInfo();
        AccessDataBase.Model.ControllerInfo modelControllerInfo = new AccessDataBase.Model.ControllerInfo();

        AccessDataBase.BLL.ExpansionBoardInfo bllExpansionBoardInfo = new AccessDataBase.BLL.ExpansionBoardInfo();
        AccessDataBase.Model.ExpansionBoardInfo modelExpansionBoardInfo = new AccessDataBase.Model.ExpansionBoardInfo();

        AccessDataBase.BLL.ExpansionBoardPointInfo bllExpansionBoardPointInof = new AccessDataBase.BLL.ExpansionBoardPointInfo();
        AccessDataBase.Model.ExpansionBoardPointInfo modelExpansionBoardPointInfo = new AccessDataBase.Model.ExpansionBoardPointInfo();

        AccessDataBase.Model.DoorUnitInfo modelDoorUnitInfo = new AccessDataBase.Model.DoorUnitInfo();
        AccessDataBase.Model.DoorUnitInfo[] arraryModelDoorUnitInfo = new AccessDataBase.Model.DoorUnitInfo[4];
        AccessDataBase.BLL.DoorUnitInfo bllDoorUnitInfo = new AccessDataBase.BLL.DoorUnitInfo();

        AccessDataBase.BLL.ReaderInfo bllReaderInfo = new AccessDataBase.BLL.ReaderInfo();
        AccessDataBase.Model.ReaderInfo modelReaderInfo = new AccessDataBase.Model.ReaderInfo();

        AccessDataBase.BLL.ReaderTimeAccess bllReaderTimeAccess = new AccessDataBase.BLL.ReaderTimeAccess();
        AccessDataBase.Model.ReaderTimeAccess modelReaderTimeAccess = new AccessDataBase.Model.ReaderTimeAccess();

        AccessDataBase.BLL.ReaderHoliday bllReaderHoliday = new AccessDataBase.BLL.ReaderHoliday();
        List<AccessDataBase.Model.ReaderHoliday> listModelReaderHoliday = new List<AccessDataBase.Model.ReaderHoliday>();
        AccessDataBase.Model.ReaderHoliday modelReaderHoliday = new AccessDataBase.Model.ReaderHoliday();

        AccessDataBase.BLL.ReaderTimeZone bllReaderTimeZone = new AccessDataBase.BLL.ReaderTimeZone();
        AccessDataBase.Model.ReaderTimeZone modelReaderTimeZone = new AccessDataBase.Model.ReaderTimeZone();


        private static object obj = new object();
        static ControllerInfo _instance = null;
        public static ControllerInfo getInstance()
        {
            if (_instance == null)
            {
                lock (obj)
                {
                    if (_instance == null)
                    {
                        _instance = new ControllerInfo(); 
                    }
                }
            }
            return _instance;
        }
        private ControllerInfo()
        {
            InitializeComponent();
            //dataGridViewWithCheckBox1.updateGridviewRow += updateGridViewWithCheckBoxRow;
            initToolStripMenu();
            refreshDataGridView();

        }

        public void refreshDataGridView() 
        {
            kryptonDataGridView1.DataSource = bllControllerInfo.GetAllList().Tables[0];
            //this.refreshDataGridView();
        }
        public void initToolStripMenu()
        {
            toolStripControllerInfo.Items.Clear();

            ImageOperate.AddButtonItemToToolStrip(toolStripControllerInfo, "add.BMP", "Add", toolStripButtonAddControllerInfoInfo_Click);
            ImageOperate.AddButtonItemToToolStrip(toolStripControllerInfo, "update.BMP", "Update", toolStripButtonUpdateUserInfo_Click);
            ImageOperate.AddButtonItemToToolStrip(toolStripControllerInfo, "delete.BMP", "Del", toolStripButtonDeleteControllerInfo_Click);
            ImageOperate.AddButtonItemToToolStrip(toolStripControllerInfo, "download.BMP", "save to device", toolStripButtonDownLoadControllerInfo_Click);
 
        }
        private void toolStripButtonAddControllerInfoInfo_Click(object sender, EventArgs e)
        {
            modelControllerInfo.ControllerID = bllControllerInfo.GetMaxId();

            FormController formController = new FormController(modelControllerInfo, OpenMode.Add);
            formController.ShowDialog();

            refreshDataGridView();
        }
        /*
        public  void updateGridViewWithCheckBoxRow(object sender, DataGridViewCellEventArgs e)
        {
            if (kryptonDataGridView1.Rows.Count <= 0)
                return;
            AccessDataBase.BLL.ControllerInfo bllControllerInfo = new AccessDataBase.BLL.ControllerInfo();
            int selectIndex = kryptonDataGridView1.CurrentRow.Index;

            string controllerID = kryptonDataGridView1["ControllerID", selectIndex].Value.ToString().Trim();

            AccessDataBase.Model.ControllerInfo modelControllerInfo = bllControllerInfo.GetModel(int.Parse(controllerID));
            FormController formController = new FormController(modelControllerInfo, OpenMode.Update);
            formController.ShowDialog();

            this.refreshDataGridView();
        }*/
        private void toolStripButtonUpdateUserInfo_Click(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.CurrentRow == null)
                return;

            AccessDataBase.BLL.ControllerInfo bllControllerInfo = new AccessDataBase.BLL.ControllerInfo();
            int selectIndex = kryptonDataGridView1.CurrentRow.Index;

            string controllerID = kryptonDataGridView1["ControllerID", selectIndex].Value.ToString().Trim();

            AccessDataBase.Model.ControllerInfo modelControllerInfo = bllControllerInfo.GetModel(int.Parse(controllerID));
            FormController formController = new FormController(modelControllerInfo,OpenMode.Update);
            formController.ShowDialog();

            refreshDataGridView();
        }
        
        #region ɾ����������Ϣ
        private ReturnValue deleteControllerInfo(int controllerID)
        {
            bool ret = bllControllerInfo.Exists(controllerID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("IDΪ��" + controllerID + "�Ŀ�����������");
                return ReturnValue.NotExist;
            }

            ret = bllControllerInfo.Delete(controllerID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("ɾ����������Ϣʧ�ܣ�������IDΪ��" + controllerID);
                return ReturnValue.Fail;
            }
            return ReturnValue.Success;
        }
        #endregion

        #region ɾ����չ��˿���Ϣ
        private ReturnValue deleteExpansionBoardPointInfo(int expansionBoardInfoID)
        {
            bool ret = bllExpansionBoardInfo.Exists(expansionBoardInfoID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("IDΪ��" + expansionBoardInfoID + "����չ�岻����");
                return ReturnValue.NotExist;
            }

            ret = bllExpansionBoardPointInof.DeleteList("select ExpansionBoardPointID from ExpansionBoardPointInfo where ExpansionBoardID=" + expansionBoardInfoID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("ɾ����չ��˿���Ϣʧ�ܣ���չ��IDΪ��" + expansionBoardInfoID);
                return ReturnValue.Fail;
            }
            return ReturnValue.Success;
        }
        #endregion

        #region ɾ����չ����Ϣ
        private ReturnValue deleteExpansionBoardInfo(int expansionBoardInfoID)
        {

            bool ret = bllExpansionBoardInfo.Exists(expansionBoardInfoID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("IDΪ��" + expansionBoardInfoID + "����չ�岻����");
                return ReturnValue.NotExist;
            }
            
            ret = bllExpansionBoardInfo.Delete(expansionBoardInfoID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("ɾ����չ����Ϣʧ�ܣ���չ��IDΪ��" + expansionBoardInfoID);
                return ReturnValue.Fail;
            }
            return ReturnValue.Success;
        }
        #endregion

        #region ɾ���ŵ�Ԫ
        private ReturnValue deleteDooorUnit(int doorUnitID)
        {
            bool ret = bllDoorUnitInfo.Exists(doorUnitID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("IDΪ��" + doorUnitID + "���ŵ�Ԫ������");
                return ReturnValue.NotExist;
            }

            ret = bllDoorUnitInfo.Delete(doorUnitID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("ɾ���ŵ�Ԫ��Ϣʧ�ܣ��ŵ�ԪIDΪ��" + doorUnitID);
                return ReturnValue.Fail;
            }
            return ReturnValue.Success;
        }
        #endregion

        #region ɾ���������ڼ��չ���ģʽ��Ϣ
        private ReturnValue deleteReaderHoliday(int readerID)
        {

            bool ret = bllReaderHoliday.Exists(readerID);
            if (ret == false)
            {
                return ReturnValue.NotExist;
            }

            ret = bllReaderHoliday.DeleteList("select ReaderHolidayID from ReaderHoliday where ReaderID =" + readerID);

            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("ɾ���������ڼ�����Ϣʧ�ܣ�������IDΪ��" + readerID);
                return ReturnValue.Fail;
            }
            return ReturnValue.Success;
        }
        #endregion

        #region ɾ����������Ϣ
        private ReturnValue deleteReaderInfo(int readerInfoID)
        {
            bool ret = bllReaderInfo.Exists(readerInfoID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("IDΪ��" + readerInfoID + "�Ķ�����������");
                return ReturnValue.NotExist;
            }

            ret = bllReaderInfo.Delete(readerInfoID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("ɾ����������Ϣʧ�ܣ�������IDΪ��" + readerInfoID);
                return ReturnValue.Fail;
            }
            return ReturnValue.Success;
        }
        #endregion

        #region ɾ���������ܹ���ģʽ��Ϣ
        private ReturnValue deleteReaderTimeAccess(int readerTimeAccessID)
        {
            bool ret = bllReaderTimeAccess.Exists(readerTimeAccessID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("IDΪ��" + readerTimeAccessID + " �Ķ������ܹ���ģʽ������");
                return ReturnValue.NotExist;
            }
            
            ret = bllReaderTimeAccess.Delete(readerTimeAccessID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("ɾ���������ܹ���ģʽ��Ϣʧ�ܣ��������ܹ���ģʽIDΪ��" + readerTimeAccessID);
                return ReturnValue.Fail;
            }
            return ReturnValue.Success;
        }
        #endregion

        #region ɾ������������ʱ����
        private ReturnValue deleteReaderTimeZone(int readerTimeZoneID)
        {
            bool ret = bllReaderTimeZone.Exists(readerTimeZoneID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("IDΪ��" + readerTimeZoneID + "�Ķ���������ʱ��������");
                return ReturnValue.NotExist;
            }
            
            ret = bllReaderTimeZone.Delete(readerTimeZoneID);
            if (ret == false)
            {
                MyMessageBox.MessageBoxOK("ɾ��������ʱ����Ϣʧ�ܣ�ʱ����ϢIDΪ��" + readerTimeZoneID);
                return ReturnValue.Fail;
            }
            return ReturnValue.Success;
        }
        #endregion
        
        private void toolStripButtonDeleteControllerInfo_Click(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.CurrentRow == null)
                return;
            if (MyMessageBox.MessageBoxOkCancel("��������Ϣɾ�����ָܻ�,�Ƿ�ɾ��?") == System.Windows.Forms.DialogResult.Cancel)
                return;

            int selectIndex = kryptonDataGridView1.CurrentRow.Index;
            string controllerIDStr = kryptonDataGridView1["ControllerID", selectIndex].Value.ToString().Trim();
            int controllerIDInt;
            
            if (int.TryParse(controllerIDStr, out controllerIDInt))
            {

                #region ɾ����������Ϣ
                modelControllerInfo = bllControllerInfo.GetModel(controllerIDInt);
                if (modelControllerInfo == null)
                    return;
                deleteControllerInfo(controllerIDInt);
                #endregion

                #region ɾ����չ��

                #region ɾ����չ��1
                if (modelControllerInfo.ExpansionBoardID1.HasValue & modelControllerInfo.ExpansionBoardID1 != 0)
                {
                    deleteExpansionBoardPointInfo(modelControllerInfo.ExpansionBoardID1.Value);
                    deleteExpansionBoardInfo(modelControllerInfo.ExpansionBoardID1.Value);
                }
                #endregion

                #region ɾ����չ��2
                if (modelControllerInfo.ExpansionBoardID2.HasValue & modelControllerInfo.ExpansionBoardID2 != 0)
                {
                    deleteExpansionBoardPointInfo(modelControllerInfo.ExpansionBoardID2.Value);
                    deleteExpansionBoardInfo(modelControllerInfo.ExpansionBoardID2.Value);
                }
                #endregion

                #region ɾ����չ��3
                if (modelControllerInfo.ExpansionBoardID3.HasValue & modelControllerInfo.ExpansionBoardID3 != 0)
                {
                    deleteExpansionBoardPointInfo(modelControllerInfo.ExpansionBoardID3.Value);
                    deleteExpansionBoardInfo(modelControllerInfo.ExpansionBoardID3.Value);
                }
                #endregion

                #region ɾ����չ4
                if (modelControllerInfo.ExpansionBoardID4.HasValue & modelControllerInfo.ExpansionBoardID4 != 0)
                {
                    deleteExpansionBoardPointInfo(modelControllerInfo.ExpansionBoardID4.Value);
                    deleteExpansionBoardInfo(modelControllerInfo.ExpansionBoardID4.Value);
                }
                #endregion

                #endregion

                #region ɾ���ŵ�Ԫ1
                //ɾ���ŵ�Ԫ
                if (modelControllerInfo.DoorUnitID1.HasValue & modelControllerInfo.DoorUnitID1.Value != 0)
                {
                    modelDoorUnitInfo = bllDoorUnitInfo.GetModel(modelControllerInfo.DoorUnitID1.Value);
                    if (modelDoorUnitInfo == null)
                        return;
                    deleteDooorUnit(modelDoorUnitInfo.DoorUnitID);

                    //ɾ����������Ϣ
                    if (modelDoorUnitInfo.ReadID1.HasValue & modelDoorUnitInfo.ReadID1.Value != 0)
                    {
                        modelReaderInfo = bllReaderInfo.GetModel(modelDoorUnitInfo.ReadID1.Value);
                        if (modelReaderInfo == null)
                            return;

                        deleteReaderHoliday(modelReaderInfo.ReaderID);
                        deleteReaderInfo(modelReaderInfo.ReaderID);

                        //ɾ���������ܹ���ģʽ
                        if (modelReaderInfo.ReadTimeAccessID.HasValue & modelReaderInfo.ReadTimeAccessID.Value != 0)
                        {
                            modelReaderTimeAccess = bllReaderTimeAccess.GetModel(modelReaderInfo.ReadTimeAccessID.Value);

                            if (modelReaderTimeAccess == null)
                                return;

                            deleteReaderTimeAccess(modelReaderTimeAccess.ReaderTimeAccessID);
                            deleteReaderTimeZone(modelReaderTimeAccess.Mon.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Tue.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Wed.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Thu.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Fri.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sat.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sun.Value);

                        }

                    }
                    if (modelDoorUnitInfo.ReadID2.HasValue & modelDoorUnitInfo.ReadID2.Value != 0)
                    {
                        modelReaderInfo = bllReaderInfo.GetModel(modelDoorUnitInfo.ReadID2.Value);
                        if (modelReaderInfo == null)
                            return;

                        deleteReaderHoliday(modelReaderInfo.ReaderID);
                        deleteReaderInfo(modelReaderInfo.ReaderID);
                        //ɾ���������ܹ���ģʽ
                        if (modelReaderInfo.ReadTimeAccessID.HasValue & modelReaderInfo.ReadTimeAccessID.Value != 0)
                        {
                            modelReaderTimeAccess = bllReaderTimeAccess.GetModel(modelReaderInfo.ReadTimeAccessID.Value);
                            if (modelReaderTimeAccess == null)
                                return;

                            deleteReaderTimeAccess(modelReaderTimeAccess.ReaderTimeAccessID);
                            deleteReaderTimeZone(modelReaderTimeAccess.Mon.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Tue.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Wed.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Thu.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Fri.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sat.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sun.Value);

                        }
                    }
                }

                #endregion

                #region ɾ���ŵ�Ԫ2
                //ɾ���ŵ�Ԫ
                if (modelControllerInfo.DoorUnitID2.HasValue & modelControllerInfo.DoorUnitID2.Value != 0)
                {
                    modelDoorUnitInfo = bllDoorUnitInfo.GetModel(modelControllerInfo.DoorUnitID2.Value);
                    if (modelDoorUnitInfo == null)
                        return;
                    deleteDooorUnit(modelDoorUnitInfo.DoorUnitID);

                    //ɾ����������Ϣ
                    if (modelDoorUnitInfo.ReadID1.HasValue & modelDoorUnitInfo.ReadID1.Value != 0)
                    {
                        modelReaderInfo = bllReaderInfo.GetModel(modelDoorUnitInfo.ReadID1.Value);
                        if (modelReaderInfo == null)
                            return;

                        deleteReaderHoliday(modelReaderInfo.ReaderID);
                        deleteReaderInfo(modelReaderInfo.ReaderID);

                        //ɾ���������ܹ���ģʽ
                        if (modelReaderInfo.ReadTimeAccessID.HasValue & modelReaderInfo.ReadTimeAccessID.Value != 0)
                        {
                            modelReaderTimeAccess = bllReaderTimeAccess.GetModel(modelReaderInfo.ReadTimeAccessID.Value);

                            if (modelReaderTimeAccess == null)
                                return;

                            deleteReaderTimeAccess(modelReaderTimeAccess.ReaderTimeAccessID);
                            deleteReaderTimeZone(modelReaderTimeAccess.Mon.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Tue.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Wed.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Thu.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Fri.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sat.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sun.Value);

                        }

                    }
                    if (modelDoorUnitInfo.ReadID2.HasValue & modelDoorUnitInfo.ReadID2.Value != 0)
                    {
                        modelReaderInfo = bllReaderInfo.GetModel(modelDoorUnitInfo.ReadID2.Value);
                        if (modelReaderInfo == null)
                            return;

                        deleteReaderHoliday(modelReaderInfo.ReaderID);
                        deleteReaderInfo(modelReaderInfo.ReaderID);
                        //ɾ���������ܹ���ģʽ
                        if (modelReaderInfo.ReadTimeAccessID.HasValue & modelReaderInfo.ReadTimeAccessID.Value != 0)
                        {
                            modelReaderTimeAccess = bllReaderTimeAccess.GetModel(modelReaderInfo.ReadTimeAccessID.Value);
                            if (modelReaderTimeAccess == null)
                                return;

                            deleteReaderTimeAccess(modelReaderTimeAccess.ReaderTimeAccessID);
                            deleteReaderTimeZone(modelReaderTimeAccess.Mon.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Tue.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Wed.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Thu.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Fri.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sat.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sun.Value);

                        }
                    }
                }
                #endregion

                #region ɾ���ŵ�Ԫ3
                //ɾ���ŵ�Ԫ
                if (modelControllerInfo.DoorUnitID3.HasValue & modelControllerInfo.DoorUnitID3.Value != 0)
                {
                    modelDoorUnitInfo = bllDoorUnitInfo.GetModel(modelControllerInfo.DoorUnitID3.Value);
                    if (modelDoorUnitInfo == null)
                        return;
                    deleteDooorUnit(modelDoorUnitInfo.DoorUnitID);

                    //ɾ����������Ϣ
                    if (modelDoorUnitInfo.ReadID1.HasValue & modelDoorUnitInfo.ReadID1.Value != 0)
                    {
                        modelReaderInfo = bllReaderInfo.GetModel(modelDoorUnitInfo.ReadID1.Value);
                        if (modelReaderInfo == null)
                            return;

                        deleteReaderHoliday(modelReaderInfo.ReaderID);
                        deleteReaderInfo(modelReaderInfo.ReaderID);

                        //ɾ���������ܹ���ģʽ
                        if (modelReaderInfo.ReadTimeAccessID.HasValue & modelReaderInfo.ReadTimeAccessID.Value != 0)
                        {
                            modelReaderTimeAccess = bllReaderTimeAccess.GetModel(modelReaderInfo.ReadTimeAccessID.Value);

                            if (modelReaderTimeAccess == null)
                                return;

                            deleteReaderTimeAccess(modelReaderTimeAccess.ReaderTimeAccessID);
                            deleteReaderTimeZone(modelReaderTimeAccess.Mon.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Tue.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Wed.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Thu.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Fri.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sat.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sun.Value);

                        }

                    }
                    if (modelDoorUnitInfo.ReadID2.HasValue & modelDoorUnitInfo.ReadID2.Value != 0)
                    {
                        modelReaderInfo = bllReaderInfo.GetModel(modelDoorUnitInfo.ReadID2.Value);
                        if (modelReaderInfo == null)
                            return;

                        deleteReaderHoliday(modelReaderInfo.ReaderID);
                        deleteReaderInfo(modelReaderInfo.ReaderID);
                        //ɾ���������ܹ���ģʽ
                        if (modelReaderInfo.ReadTimeAccessID.HasValue & modelReaderInfo.ReadTimeAccessID.Value != 0)
                        {
                            modelReaderTimeAccess = bllReaderTimeAccess.GetModel(modelReaderInfo.ReadTimeAccessID.Value);
                            if (modelReaderTimeAccess == null)
                                return;

                            deleteReaderTimeAccess(modelReaderTimeAccess.ReaderTimeAccessID);
                            deleteReaderTimeZone(modelReaderTimeAccess.Mon.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Tue.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Wed.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Thu.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Fri.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sat.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sun.Value);

                        }
                    }
                }
                #endregion

                #region ɾ���ŵ�Ԫ4
                //ɾ���ŵ�Ԫ
                if (modelControllerInfo.DoorUnitID4.HasValue & modelControllerInfo.DoorUnitID4.Value != 0)
                {
                    modelDoorUnitInfo = bllDoorUnitInfo.GetModel(modelControllerInfo.DoorUnitID4.Value);
                    if (modelDoorUnitInfo == null)
                        return;
                    deleteDooorUnit(modelDoorUnitInfo.DoorUnitID);

                    //ɾ����������Ϣ
                    if (modelDoorUnitInfo.ReadID1.HasValue & modelDoorUnitInfo.ReadID1.Value != 0)
                    {
                        modelReaderInfo = bllReaderInfo.GetModel(modelDoorUnitInfo.ReadID1.Value);
                        if (modelReaderInfo == null)
                            return;

                        deleteReaderHoliday(modelReaderInfo.ReaderID);
                        deleteReaderInfo(modelReaderInfo.ReaderID);

                        //ɾ���������ܹ���ģʽ
                        if (modelReaderInfo.ReadTimeAccessID.HasValue & modelReaderInfo.ReadTimeAccessID.Value != 0)
                        {
                            modelReaderTimeAccess = bllReaderTimeAccess.GetModel(modelReaderInfo.ReadTimeAccessID.Value);

                            if (modelReaderTimeAccess == null)
                                return;

                            deleteReaderTimeAccess(modelReaderTimeAccess.ReaderTimeAccessID);
                            deleteReaderTimeZone(modelReaderTimeAccess.Mon.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Tue.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Wed.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Thu.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Fri.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sat.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sun.Value);

                        }

                    }
                    if (modelDoorUnitInfo.ReadID2.HasValue & modelDoorUnitInfo.ReadID2.Value != 0)
                    {
                        modelReaderInfo = bllReaderInfo.GetModel(modelDoorUnitInfo.ReadID2.Value);
                        if (modelReaderInfo == null)
                            return;

                        deleteReaderHoliday(modelReaderInfo.ReaderID);
                        deleteReaderInfo(modelReaderInfo.ReaderID);
                        //ɾ���������ܹ���ģʽ
                        if (modelReaderInfo.ReadTimeAccessID.HasValue & modelReaderInfo.ReadTimeAccessID.Value != 0)
                        {
                            modelReaderTimeAccess = bllReaderTimeAccess.GetModel(modelReaderInfo.ReadTimeAccessID.Value);
                            if (modelReaderTimeAccess == null)
                                return;

                            deleteReaderTimeAccess(modelReaderTimeAccess.ReaderTimeAccessID);
                            deleteReaderTimeZone(modelReaderTimeAccess.Mon.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Tue.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Wed.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Thu.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Fri.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sat.Value);
                            deleteReaderTimeZone(modelReaderTimeAccess.Sun.Value);

                        }
                    }
                }
                #endregion

                
            }
            refreshDataGridView();
        }
        private void toolStripButtonDownLoadControllerInfo_Click(object sender, EventArgs e)
        {
            AccessDataBase.BLL.ControllerInfo bllControllerInfo = new AccessDataBase.BLL.ControllerInfo();
            if (MyMessageBox.MessageBoxOkCancel("���ؿ�������Ϣ���豸?") == System.Windows.Forms.DialogResult.Cancel)
                return;
            int selectIndex = kryptonDataGridView1.CurrentRow.Index;
            string controllerID = kryptonDataGridView1["ControllerID", selectIndex].Value.ToString().Trim();

            AccessDataBase.Model.ControllerInfo modelControllerInfo = bllControllerInfo.GetModel(int.Parse(controllerID));

            int doorUnitCounts =    (modelControllerInfo.DoorUnitEnable1 == true ? 1 : 0) +
                                    (modelControllerInfo.DoorUnitEnable2 == true ? 1 : 0) +
                                    (modelControllerInfo.DoorUnitEnable3 == true ? 1 : 0) +
                                    (modelControllerInfo.DoorUnitEnable4 == true ? 1 : 0);
            int expansionBoardCounts =
                (modelControllerInfo.ExpansionBoardEnable1 == true ? 1 : 0) +
                (modelControllerInfo.ExpansionBoardEnable2 == true ? 1 : 0) +
                (modelControllerInfo.ExpansionBoardEnable3 == true ? 1 : 0) +
                (modelControllerInfo.ExpansionBoardEnable4 == true ? 1 : 0);
           
            string data = 
                "ControllerID=" + modelControllerInfo.ControllerID+","+
                "ControllerType="+modelControllerInfo.ControllerType+","+
                "ControllerName='"+modelControllerInfo.ControllerName+"',"+
                "ControllerLocation='"+modelControllerInfo.ControllerLocation+"',"+
                "EncryptionType="+modelControllerInfo.CommunicateType+","+
                "ControllerVersion='"+modelControllerInfo.ControllerVersion+"',"+
                "ControllerMAC='"+modelControllerInfo.ControllerMAC+"',"+
                "ControllerIP='"+modelControllerInfo.ControllerIP+"',"+
                "ControllerSubnetMask='"+modelControllerInfo.ControllerSubnetMask+"',"+
                "ControllerGateway='"+modelControllerInfo.ControllerGateway+"',"+
                "ControllerPort="+modelControllerInfo.ControllerPort+","+
                "ControllerDNS='"+modelControllerInfo.ControllerDNS+"',"+
                "ControllerBUDNS='"+modelControllerInfo.ControllerBUDNS+"',"+
                "ControllerAddr485="+modelControllerInfo.ControllerAddr485+","+
                "ControllerBaudrate="+modelControllerInfo.ControllerBaudrate+","+
                "ControllerDataBits="+modelControllerInfo.ControllerDataBits+","+
                //"ControllerStopBits="+modelControllerInfo.ControllerStopBits+","+
                "ControllerStopBits=" + 1 + "," +
                "ControllerParityCheck='"+modelControllerInfo.ControllerParityCheck+"',"+
                "ControllerFlowControl='"+modelControllerInfo.ControllerFlowControl+"',"+
                "ControllerSAM="+modelControllerInfo.ControllerSAM+","+
                "ControllerSAMType="+modelControllerInfo.ControllerSAMType+","+
                "DoorUnitCounts=" + doorUnitCounts+ "," +
                "ExpansionBoardCounts=" + expansionBoardCounts;
            /*
             * ����API����
             */

        }

        private void kryptonDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void ControllerInfo_Load(object sender, EventArgs e)
        {

        }
    }
}