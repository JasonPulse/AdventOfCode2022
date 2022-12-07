using AdventOfCode2022.Year2022.Day_6.Interfaces;
using AdventOfCode2022.Year2022.Day_6.Models;

namespace AdventOfCode2022.Year2022.Day_6.Services;

public class MessageDetector : IMessageDetector
{
    public int StartOfMessage(string datastream)
    {
        var buffer = new RollingList<char>(14);
        buffer.Add(datastream[0]);
        buffer.Add(datastream[1]);
        buffer.Add(datastream[2]);
        buffer.Add(datastream[3]);
        buffer.Add(datastream[4]);
        buffer.Add(datastream[5]);
        buffer.Add(datastream[6]);
        buffer.Add(datastream[7]);
        buffer.Add(datastream[8]);
        buffer.Add(datastream[9]);
        buffer.Add(datastream[10]);
        buffer.Add(datastream[11]);
        buffer.Add(datastream[12]);
        buffer.Add(datastream[13]);

        for (var i = 14; i < datastream.Length; i++)
        {
            buffer.Add(datastream[i]);

            if (CheckBufferUnique(buffer))
                return i + 1;
        }

        return 0;
    }

    private bool CheckBufferUnique(RollingList<char> buffer)
    {
        return buffer.Distinct().Count() == 14;
    }
}