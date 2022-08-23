using CsvHelper.Configuration;

namespace App.Models;

public sealed class VolunteerMap : ClassMap<Volunteer>
{
    public VolunteerMap()
    {
        Map(m => m.ID_Volunteer).Name("VolunteerId");
        Map(m => m.First_Name).Name("FirstName");
        Map(m => m.Last_Name).Name("LastName");
        Map(m => m.ID_Country).Name("CountryCode");
        Map(m => m.Gender_ID).Name("Gender");
    }
}