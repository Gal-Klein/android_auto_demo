using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyPodCast.MediaService
{
    public class Content
    {
        private string appKey = "AndroidAuto";
        private string apiKey = "c2267cf418274ceb95c15ad2fbd212a3";

        public Content()
        {

        }

        public async Task<AudioBurstResponse> GetPlaylistBurstsAsync(int playlistId)
        {
            string apiURL = $"https://sapi.audioburst.com/v2/topstories/category?appkey={appKey}&device=mobile&category={playlistId}";
            if (playlistId == 0)
                apiURL = $"https://sapi.audioburst.com/v2/topstories?appkey={appKey}&device=mobile";
            HttpClient hc = new HttpClient();
            //hc.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            string json = await hc.GetStringAsync(apiURL);
            hc.Dispose();
            AudioBurstResponse playlistData = JsonConvert.DeserializeObject<AudioBurstResponse>(json);
            return playlistData;
        }
        public AudioBurstResponse GetPlaylistBursts(int playlistId)
        {
            string apiURL = $"https://sapi.audioburst.com/v2/topstories/category?appkey={appKey}&device=mobile&category={playlistId}";
            if (playlistId == 0)
                apiURL = $"https://sapi.audioburst.com/v2/topstories?appkey={appKey}&device=mobile";
            HttpClient hc = new HttpClient();
            //hc.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            var task = hc.GetStringAsync(apiURL);
            task.Wait();
            string json = task.Result; 
            hc.Dispose();
            AudioBurstResponse playlistData = JsonConvert.DeserializeObject<AudioBurstResponse>(json);
            return playlistData;
        }
        public Playlist[] GetPlaylists()
        {
            List<Playlist> list = new List<Playlist>();
            list.Add(new Playlist
            {
                Id = 91,
                Name = "Editors' Picks",
                ImageURL = "http://storageaudiobursts.blob.core.windows.net/site/images/CategoryIcons/intro1.png"
            });
            list.Add(new Playlist
            {
                Id = 4,
                Name = "US News",
                ImageURL = "https://storageaudiobursts.blob.core.windows.net/site/images/CategoryIcons/AB_API_usnews_01_600x315.png"
            });
            return list.ToArray();
        }

        public async Task<AudioBurstResponse> Search(string searchTerm)
        {
            string apiURL = $"http://sapi.audioburst.com/search/site?appKey={appKey}&device=mobile&user=gal&value={searchTerm}";
            HttpClient hc = new HttpClient();
            //hc.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            string json = await hc.GetStringAsync(apiURL);
            hc.Dispose();
            AudioBurstResponse playlistData = JsonConvert.DeserializeObject<AudioBurstResponse>(json);
            return playlistData;
        }
    }
}