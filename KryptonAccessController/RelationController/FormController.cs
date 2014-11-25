using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using KryptonAccessController.ResourcesFile;
using KryptonAccessController.Common;
using KryptonAccessController.AccessDataBase;

namespace KryptonAccessController.RelationController
{
    public partial class FormController : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private AccessDataBase.Model.ControllerInfo modelControllerInfo = new AccessDataBase.Model.ControllerInfo();
        private AccessDataBase.BLL.ControllerInfo bllControllerInfo = new AccessDataBase.BLL.ControllerInfo();
        
        private AccessDataBase.BLL.DoorUnitInfo bllDoorUnitInfo = new AccessDataBase.BLL.DoorUnitInfo();
        private AccessDataBase.Model.DoorUnitInfo[] arrayDoorUnitInfo = new AccessDataBase.Model.DoorUnitInfo[4];

        private AccessDataBase.BLL.ReaderInfo bllReaderInfo = new AccessDataBase.BLL.ReaderInfo();
        private AccessDataBase.Model.ReaderInfo modelReaderInfo = new AccessDataBase.Model.ReaderInfo();
        //private AccessDataBase.Model.ReaderInfo[] arraryReaderInfo = new AccessDataBase.Model.ReaderInfo[8];

        private AccessDataBase.BLL.ReaderTimeZone bllReaderTimeZone = new AccessDataBase.BLL.ReaderTimeZone();
        private AccessDataBase.Model.ReaderTimeZone modelReaderTimeZone = new AccessDataBase.Model.ReaderTimeZone();

        private AccessDataBase.BLL.ReaderTimeAccess bllReaderTimeAccess = new AccessDataBase.BLL.ReaderTimeAccess();
        private AccessDataBase.Model.ReaderTimeAccess modelReaderTimeAccess = new AccessDataBase.Model.ReaderTimeAccess();

