using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WinformStudy.Lib.Crypter;
using WinformStudy.Lib.DataBase;
using WinformStudy.Lib.Interface;

namespace SimpleERP.WebApiServer.Models
{
    public class MLogin : ILogin
    {
        public int USER_SEQ { get; set; }
        public string USER_ID { get; set; }

        [JsonIgnore]
        public string USER_PW { get; set; }
        [JsonIgnore]
        public string SALT { get; set; }

        public string USER_NAME { get; set; }
        public string LAST_LOGIN_DATE { get; set; }
        public string ROLES { get; set; }
        public string STATUS { get; set; }
        public DateTime NextCheckTime { get; set; }

        public async static Task<MLogin> GetLogin(string user_id, string user_pw)
        {
            var user = (await SqlDapperHelper.RunGetQueryFromXmlAsync<MLogin>("Sql/User.xml", "GetUserFromId", new { user_id = user_id })).FirstOrDefault();
            
            if (user is null)
                throw new Exception("ID가 없습니다");

            //user.STATUS --사용자 접근권한 확인?

            //user.SALT = Guid.NewGuid().ToString();
            //user.USER_PW = HMacSha256.GetHMac(user_pw, user.SALT);
            //await user.UpdatePw();

            if (user.USER_PW == HMacSha256.GetHMac(user_pw, user.SALT))
            {
                return await Get(user.USER_SEQ);
            }
            else
            {
                throw new Exception("비밀번호가 틀렸습니다");
            }
        }

        public async Task<int> UpdatePw()
        {
            return await SqlDapperHelper.RunExecuteFromXmlAsync("Sql/User.xml", "UpdateUserPw", this);
        }

        public async static Task<MLogin> Get(int user_seq)
        {
            return (await SqlDapperHelper.RunGetQueryFromXmlAsync<MLogin>("Sql/User.xml", "GetUser", new { user_seq = user_seq })).FirstOrDefault();
        }
    }
}
