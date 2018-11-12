using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Participation
/// </summary>
public class Participation
{
    public int RoleID { get; set; }
    public string StudentID { get; set; }
    public int Hours { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }

    public Participation() { }
}