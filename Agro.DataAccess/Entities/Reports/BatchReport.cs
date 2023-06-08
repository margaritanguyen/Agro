namespace Agro.DataAccess.Entities
{
    public class BatchReport
    {
        public int ManufNr { get; set; }
        public string ProductName { get; set; }
        public int ProductVersion { get; set; }
        public int BatchNum { get; set; }
        public double ReqWeight { get; set; }
        public double RealWeight { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DosingTaskId { get; set; }

    }
}
