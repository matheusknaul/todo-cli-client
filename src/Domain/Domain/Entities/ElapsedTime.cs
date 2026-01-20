namespace Domain.Entities
{
    public class ElapsedTime
    {
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public int Minutes { get; set; }

        public void Start()
        {
            StartedAt = DateTime.Now;
        }

        public void Finish()
        {
            FinishedAt = DateTime.Now;

            Minutes = (int)(FinishedAt - StartedAt).TotalMinutes;
        }
    }
}
