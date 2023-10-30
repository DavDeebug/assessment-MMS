namespace Assessment.Console.Models;

public class Csv
{
    public string? GivenName { get; }
    public string? FamilyName { get; }

    public Csv(string? givenName, string? familyName)
    {
        GivenName = givenName ?? string.Empty;
        FamilyName = familyName ?? string.Empty;
    }

    public bool Equals(Csv? other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(other, this)) return true;
        return string.Equals(GivenName, other.GivenName, StringComparison.InvariantCultureIgnoreCase)
            && string.Equals(FamilyName, other.FamilyName, StringComparison.InvariantCultureIgnoreCase);
    }


    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, null)) return false;
        if (ReferenceEquals(obj, this)) return true;
        return obj.GetType() == this.GetType()
            && Equals((Csv)obj);
    }

    public override int GetHashCode()
    {
        HashCode hashCode = new();
        hashCode.Add(GivenName, StringComparer.InvariantCultureIgnoreCase);
        hashCode.Add(FamilyName, StringComparer.InvariantCultureIgnoreCase);

        return hashCode.ToHashCode();
    }    
}