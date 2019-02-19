using Model;
using ModelService;


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

    }
}
