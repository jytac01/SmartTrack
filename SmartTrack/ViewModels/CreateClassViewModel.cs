namespace SmartTrack.ViewModels
{
    public class CreateClassViewModel
    {
        public string Teacher { get; set; }
        public string Subject { get; set; }
        public string Room { get; set; }

        public TimeOnly ClassTime { get; set; }
        public string ClassDay { get; set; }
    }
}
