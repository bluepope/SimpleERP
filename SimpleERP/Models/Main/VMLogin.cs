using SimpleERP.Lib.Wpf.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace SimpleERP.Models.Main
{
    public class VMLogin
    {
        public string USER_ID { get; set; }
        public string PASSWORD { get; set; }

        public DelegateCommand<PasswordBox> LoginCmd { get; set; } = new DelegateCommand<PasswordBox>();
        public VMLogin()
        {
            LoginCmd.ExecuteTargets += LoginCmd_ExecuteTargets;
        }

        private void LoginCmd_ExecuteTargets(PasswordBox obj)
        {
            //this.USER_ID
            //obj.Password
        }
    }
}
