using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace T2P._2015.Cross.Model
{
    [Serializable]
    public class C_KeyWordDetail : BaseModel
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long _c_KeyWordID;
        public long C_KeyWordID
        {
            get { return _c_KeyWordID; }
            set { _c_KeyWordID = value; }
        }
        private long _m_HotelID;
        public long M_HotelID
        {
            get { return _m_HotelID; }
            set { _m_HotelID = value; }
        }
        private string _lineIndex;
        public string LineIndex
        {
            get { return _lineIndex; }
            set { _lineIndex = value; }
        }
        private int? _xPos;
        public int? XPos
        {
            get { return _xPos; }
            set { _xPos = value; }
        }
        private int? _yPos;
        public int? YPos
        {
            get { return _yPos; }
            set { _yPos = value; }
        }
        private int? _width;
        public int? Width
        {
            get { return _width; }
            set { _width = value; }
        }
        private int? _height;
        public int? Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public override string Table { get { return "C_KeyWordDetail"; } }
        public override string PrimaryKey { get { return ID.ToString(); } }
        public override string InsertUpdateProcedure { get { return "p_C_KeyWordDetail_InsertOrUpdate"; } }
    }
    public enum C_KeyWordDetailColumns
    {
        ID,
        C_KeyWordID,
        M_HotelID,
        LineIndex,
        XPos,
        YPos,
        Width,
        Height,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate,
        Status,
    }
    public enum C_KeyWordDetailProcedure
    {

    }
    public class C_KeyWordDetailList : List<C_KeyWordDetail>
    {

    }
}