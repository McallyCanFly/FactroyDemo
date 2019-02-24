using Model;
using ModelService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Service
{
    public class LoginService
    {
        /// <summary>
        /// 登录验证
        /// Mcally  2019年2月19日10:04:44
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static Login GetUser(Login login)
        {

            return LoginModelService.GetUser(login);

        }


        public static bool Insert(Login login)
        {

            return LoginModelService.Insert(login);

        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static bool Update(Login login)
        {
         
            return LoginModelService.Update(login);

        }
        public static IList<Login> getAllUser(string Status)
        {

            return LoginModelService.getAllUser(Status);

        }



        public static IList<Hashtable> getAllUserListHsah(string Status)
        {
            return LoginModelService.getAllUserListHsah(Status);

        }
        public static DataTable getAllUserDataTable(ref int total,int page=0,int rows=10)
        {
            
            return LoginModelService.getAllUserDataTable(page,rows, ref total);

        }

        public static bool CheckAccount(string Account)
        {

            return LoginModelService.CheckAccount(Account);


        }

        public static bool Delete(string LoginID, string Account, string Status)
        {

            return  LoginModelService.Delete(LoginID,Account,Status);

        }

    }
}
