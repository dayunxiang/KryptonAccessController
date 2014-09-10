Create database InteractRelation
drop database InteractRelation
use InteractRelation

Create Table EventPictureInfo(
	EventPictureID int primary key,
	EventPictureName nvarchar(50),
	EventPictureComercial int default(1),
	EventPictureType int default(1),
	EventPictureImage image
);

--�¼�������Ϣ
Create Table EventCodeInfo(
	EventCodeID int primary key,
	EventCodeType int,
	EventCodeName nvarchar(50),
	EventCodePictureID int references EventPictureInfo(EventPictureID),
	EventUpLoadPriority int default(1)
);
--�¼���Ϣ
Create Table EventInfo(
	EventID int primary key,
	ControllerID int,
	PointType int,
	PointID int,
	CardID nvarchar(10),
	EventCodeID int references EventCodeInfo(EventCodeID),
	EventDateTime nvarchar(10)
);

--���������������Ϣ��
Create Table ControllerInfoInLAN(
	ControllerID int primary key,
	ControllerName nvarchar(20),
	ControllerType int default(1),
	ComunicateType int default(0),
	ControllerIP nvarchar(20) default('192.168.1.241'),
	ControllerPort int,
	ControllerAddr485 int,
	ControllerBaudrate int,
	ControllerDataBits int,
	ControllerStopBits int,
	ControllerParityCheck nvarchar(8) default('None'),
	ControllerFlowControl nvarchar(8) default('None')
);
--ICP
Create Table InterControlProgram(
	ICPID int primary key,
	ICPName nvarchar(50),
	ICPWaitTimeLength int,
	DesControllerInfoInLANID int references ControllerInfoInLAN(ControllerID),
	PointType int,
	PointID int,
	PointState int,
	OutPutLength int
);

--ʱ��������ICP ���
Create Table TimeICP(
	TimeICPID int primary key,
	TimeICPName nvarchar(50),
	TimeICPEnable bit default(1),
	TimeICPLoop bit default(1),
	MonEnable bit default(1),
	TueEnable bit default(1),
	WedEnable bit default(1),
	ThuEnable bit default(1),
	FriEnable bit default(1),
	SatEnable bit default(1),
	SunEnable bit default(1),
	TimePoint nvarchar(8),
	ICPID int references InterControlProgram(ICPID)
);
--ICP�ڼ��չ����
Create Table HolidayICP(
	HolidayID int primary key ,
	HolidayName nvarchar(50),
	HolidayStartDate nvarchar(10),
	HolidayEndDate	nvarchar(10),
	HolidayType int,
	TimeICPID int references TimeICP(TimeICPID)
);

--�¼�������ICP��
Create Table EventICP(
	EventICPID int primary key,
	EventICPName nvarchar(50) not null,
	EventICPEnable bit default(1),
	PointType int,
	PointID int,
	EventCodeID int references EventCodeInfo(EventCodeID),
	ICPID int references InterControlProgram(ICPID)
);
--SOP
Create Table StandardOperateProcedure(
	SOPID int primary key,
	SOPName nvarchar(50),
	SOPWaitTimeLength int,
	DesControllerInfoInLANID int references ControllerInfoInLAN(ControllerID),
	Action nvarchar(100),
	OutPutLength int
);

--ʱ��������SOP���
Create Table TimeSOP(
	TimeSOPGID int primary key,
	TimeSOPGName nvarchar(50),
	TimeSOPGEnable bit default(1),
	TimeSOPGLoop bit default(1),
	MonEnable bit default(1),
	TueEnable bit default(1),
	WedEnable bit default(1),
	ThuEnable bit default(1),
	FriEnable bit default(1),
	SatEnable bit default(1),
	SunEnable bit default(1),
	TimePoint nvarchar(8),
	SOPID int  references StandardOperateProcedure(SOPID)

);
--SOP�ڼ��ձ�
Create Table HolidaySOP(
	HolidayID int primary key ,
	HolidayName nvarchar(50),
	HolidayStartDate nvarchar(10),
	HolidayEndDate	nvarchar(10),
	HolidayType int,
	TimeSOPID int references TimeSOP(TimeSOPGID)
);
--�¼�������SOP���
Create Table EventSOP(
	EventSOPGID int primary key,
	EventSOPGName nvarchar(50),
	EventSOPGEnable bit default(1),
	PointType int,
	PointID int,
	EventCodeID int references EventCodeInfo(EventCodeID),
	SOPID int  references StandardOperateProcedure(SOPID)
);
--����
Create Table InterLock(
	InterLockID int primary key,
	InterLockEnable bit default(1),
	ControlerInfoInLANID1 int references ControllerInfoInLAN(ControllerID),
	DoorUnitID1 int,
	ControlerInfoInLANID2 int references ControllerInfoInLAN(ControllerID),
	DoorUnitID2 int
);
--��Ǳ��
Create Table AntiPassBack(
	AntiPassBackID int primary key ,
	AntiPassBackMode int default(0),
	AntiPassEnable bit default(1),
	ControlerInfoInLANID1 int references ControllerInfoInLAN(ControllerID),
	DoorUnitID1 int,
	ControlerInfoInLANID2 int references ControllerInfoInLAN(ControllerID),
	DoorUnitID2 int,
	ControlerInfoInLANID3 int references ControllerInfoInLAN(ControllerID),
	DoorUnitID3 int,
	ControlerInfoInLANID4 int references ControllerInfoInLAN(ControllerID),
	DoorUnitID4 int
);