        private OpenMode openMode;
        public FormController(AccessDataBase.Model.ControllerInfo ModelControllerInfo, OpenMode openMode)
        {
            InitializeComponent();

            doorUnit1.KryptonButtonReaderAdd1.Click += KryptonButtonReaderAddClick1;
            doorUnit1.KryptonButtonReaderAdd2.Click += KryptonButtonReaderAddClick1;
            doorUnit1.KryptonButtonReaderUpdate1.Click += KryptonButtonReaderUpdateClick1;
            doorUnit1.KryptonButtonReaderUpdate2.Click += KryptonButtonReaderUpdateClick1;
            doorUnit1.KryptonCheckBoxReader1.CheckedChanged += KryptonCheckBoxReaderCheckedChanged1;
            doorUnit1.KryptonCheckBoxReader2.CheckedChanged += KryptonCheckBoxReaderCheckedChanged1;

            doorUnit2.KryptonButtonReaderAdd1.Click += KryptonButtonReaderAddClick1;
            doorUnit2.KryptonButtonReaderAdd2.Click += KryptonButtonReaderAddClick1;
            doorUnit2.KryptonButtonReaderUpdate1.Click += KryptonButtonReaderUpdateClick2;
            doorUnit2.KryptonButtonReaderUpdate2.Click += KryptonButtonReaderUpdateClick2;
            doorUnit2.KryptonCheckBoxReader1.CheckedChanged += KryptonCheckBoxReaderCheckedChanged2;
            doorUnit2.KryptonCheckBoxReader2.CheckedChanged += KryptonCheckBoxReaderCheckedChanged2;

            doorUnit3.KryptonButtonReaderAdd1.Click += KryptonButtonReaderAddClick1;
            doorUnit3.KryptonButtonReaderAdd2.Click += KryptonButtonReaderAddClick1;
            doorUnit3.KryptonButtonReaderUpdate1.Click += KryptonButtonReaderUpdateClick3;
            doorUnit3.KryptonButtonReaderUpdate2.Click += KryptonButtonReaderUpdateClick3;
            doorUnit3.KryptonCheckBoxReader1.CheckedChanged += KryptonCheckBoxReaderCheckedChanged3;
            doorUnit3.KryptonCheckBoxReader2.CheckedChanged += KryptonCheckBoxReaderCheckedChanged3;

            doorUnit4.KryptonButtonReaderAdd1.Click += KryptonButtonReaderAddClick4;
            doorUnit4.KryptonButtonReaderAdd2.Click += KryptonButtonReaderAddClick4;
            doorUnit4.KryptonButtonReaderUpdate1.Click += KryptonButtonReaderUpdateClick4;
            doorUnit4.KryptonButtonReaderUpdate2.Click += KryptonButtonReaderUpdateClick4;
            doorUnit4.KryptonCheckBoxReader1.CheckedChanged += KryptonCheckBoxReaderCheckedChanged4;
            doorUnit4.KryptonCheckBoxReader2.CheckedChanged += KryptonCheckBoxReaderCheckedChanged4;
            
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = GetResourcesFile.getSystemIco();

            this.modelControllerInfo = ModelControllerInfo;
            this.openMode = openMode;
            for (int i = 0; i < 4;i++ )
                arrayDoorUnitInfo[i] = new AccessDataBase.Model.DoorUnitInfo();

            if (openMode == OpenMode.Add)
            {
                showAddPara();
            }
            else if (openMode == OpenMode.Update)
            {
                showUpdatePara();
            }
        }
        private void showAddPara()
        {
            #region ��������
            kryptonTextBoxControllerID.Text = modelControllerInfo.ControllerID.ToString();
            kryptonTextBoxControllerName.Text = "������" + modelControllerInfo.ControllerID.ToString();
            kryptonComboBoxControllerType.SelectedIndex = 0;
            kryptonTextBoxControllerLoaction.Text = "Ĭ�ϵ�ַ";
            kryptonTextBoxControllerVersion.Text = "V20140321";
            #endregion

            #region ͨѶ����
            kryptonCheckBoxCommunicateTypeTCP.Checked = true;
            kryptonGroupBoxTCP.Enabled = true;

            kryptonCheckBoxCommunicateType485.Checked = false;
            kryptonGroupBox485.Enabled = false;

            textBoxNewDeviceIP.Text = "192.168.1.100";
            textBoxMask.Text = "255.255.255.0";
            textBoxGateway.Text = "192.168.1.1";
            textBoxMAC.Text = "";
            textBoxDNS.Text = "8.8.8.8" ;
            kryptonTextBoxBackUpDNS.Text = "192.168.1.1";
            ///���RS485 ����
            #endregion ͨѶ����

            #region ������Ԫ
            kryptonComboBoxInputStateType0.SelectedIndex = 1;
            kryptonTextBoxAuxOutPutPoint.Text = "10";
            kryptonTextBoxFireSensing.Text = "10";
            kryptonTextBoxTamperSensing.Text = "11";
            kryptonTextBoxLowVoltage.Text = "12";
            kryptonTextBoxPowerOutage.Text = "13";
            #endregion ������Ԫ

            #region �ŵ�Ԫ1
            kryptonCheckBoxDoorUnitEnable1.Checked = true;
            doorUnit1.KryptonGroupBoxDoorUnit.Panel.Enabled = true;
            doorUnit1.KryptonTextBoxOutPoint.Text = "01";
            doorUnit1.KryptonTextBoxExitButton.Text = "01";
            doorUnit1.KryptonTextBoxDoorContact.Text = "02";
            doorUnit1.KryptonTextBoxDoorPosition.Text = "03";
            doorUnit1.KryptonTextBoxBreakGlass.Text = "04";
            doorUnit1.KryptonTextBoxReader1.Text = bllReaderInfo.GetMaxId().ToString();
            doorUnit1.KryptonTextBoxReader2.Text = (bllReaderInfo.GetMaxId() + 1).ToString();
            #endregion �ŵ�Ԫ1

            #region �ŵ�Ԫ2
            kryptonCheckBoxDoorUnitEnable2.Checked = true;
            doorUnit2.KryptonGroupBoxDoorUnit.Panel.Enabled = true;
            doorUnit2.KryptonTextBoxOutPoint.Text = "02";
            doorUnit2.KryptonTextBoxExitButton.Text = "05";
            doorUnit2.KryptonTextBoxDoorContact.Text = "06";
            doorUnit2.KryptonTextBoxDoorPosition.Text = "07";
            doorUnit2.KryptonTextBoxBreakGlass.Text = "08";
            doorUnit2.KryptonTextBoxReader1.Text = (bllReaderInfo.GetMaxId() + 2).ToString();
            doorUnit2.KryptonTextBoxReader2.Text = (bllReaderInfo.GetMaxId() + 3).ToString();
            #endregion �ŵ�Ԫ2

            #region �ŵ�Ԫ3
            kryptonCheckBoxDoorUnitEnable3.Checked = false;
            doorUnit3.KryptonGroupBoxDoorUnit.Panel.Enabled = false;
            doorUnit3.KryptonTextBoxOutPoint.Text = "03";
            doorUnit3.KryptonTextBoxExitButton.Text = "11";
            doorUnit3.KryptonTextBoxDoorContact.Text = "12";
            doorUnit3.KryptonTextBoxDoorPosition.Text = "13";
            doorUnit3.KryptonTextBoxBreakGlass.Text = "14";
            doorUnit3.KryptonTextBoxReader1.Text = (bllReaderInfo.GetMaxId() + 4).ToString();
            doorUnit3.KryptonTextBoxReader2.Text = (bllReaderInfo.GetMaxId() + 5).ToString();
            #endregion �ŵ�Ԫ3

            #region �ŵ�Ԫ4
            kryptonCheckBoxDoorUnitEnable4.Checked = false;
            doorUnit4.KryptonGroupBoxDoorUnit.Panel.Enabled = false;
            doorUnit4.KryptonTextBoxOutPoint.Text = "04";
            doorUnit4.KryptonTextBoxExitButton.Text = "15";
            doorUnit4.KryptonTextBoxDoorContact.Text = "16";
            doorUnit4.KryptonTextBoxDoorPosition.Text = "17";
            doorUnit4.KryptonTextBoxBreakGlass.Text = "18";
            doorUnit4.KryptonTextBoxReader1.Text = (bllReaderInfo.GetMaxId() + 6).ToString();
            doorUnit4.KryptonTextBoxReader2.Text = (bllReaderInfo.GetMaxId() + 7).ToString();
            #endregion �ŵ�Ԫ4

            #region ����IO
            #endregion ����IO

            #region ��չIO1
            #endregion ��չIO1

            #region ��չIO2
            #endregion ��չIO2

            #region ��չIO3
            #endregion ��չIO3

            #region ��չIO4
            #endregion ��չIO4
        }
        private void showDoorUnitControl(ref MyComponents.DoorUnit doorUnit,KryptonAccessController.AccessDataBase.Model.DoorUnitInfo modelDoorUnit)
        {
            doorUnit.KryptonComboBoxInputStateType.SelectedIndex = modelDoorUnit.InputStateType == 2 ? 0 : 1;
            doorUnit.KryptonTextBoxOutPoint.Text = modelDoorUnit.OutPutLockID.ToString();
            doorUnit.KryptonTextBoxExitButton.Text = modelDoorUnit.ExitButtonID.ToString();
            doorUnit.KryptonTextBoxDoorContact.Text = modelDoorUnit.DoorContactID.ToString();
            doorUnit.KryptonTextBoxDoorPosition.Text = modelDoorUnit.DoorPositionID.ToString();
            doorUnit.KryptonTextBoxBreakGlass.Text = modelDoorUnit.BreakGlassID.ToString();
            doorUnit.KryptonTextBoxReader1.Text = modelDoorUnit.ReadID1.ToString();
            doorUnit.KryptonTextBoxReader2.Text = modelDoorUnit.ReadID2.ToString();
        }
        private void showDoorUnitControlNull(ref MyComponents.DoorUnit doorUnit) 
        {
            doorUnit.KryptonTextBoxOutPoint.Text = null;
            doorUnit.KryptonTextBoxExitButton.Text = null;
            doorUnit.KryptonTextBoxDoorContact.Text = null;
            doorUnit.KryptonTextBoxDoorPosition.Text = null;
            doorUnit.KryptonTextBoxBreakGlass.Text = null;
            doorUnit.KryptonTextBoxReader1.Text = null;
            doorUnit.KryptonTextBoxReader2.Text = null;
        }
        private void showUpdatePara()
        {
            #region ��������
            kryptonTextBoxControllerID.Text = modelControllerInfo.ControllerID.ToString();
            kryptonTextBoxControllerName.Text = modelControllerInfo.ControllerName.Trim();
            kryptonComboBoxControllerType.SelectedIndex = modelControllerInfo.ControllerType.HasValue ? modelControllerInfo.ControllerType.Value - 1 : 0;
            kryptonTextBoxControllerLoaction.Text = modelControllerInfo.ControllerLocation.Trim();
            kryptonTextBoxControllerVersion.Text = modelControllerInfo.ControllerVersion.Trim();
            #endregion ��������

            #region ͨѶ����
            if (modelControllerInfo.CommunicateType == 1)
            {
                kryptonCheckBoxCommunicateTypeTCP.Checked = true;
                textBoxNewDeviceIP.Text = modelControllerInfo.ControllerIP;
                textBoxMask.Text = modelControllerInfo.ControllerSubnetMask;
                textBoxGateway.Text = modelControllerInfo.ControllerGateway;
                textBoxMAC.Text = modelControllerInfo.ControllerMAC;
                textBoxDNS.Text = modelControllerInfo.ControllerDNS;
                kryptonTextBoxBackUpDNS.Text = modelControllerInfo.ControllerBUDNS;

                kryptonCheckBoxCommunicateType485.Checked = false;
                kryptonGroupBox485.Enabled = false;
            }
            else if (modelControllerInfo.CommunicateType == 2)
            {
                kryptonCheckBoxCommunicateTypeTCP.Checked = false;
                kryptonGroupBoxTCP.Enabled = false;

                kryptonCheckBoxCommunicateType485.Checked = true;
                kryptonTextBoxControllerAddr485.Text = modelControllerInfo.ControllerAddr485.ToString();
                kryptonTextBoxControllerBaudrate.Text = modelControllerInfo.ControllerBaudrate.ToString();
                kryptonTextBoxControllerDataBits.Text = modelControllerInfo.ControllerDataBits.ToString();
            }
            else
            {
                kryptonCheckBoxCommunicateTypeTCP.Checked = true;
                textBoxNewDeviceIP.Text = modelControllerInfo.ControllerIP;
                textBoxMask.Text = modelControllerInfo.ControllerSubnetMask;
                textBoxGateway.Text = modelControllerInfo.ControllerGateway;
                textBoxMAC.Text = modelControllerInfo.ControllerMAC;
                textBoxDNS.Text = modelControllerInfo.ControllerDNS;
                kryptonTextBoxBackUpDNS.Text = modelControllerInfo.ControllerBUDNS;

                kryptonCheckBoxCommunicateType485.Checked = true;
                kryptonCheckBoxCommunicateType485.Checked = true;
                kryptonTextBoxControllerAddr485.Text = modelControllerInfo.ControllerAddr485.ToString();
                kryptonTextBoxControllerBaudrate.Text = modelControllerInfo.ControllerBaudrate.ToString();
                kryptonTextBoxControllerDataBits.Text = modelControllerInfo.ControllerDataBits.ToString();

            }
            #endregion ͨѶ����

            #region ������Ԫ
            kryptonComboBoxInputStateType0.SelectedIndex = modelControllerInfo.InputStateType == 2 ? 0 : 1;
            kryptonTextBoxAuxOutPutPoint.Text = modelControllerInfo.AuxOutPutPointID.ToString();
            kryptonTextBoxFireSensing.Text = modelControllerInfo.FireSensingID.ToString();
            kryptonTextBoxTamperSensing.Text = modelControllerInfo.TamperSensingID.ToString();
            kryptonTextBoxLowVoltage.Text = modelControllerInfo.LowVoltageID.ToString();
            kryptonTextBoxPowerOutage.Text = modelControllerInfo.PowerOutageID.ToString();
            #endregion ������Ԫ

            #region �ŵ�Ԫ1
            kryptonCheckBoxDoorUnitEnable1.Checked = modelControllerInfo.DoorUnitEnable1;
            
            if (modelControllerInfo.DoorUnitID1.HasValue)
            {
                List<KryptonAccessController.AccessDataBase.Model.DoorUnitInfo> listDoorUnitInfo = bllDoorUnitInfo.GetModelList("DoorUnitID = " + modelControllerInfo.DoorUnitID1.Value);
                if (listDoorUnitInfo.Count >0)
                {
                    arrayDoorUnitInfo[0] = listDoorUnitInfo[0];
                    showDoorUnitControl(ref doorUnit1, arrayDoorUnitInfo[0]);
                }
                
            }
            else 
            {
                kryptonCheckBoxDoorUnitEnable1.Checked = false;
                showDoorUnitControlNull(ref doorUnit1);
            }
            #endregion �ŵ�Ԫ1

            #region �ŵ�Ԫ2
            kryptonCheckBoxDoorUnitEnable2.Checked = modelControllerInfo.DoorUnitEnable2;

            if (modelControllerInfo.DoorUnitID2.HasValue)
            {
                List<KryptonAccessController.AccessDataBase.Model.DoorUnitInfo> listDoorUnitInfo = bllDoorUnitInfo.GetModelList("DoorUnitID = " + modelControllerInfo.DoorUnitID2.Value);
                if (listDoorUnitInfo.Count > 0)
                {
                    arrayDoorUnitInfo[1] = listDoorUnitInfo[0];
                    showDoorUnitControl(ref doorUnit2, arrayDoorUnitInfo[1]);
                }
            }
            else
            {
                kryptonCheckBoxDoorUnitEnable2.Checked = false;
                showDoorUnitControlNull(ref doorUnit2);
            }
            #endregion �ŵ�Ԫ2

            #region �ŵ�Ԫ3
            kryptonCheckBoxDoorUnitEnable3.Checked = modelControllerInfo.DoorUnitEnable3;

            if (modelControllerInfo.DoorUnitID3.HasValue)
            {
                List<KryptonAccessController.AccessDataBase.Model.DoorUnitInfo> listDoorUnitInfo = bllDoorUnitInfo.GetModelList("DoorUnitID = " + modelControllerInfo.DoorUnitID3.Value);
                if (listDoorUnitInfo.Count>0)
                {
                    arrayDoorUnitInfo[2] = listDoorUnitInfo[0];
                    showDoorUnitControl(ref doorUnit3, arrayDoorUnitInfo[2]);
                }
            }
            else
            {
                kryptonCheckBoxDoorUnitEnable3.Checked = false;
                showDoorUnitControlNull(ref doorUnit3);
            }
            #endregion �ŵ�Ԫ3

            #region �ŵ�Ԫ4
             kryptonCheckBoxDoorUnitEnable4.Checked = modelControllerInfo.DoorUnitEnable4;

             if (modelControllerInfo.DoorUnitID4.HasValue)
             {
                 List<KryptonAccessController.AccessDataBase.Model.DoorUnitInfo> listDoorUnitInfo = bllDoorUnitInfo.GetModelList("DoorUnitID = " + modelControllerInfo.DoorUnitID4.Value);
                 if (listDoorUnitInfo.Count > 0)
                 {
                     arrayDoorUnitInfo[3] = listDoorUnitInfo[0];
                     showDoorUnitControl(ref doorUnit4, arrayDoorUnitInfo[3]);
                 }
             }
             else
             {
                 kryptonCheckBoxDoorUnitEnable4.Checked = false;
                 showDoorUnitControlNull(ref doorUnit4);
             }
            #endregion �ŵ�Ԫ4

            #region ����IO
            #endregion ����IO

            #region ��չIO1
            #endregion ��չIO1

            #region ��չIO2
            #endregion ��չIO2

            #region ��չIO3
            #endregion ��չIO3

            #region ��չIO4
            #endregion ��չIO4

        }

