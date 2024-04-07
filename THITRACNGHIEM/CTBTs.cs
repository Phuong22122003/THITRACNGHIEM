using System;
using System.Collections.Generic;
using System.Linq;
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
    internal class CTBT
    {
        private int _CauHoi;
        private char _LuaChonSV;
        private int _ThuTu;
        private List<char> _DapAn_ThuTu;
        private char _dap_an;
        public CTBT() { 
            _DapAn_ThuTu = new List<char>(4);
            _LuaChonSV = '\0';
        }
        public CTBT(int cauHoi, char luaChonSV, int thuTu)
        {
            _CauHoi = cauHoi;
            _LuaChonSV = luaChonSV;
            _ThuTu = thuTu;
            _DapAn_ThuTu = new List<char>(4);
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
        public List<char> DapAn_Thutu
        {
            get { return _DapAn_ThuTu; }
        }
    }
}
