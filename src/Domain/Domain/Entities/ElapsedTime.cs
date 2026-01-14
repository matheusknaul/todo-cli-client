namespace Domain.Entities
{
    public class ElapsedTime
    {
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public int Minutes =>
            (int)(FinishedAt - StartedAt).TotalMinutes;

        public void Start()
        {
            StartedAt = DateTime.Now;
        }

        public int Finish()
        {
            FinishedAt = DateTime.Now;

            return this.Minutes;
        }
    }
}