        private void kryptonButtonControllerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// ����ͼ�ؼ��л�ȡ�ŵ�Ԫ��Ϣ
        /// </summary>
        /// <param name="doorUnit"></param>
        /// <returns>�ŵ�Ԫ��Ϣ</returns>
        private void getModelDoorUnitInfo(ref AccessDataBase.Model.DoorUnitInfo modelDoorUnitInfo, MyComponents.DoorUnit doorUnit)
        {
            #region ������Ϣ
            modelDoorUnitInfo.DoorUnitID = bllDoorUnitInfo.GetMaxId();
            modelDoorUnitInfo.OutPutLockID = int.Parse(doorUnit.KryptonTextBoxOutPoint.Text.ToString());
            //modelDoorUnitInfo.OutPutTimeLeng;
            //modelDoorUnitInfo.OpenDoorOverTimeLen;
            //modelDoorUnitInfo.AccessCapacityEnable;
            //modelDoorUnitInfo.AccessCapacityMax;
            //modelDoorUnitInfo.AccessCapacityMin;
            #endregion

            #region ��������Ϣ
            modelDoorUnitInfo.ReadID1 = int.Parse(doorUnit.KryptonTextBoxReader1.Text.ToString());
            modelDoorUnitInfo.ReadIDEnable1 = doorUnit.KryptonCheckBoxReader1.Checked;
            modelDoorUnitInfo.ReadID2 = int.Parse(doorUnit.KryptonTextBoxReader2.Text.ToString());
            modelDoorUnitInfo.ReadIDEnable2 = doorUnit.KryptonCheckBoxReader2.Checked;
            #endregion

            #region �������Ϣ
            modelDoorUnitInfo.InputStateType = doorUnit.KryptonComboBoxInputStateType.SelectedIndex;
            
            modelDoorUnitInfo.ExitButtonID = int.Parse(doorUnit.KryptonTextBoxExitButton.Text.ToString());
            //modelDoorUnitInfo.ExitButtonMode;
            //modelDoorUnitInfo.ExtiButtonEnable;

            modelDoorUnitInfo.DoorContactID = int.Parse(doorUnit.KryptonTextBoxDoorContact.Text.ToString());
            //modelDoorUnitInfo.DoorContactMode;
            //modelDoorUnitInfo.DoorPositionEnable;

            modelDoorUnitInfo.DoorPositionID = int.Parse(doorUnit.KryptonTextBoxDoorPosition.Text.ToString());
            //modelDoorUnitInfo.DoorPositionMode;
            //modelDoorUnitInfo.DoorPositionEnable;

            modelDoorUnitInfo.BreakGlassID = int.Parse(doorUnit.KryptonTextBoxBreakGlass.Text.ToString());
            //modelDoorUnitInfo.BreakGlassMode;
            //modelDoorUnitInfo.BreakGlassEnable;
            #endregion

            #region ���ӵ�ͼ
            //modelDoorUnitInfo.ElectronicMapID;
            //modelDoorUnitInfo.PositionX;
            //modelDoorUnitInfo.PositionY;
            //modelDoorUnitInfo.StateImageOpen;
            //modelDoorUnitInfo.StateImageClose;
            //modelDoorUnitInfo.StateImageAlarmOpen;
            //modelDoorUnitInfo.StateImageAlarmClose;
            #endregion
        }
        
