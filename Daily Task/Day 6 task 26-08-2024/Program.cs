using System.Data.SqlClient;
using System.Runtime.InteropServices;

internal class Program
{
    static int inee;

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        SqlConnection conn = new SqlConnection("data source =PTSQLTESTDB01;database=Sports_Sidd;integrated security=true;");


        conn.Open();


        SqlCommand cmd = new SqlCommand("select * from Product", conn);



        SqlDataReader sdr = cmd.ExecuteReader();

        while (sdr.Read())
        {
            Console.WriteLine(sdr[0].ToString() + " " + sdr[1].ToString());
        }
        static void display()
        {

        }
        conn.Close();
    }
}