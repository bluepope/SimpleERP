using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleERP.Models.Main
{
    public interface IMLogin
    {
        public uint USER_SEQ { get; set; }
        public string UID { get; set; }
        public string NAME { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime RefreshTime { get; set; }

    }
}
