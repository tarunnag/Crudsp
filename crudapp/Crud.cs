using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudapp
{
    public  class Crudoperation
    {
        private SqlConnection con = new SqlConnection("Data Source=MOBACK;DataBase=Student;Integrated Security=True");
        public void Create(string operation,int id,string name,int age,float salary,int salid)
        {
            try
            {
                con.Open();
                SqlCommand insertCmd = new SqlCommand("spEmployeeop",con);
                insertCmd.CommandText = "spEmployeeop";
                insertCmd.CommandType = System.Data.CommandType.StoredProcedure;
                insertCmd.Parameters.AddWithValue("@action", "insert");
                insertCmd.Parameters.Add(new SqlParameter("@empname", SqlDbType.VarChar)).Value = name;
                insertCmd.Parameters.Add(new SqlParameter("@empage", SqlDbType.Int)).Value = age;
                insertCmd.Parameters.Add(new SqlParameter("@empid", SqlDbType.Int)).Value = id;
                insertCmd.Parameters.Add(new SqlParameter("@empsalary", SqlDbType.Float)).Value = salary;
                insertCmd.Parameters.Add(new SqlParameter("@empsalid", SqlDbType.Int)).Value = salid;
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Data Will be successfully inserted into the table");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Retrive(string operation,string name,int age,int id,float salary,int salid)
        {
            try
            {
                con.Open();
                SqlCommand displaycommand = new SqlCommand("spEmployeeop", con);
                displaycommand.CommandText = "spEmployeeop";
                displaycommand.CommandType = System.Data.CommandType.StoredProcedure;
                displaycommand.Parameters.AddWithValue("@action", "select");
                SqlDataAdapter da= new SqlDataAdapter(displaycommand);
                DataSet dt = new DataSet();
                da.Fill(dt);
                //SqlDataReader datareader = displaycommand.ExecuteReader();
                //datareader.Close();
            }
            catch (Exception e)
            {
                string message = e.Message;
            }
            finally
            {
                con.Close();
            }
        }
        public void Update(string operation, string name, int age, int id, float salary, int salid)
        {
            try
            {
                con.Open();
                SqlCommand updateCommand = new SqlCommand("spEmployeeop", con);
                updateCommand.CommandText = "spEmployeeop";
                updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
                updateCommand.Parameters.AddWithValue("@action","update");
                updateCommand.Parameters.AddWithValue("@empsalary", Convert.ToDecimal(salary));
                updateCommand.Parameters.AddWithValue("@empid", Convert.ToDecimal(id));
                updateCommand.ExecuteNonQuery();
                Console.WriteLine("data updated successfully");
            }
            catch (Exception e)
            {
                string message = e.Message;
            }
            finally
            {
                con.Close();
            }
        }
        public void Delete(string operation, string name, int age, int id, float salary, int salid)
        {
            try
            {
                con.Open();
                SqlCommand deleteCommand = new SqlCommand("spEmployeeop", con);
                deleteCommand.CommandText = "spEmployeeop";
                deleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
                deleteCommand.Parameters.AddWithValue("@action", "delete");
                deleteCommand.Parameters.AddWithValue("@empid", Convert.ToInt32(id));
                deleteCommand.ExecuteNonQuery();
                Console.WriteLine("Deleted successfully");
            }
            catch (Exception e)
            {
                string message = e.Message;
            }
            finally
            {
                con.Close();
            }
        }
        public void View(string Vwdet)
        {
            try
            {
                con.Open();
                DataTable table = new DataTable();
                SqlCommand view = new SqlCommand("select * from Vwdet",con);
                table.Load(view.ExecuteReader());
            }
            catch(Exception e)
            {
                string message = e.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
