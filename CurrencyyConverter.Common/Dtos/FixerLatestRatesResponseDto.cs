namespace CurrencyyConverter.Infrastructure.Dtos
{
    public class FixerLatestRatesResponseDto
    {
        public bool Success { get; set; }
        public long Timestamp { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}
