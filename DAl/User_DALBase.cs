using ApiDemo.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace ApiDemo.DAl
{
    public class User_DALBase : DAL_Helper
    {
        public List<UserModel> PR_SELECT_ALL_USER()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_USER");
                List<UserModel> userModels = new List<UserModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        UserModel userModel = new UserModel();
                        userModel.User_ID = Convert.ToInt32(dr["User_ID"]);
                        userModel.Name = dr["Name"].ToString();
                        userModel.Contact = dr["Contact"].ToString();
                        userModel.Email = dr["Email"].ToString();
                        userModels.Add(userModel);
                    }
                }
                return userModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UserModel PR_SELECT_BY_PK_USER(int User_ID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_USER");
                sqlDatabase.AddInParameter(dbCommand, "@User_ID", SqlDbType.Int, User_ID);
                UserModel userModel = new UserModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        userModel.User_ID = Convert.ToInt32(dr["User_ID"].ToString());
                        userModel.Name = dr["Name"].ToString();
                        userModel.Contact = dr["Contact"].ToString();
                        userModel.Email = dr["Email"].ToString();
                    }

                }
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
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_DELETE_USER");
                sqlDatabase.AddInParameter(dbCommand, "@User_ID", SqlDbType.Int, User_ID);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool PR_INSERT_USER(UserModel userModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_INSERT_USER");
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.VarChar, userModel.Name);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, userModel.Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, userModel.Email);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool PR_UPDATE_USER(int User_ID, UserModel userModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_UPDATE_USER");
                sqlDatabase.AddInParameter(dbCommand, "@User_ID", SqlDbType.Int, User_ID);
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.VarChar, userModel.Name);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, userModel.Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, userModel.Email);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
