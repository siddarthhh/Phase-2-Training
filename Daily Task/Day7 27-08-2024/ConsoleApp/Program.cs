using System.Data.SqlClient;
using System.Runtime.InteropServices;

internal class Program
{
    static SqlConnection conn;
    static SqlCommand cmd;
    static void getConnection()
    {
         conn = new SqlConnection("data source =PTSQLTESTDB01;database=Sports_Sidd;integrated security=true;");
         conn.Open();
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to application");
        string choice = "yes";
        do
        {
            Console.WriteLine("Press 1 to insert");
            Console.WriteLine("Press 2 to delete");
            Console.WriteLine("Press 3 to update");
            Console.WriteLine("Press 4 to fetch");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    insert();
                    break;
                case 2:
                    delete();
                    break;
                case 3:
                    update();
                    break;
                case 4:
                    fetch();
                    break;
                default:
                    Console.WriteLine("Enter a correct choice");
                    break;


            }


            Console.WriteLine("Do you want to continue(yes/no)");
            choice = Console.ReadLine();
        } while (choice.ToLower().Equals("yes"));

    }
    public static void insert()
    {
        getConnection();
        Console.WriteLine("Enter the number of records to be inserted");
        int num = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine("Enter the product id , name ");
            int id = Convert.ToInt32(Console.ReadLine());
            string name = Console.ReadLine();
            cmd = new SqlCommand("insert into Product values(@id,@name)", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);

            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Records inserted");
        conn.Close();

    }
    public static void fetch() {
        getConnection();
        cmd = new SqlCommand("select * from Product", conn);
        SqlDataReader sdr = cmd.ExecuteReader();

        while (sdr.Read())
        {
            Console.WriteLine(sdr[0].ToString() + " " + sdr[1].ToString());
        }
        conn.Close();
    }
    public static void update()
    {
        getConnection();
        Console.WriteLine("Enter the id of the product which you want to update the name");
        int idcheck = Convert.ToInt32(Console.ReadLine());
        SqlCommand check = new SqlCommand("select * from Product where ProId = @id", conn);
        check.Parameters.AddWithValue("id", idcheck);
        SqlDataReader sdr = check.ExecuteReader();
        if (!sdr.Read())
        {
            Console.WriteLine("ID not found");
            return;
        }
        conn.Close();
        getConnection();
        int id = idcheck;
        Console.WriteLine("Enter the new name");
        string name = Console.ReadLine();
        cmd = new SqlCommand("Update Product Set ProName =@name where ProId=@id",conn);
        cmd.Parameters.AddWithValue ("id", id);
        cmd.Parameters.AddWithValue("name", name);

        cmd.ExecuteNonQuery();
        conn.Close();
    }
    public static void delete()
    {
        getConnection();
        Console.WriteLine("Enter the id of the product which you want to delete");
        int idcheck = Convert.ToInt32(Console.ReadLine());
        SqlCommand check = new SqlCommand("select * from Product where ProId = @id", conn);
        check.Parameters.AddWithValue("id", idcheck);
        SqlDataReader sdr = check.ExecuteReader();
        if (!sdr.Read())
        {
            Console.WriteLine("ID not found");
            return;
        }
        conn.Close();
        getConnection();
        int id = idcheck;
        cmd = new SqlCommand("Delete from Product where ProId=@id", conn);
        cmd.Parameters.AddWithValue("id", id);

        cmd.ExecuteNonQuery();
        conn.Close();
    }


}