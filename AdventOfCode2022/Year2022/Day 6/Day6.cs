using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using AdventOfCode2022.Year2022.Day_6.Interfaces;

namespace AdventOfCode2022.Year2022.Day_6;

public class Day6 : BaseDay
{
    private IEnumerable<string> RawData { get; set; }
    protected IPacketDetector PacketDetector { get; set; }
    
    protected IMessageDetector MessageDetector { get; set; }
    public Day6(IInputFileService inputFileService, IPacketDetector packetDetector, IMessageDetector messageDetector) : base("Day6InputData.txt", inputFileService)
    {
        this.PacketDetector = packetDetector;
        this.MessageDetector = messageDetector;
        this.RawData = this.GetInputs();
    }

    public int CheckForPacket()
    {
        return this.PacketDetector.StartOfPacket(RawData.ToList()[0]);
    }
    
    public int CheckForMessage()
    {
        return this.MessageDetector.StartOfMessage(RawData.ToList()[0]);
    }
}