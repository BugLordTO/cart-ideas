public class BizAccount
{
    //...
    public OpeningSchedule OpeningSchedule { get; set; }
}

public class OpeningSchedule
{
    /// <summary>
    /// +7
    /// </summary>
    public int TimeZoneHour { get; set; }
    public IEnumerable<Schedule> Schedules { get; set; }
    /// <summary>
    /// ปิดร้านชั่วคราวถึงเวลา
    /// </summary>
    public DateTime? TemporaryClosingThruTime { get; set; }
}

public class Schedule
{
    /// <summary>
    /// 24h format  : hhmm => 0800 , 2200
    /// แปลงเป็น .ToString("0000") ก่อนใช้งาน
    /// </summary>
    public int OpeningTime { get; set; }
    /// <summary>
    /// 24h format  : hhmm => 0800 , 2200
    /// แปลงเป็น .ToString("0000") ก่อนใช้งาน
    /// </summary>
    public int ClosingTime { get; set; }
    
    public bool OnSunday { get; set; }
    public bool OnMonday { get; set; }
    public bool OnTuesday { get; set; } 
    public bool OnWednesday { get; set; }
    public bool OnThursday { get; set; }
    public bool OnFriday { get; set; }
    public bool OnSaturday { get; set; }
}