using System.Data;
using System.Data.SqlClient;

namespace ADO_Masked {
    public class Program
    {
        public static void Main()
        {
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = new SqlConnection("Server=localhost; Database=Classwork; Integrated Security=True;");

                sqlConnection.Open();


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("execute as user = 'Exi'; Select * from Users", sqlConnection);

                DataTable dataSet = new DataTable();

                sqlDataAdapter.Fill(dataSet);




                    foreach (DataColumn column in dataSet.Columns)
                    {
                        Console.WriteLine(column);

                        foreach (DataRow row in dataSet.Rows)
                        {
                        Console.WriteLine(row[column]);
                        }

                    }







                //while (sqlDataReader.Read())
                //{
                //    Console.WriteLine(
                //        "Firstname: " + sqlDataReader["FirstName"] + "\n" +
                //        "LastName: " + sqlDataReader["LastName"] + "\n" +
                //        "CardNumber: " + sqlDataReader["CardNumber"] + "\n" +
                //        new String('-', 50)
                //        );
                //}
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                sqlConnection.Close();
            }



        }
    }
}

