using StatsLibrary;

/// class ColumnHeader with name, type, description, formatting, and timestamp
public class ColumnHeader
{
    /// name of column
    public string Name { get; set; }
    /// type of column (int, double, DateTime) as enum
    public ColumnType Type { get; set; }
    /// enum for column type
    public enum ColumnType
    {
        Int,
        Double,
        DateTime
    }
    /// description of column
    public string Description { get; set; }
    /// formatting of column
    public string Format { get; set; }
    /// timestamp of column
    public DateTime Timestamp { get; set; }

    /// constructor with name, type, description, formatting, and timestamp
    public ColumnHeader(string name, ColumnType type, string description, string format, DateTime timestamp)
    {
        Name = name;
        Type = type;
        Description = description;
        Format = format;
        Timestamp = timestamp;
    }

    /// constructor with name, type, description, formatting
    public ColumnHeader(string name, ColumnType type, string description, string format) : this(name, type, description, format, DateTime.Now)
    {
    }
    /// constructor with name, type, description
    public ColumnHeader(string name, ColumnType type, string description) : this(name, type, description, "", DateTime.Now)
    {
    }
    /// constructor with name, type
    public ColumnHeader(string name, ColumnType type) : this(name, type, "", "", DateTime.Now)
    {
    }
    /// constructor with name
    public ColumnHeader(string name) : this(name, ColumnType.Double, "", "", DateTime.Now)
    {
    }

    /// equals method
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        ColumnHeader columnHeader = (ColumnHeader)obj;
        return Name == columnHeader.Name && Type == columnHeader.Type && Description == columnHeader.Description && Format == columnHeader.Format && Timestamp == columnHeader.Timestamp;
    }

    /// override GetHashCode
    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Type.GetHashCode() ^ Description.GetHashCode() ^ Format.GetHashCode() ^ Timestamp.GetHashCode();
    }   
    /// equality operator
    public static bool operator ==(ColumnHeader columnHeader1, ColumnHeader columnHeader2)
    {
        return columnHeader1.Equals(columnHeader2);
    }   
    /// inequality operator
    public static bool operator !=(ColumnHeader columnHeader1, ColumnHeader columnHeader2)
    {
        return !columnHeader1.Equals(columnHeader2);
    }
    /// override ToString
    public override string ToString()
    {
        return $"{Name} {Type} {Description} {Format} {Timestamp}";
    }
    /// override Equals
    public bool Equals(ColumnHeader columnHeader)
    {
        return Name == columnHeader.Name && Type == columnHeader.Type && Description == columnHeader.Description && Format == columnHeader.Format && Timestamp == columnHeader.Timestamp;
    }
    /// copy constructor
    public ColumnHeader(ColumnHeader columnHeader)
    {
        Name = columnHeader.Name;
        Type = columnHeader.Type;
        Description = columnHeader.Description;
        Format = columnHeader.Format;
        Timestamp = columnHeader.Timestamp;
    }
    /// default constructor
    public ColumnHeader(): this("", ColumnType.Double, "", "", DateTime.Now)
    {
    }
    /// formatted ToString
    public string ToString(string format = "yyyy-MM-dd HH:mm:ss")
    {
        return $"{Name} {Type} {Description} {Format} {Timestamp.ToString(format)}";
    }



}
