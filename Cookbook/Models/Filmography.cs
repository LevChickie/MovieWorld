using System.Collections.Generic;

public class Filmography
{
    public List<Genre> genres { get; set; }
    public Production_Companies[] production_companies { get; set; }
}

public class Production_Companies
{
    public int id { get; set; }
    public string logo_path { get; set; }
    public string name { get; set; }
    public string origin_country { get; set; }
}
