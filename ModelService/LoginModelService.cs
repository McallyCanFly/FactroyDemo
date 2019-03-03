using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utillib;
using winDemo;

namespace ModelService
{
    public class LoginModelService : Super<Login>
    {

        /// <summary>
        /// 验证用户是否存在
        /// Mcally 2019年2月21日22:17:35
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static Login GetUser(Login login)
        {
            string sql = @"SELECT  *  FROM   Login  WHERE  Account=@Account  and PassWord=@PassWord  and  Status=@Status  and   Status <> '10000003'";

            List<SQLiteParameter> sQLites = new List<SQLiteParameter>();
            sQLites.Add(new SQLiteParameter("@Account", login.Account));
            sQLites.Add(new SQLiteParameter("@PassWord", login.PassWord));
            sQLites.Add(new SQLiteParameter("@Status", login.Status));
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, sQLites.ToArray());
            if (dt.Rows.Count == 0)
                return null;
            return ToEntity(dt);



        }
        /// <summary>
        /// 新增用户
        /// Mcally  2019年2月21日22:16:24
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static bool Insert(Login login)
        {
            string sql = $@" INSERT  INTO Login(LoginID,EmpNo,Account,PassWord,UserName,Sex,Address,Age,CreateTime,ModifyTime,Status,Job) 
                             VALUES(
                             @LoginID,@EmpNo,@Account,@PassWord,@UserName,@Sex,@Address,@Age,
                             '{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}',@ModifyTime,@Status,@Job
                                   )";

            List<SQLiteParameter> sQLites = new List<SQLiteParameter>();
            sQLites.Add(new SQLiteParameter("@LoginID", login.LoginID));
            sQLites.Add(new SQLiteParameter("@EmpNo", login.EmpNo));
            sQLites.Add(new SQLiteParameter("@Account", login.Account));
            sQLites.Add(new SQLiteParameter("@PassWord", login.PassWord));
            sQLites.Add(new SQLiteParameter("@UserName", login.UserName));
            sQLites.Add(new SQLiteParameter("@Sex", login.Sex));
            sQLites.Add(new SQLiteParameter("@Address", login.Address));
            sQLites.Add(new SQLiteParameter("@ModifyTime", login.ModifyTime));
            sQLites.Add(new SQLiteParameter("@Age", login.Age));
            sQLites.Add(new SQLiteParameter("@Status", login.Status));
            sQLites.Add(new SQLiteParameter("@Job", login.Job));
            return SQLiteHelper.ExecuteNonQuery(sql, CommandType.Text, sQLites.ToArray()) > 0;

        }
        public static bool Update(Login login)
        {
            string sql = $@" UPDATE   Login 
                                      set
                                      EmpNo=@EmpNo,
                                      Account=@Account,
                                      UserName=@UserName,
                                      Sex=@Sex,
                                      Address=@Address,
                                      Age=@Age,
                                      ModifyTime='{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}',
                                      Job=@Job 
                                      WHERE  LoginID=@LoginID  ";

            List<SQLiteParameter> sQLites = new List<SQLiteParameter>();
            sQLites.Add(new SQLiteParameter("@LoginID", login.LoginID));
            sQLites.Add(new SQLiteParameter("@EmpNo", login.EmpNo));
            sQLites.Add(new SQLiteParameter("@Account", login.Account));
            sQLites.Add(new SQLiteParameter("@UserName", login.UserName));
            sQLites.Add(new SQLiteParameter("@Sex", login.Sex));
            sQLites.Add(new SQLiteParameter("@Address", login.Address));
            sQLites.Add(new SQLiteParameter("@ModifyTime", login.ModifyTime));
            sQLites.Add(new SQLiteParameter("@Age", login.Age));
            sQLites.Add(new SQLiteParameter("@Job", login.Job));
            return SQLiteHelper.ExecuteNonQuery(sql, CommandType.Text, sQLites.ToArray()) > 0;

        }
        /// <summary>
        /// 根据状态来获取所有的用户
        /// Mcally 2019年2月23日20:24:13
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static IList<Login> getAllUser(string Status)
        {

            string sql = $@" SELECT  *  FROM   Login  WHERE  Status=@Status and  Status <> '10000003'  ";

            List<SQLiteParameter> sQLites = new List<SQLiteParameter>();
            sQLites.Add(new SQLiteParameter("@Status", Status.Trim()));

            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, sQLites.ToArray());
            if (dt.Rows.Count == 0)
                return null;
            return ToListEntity(dt);


        }


        public static IList<Hashtable> getAllUserListHsah(string Status)
        {

            string sql = $@" SELECT  *  FROM   Login  WHERE  Status=@Status and  Status <> '10000003'  ";

            List<SQLiteParameter> sQLites = new List<SQLiteParameter>();
            sQLites.Add(new SQLiteParameter("@Status", Status.Trim()));

            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, sQLites.ToArray());
            if (dt.Rows.Count == 0)
                return null;

            return ToEntityListHash(dt);


        }
        public static DataTable getAllUserDataTable(int page, int rows, ref int count)
        {

            string sql = $@" SELECT
                                LoginID,
                                UserName,
                                Age,
                                CreateTime,
                                ModifyTime,
                                Address,
                                EmpNo,
                                Job,
                                Account,
                                CASE Sex WHEN 0 THEN '男' ELSE  '女' END AS  Sex,
                                CASE Status WHEN '10000000' THEN '正常' ELSE  '作废' END AS  Status 
                            FROM  Login 
                            WHERE   Status <> '10000003'  
                            ORDER BY CreateTime DESC 
                            limit {(page - 1) * rows},{rows} ";

            //List<SQLiteParameter> sQLites = new List<SQLiteParameter>();
            //sQLites.Add(new SQLiteParameter("@Status", Status.Trim()));
            count = SQLiteHelper.GetCount(@" SELECT COUNT(*) FROM Login  WHERE  Status <> '10000003'  ");
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);
            if (dt.Rows.Count == 0)
                return new DataTable();

            return dt;


        }

        /// <summary>
        /// 账号重复判定
        /// Mcally 2019年2月24日20:05:03
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static bool CheckAccount(string Account)
        {

            string sql = $@" SELECT  *  FROM   Login
                             WHERE  Account=@Account  and  Status <> '10000003'  ";

            List<SQLiteParameter> sQLites = new List<SQLiteParameter>();
            sQLites.Add(new SQLiteParameter("@Account", Account.Trim()));

            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, sQLites.ToArray());
            if (dt.Rows.Count == 0)
                return false;

            return true;


        }

        public static bool Delete(string LoginID, string Account, string Status)
        {

            string sql = $@" Update  Login  set Status=@Status  
                             WHERE  Account=@Account and Status <> '10000003' ";

            if (!string.IsNullOrWhiteSpace(LoginID))
            {
                sql += $@" and   LoginID=@LoginID  ";
            }
            List<SQLiteParameter> sQLites = new List<SQLiteParameter>();
            sQLites.Add(new SQLiteParameter("@Status", Status.Trim()));
            sQLites.Add(new SQLiteParameter("@LoginID", LoginID.Trim()));
            sQLites.Add(new SQLiteParameter("@Account", Account.Trim()));

            return SQLiteHelper.ExecuteNonQuery(sql, CommandType.Text, sQLites.ToArray()) > 0;

        }


        public void get()
        {

            createNewDatabase();
            connectToDatabase();
            createTable();
            fillTable();
            printHighscores();



        }

        //数据库连接

        static SQLiteConnection m_dbConnection;

        //创建一个空的数据库

        static void createNewDatabase()

        {

            SQLiteConnection.CreateFile("Mcally.db");

        }



        //创建一个连接到指定数据库

        static void connectToDatabase()

        {

            m_dbConnection = new SQLiteConnection("Data Source=Factroy.db;Version =3;");

            m_dbConnection.Open();


        }



        //在指定数据库中创建一个table

        static void createTable()

        {

            string sql = @"CREATE TABLE Login(
                          ID integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                          UserName TEXT(8) NOT NULL,
                          PassWord TEXT(300) NOT NULL,
                          CreateTime text(30) NOT NULL,
                          ModifyTime TEXT(30),
                          Status TEXT(30) NOT NULL
                        )";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            command.ExecuteNonQuery();

        }



        //插入一些数据

        static void fillTable()

        {

            string sql = "INSERT INTO Login( UserName, PassWord, CreateTime, ModifyTime, Status) VALUES ( 'Mcally', '123465', '2019-02-16 23:45:33', NULL, '10001');";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            command.ExecuteNonQuery();




        }



        //使用sql查询语句，并显示结果

        void printHighscores()

        {

            string sql = "select * from highscores order by score desc";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())

                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);

            Console.ReadLine();

        }







    }
}