        private int addDefaultReaderTimeAccess()
        {
            
            modelReaderTimeAccess.ReaderTimeAccessID = bllReaderTimeAccess.GetMaxId();
            modelReaderTimeAccess.ReaderTimeAccessName = "";

            modelReaderTimeZone.ReaderTimeZoneID = bllReaderTimeZone.GetMaxId();
            bllReaderTimeZone.Add(modelReaderTimeZone);
            modelReaderTimeAccess.Mon = modelReaderTimeZone.ReaderTimeZoneID;

            modelReaderTimeZone.ReaderTimeZoneID = bllReaderTimeZone.GetMaxId();
            bllReaderTimeZone.Add(modelReaderTimeZone);
            modelReaderTimeAccess.Tue = modelReaderTimeZone.ReaderTimeZoneID;

            modelReaderTimeZone.ReaderTimeZoneID = bllReaderTimeZone.GetMaxId();
            bllReaderTimeZone.Add(modelReaderTimeZone);
            modelReaderTimeAccess.Wed = modelReaderTimeZone.ReaderTimeZoneID;

            modelReaderTimeZone.ReaderTimeZoneID = bllReaderTimeZone.GetMaxId();
            bllReaderTimeZone.Add(modelReaderTimeZone);
            modelReaderTimeAccess.Thu = modelReaderTimeZone.ReaderTimeZoneID;

            modelReaderTimeZone.ReaderTimeZoneID = bllReaderTimeZone.GetMaxId();
            bllReaderTimeZone.Add(modelReaderTimeZone);
            modelReaderTimeAccess.Fri = modelReaderTimeZone.ReaderTimeZoneID;

            modelReaderTimeZone.ReaderTimeZoneID = bllReaderTimeZone.GetMaxId();
            bllReaderTimeZone.Add(modelReaderTimeZone);
            modelReaderTimeAccess.Sat = modelReaderTimeZone.ReaderTimeZoneID;

            modelReaderTimeZone.ReaderTimeZoneID = bllReaderTimeZone.GetMaxId();
            bllReaderTimeZone.Add(modelReaderTimeZone);
            modelReaderTimeAccess.Sun = modelReaderTimeZone.ReaderTimeZoneID;

            bllReaderTimeAccess.Add(modelReaderTimeAccess);
            return modelReaderTimeAccess.ReaderTimeAccessID;
        }

