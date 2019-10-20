using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleERP.Models.Main
{
    public class MLogin : IMLogin
    {
        public uint USER_SEQ { get; set; }
        public string UID { get; set; }
        public string NAME { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime RefreshTime { get; set; }

        public MLogin GetLogin(string uid, string password)
        {
            //로그인 실패
            return null;
        }
    }
}
