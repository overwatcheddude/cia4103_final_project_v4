using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Organizer
/// </summary>
public class Organizer
{
    public int OrganizerID { get; set; }
    public int OrganizationID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public char Gender { get; set; }
    public string MobileNumber { get; set; }
    public bool IsAdmin { get; set; }

    public static DataTable GetOrganizersByOrganizationID(int OrganizationID)
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command
        string query = "SELECT * FROM Organizers WHERE OrganizationID = @organizationID";
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

    public Organizer() { }
}