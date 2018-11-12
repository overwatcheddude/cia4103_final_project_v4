using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Config
/// </summary>
public class Config
{
    private const string SECRET = "Hu4jH3vGcFnSeuyZ";

    public Config() { }

    public static string GetConnectionString()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        return connectionString;
    }

    public static string GetSecretString()
    {
        return SECRET;
    }
}