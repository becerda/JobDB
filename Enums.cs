using System;

namespace Job_Application_Database.Enum
{
    /// <summary>
    /// Current Application Status With A Company
    /// </summary>
    [Flags]
    public enum ApplicationStatus
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

    /// <summary>
    /// The Type Of Position With A Company
    /// </summary>
    public enum PositionType
    {
        NA = 0,         // Not Applicable / Blank
        Part = 1,       // Part-Time
        Full = 2,       // Full-Time
        Contract = 3    // Contract
    }

    /// <summary>
    /// Window Exit Status
    /// </summary>
    public enum ExitStatus
    {
        Ok,             // Status Ok
        Cancel          // Status Cancel
    }

    /// <summary>
    /// Window Creation Mode
    /// </summary>
    public enum EditMode
    {
        New,            // Window Mode New
        Edit            // Window Mode Edit
    }

    /// <summary>
    /// Graph Types
    /// </summary>
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
        /// <summary>
        /// Parse An Int To A Status Flag
        /// </summary>
        /// <param name="status">The Flag To Parse</param>
        /// <returns></returns>
        public static ApplicationStatus ParseStatus(int status)
        {
            ApplicationStatus s = ApplicationStatus.NA;

            if ((status & 1) == 1) s |= ApplicationStatus.Applied;
            if ((status & 2) == 2) s |= ApplicationStatus.Hunted;
            if ((status & 4) == 4) s |= ApplicationStatus.Assignment;
            if ((status & 8) == 8) s |= ApplicationStatus.Interview;
            if ((status & 16) == 16) s |= ApplicationStatus.Offered;
            if ((status & 32) == 32) s |= ApplicationStatus.Accepted;
            if ((status & 64) == 64) s |= ApplicationStatus.Denied;
            if ((status & 128) == 128) s |= ApplicationStatus.Rejected;

            return s;
        }

        /// <summary>
        /// Parse An Int To A Position Type
        /// </summary>
        /// <param name="type">The Flag To Parse</param>
        /// <returns></returns>
        public static PositionType ParsePositionType(int type)
        {
            if (type == 1) return PositionType.Part;
            if (type == 2) return PositionType.Full;
            if (type == 3) return PositionType.Contract;
            return PositionType.NA;
        }
    }

}
