using System;

public class SensorLine
{
	public SensorLine()
	{
	}

    public long Id { get; set; }
    public DateTime Timestamp { get; set; }

    public decimal? Value1 { get; set; }
    public decimal? Value2 { get; set; }
}