        private void addControllerInfo() 
        {
            
            #region ��������Ϣ
            modelControllerInfo.ControllerID = int.Parse(kryptonTextBoxControllerID.Text.Trim());
            modelControllerInfo.ControllerName = kryptonTextBoxControllerName.Text.Trim();
            modelControllerInfo.ControllerType = kryptonComboBoxControllerType.SelectedIndex + 1;
            modelControllerInfo.ControllerLocation = kryptonTextBoxControllerLoaction.Text.Trim();
            modelControllerInfo.ControllerVersion = kryptonTextBoxControllerVersion.Text.ToString();

            ///TCPͨ�Ų���
            modelControllerInfo.ControllerIP = textBoxNewDeviceIP.Text.Trim();
            modelControllerInfo.ControllerSubnetMask = textBoxMask.Text.Trim();
            modelControllerInfo.ControllerGateway = textBoxGateway.Text.Trim();
            modelControllerInfo.ControllerMAC = textBoxMAC.Text;
            modelControllerInfo.ControllerDNS = textBoxDNS.Text;
            modelControllerInfo.ControllerBUDNS = kryptonTextBoxBackUpDNS.Text;

            ///RS485ͨ�Ų���

            #endregion ��������Ϣ

            #region ������Ԫ
            modelControllerInfo.AuxOutPutPointID = int.Parse(kryptonTextBoxAuxOutPutPoint.Text.ToString());
            modelControllerInfo.InputStateType = kryptonComboBoxInputStateType0.SelectedIndex + 1;

            modelControllerInfo.FireSensingEnable = true;
            modelControllerInfo.FireSensingID = int.Parse(kryptonTextBoxFireSensing.Text.ToString());

            modelControllerInfo.TamperSensingEnable = true;
            modelControllerInfo.TamperSensingID = int.Parse(kryptonTextBoxTamperSensing.Text.ToString());

            modelControllerInfo.LowVoltageEnable = true;
            modelControllerInfo.LowVoltageID = int.Parse(kryptonTextBoxLowVoltage.Text.ToString());

            modelControllerInfo.PowerOutageEnable = true;
            modelControllerInfo.PowerOutageID = int.Parse(kryptonTextBoxPowerOutage.Text.ToString());
            #endregion

            int readerID;

            #region �ŵ�Ԫ1
            modelControllerInfo.DoorUnitEnable1 = this.kryptonCheckBoxDoorUnitEnable1.Checked;
            modelControllerInfo.DoorUnitID1 = arrayDoorUnitInfo[0].DoorUnitID = bllDoorUnitInfo.GetMaxId();
            getModelDoorUnitInfo(ref arrayDoorUnitInfo[0], this.doorUnit1);

            #region ������1
            readerID = arrayDoorUnitInfo[0].ReadID1.Value;
            if (!bllReaderInfo.Exists(readerID))
            {
                modelReaderInfo.ReaderID = readerID;
                modelReaderInfo.ReaderPointID = 1;
                modelReaderInfo.ReadTimeAccessID = addDefaultReaderTimeAccess();
                bllReaderInfo.Add(modelReaderInfo);
            }
            
            #endregion

            #region ������2
            readerID = arrayDoorUnitInfo[0].ReadID2.Value;
            if (!bllReaderInfo.Exists(readerID))
            {
                
                modelReaderInfo.ReaderID = readerID;
                modelReaderInfo.ReaderPointID = 1;
                modelReaderInfo.ReadTimeAccessID = addDefaultReaderTimeAccess();
                bllReaderInfo.Add(modelReaderInfo);
            }
            
            #endregion

            bllDoorUnitInfo.Add(arrayDoorUnitInfo[0]);
            #endregion

            #region �ŵ�Ԫ2
            modelControllerInfo.DoorUnitEnable2 = this.kryptonCheckBoxDoorUnitEnable2.Checked;
            modelControllerInfo.DoorUnitID2 = arrayDoorUnitInfo[1].DoorUnitID = bllDoorUnitInfo.GetMaxId();
            getModelDoorUnitInfo(ref arrayDoorUnitInfo[1], this.doorUnit2);

            #region ������1
            readerID = arrayDoorUnitInfo[1].ReadID1.Value;
            if (!bllReaderInfo.Exists(readerID))
            {
                modelReaderInfo.ReaderID = readerID;
                modelReaderInfo.ReaderPointID = 2;
                modelReaderInfo.ReadTimeAccessID = addDefaultReaderTimeAccess();
                bllReaderInfo.Add(modelReaderInfo);
            }
            #endregion

            #region ������2
            readerID = arrayDoorUnitInfo[1].ReadID2.Value;
            if (!bllReaderInfo.Exists(readerID))
            {
                modelReaderInfo.ReaderPointID = 2;
                modelReaderInfo.ReaderID = readerID;
                modelReaderInfo.ReadTimeAccessID = addDefaultReaderTimeAccess();
                bllReaderInfo.Add(modelReaderInfo);
            }
            #endregion

            bllDoorUnitInfo.Add(arrayDoorUnitInfo[1]);
            #endregion

            #region �ŵ�Ԫ3
            modelControllerInfo.DoorUnitEnable3 = this.kryptonCheckBoxDoorUnitEnable3.Checked;
            modelControllerInfo.DoorUnitID3 = arrayDoorUnitInfo[2].DoorUnitID = bllDoorUnitInfo.GetMaxId();
            getModelDoorUnitInfo(ref arrayDoorUnitInfo[2], this.doorUnit3);

            #region ������1
            readerID = arrayDoorUnitInfo[2].ReadID1.Value;
            if (!bllReaderInfo.Exists(readerID))
            {
                modelReaderInfo.ReaderID = readerID;
                modelReaderInfo.ReaderPointID = 3;
                modelReaderInfo.ReadTimeAccessID = addDefaultReaderTimeAccess();
                bllReaderInfo.Add(modelReaderInfo);
            }
            
            #endregion

            #region ������2
            readerID = arrayDoorUnitInfo[2].ReadID2.Value;
            if (!bllReaderInfo.Exists(readerID))
            {
                modelReaderInfo.ReaderID = readerID;
                modelReaderInfo.ReaderPointID = 3;
                modelReaderInfo.ReadTimeAccessID = addDefaultReaderTimeAccess();
                bllReaderInfo.Add(modelReaderInfo);
            }
            
            #endregion

            bllDoorUnitInfo.Add(arrayDoorUnitInfo[2]);
            #endregion

            #region �ŵ�Ԫ4
            modelControllerInfo.DoorUnitEnable4 = this.kryptonCheckBoxDoorUnitEnable4.Checked;
            modelControllerInfo.DoorUnitID4 = arrayDoorUnitInfo[3].DoorUnitID = bllDoorUnitInfo.GetMaxId();
            getModelDoorUnitInfo(ref arrayDoorUnitInfo[3], this.doorUnit4);

            #region ������1
            readerID = arrayDoorUnitInfo[3].ReadID1.Value;
            if (!bllReaderInfo.Exists(readerID))
            {
                modelReaderInfo.ReaderID = readerID;
                modelReaderInfo.ReaderPointID = 4;
                modelReaderInfo.ReadTimeAccessID = addDefaultReaderTimeAccess();
                bllReaderInfo.Add(modelReaderInfo);
            }
           
            #endregion

            #region ������2
            readerID = arrayDoorUnitInfo[3].ReadID2.Value;
            if (!bllReaderInfo.Exists(readerID))
            {
                modelReaderInfo.ReaderID = readerID;
                modelReaderInfo.ReaderPointID = 4;
                modelReaderInfo.ReadTimeAccessID = addDefaultReaderTimeAccess();
                bllReaderInfo.Add(modelReaderInfo);
            }
            
            #endregion

            bllDoorUnitInfo.Add(arrayDoorUnitInfo[3]);
            #endregion

            #region ����IO
            #endregion

            #region ��չIO1
            #endregion

            #region ��չIO2
            #endregion

            #region ��չIO3
            #endregion

            #region ��չIO4
            #endregion

            bllControllerInfo.Add(modelControllerInfo);

        }
        private ReturnValue updateControllerInfo()
        {
            int controllerID;

            bool ret =  int.TryParse(kryptonTextBoxControllerID.Text.Trim(), out controllerID);
            if (!ret)
            {
                MyMessageBox.MessageBoxOK("����ID����Ϊ��Ч����");
                return ReturnValue.Fail;
            }
            modelControllerInfo = bllControllerInfo.GetModel(controllerID);
            if (modelControllerInfo == null)
            {
                return ReturnValue.NotExist;
            }

            #region ������������Ϣ
            modelControllerInfo.ControllerID = int.Parse(kryptonTextBoxControllerID.Text.Trim());
            modelControllerInfo.ControllerName = kryptonTextBoxControllerName.Text.Trim();
            modelControllerInfo.ControllerType = kryptonComboBoxControllerType.SelectedIndex + 1;
            modelControllerInfo.ControllerLocation = kryptonTextBoxControllerLoaction.Text.Trim();
            modelControllerInfo.ControllerVersion = kryptonTextBoxControllerVersion.Text.ToString();
            #endregion ��������Ϣ

            #region ͨѶ����
            if ((kryptonCheckBoxCommunicateTypeTCP.Checked) && (kryptonCheckBoxCommunicateType485.Checked))
                modelControllerInfo.CommunicateType = 0;
            else if (kryptonCheckBoxCommunicateType485.Checked)
                modelControllerInfo.CommunicateType = 2;
            else
                modelControllerInfo.CommunicateType = 1;

            //TCP ͨ�Ų���
            modelControllerInfo.ControllerIP = textBoxNewDeviceIP.Text.Trim();
            modelControllerInfo.ControllerSubnetMask = textBoxMask.Text.Trim();
            modelControllerInfo.ControllerGateway = textBoxGateway.Text.Trim();
            modelControllerInfo.ControllerMAC = textBoxMAC.Text;
            modelControllerInfo.ControllerDNS = textBoxDNS.Text;
            modelControllerInfo.ControllerBUDNS = kryptonTextBoxBackUpDNS.Text;

            //RS485ͨ�Ų���
            #endregion

            #region ������Ԫ
            modelControllerInfo.AuxOutPutPointID = int.Parse(kryptonTextBoxAuxOutPutPoint.Text.ToString());
            modelControllerInfo.InputStateType = kryptonComboBoxInputStateType0.SelectedIndex + 1;


            modelControllerInfo.FireSensingID = int.Parse(kryptonTextBoxFireSensing.Text.ToString());
            modelControllerInfo.FireSensingEnable = true;
            modelControllerInfo.FireSensingMode = 1;

            modelControllerInfo.TamperSensingID = int.Parse(kryptonTextBoxTamperSensing.Text.ToString());
            modelControllerInfo.TamperSensingEnable = true;
            modelControllerInfo.TamperSensingMode = 1;

            modelControllerInfo.LowVoltageID = int.Parse(kryptonTextBoxLowVoltage.Text.ToString());
            modelControllerInfo.LowVoltageEnable = true;
            modelControllerInfo.LowVoltageMode = 1;

            modelControllerInfo.PowerOutageID = int.Parse(kryptonTextBoxPowerOutage.Text.ToString());
            modelControllerInfo.PowerOutageEnable = true;
            modelControllerInfo.PowerOutageMode = 1;
            #endregion

            #region �ŵ�Ԫ1
            modelControllerInfo.DoorUnitEnable1 = kryptonCheckBoxDoorUnitEnable1.Checked;
            #endregion

            #region �ŵ�Ԫ2
            modelControllerInfo.DoorUnitEnable2 = kryptonCheckBoxDoorUnitEnable2.Checked;

            #endregion

            #region �ŵ�Ԫ3
            modelControllerInfo.DoorUnitEnable3 = kryptonCheckBoxDoorUnitEnable3.Checked;
            #endregion

            #region �ŵ�Ԫ4
            modelControllerInfo.DoorUnitEnable4 = kryptonCheckBoxDoorUnitEnable4.Checked;
            #endregion

            #region ����IO

            #endregion

            #region ��չIO1

            #endregion

            #region ��չIO2

            #endregion

            #region ��չIO3

            #endregion

            #region ��չIO4

            #endregion

            bllControllerInfo.Update(modelControllerInfo);

            return ReturnValue.Success;
        }
        private void kryptonButtonControllerOK_Click(object sender, EventArgs e)
        {
            
            if (openMode == OpenMode.Update)
            {
                updateControllerInfo();
                    this.Close();
            }
            else if (openMode == OpenMode.Add)
            {
                addControllerInfo();
                this.Close();
            }

        }

