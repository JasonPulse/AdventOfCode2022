using AdventOfCode2022.Year2022.Day_6.Interfaces;
using AdventOfCode2022.Year2022.Day_6.Models;

namespace AdventOfCode2022.Year2022.Day_6.Services;

public class PacketDetector : IPacketDetector
{
    
    public int StartOfPacket(string datastream)
    {
        var buffer = new RollingList<char>(4);
        buffer.Add(datastream[0]);
        buffer.Add(datastream[1]);
        buffer.Add(datastream[2]);
        
        for (var i = 3; i < datastream.Length; i++)
        {
            buffer.Add(datastream[i]);

            if (CheckBufferUnique(buffer))
                return i + 1;
        }

        return 0;
    }

    private bool CheckBufferUnique(RollingList<char> buffer)
    {
        return buffer.Distinct().Count() == 4;
    }
}