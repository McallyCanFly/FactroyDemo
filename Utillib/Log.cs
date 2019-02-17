using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utillib
{
    public class Log
    {

        public static void WriteLog(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("错误发生时间为:" + DateTime.Now + "\r\n");
            sb.Append("错误类型:" + ex.Message + "\r\n");
            sb.Append("具体错误:\r\n" + ex.ToString() + "\r\n");
            sb.Append("=============================================================================");

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorLog", DateTime.Now.ToString("yyyy-MM-dd") + ".txt");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            FileInfo fileInfo = new FileInfo(path);
            using (StreamWriter sw = fileInfo.AppendText())
            {
                sw.Write(sb.ToString());

            }


        }




    }
}
