using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utillib;

namespace Model
{
    public class Login : IModel
    {

        public long ID { set; get; }
        public string UserName { set; get; }
        public int Age { set; get; }
        public string PassWord { set; get; }
        public string CreateTime { set; get; }
        public string ModifyTime { set; get; }
        public string Status { set; get; }
        public string Account { set; get; }
        public string EmpNo { set; get; }
        public string Address { set; get; }
        public string Job { set; get; }
        public int Sex { set; get; }
        public string LoginID { set; get; }

        public override string ToString()
        {
             
            return LoginID;

        }
    }
}
