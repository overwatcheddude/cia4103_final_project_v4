using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student
{
    public string StudentID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public char Gender { get; set; }
    public string MobileNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string EmiratesID { get; set; }
    public string RememberToken { get; set; }

    public Student() { }

    public static bool Authenticate(string id, string password)
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command with Parameter
        string sql = "SELECT StudentID, Password FROM Students WHERE StudentID = @id";
        SqlCommand cmd = new SqlCommand(sql, conn);

        // Set the parameter value to email that is sent to the method.
        cmd.Parameters.AddWithValue("id", id);

        // Reads the query row from the command.
        SqlDataReader reader = cmd.ExecuteReader();

        // Checks if the command returned a row and returns false.
        if (!reader.Read())
        {
            reader.Close();
            conn.Close();

            return false;
        }

        // Gets the BCrypt hashed password from the database.
        string hashedPassword = reader.GetString(1);

        // Uses BCrypt.Net library to verify if the plain-text password matches the hashed.
        bool hashMatches = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

        reader.Close();
        conn.Close();
        
        return hashMatches;
    }

    /*Check if the student is logged in or not.
     * The parameter requires the session object.
     * Example: IsAuthenticated(Session);
    */
    public static bool IsAuthenticated(HttpSessionState Session, HttpRequest Request)
    {
        if (Session["studentId"] != null)
        {
            return true;
        }
        else if (Request.Cookies["studentCookie"] != null)
        {
            string id = Request.Cookies["studentCookie"].Values["id"];
            string token = id + Config.GetSecretString();

            if (BCrypt.Net.BCrypt.Verify(token, GetRememberToken(id)))
            {
                Session["studentId"] = id;

                Student std = GetById(id);
                Session["studentName"] = std.FirstName + " " + std.LastName;

                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public static Student GetById(string id)
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command with Parameter
        string sql = "SELECT * FROM Students WHERE StudentID = @id";
        SqlCommand cmd = new SqlCommand(sql, conn);

        // Set the parameter value to email that is sent to the method.
        cmd.Parameters.AddWithValue("id", id);

        // Reads the query row from the command.
        SqlDataReader reader = cmd.ExecuteReader();

        // Checks if the command returned a row and returns false.
        if (!reader.Read())
        {
            reader.Close();
            conn.Close();

            return null;
        }

        Student student = new Student();
        student.StudentID = reader.GetString(0);
        student.Email = reader.GetString(1);
        student.Password = reader.GetString(2);
        student.FirstName = reader.GetString(3);
        student.MiddleName = reader.GetString(4);
        student.LastName = reader.GetString(5);
        student.Gender = Convert.ToChar(reader.GetString(6));
        student.MobileNumber = reader.GetString(7);
        student.DateOfBirth = reader.GetDateTime(8);
        student.EmiratesID = reader.GetString(9);

        reader.Close();
        conn.Close();

        return student;
    }

    public static void SaveRememberToken(string token, string id)
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command with Parameter
        string sql = "UPDATE Students SET RememberToken = @token WHERE StudentID = @id";
        SqlCommand cmd = new SqlCommand(sql, conn);

        // Set the parameter value to email that is sent to the method.
        cmd.Parameters.AddWithValue("token", token);
        cmd.Parameters.AddWithValue("id", id);

        // Execute statement
        cmd.ExecuteNonQuery();
    }

    public static string GetRememberToken(string id)
    {
        // Open Database Connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionString();
        conn.Open();

        // Prepare SQL Command with Parameter
        string sql = "SELECT RememberToken FROM Students WHERE StudentID = @id";
        SqlCommand cmd = new SqlCommand(sql, conn);

        // Set the parameter value to email that is sent to the method.
        cmd.Parameters.AddWithValue("id", id);

        // Reads the query row from the command.
        SqlDataReader reader = cmd.ExecuteReader();

        // Checks if the command returned a row and returns false.
        if (!reader.Read())
        {
            reader.Close();
            conn.Close();

            return null;
        }

        return reader.GetString(0);
    }
}