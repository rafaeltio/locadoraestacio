using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Locadora.Core.Entity;
using Locadora.Core.Util;
using Locadora.Core.CustomAttributes;

namespace Locadora.Core.DAO
{
    public class GenericDAO<T> : IGenericDAO<T> where T : class, IEntity
    {
        public const string CONECTION_STRING = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=""C:\Users\rafael.menezes\Documents\Visual Studio 2013\Projects\locadoraestacio\Locadora.Core\App_data\Locadora.mdf"";Integrated Security=True";
        public T Save(T entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    SqlCommand command = new SqlCommand();
                    conn.ConnectionString = CONECTION_STRING;
                    command.Connection = conn;
                    if (entity.ID.Equals(0))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("INSERT INTO {0} ", entity.GetType().Name);
                        sb.Append("(");

                        foreach (var propertie in typeof(T).GetProperties())
                        {
                            object[] attr = propertie.GetCustomAttributes(true);
                            if(attr.Length == 0)
                                if (!propertie.Name.Equals("ID"))
                                    sb.AppendFormat("{0},", propertie.Name);
                        }
                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append(") VALUES (");
                        
                        foreach (var propertie in typeof(T).GetProperties())
                        {
                            object[] attr = propertie.GetCustomAttributes(true);
                            if (attr.Length == 0)
                                if (!propertie.Name.Equals("ID"))
                                    sb.AppendFormat("@{0},", propertie.Name);
                        }
                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append(")");
                        
                        command.CommandText = sb.ToString();

                        foreach (var propertie in typeof(T).GetProperties())
                        {
                            object[] attr = propertie.GetCustomAttributes(true);
                            if (attr.Length == 0)
                                if (!propertie.Name.Equals("ID"))
                                    command.Parameters.AddWithValue("@" + propertie.Name ,propertie.GetValue(entity, null));
                        }
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ReturnLastElement(entity);
        }

        public T ReturnLastElement(T e)
        {
            T element = Activator.CreateInstance<T>();
            SqlDataReader reader;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    conn.ConnectionString = CONECTION_STRING;
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT TOP 1 * FROM " + e.GetType().Name + " ORDER BY ID DESC";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        foreach (var f in typeof(T).GetProperties())
                        {
                            if (f.GetCustomAttributes(true).Length == 0)
                            {
                                var o = reader[f.Name];
                                if (o.GetType() != typeof(DBNull)) f.SetValue(element, o, null);
                            }
                        }
                        return element;
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return element;
        }

        public void Delete(T entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    SqlCommand command = new SqlCommand();
                    conn.ConnectionString = CONECTION_STRING;
                    command.Connection = conn;
                    if (!entity.ID.Equals(0))
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.AppendFormat("DELETE FROM {0} ", entity.GetType().Name);

                        sb.Append(" WHERE ID = @ID;");

                        command.CommandText = sb.ToString();

                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(T entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    SqlCommand command = new SqlCommand();
                    conn.ConnectionString = CONECTION_STRING;
                    command.Connection = conn;
                    if (!entity.ID.Equals(0))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("UPDATE {0} ", entity.GetType().Name);
                        sb.Append("SET ");

                        foreach (var propertie in typeof(T).GetProperties())
                        {
                            object[] attr = propertie.GetCustomAttributes(true);
                            if (attr.Length == 0)
                                if (!propertie.Name.Equals("ID"))
                                    if (propertie.GetValue(entity, null) != null)
                                        sb.AppendFormat("{0} = @{1},", propertie.Name, propertie.Name);
                        }
                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append(" WHERE ID = @ID;");

                        command.CommandText = sb.ToString();

                        foreach (var propertie in typeof(T).GetProperties())
                        {
                            object[] attr = propertie.GetCustomAttributes(true);
                            if (attr.Length == 0)
                                if (!propertie.Name.Equals("ID"))
                                    if (propertie.GetValue(entity, null) != null)
                                        command.Parameters.AddWithValue("@" + propertie.Name, propertie.GetValue(entity, null));
                        }
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> All()
        {
            SqlDataReader reader;
            IEnumerable<T> list;
            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand command = new SqlCommand();
                StringBuilder sb = new StringBuilder();
                conn.ConnectionString = CONECTION_STRING;
                command.Connection = conn;

                sb.Append("SELECT ");
                 
                foreach (var propertie in typeof(T).GetProperties())
                {
                    object[] attr = propertie.GetCustomAttributes(true);
                    if (attr.Length == 0)
                        sb.AppendFormat("{0},", propertie.Name);
                }
                sb = sb.Remove(sb.Length - 1, 1);
                sb.AppendFormat(" FROM {0} ", typeof(T).Name);

                command.CommandText = sb.ToString();

                conn.Open();
                reader = command.ExecuteReader();
                list = new List<T>().FromDataReader(reader);
                conn.Close();
            }
            return list;
        }
    }
}
