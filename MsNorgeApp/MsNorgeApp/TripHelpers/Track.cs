using MsNorgeApp.MapHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsNorgeApp.TripHelpers
{
    public class Track
    {
        public DateTime Time { get; set; }
        public GeoLocation GeoLoc { get; set; }

        public Status TrackStatus { get; set; }
        

        public Track(GeoLocation loc, Status status = Status.Track)
        {
            Time = DateTime.Now;
            GeoLoc = loc;
            TrackStatus = status; //Default

        }

        public void setStatus(Status s)
        {
            TrackStatus = s;
        }
    }
    public enum Status : int
    {
        Start = 0,
        Track = 1,
        Stop = 2,
        BreakStart = 11,
        BreakStop = 12,
        PowerOff = 21,
        LostSignal = 22,
        Unknown = 29
    }

}
