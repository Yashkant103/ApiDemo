using ApiDemo.DAl;
using ApiDemo.Model;

namespace ApiDemo.BAL
{
    public class User_BALBase
    {
        public List<UserModel> PR_SELECT_ALL_USER()
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                List<UserModel> userModels = user_DALBase.PR_SELECT_ALL_USER();
                return userModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public UserModel PR_SELECT_BY_PK_USER(int UserID)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                UserModel userModel = user_DALBase.PR_SELECT_BY_PK_USER(UserID);
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool PR_DELETE_USER(int User_ID)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                if (user_DALBase.PR_DELETE_USER(User_ID))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool PR_INSERT_USER(UserModel userModel)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                if (user_DALBase.PR_INSERT_USER(userModel))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool PR_UPDATE_USER(int User_ID, UserModel userModel)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                if (user_DALBase.PR_UPDATE_USER(User_ID, userModel))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
