using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace CodeWars_Tasks;

public class HumanTimeFormat
{
    public static string formatDuration(int seconds)
    {
        if (seconds == 0)
            return "now";
        var year = seconds / (365 * 24 * 60 * 60);
        var day = seconds / (24 * 60 * 60) - year * 365;
        var hour = seconds / (60 * 60) - year * 365 * 24 - day * 24;
        var minute = seconds / 60 - year * 365 * 24 * 60 - day * 24 * 60 - hour * 60;
        seconds += -year * 365 * 24 * 60 * 60 - day * 24 * 60 * 60 - hour * 60 * 60 - minute * 60;
        var dict = new Dictionary<string, int>()
        {
            { "year", year },
            { "day", day },
            { "hour", hour },
            { "minute", minute },
            { "second", seconds }
        };
        var resultedValues = new List<string>();
        foreach (var interval in dict)
        {
            switch (dict[interval.Key])
            {
                case 0:
                    continue;
                case 1:
                    resultedValues.Add(interval.Value + " " + interval.Key);
                    continue;
                default:
                    resultedValues.Add(interval.Value + " " + interval.Key + "s");
                    break;
            }
        }

        var result = new StringBuilder();
        if (resultedValues.Count == 1)
            return resultedValues[0];
        for (var i = 0; i < resultedValues.Count-2; i++)
        {
            result.Append(resultedValues[i] + ", ");
        }
        
        result.Append(resultedValues[^2] + " and " + resultedValues[^1]);
        return result.ToString();
    }
}

[TestFixture]
public class Tests
{
    [Test]
    public void basicTests()
    {
        Assert.AreEqual("now", HumanTimeFormat.formatDuration(0));
        Assert.AreEqual("1 second", HumanTimeFormat.formatDuration(1));
        Assert.AreEqual("1 minute and 2 seconds", HumanTimeFormat.formatDuration(62));
        Assert.AreEqual("2 minutes", HumanTimeFormat.formatDuration(120));
        Assert.AreEqual("1 hour, 1 minute and 2 seconds", HumanTimeFormat.formatDuration(3662));
        Assert.AreEqual("182 days, 1 hour, 44 minutes and 40 seconds", HumanTimeFormat.formatDuration(15731080));
        Assert.AreEqual("4 years, 68 days, 3 hours and 4 minutes", HumanTimeFormat.formatDuration(132030240));
        Assert.AreEqual("6 years, 192 days, 13 hours, 3 minutes and 54 seconds",
            HumanTimeFormat.formatDuration(205851834));
        Assert.AreEqual("8 years, 12 days, 13 hours, 41 minutes and 1 second",
            HumanTimeFormat.formatDuration(253374061));
        Assert.AreEqual("7 years, 246 days, 15 hours, 32 minutes and 54 seconds",
            HumanTimeFormat.formatDuration(242062374));
        Assert.AreEqual("3 years, 85 days, 1 hour, 9 minutes and 26 seconds",
            HumanTimeFormat.formatDuration(101956166));
        Assert.AreEqual("1 year, 19 days, 18 hours, 19 minutes and 46 seconds",
            HumanTimeFormat.formatDuration(33243586));
    }
}