using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utillib
{
    public class Super<T> where T : Utillib.IModel, new()
    {
        public Super()
        {

        }

        /// <summary>
        ///单条实体类 
        ///Mcally  2019年2月17日13:57:41
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T ToEntity(DataTable dt)
        {
            try
            {
                Type type = typeof(T);
                object entity = type.Assembly.CreateInstance(type.FullName);
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        PropertyInfo[] files = type.GetProperties();
                        foreach (PropertyInfo pro in files)
                        {
                            string fieldName = pro.Name;
                            if (fieldName == column.ColumnName)
                            {

                                if (row[column.ColumnName].GetType().ToString() == "System.Int32")
                                {
                                    pro.SetValue(entity, int.Parse(row[column.ColumnName].ToString()));
                                }
                                else if (row[column.ColumnName].GetType().ToString() == "System.DBNull")
                                {
                                    pro.SetValue(entity, null);
                                }
                                else
                                {
                                    pro.SetValue(entity, row[column.ColumnName]);
                                }

                            }

                        }

                    }
                }

                return (T)entity;

            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return default(T);



            }


        }

        /// <summary>
        /// 实体集合  
        /// Mcally 2019年2月17日13:57:49
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IList<T> ToListEntity(DataTable dt)
        {
            IList<T> ts = new List<T>();
            try
            {
                if (dt != null && dt.Rows.Count == 0)
                    return ts;
                Type type = typeof(T);
                object entity = null;
                foreach (DataRow row in dt.Rows)
                {
                    entity = type.Assembly.CreateInstance(type.FullName);
                    foreach (DataColumn column in dt.Columns)
                    {
                        PropertyInfo[] files = type.GetProperties();
                        foreach (PropertyInfo pro in files)
                        {
                            string fieldName = pro.Name;
                            if (fieldName == column.ColumnName)
                            {

                                if (row[column.ColumnName].GetType().ToString() == "System.Int32")
                                {
                                    pro.SetValue(entity, int.Parse(row[column.ColumnName].ToString()));
                                }
                                else if (row[column.ColumnName].GetType().ToString() == "System.DBNull")
                                {
                                    pro.SetValue(entity, null);
                                }
                                else
                                {
                                    pro.SetValue(entity, row[column.ColumnName]);
                                }

                            }

                        }

                    }
                    ts.Add((T)entity);
                }
                return ts;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return new List<T>();
            }


        }
        /// <summary>
        /// Mcally 2019年2月17日13:58:05
        /// 转换为集合类型
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>

        public static  IList<Hashtable> ToEntityListHash(DataTable dt)
        {
            IList<Hashtable> hashtables = new List<Hashtable>();
            if (dt != null && dt.Rows.Count == 0)
                return hashtables;

            Hashtable hash = null;
            foreach (DataRow rows in dt.Rows)
            {
                hash = new Hashtable();
                foreach (DataColumn column in dt.Columns)
                {
                    hash.Add(column.ColumnName, rows[column.ColumnName]);
                }
                hashtables.Add(hash);
            }
            int i = 0;

            return hashtables;
        }

    }
}
