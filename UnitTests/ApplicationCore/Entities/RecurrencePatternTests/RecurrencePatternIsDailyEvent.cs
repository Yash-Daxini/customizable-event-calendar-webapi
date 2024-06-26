﻿using Core.Entities;
using Core.Entities.Enums;

namespace UnitTests.ApplicationCore.Entities.RecurrencePatternTests;

public class RecurrencePatternIsDailyEvent
{

    private readonly RecurrencePattern _recurrencePattern;

    public RecurrencePatternIsDailyEvent()
    {
        _recurrencePattern = new RecurrencePattern()
        {
            Frequency = Frequency.Daily,
        };
    }

    [Fact]
    public void Should_ReturnTrue_When_FrequencyIsDaily()
    {
        bool result = _recurrencePattern.IsDailyEvent();

        Assert.True(result);
    }

    [Theory]
    [InlineData(Frequency.Yearly)]
    [InlineData(Frequency.Monthly)]
    [InlineData(Frequency.Weekly)]
    [InlineData(Frequency.None)]
    public void Should_ReturnFalse_When_FrequencyIsNotDaily(Frequency frequency)
    {
        _recurrencePattern.Frequency = frequency;

        bool result = _recurrencePattern.IsDailyEvent();

        Assert.False(result);
    }
}
