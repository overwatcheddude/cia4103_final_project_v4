using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Opportunity
/// </summary>
public class Opportunity
{
    public int OpportunityID { get; set; }
    public int OrganizerID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Emirate { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public Opportunity() { }

    public static DataTable GetAll()
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command
        string query = "SELECT * FROM Opportunities";
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

    public static DataTable GetAllUpcoming()
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command
        string query = @"SELECT opp.*, org.Name AS OrganizationName, org.Logo FROM Opportunities opp
                        JOIN Organizers ON opp.OrganizerID = Organizers.OrganizerID
                        JOIN Organizations org ON Organizers.OrganizationID = org.OrganizationID
                        WHERE GetDate() < opp.StartDate";
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

    public static DataTable GetAllFiltered(string emirate, int? organizationId, DateTime? dateFrom, DateTime? dateTo)
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command
        string query = @"SELECT opp.*, org.Name AS OrganizationName, org.Logo FROM Opportunities opp
                        JOIN Organizers ON opp.OrganizerID = Organizers.OrganizerID
                        JOIN Organizations org ON Organizers.OrganizationID = org.OrganizationID
                        WHERE GetDate() < opp.StartDate ";

        if (!String.IsNullOrEmpty(emirate)) query += "AND opp.Emirate = @emirate ";
        if (organizationId != null) query += "AND org.OrganizationID = @organizationId ";
        if (dateFrom != null)
        {
            query += "AND @dateFrom <= opp.StartDate ";

            if (dateTo != null) query += @"AND @dateTo >= opp.EndDate";
        }

        SqlCommand cmd = new SqlCommand(query, conn);

        if (!String.IsNullOrEmpty(emirate)) cmd.Parameters.AddWithValue("emirate", emirate);
        if (organizationId != null) cmd.Parameters.AddWithValue("organizationId", organizationId);
        if (dateFrom != null)
        {
            cmd.Parameters.AddWithValue("dateFrom", dateFrom);

            if (dateTo != null) cmd.Parameters.AddWithValue("dateTo", dateTo);
        }

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

    public static DataTable GetAllEmirates()
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command
        string query = "SELECT DISTINCT Emirate FROM Opportunities";
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
}