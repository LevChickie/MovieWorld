using System.Collections.Generic;

public class SeriesGroup
{
    public int page { get; set; }
    public List<SeriesWithGenreIDs> results { get; set; }
    public int total_results { get; set; }
    public int total_pages { get; set; }
}
