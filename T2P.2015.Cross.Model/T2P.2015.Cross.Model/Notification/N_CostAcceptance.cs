using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace T2P._2015.Cross.Model
{
    [Serializable]
    public class N_CostAcceptance : BaseModel
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long _b_AccessID;
        public long B_AccessID
        {
            get { return _b_AccessID; }
            set { _b_AccessID = value; }
        }
        private long _m_FileLocationID;
        public long M_FileLocationID
        {
            get { return _m_FileLocationID; }
            set { _m_FileLocationID = value; }
        }
        private long _m_NotificationTemplateID;
        public long M_NotificationTemplateID
        {
            get { return _m_NotificationTemplateID; }
            set { _m_NotificationTemplateID = value; }
        }
        private long _m_HotelPlatformSettingID;

        public long M_HotelPlatformSettingID
        {
            get { return _m_HotelPlatformSettingID; }
            set { _m_HotelPlatformSettingID = value; }
        }
        private string _from;
        public string From
        {
            get { return _from; }
            set { _from = value; }
        }
        private string _to;
        public string To
        {
            get { return _to; }
            set { _to = value; }
        }
        private DateTime _sendDate;
        public DateTime SendDate
        {
            get { return _sendDate; }
            set { _sendDate = value; }
        }
        private string _faxID;
        public string FaxID
        {
            get { return _faxID; }
            set { _faxID = value; }
        }

        private string _faxResult;

        public string FaxResult
        {
            get { return _faxResult; }
            set { _faxResult = value; }
        }

        private string _faxStatus;
        public string FaxStatus
        {
            get { return _faxStatus; }
            set { _faxStatus = value; }
        }
        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        private int _retry;
        public int Retry
        {
            get { return _retry; }
            set { _retry = value; }
        }
        private string _body;

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
        public override string Table { get { return "N_CostAcceptance"; } }
        public override string PrimaryKey { get { return ID.ToString(); } }
        public override string InsertUpdateProcedure { get { return "p_N_CostAcceptance_InsertOrUpdate"; } }
    }
    public enum N_CostAcceptanceColumns
    {
        ID,
        B_AccessID,
        M_FileLocationID,
        M_NotificationTemplateID,
        M_HotelPlatformSettingID,
        From,
        To,
        SendDate,
        FaxID,
        FaxResult,
        FaxStatus,
        FilePath,
        FileName,
        Retry,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate,
        Status,
    }
    public enum N_CostAcceptanceProcedure
    {
        p_N_CostAcceptance_GetForCheck,
        p_N_CostAcceptance_GetByBookingId,
        p_N_CostAcceptance_Get_ForDelete
    }
    public class N_CostAcceptanceList : List<N_CostAcceptance>
    {

    }

    public class P_CostAcceptance : N_CostAcceptance
    {
        private string _faxUserName;

        public string FaxUserName
        {
            get { return _faxUserName; }
            set { _faxUserName = value; }
        }

        private string _faxPassword;

        public string FaxPassword
        {
            get { return _faxPassword; }
            set { _faxPassword = value; }
        }

        private string _faxNumber;

        public string FaxNumber
        {
            get { return _faxNumber; }
            set { _faxNumber = value; }
        }

        private string _iP;

        public string IP
        {
            get { return _iP; }
            set { _iP = value; }
        }

        private string _mailServer;

        public string MailServer
        {
            get { return _mailServer; }
            set { _mailServer = value; }
        }

        private string _mailUsername;

        public string MailUsername
        {
            get { return _mailUsername; }
            set { _mailUsername = value; }
        }

        private string _mailPassword;

        public string MailPassword
        {
            get { return _mailPassword; }
            set { _mailPassword = value; }
        }

        private long m_HotelID;

        public long M_HotelID
        {
            get { return m_HotelID; }
            set { m_HotelID = value; }
        }

        private string fax;

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
    }
}