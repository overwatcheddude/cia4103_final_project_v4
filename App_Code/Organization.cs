using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Organization
/// </summary>
public class Organization
{
    public int OrganizationID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Logo { get; set; }

    public Organization() { }

    public static DataTable GetAll()
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command
        string query = "SELECT * FROM Organizations";
        SqlCommand cmd = new SqlCommand(query, conn);

        // Create Data Adapter
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        // Initiate DataTable result with Data Adapter
        DataTable result = new DataTable();
        da.Fill(result);

        // Close connection and release Data Adapter
        conn.Close();
        da.Dispose();

        return result;
    }

    public static DataTable GetNames()
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command
        string query = "SELECT DISTINCT OrganizationID, Name FROM Organizations";
        SqlCommand cmd = new SqlCommand(query, conn);

        // Create Data Adapter
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        // Initiate DataTable result with Data Adapter
        DataTable result = new DataTable();
        da.Fill(result);

        // Close connection and release Data Adapter
        conn.Close();
        da.Dispose();

        return result;
    }

    public static DataTable GetAllLikeName(string name)
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command
        string query = "SELECT * FROM Organizations WHERE Name LIKE @name";
        SqlCommand cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("name", "%" + name + "%");

        // Create Data Adapter
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        // Initiate DataTable result with Data Adapter
        DataTable result = new DataTable();
        da.Fill(result);

        // Close connection and release Data Adapter
        conn.Close();
        da.Dispose();

        return result;
    }

    public static DataTable GetOrgByID(int OrganizationID)
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command
        string query = "SELECT * FROM Organizations WHERE OrganizationID = @organizationID";
        SqlCommand cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("organizationID", OrganizationID);

        // Create Data Adapter
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        // Initiate DataTable result with Data Adapter
        DataTable result = new DataTable();
        da.Fill(result);

        // Close connection and release Data Adapter
        conn.Close();
        da.Dispose();

        return result;
    }
}