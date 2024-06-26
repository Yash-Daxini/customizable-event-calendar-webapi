﻿namespace WebAPI.Dtos;

public class RecurrencePatternDto
{
    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Frequency { get; set; }

    public int Interval { get; set; }

    public List<int>? ByWeekDay { get; set; }

    public int? WeekOrder { get; set; }

    public int? ByMonthDay { get; set; }

    public int? ByMonth { get; set; }
}
