namespace Willow.Kermit.Shell.Interfaces {
    public interface KermitShell
    {
        string Title { get; set; }
        TopNavigation Navigation { get; set; }
        ArtFiller Art { get; set; }
        Main Main { get; set; }
        Search Search { get; set; }
        Status Status { get; set; }
    }
}
