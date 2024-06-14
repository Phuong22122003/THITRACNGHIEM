using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace THITRACNGHIEM
{
    internal class CTBTs
    {
        private int IDBD;//id bảng điẻm
        private List<CTBT> li;
        public CTBTs()
        {
            li = new List<CTBT>();
        }    
        public CTBTs(int size)
        {
            li = new List<CTBT>(size);
        }
        public List<CTBT> getList()
        {
            return this.li;
        }
        public void setIDBD(int IDBD)
        {
            this.IDBD = IDBD;
        }
        public void addLuaChon(CTBT ct)
        {
            this.li.Add(ct);
        }
        public CTBT getCTBT(int thuTu)
        {
            return li[thuTu];
        }
        public void setLuaChonSV(int thuTu, char LuaChonSV)
        {
            li[thuTu].LuaChonSV = LuaChonSV;
        }
    }
    /// <summary>
    /// Dùng cho lưu chi tiết bài thi
    /// </summary>
    internal class CTBT
    {
        private int _CauHoi;
        private char _LuaChonSV;
        private int _ThuTu;
        private Dictionary<String,int> _DapAn_ThuTu;
        private Dictionary<int, String> _ThuTu_DapAn;
        private char _dap_an;
        public CTBT() { 
            _ThuTu_DapAn = new Dictionary<int, String>();
            _DapAn_ThuTu = new Dictionary<String, int>();
            _LuaChonSV = '\0';
        }
        public CTBT(int cauHoi, char luaChonSV, int thuTu)
        {
            _CauHoi = cauHoi;
            _LuaChonSV = luaChonSV;
            _ThuTu = thuTu;
            _DapAn_ThuTu = new Dictionary<String, int>();
        }
        public char LuaChonSV
        {
            get { return _LuaChonSV; }
            set { _LuaChonSV = value; }
        }
        public char Dap_An
        {
            get { return _dap_an; }
            set { _dap_an = value; }
        }
        public int ThuTu
        {
            get { return _ThuTu; }
            set
            {
                _ThuTu = value;
            }
        }
        public int CauHoi
        {
            get
            {
                return _CauHoi;

            }
            set
            {
                _CauHoi = value;
            }
        }

        /// <summary>
        /// Trả về từ điển với khóa là đáp án còn value là thứ tự của đáp án đó trong ctbt.
        /// Dùng mục đích lưu thứ tự xuống database
        /// </summary>
        public Dictionary<String, int>DapAn_Thutu
        {
            get { return _DapAn_ThuTu; }
        }

        /// <summary>
        /// trả về từ điển chứa khóa là thứ tự và value là đáp án.
        /// Ví dụ ThuTu_DapAn[1] = A.
        /// Dùng để lưu đáp án thực sự cho vị trí đó.
        ///  ví dụ:
        ///   + hiển thị:    A B C D
        ///   + đáp án:     B D A C
        ///   Khi đó ta có vị trí 1 là B bằng cách lấy ThuTu_DapAn[1] = A.
        /// </summary>
        public Dictionary<int, String> ThuTu_DapAn
        {
            get { return _ThuTu_DapAn; }
        }
    }
}
