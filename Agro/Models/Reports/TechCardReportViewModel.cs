namespace Agro.Models
{
    public class TechCardReportViewModel
    {
        public long Num { get; set; }
        public int ManufNr { get; set; }
        public string ProductName { get; set; }
        public int ProductVersion { get; set; }
        public int BatchNum { get; set; }
        public float ReqWeight { get; set; }
        public double RealWeight { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DosingTaskId { get; set; }
        public string Message { get; set; }
        public string ResourceName { get; set; }
    }
}