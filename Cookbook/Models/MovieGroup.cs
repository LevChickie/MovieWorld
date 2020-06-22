using System.Collections.Generic;

public class MovieGroup
    {
    public int page { get; set; }
    public List<MovieWithGenreIDs> results { get; set; }
    public int total_results { get; set; }
    public int total_pages { get; set; }
}
