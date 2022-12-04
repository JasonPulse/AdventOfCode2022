namespace AdventOfCode2022.Day_3;

public class RuckSackCompartments : IEquatable<RuckSackCompartments>
{
    public string Compartment1 { get; set; }
    public string Compartment2 { get; set; }
    
    public List<char> CommonItems { get; set; }

    public bool Equals(RuckSackCompartments? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Compartment1 == other.Compartment1 && Compartment2 == other.Compartment2 && CommonItems.Equals(other.CommonItems);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((RuckSackCompartments)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Compartment1, Compartment2, CommonItems);
    }
}