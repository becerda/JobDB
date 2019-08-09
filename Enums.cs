using System;

namespace Job_Application_Database.Enum
{
    // Current Position Status With A Company
    [Flags]
    public enum Status
    {
        NA = 0,
        Applied = 1,     // I Applied to company
        Hunted = 2,      // I was head Hunted
        Assignment = 4,  // Company gave me Assingment/Skills test
        Interview = 8,   // Company offered Interview
        Offered = 16,     // Company Offered position
        Accepted = 32,    // I Accepted offered position
        Denied = 64,      // I Denied offered position
        Rejected = 128    // Company Rejected my application
    }

    // Position Type
    public enum PositionType
    {
        NA = 0,         // Not Applicable / Blank
        Part = 1,       // Part-Time
        Full = 2,       // Full-Time
        Contract = 3    // Contract
    }

    // Window Exit Status
    public enum ExitStatus
    {
        Ok,             // Status Ok
        Cancel          // Status Cancel
    }

    // Creation Window Mode
    public enum EditMode
    {
        New,            // Window Mode New
        Edit            // Window Mode Edit
    }

    public enum SeriesType
    {
        Area,           // AreaSeries
        Bar,            // BarSeries
        Column,         // ColumnSeries
        Line,           // LineSeries
        Pie,            // PieSeries
        Scatter         // ScatterSeries
        
    }

    /// <summary>
    /// Enum Class With Helper Functions
    /// </summary>
    public static class Enums
    {
        // Parse An Int To A Status Flag
        public static Status ParseStatus(int status)
        {
            Status s = Status.NA;

            if ((status & 1) == 1) s |= Status.Applied;
            if ((status & 2) == 2) s |= Status.Hunted;
            if ((status & 4) == 4) s |= Status.Assignment;
            if ((status & 8) == 8) s |= Status.Interview;
            if ((status & 16) == 16) s |= Status.Offered;
            if ((status & 32) == 32) s |= Status.Accepted;
            if ((status & 64) == 64) s |= Status.Denied;
            if ((status & 128) == 128) s |= Status.Rejected;

            return s;
        }

        // Parse An Int To A Position Type
        public static PositionType ParsePositionType(int type)
        {
            if (type == 1) return PositionType.Part;
            if (type == 2) return PositionType.Full;
            if (type == 3) return PositionType.Contract;
            return PositionType.NA;
        }
    }

}
