﻿using Core.Entities.Enums;
using Core.Entities;

namespace UnitTests.ApplicationCore.Entities.RecurrencePatternTests;

public class RecurrencePatternIsWeeklyEvent
{
    private readonly RecurrencePattern _recurrencePattern;

    public RecurrencePatternIsWeeklyEvent()
    {
        _recurrencePattern = new RecurrencePattern()
        {
            Frequency = Frequency.Weekly,
        };
    }

    [Fact]
    public void Should_ReturnTrue_When_FrequencyIsWeekly()
    {
        bool result = _recurrencePattern.IsWeeklyEvent();

        Assert.True(result);
    }

    [Theory]
    [InlineData(Frequency.Yearly)]
    [InlineData(Frequency.Monthly)]
    [InlineData(Frequency.Daily)]
    [InlineData(Frequency.None)]
    public void Should_ReturnFalse_When_FrequencyIsNotWeekly(Frequency frequency)
    {
        _recurrencePattern.Frequency = frequency;

        bool result = _recurrencePattern.IsWeeklyEvent();

        Assert.False(result);
    }
}
