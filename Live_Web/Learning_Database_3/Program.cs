using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Learning_Database_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int ch=10,id,room,mem,bus,i,newroom;
            string name;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Visual Studio Projects\Learning_Database_3\Database1.mdf;Integrated Security=True");
            con.Open();
            
            
            Console.WriteLine("1.Inserting data. 2.Retriving Information. 3.Deleting Data. 4. Update Data.  5. Exit");
            while (ch != 5)
            {

                Console.WriteLine("Enter your choice");
                ch = Convert.ToInt32(Console.ReadLine());
                switch(ch)
                {
                    case 1: Console.WriteLine("Enter the name of the hostelite: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter the room number of the hostelite: ");
                            room = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the number of memos assigned to the hostelite: ");
                            mem = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Does the hostelite use the hostel transport facility?: ");
                            bus = Convert.ToInt32(Console.ReadLine());
                            SqlCommand cmd = new SqlCommand("Insert into Hostelites(Name,RoomNo,Memos,BusPass) values(@Name,@RoomNo,@Memos,@BusPass)",con);
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@RoomNo", room);
                            cmd.Parameters.AddWithValue("@Memos",mem);
                            cmd.Parameters.AddWithValue("@BusPass", bus);
                            cmd.ExecuteNonQuery();
                            break;
                    case 2:
                            SqlDataReader rd;
                            Console.WriteLine("Enter the ID of the hostelite whose information you want to retrive: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            SqlCommand cmd1 = new SqlCommand("Select * from Hostelites where Id=@id ",con);
                             cmd1.Parameters.AddWithValue("@Id", id);
                             rd = cmd1.ExecuteReader();
                            
                            while(rd.Read())
                            {
                                Console.WriteLine("Id:{0}  Name:{1}.  Room number:{2}.  Number of memos assigned:{3}.",rd["Id"], rd["Name"], rd["RoomNo"], rd["Memos"]);
                            }
                            rd.Close();
                            break;
                    case 3: Console.WriteLine("Enter the id of the hostelite whose data you want to delete: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            SqlCommand cmd2 = new SqlCommand("Delete from Hostelites where Id=@id",con);
                            cmd2.Parameters.AddWithValue("@Id", id);
                            cmd2.ExecuteNonQuery();
                            break;

                    case 4:
                            
                            Console.WriteLine("Enter the ID of the hostelite whose information you want to update: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the number of the room where you want to shift: ");
                            room= Convert.ToInt32(Console.ReadLine());
                        SqlCommand cmd4;
                        cmd4 = new SqlCommand("Update Hostelites Set RoomNo=@RoomNo WHERE Id=@id", con);
                        cmd4.Parameters.AddWithValue("@Id", id);
                        cmd4.Parameters.AddWithValue("@RoomNo",room);
                        cmd4.ExecuteNonQuery();

                        break;
                }

            }
            con.Close();
        }
    }
}