        private void kryptonCheckBoxCommunicateTypeTCP_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonCheckBoxCommunicateTypeTCP.Checked == true)
                kryptonGroupBoxTCP.Enabled = true;
            else
                kryptonGroupBoxTCP.Enabled = false;
        }

        private void kryptonCheckBoxCommunicateType485_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonCheckBoxCommunicateType485.Checked == true)
                kryptonGroupBox485.Enabled = true;
            else
                kryptonGroupBox485.Enabled = false;
        }

        private void openReadInfoDialog(int readerID,OpenMode openMode)
        {
            if (bllReaderInfo.Exists(readerID))
                openMode = OpenMode.Update;
            else
                openMode = OpenMode.Add;

            modelReaderInfo = new AccessDataBase.Model.ReaderInfo();
            modelReaderInfo.ReaderID = readerID;
            FormReaderInfo formReaderInfo = new FormReaderInfo(modelReaderInfo,openMode);
            formReaderInfo.Show();
        }

        private void KryptonButtonReaderUpdateClick1(object sender, EventArgs e)
        {
            switch (((KryptonButton)sender).Name)
            {
                case "kryptonButtonReaderUpdate1": openReadInfoDialog(int.Parse(doorUnit1.KryptonTextBoxReader1.Text.Trim()), OpenMode.Update); break;
                case "kryptonButtonReaderUpdate2": openReadInfoDialog(int.Parse(doorUnit1.KryptonTextBoxReader2.Text.Trim()), OpenMode.Update); break;
                default: break;
            }
        }
        private void KryptonButtonReaderAddClick1(object sender, EventArgs e)
        {
            switch (((KryptonButton)sender).Name)
            {
                case "kryptonButtonReaderAdd1": openReadInfoDialog(int.Parse(doorUnit1.KryptonTextBoxReader1.Text.Trim()), OpenMode.Add); break;
                case "kryptonButtonReaderAdd2": openReadInfoDialog(int.Parse(doorUnit1.KryptonTextBoxReader2.Text.Trim()), OpenMode.Add); break;
                default: break;
            }
        }
        private void KryptonButtonReaderUpdateClick2(object sender, EventArgs e)
        {
            switch (((KryptonButton)sender).Name)
            {
                case "kryptonButtonReaderUpdate1": openReadInfoDialog(int.Parse(doorUnit2.KryptonTextBoxReader1.Text.Trim()), OpenMode.Update); break;
                case "kryptonButtonReaderUpdate2": openReadInfoDialog(int.Parse(doorUnit2.KryptonTextBoxReader2.Text.Trim()), OpenMode.Update); break;
                default: break;
            }
        }
        private void KryptonButtonReaderAddClick2(object sender, EventArgs e)
        {
            switch (((KryptonButton)sender).Name)
            {
                case "kryptonButtonReaderAdd1": openReadInfoDialog(int.Parse(doorUnit1.KryptonTextBoxReader1.Text.Trim()), OpenMode.Add); break;
                case "kryptonButtonReaderAdd2": openReadInfoDialog(int.Parse(doorUnit1.KryptonTextBoxReader2.Text.Trim()), OpenMode.Add); break;
                default: break;
            }
        }

        private void KryptonButtonReaderUpdateClick3(object sender, EventArgs e)
        {
            switch (((KryptonButton)sender).Name)
            {
                case "kryptonButtonReaderUpdate1": openReadInfoDialog(int.Parse(doorUnit3.KryptonTextBoxReader1.Text.Trim()), OpenMode.Update); break;
                case "kryptonButtonReaderUpdate2": openReadInfoDialog(int.Parse(doorUnit3.KryptonTextBoxReader2.Text.Trim()), OpenMode.Update); break;
                default: break;

            }
        }
        private void KryptonButtonReaderAddClick3(object sender, EventArgs e)
        {
            switch (((KryptonButton)sender).Name)
            {
                case "kryptonButtonReaderAdd1": openReadInfoDialog(int.Parse(doorUnit1.KryptonTextBoxReader1.Text.Trim()), OpenMode.Add); break;
                case "kryptonButtonReaderAdd2": openReadInfoDialog(int.Parse(doorUnit1.KryptonTextBoxReader2.Text.Trim()), OpenMode.Add); break;
                default: break;
            }
        }
        private void KryptonButtonReaderUpdateClick4(object sender, EventArgs e)
        {
            switch (((KryptonButton)sender).Name)
            {
                case "kryptonButtonReaderUpdate1": openReadInfoDialog(int.Parse(doorUnit4.KryptonTextBoxReader1.Text.Trim()), OpenMode.Update); break;
                case "kryptonButtonReaderUpdate2": openReadInfoDialog(int.Parse(doorUnit4.KryptonTextBoxReader2.Text.Trim()), OpenMode.Update); break;
                default: break;

            }
        }
        private void KryptonButtonReaderAddClick4(object sender, EventArgs e)
        {
            switch (((KryptonButton)sender).Name)
            {
                case "kryptonButtonReaderAdd1": openReadInfoDialog(int.Parse(doorUnit1.KryptonTextBoxReader1.Text.Trim()), OpenMode.Add); break;
                case "kryptonButtonReaderAdd2": openReadInfoDialog(int.Parse(doorUnit1.KryptonTextBoxReader2.Text.Trim()), OpenMode.Add); break;
                default: break;
            }
        }
        private void kryptonComboBoxControllerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((kryptonComboBoxControllerType.SelectedIndex == 0) || (kryptonComboBoxControllerType.SelectedIndex == 2))
            {
                kryptonCheckBoxDoorUnitEnable1.Checked = true;
                kryptonCheckBoxDoorUnitEnable1.Enabled = true;

                kryptonCheckBoxDoorUnitEnable2.Checked = true;
                kryptonCheckBoxDoorUnitEnable2.Enabled = true;

                kryptonCheckBoxDoorUnitEnable3.Checked = false;
                kryptonCheckBoxDoorUnitEnable3.Enabled = false;

                kryptonCheckBoxDoorUnitEnable4.Checked = false;
                kryptonCheckBoxDoorUnitEnable4.Enabled = false;
            }
            else if (kryptonComboBoxControllerType.SelectedIndex == 1)
            {
                kryptonCheckBoxDoorUnitEnable1.Checked = true;
                kryptonCheckBoxDoorUnitEnable1.Enabled = true;

                kryptonCheckBoxDoorUnitEnable2.Checked = true;
                kryptonCheckBoxDoorUnitEnable2.Enabled = true;

                kryptonCheckBoxDoorUnitEnable3.Checked = true;
                kryptonCheckBoxDoorUnitEnable3.Enabled = true;

                kryptonCheckBoxDoorUnitEnable4.Checked = true;
                kryptonCheckBoxDoorUnitEnable4.Enabled = true;
            }
            
        }

        private void kryptonCheckBoxDoorUnitEnable_CheckedChanged(object sender, EventArgs e)
        {
            switch (((KryptonCheckBox)sender).Name)
            {
                case "kryptonCheckBoxDoorUnitEnable1": doorUnit1.KryptonGroupBoxDoorUnit.Panel.Enabled = kryptonCheckBoxDoorUnitEnable1.Checked; break;
                case "kryptonCheckBoxDoorUnitEnable2": doorUnit2.KryptonGroupBoxDoorUnit.Panel.Enabled = kryptonCheckBoxDoorUnitEnable2.Checked; break;
                case "kryptonCheckBoxDoorUnitEnable3": doorUnit3.KryptonGroupBoxDoorUnit.Panel.Enabled = kryptonCheckBoxDoorUnitEnable3.Checked; break;
                case "kryptonCheckBoxDoorUnitEnable4": doorUnit4.KryptonGroupBoxDoorUnit.Panel.Enabled = kryptonCheckBoxDoorUnitEnable4.Checked; break;
                default: break;
            }
        }
        private void KryptonCheckBoxReaderCheckedChanged1(object sender, EventArgs e)
        {
            switch (((KryptonCheckBox)sender).Name)
            {
                case "kryptonCheckBoxReader1": 
                    doorUnit1.KryptonButtonReaderUpdate1.Enabled = doorUnit1.KryptonCheckBoxReader1.Checked ;
                    doorUnit1.KryptonButtonReaderAdd1.Enabled = doorUnit1.KryptonCheckBoxReader1.Checked;
                    break;
                case "kryptonCheckBoxReader2":
                    doorUnit1.KryptonButtonReaderUpdate2.Enabled = doorUnit1.KryptonCheckBoxReader2.Checked;
                    doorUnit1.KryptonButtonReaderAdd2.Enabled = doorUnit1.KryptonCheckBoxReader2.Checked;
                    break;
                default: break;
            }
        }
        private void KryptonCheckBoxReaderCheckedChanged2(object sender, EventArgs e)
        {
            switch (((KryptonCheckBox)sender).Name)
            {
                case "kryptonCheckBoxReader1":
                    doorUnit2.KryptonButtonReaderUpdate1.Enabled = doorUnit2.KryptonCheckBoxReader1.Checked;
                    doorUnit2.KryptonButtonReaderAdd1.Enabled = doorUnit2.KryptonCheckBoxReader1.Checked;
                    break;
                case "kryptonCheckBoxReader2":
                    doorUnit2.KryptonButtonReaderUpdate2.Enabled = doorUnit2.KryptonCheckBoxReader2.Checked;
                    doorUnit2.KryptonButtonReaderAdd2.Enabled = doorUnit2.KryptonCheckBoxReader2.Checked;
                    break;
                default: break;
            }
        }
        private void KryptonCheckBoxReaderCheckedChanged3(object sender, EventArgs e)
        {
            switch (((KryptonCheckBox)sender).Name)
            {
                case "kryptonCheckBoxReader1":
                    doorUnit3.KryptonButtonReaderUpdate1.Enabled = doorUnit3.KryptonCheckBoxReader1.Checked;
                    doorUnit3.KryptonButtonReaderAdd1.Enabled = doorUnit3.KryptonCheckBoxReader1.Checked;
                    break;
                case "kryptonCheckBoxReader2":
                    doorUnit3.KryptonButtonReaderUpdate2.Enabled = doorUnit3.KryptonCheckBoxReader2.Checked;
                    doorUnit3.KryptonButtonReaderAdd2.Enabled = doorUnit3.KryptonCheckBoxReader2.Checked;
                    break;
                default: break;
            }
        }
        private void KryptonCheckBoxReaderCheckedChanged4(object sender, EventArgs e)
        {
            switch (((KryptonCheckBox)sender).Name)
            {
                case "kryptonCheckBoxReader1":
                    doorUnit4.KryptonButtonReaderUpdate1.Enabled = doorUnit4.KryptonCheckBoxReader1.Checked;
                    doorUnit4.KryptonButtonReaderAdd1.Enabled = doorUnit4.KryptonCheckBoxReader1.Checked;
                    break;
                case "kryptonCheckBoxReader2":
                    doorUnit4.KryptonButtonReaderUpdate2.Enabled = doorUnit4.KryptonCheckBoxReader2.Checked;
                    doorUnit4.KryptonButtonReaderAdd2.Enabled = doorUnit4.KryptonCheckBoxReader2.Checked;
                    break;
                default: break;
            }
        }
    }
}