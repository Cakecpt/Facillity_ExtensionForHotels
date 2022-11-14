using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata;

SqlConnection sqlConnection;
string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hotel_FacillitiesDB;Integrated Security=True";


// This is the code that can create "Facillities" in our hotels
try
{
    sqlConnection = new SqlConnection(connectionString);
    sqlConnection.Open();
    Console.WriteLine("Connection established successfully :)");
    Console.WriteLine("Select from the options below\n1.Creation\n2.Retrieve\n.3.Update\n4.Delete");
    int choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
    #region CREATE FACILLITY

    Console.WriteLine("Enter The Facillity Name");
    var userName = Console.ReadLine();
    Console.WriteLine("Enter Area of Facillity");
    var userArea = Console.ReadLine();
    string insertQuery = "INSERT INTO Facillity_Details(user_name, user_area) VALUES( '" + userName + "' ,'" + userArea + "')";

    SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
    insertCommand.ExecuteNonQuery();
    Console.WriteLine("The Data Has Successfully Been Inserted Into The Table! :D");
            #endregion
        break;
        case 2:
    #region READ DATA
    //This will display the the current data that has been created with the C method
    string displayQuery = "SELECT * FROM Facillity_Details";
    SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
    SqlDataReader dataReader = displayCommand.ExecuteReader();
    while (dataReader.Read())
    {
        Console.WriteLine("Id: " + dataReader.GetValue(0).ToString());
        Console.WriteLine("Name: " + dataReader.GetValue(1).ToString());
        Console.WriteLine("Area: " + dataReader.GetValue(2).ToString());
    }
    dataReader.Close();
            #endregion
        break;
        case 3:
    #region UPDATE FACILLITY
    //This can update the facillities in our database 

     Console.WriteLine("Enter the facillity id that you want to update :D");
     var u_id = Console.ReadLine();

     Console.WriteLine("Enter the new name of the facillity");
    var u_Name = Console.ReadLine();

    string updateQuery = "UPDATE Facillity_Details SET user_name = " + u_Name + " WHERE user_id = " + u_id + "";
     SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
     updateCommand.ExecuteNonQuery();  
   Console.WriteLine("Data has been updated successfully C:");
            #endregion
        break;
        case 4:
    #region DELETE FACILLITY

    double d_id;
    Console.WriteLine("Enter the id of the facillity that u want to delete :)");
    d_id = double.Parse(Console.ReadLine());

    string deleteQuery = "DELETE FROM Facillity_Details Where user_id = " + d_id;
    SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
    deleteCommand.ExecuteNonQuery();
    Console.WriteLine("Deleted successfully :)");


            #endregion
        break;
        default:
    Console.WriteLine("Invalid input");
        break;
     
    }

    sqlConnection.Close();
}


catch (Exception e)
{
    Console.WriteLine(e.Message);
}
