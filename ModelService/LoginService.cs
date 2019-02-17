using Model;
using System;
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
    public class LoginService : Super<Login>
    {
        public static Login GetUser(Login login)
        {
            string sql = @"SELECT  *  FROM   Login  WHERE  UserName=@UserName  and PassWord=@PassWord ";

            List<SQLiteParameter> sQLites = new List<SQLiteParameter>();
            sQLites.Add(new SQLiteParameter("@UserName", login.UserName));
            sQLites.Add(new SQLiteParameter("@PassWord", login.PassWord));
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, sQLites.ToArray());
            if (dt.Rows.Count == 0)
                return null;
            return ToEntity(dt);



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
