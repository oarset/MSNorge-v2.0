using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsNorgeApp.MapHelpers;
using MsNorgeApp.TripHelpers;


namespace MsNorgeApp.UserData
{
    public class Trip : Calculations
    {
        public IList<Track> Tracks { get; set; }
        
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        private TripStatus Status;
        private double Duration;
        private double Distance;
        private Track PreviousTrack;


        public Trip() 
        {
            Status = TripStatus.Created;
        }
        public void StartTrip(GeoLocation loc)
        {
            StartTime = DateTime.Now;
            Status = TripStatus.Started;
            Track PreviousTrack = AddTrack(loc, TripHelpers.Status.Start);
            Duration = 0;
            Distance = 0;
        }

        public Track AddTrack(GeoLocation loc, Status status = TripHelpers.Status.Track)
        {
            Track trackToAdd = new Track(loc, status);
            Distance += calculateDistance(PreviousTrack, trackToAdd);
            Duration += calculateDuration(PreviousTrack, trackToAdd);
            Tracks.Add(trackToAdd);
            PreviousTrack = trackToAdd;
            return trackToAdd;
        }

        public double calculateDuration(Track t1, Track t2)
        {
            
            return (t2.Time - t1.Time).TotalSeconds;
        }

        public double calculateDistance(Track from, Track to)
        {
            var lat1 = from.GeoLoc.Latitude;
            var lat2 = to.GeoLoc.Latitude;
            var lon1 = from.GeoLoc.Longitude;
            var lon2 = to.GeoLoc.Longitude;

            var earthRadius = 637100;
            
            //double lat1rad = ;
            //double lat2rad = ;

            var lonDiff = deg2rad(lon2 - lon1);
            var latDiff = deg2rad(lat2 - lat1);

            //haversine
            var a = Math.Sin(latDiff/2) * Math.Sin(latDiff/2) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(lonDiff/2) * Math.Cos(lonDiff/2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return (earthRadius * c);
        }


    }
    public enum TripStatus
    {
        Created = 0,
        Started = 1,
        InProgress = 2,
        Break = 3,
        Halted = 4,
        Completed = 5,
        Aborted = 10,
        Unknown = 11
    }
}
