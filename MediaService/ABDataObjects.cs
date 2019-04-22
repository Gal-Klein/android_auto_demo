using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyPodCast.MediaService
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
    }

    public class AudioBurstResponse
    {
        public string type { get; set; }
        public long queryID { get; set; }
        public string query { get; set; }
        public BurstData[] bursts { get; set; }
    }

    public class BurstData
    {
        public int index { get; set; }
        public string burstID { get; set; }
        public string title { get; set; }
        public BurstContent contentURLs { get; set; }
        public BurstSource source { get; set; }
        public string[] entities { get; set; }
        public string[] keywords { get; set; }
        public string category { get; set; }
        public double duration { get; set; }
        public DateTime creationDate { get; set; }
        public string color { get; set; }
    }

    public class BurstContent
    {
        public string burstURL { get; set; }
        public string audioURL { get; set; }
        public string[] imageURL { get; set; }
        public string searchSiteURL { get; set; }
    }
    public class BurstSource
    {
        public int sourceId { get; set; }
        public string sourceName { get; set; }
        public string sourceType { get; set; }
        public int showId { get; set; }
        public string showName { get; set; }
        public double position { get; set; }
        public string audioURL { get; set; }
        public string imageURL { get; set; }

    }
    public class AudioBurstSource
    {
        public string sourceID { get; set; }
        public string audioURL { get; set; }
        public double burstStartTime { get; set; }
    }

    public class BurstEntry
    {
        public string BurstId { get; set; }
        public string AudioURL { get; set; }
        public string SourceName { get; set; }
        public string ShowName { get; set; }
        public string Category { get; set; }
        public string BurstImage { get; set; }
        public string BurstIcon { get; set; }
        public string Title { get; set; }
    }
}