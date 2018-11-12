using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Role
/// </summary>
public class Role
{
    public int RoleID { get; set; }
    public int OpportunityID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int VolunteersRequired { get; set; }
    public char GenderRequired { get; set; }
    public int AgeRequired { get; set; }

    public Role() { }
}