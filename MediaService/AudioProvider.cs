using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Media;
using Android.Media.Session;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SkiaSharp;
using SkiaSharp.Views.Android;
using System.Collections.Concurrent;

namespace MyPodCast.MediaService
{
    public enum State
    {
        NotInitialized,
        Initializing,
        Initialized
    };

    public class AudioProvider
    {
        public const string PodcastSource = "PODCASTS_SOURCE";
        private Dictionary<int, List<MediaMetadata>> _musicListByPlayist;
        private Dictionary<string, MediaMetadata> _musicListById;
        private List<string> _favorites;
        private volatile State _currentState = State.NotInitialized;
        public Playlist[] _playlists;
        private string appKey = "AndroidAuto";
        private string apiKey = "c2267cf418274ceb95c15ad2fbd212a3";


        //public List<string> Months
        //{
        //    get
        //    {
        //        return _currentState != State.Initialized ? new List<string>() : new List<string>(_musicListByPlayist.Keys);
        //    }
        //}
        public bool IsInitialized
        {
            get
            {
                return _currentState == State.Initialized;
            }
        }
        private Playlist[] GetPlaylists()
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
                Id = 0,
                Name = "Top Stories",
                ImageURL = "https://storageaudiobursts.blob.core.windows.net/site/images/CategoryIcons/AB_API_usnews_01_200x200.png"
            });
            list.Add(new Playlist
            {
                Id = 90,
                Name = "Offbeat",
                ImageURL = "https://storageaudiobursts.blob.core.windows.net/site/images/CategoryIcons/AB_API_offbeat_01_200x200.png"
            });
            list.Add(new Playlist
            {
                Id = 4,
                Name = "US News",
                ImageURL = "https://storageaudiobursts.blob.core.windows.net/site/images/CategoryIcons/AB_API_usnews_01_200x200.png"
            });
            list.Add(new Playlist
            {
                Id = 10,
                Name = "Sports",
                ImageURL = "https://storageaudiobursts.blob.core.windows.net/site/images/CategoryIcons/AB_API_sports_01_200x200.png"
            });
            list.Add(new Playlist
            {
                Id = 9,
                Name = "Entertainment",
                ImageURL = "https://storageaudiobursts.blob.core.windows.net/site/images/CategoryIcons/AB_API_entertainment_01_200x200.png"
            });
            list.Add(new Playlist
            {
                Id = 6,
                Name = "World News",
                ImageURL = "https://storageaudiobursts.blob.core.windows.net/site/images/CategoryIcons/AB_API_worldnews_01_200x200.png"
            });
            list.Add(new Playlist
            {
                Id = 3,
                Name = "Business",
                ImageURL = "https://storageaudiobursts.blob.core.windows.net/site/images/CategoryIcons/AB_API_business_01_200x200.png"
            });
            list.Add(new Playlist
            {
                Id = 5,
                Name = "Tech",
                ImageURL = "https://storageaudiobursts.blob.core.windows.net/site/images/CategoryIcons/AB_API_business_01_200x200.png"
            });
            return list.ToArray();
        }
        private AudioBurstResponse GetPlaylistBursts(int playlistId)
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
        public AudioProvider()
        {
            _playlists = GetPlaylists();
            _musicListByPlayist = new Dictionary<int, List<MediaMetadata>>();
            _musicListById = new Dictionary<string, MediaMetadata>();
            _favorites = new List<string>();
        }


        public IEnumerable<MediaMetadata> GetMusicsByPlaylist(int playlistId)
        {
            if (_currentState != State.Initialized || !_musicListByPlayist.ContainsKey(playlistId))
                return new List<MediaMetadata>();

            return _musicListByPlayist[playlistId];
        }

        public IEnumerable<MediaMetadata> SearchMusic(string titleQuery)
        {
            if (_currentState != State.Initialized)
                return new List<MediaMetadata>();

            var result = new List<MediaMetadata>();
            titleQuery = titleQuery.ToLower();
            foreach (var track in _musicListById.Values)
            {
                if (track.GetString(MediaMetadata.MetadataKeyTitle).ToLower().Contains(titleQuery))
                    result.Add(track);
            }
            return result;
        }

        public MediaMetadata GetMusic(string mediaId)
        {
            return _musicListById.ContainsKey(mediaId) ? _musicListById[mediaId] : null;
        }

        public void SetFavorite(string mediaId, bool favorite)
        {
            if (favorite)
                _favorites.Add(mediaId);
            else
                _favorites.Remove(mediaId);
        }

        public bool IsFavorite(string mediaId)
        {
            return _favorites.Contains(mediaId);
        }

        public void RetrieveMedia(Action<bool> callback)
        {
            Logger.Debug("RetrieveMedia");
            if (_currentState == State.Initialized)
            {
                callback(true);
                return;
            }

            try
            {
                if (_currentState == State.NotInitialized)
                {
                    _currentState = State.Initializing;
                    GetSource();
                    BuildListsByPlaylist();
                    _currentState = State.Initialized;
                }
            }
            catch (Exception e)
            {
                _currentState = State.NotInitialized;
            }
            callback(_currentState == State.Initialized);
        }

        private void BuildListsByPlaylist()
        {
            _musicListByPlayist = new Dictionary<int, List<MediaMetadata>>();
            foreach (var m in _musicListById.Values)
            {
                var genre = m.GetString(MediaMetadata.MetadataKeyGenre);
                int playlistId = _playlists.Where(p => p.Name == genre).First().Id;
                if (_musicListByPlayist.ContainsKey(playlistId))
                    _musicListByPlayist[playlistId].Add(m);
                else
                    _musicListByPlayist.Add(playlistId, new List<MediaMetadata> { m });
            }
        }

        private void GetSource()
        {
            var results = new ConcurrentBag<BurstEntry>();
            Parallel.ForEach(_playlists, (pl) =>
            {
                var bursts = GetPlaylistBursts(pl.Id).bursts;
                Parallel.ForEach(bursts, (burst) =>
                {
                    results.Add(new BurstEntry
                    {
                        BurstId = burst.burstID + "_" + pl.Id,
                        AudioURL = burst.contentURLs.audioURL,
                        SourceName = burst.source.sourceName,
                        ShowName = burst.source.showName,
                        Category = pl.Name,
                        BurstIcon = burst.contentURLs.imageURL[3],
                        BurstImage = burst.contentURLs.imageURL[1],
                        Title = burst.title
                    });
                });
            });

            

            foreach (var data in results)
            {
                //List<Bitmap> images = GetImage(800, 480, 128, 128, data.BurstImage);
                try
                {
                    _musicListById.Add(data.BurstId, new MediaMetadata.Builder()
                    .PutString(MediaMetadata.MetadataKeyMediaId, data.BurstId)
                    .PutString(PodcastSource, data.AudioURL)
                    .PutString(MediaMetadata.MetadataKeyAlbum, data.SourceName)
                    .PutString(MediaMetadata.MetadataKeyArtist, data.ShowName)
                    .PutString(MediaMetadata.MetadataKeyGenre, data.Category)
                    .PutString(MediaMetadata.MetadataKeyAlbumArtUri, data.BurstIcon)
                    .PutString(MediaMetadata.MetadataKeyTitle, data.Title)
                    //.PutBitmap(MediaMetadata.MetadataKeyAlbumArt, images[0])
                    //.PutBitmap(MediaMetadata.MetadataKeyDisplayIcon, images[1])
                    //.PutLong(MediaMetadata.MetadataKeyDuration, duration)
                    //.PutLong(MediaMetadata.MetadataKeyTrackNumber, trackNumber)
                    //.PutLong(MediaMetadata.MetadataKeyNumTracks, totalTrackCount)
                    .Build());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        private static List<Bitmap> GetImage(int width, int height, int iconWidth, int iconHeight, string url)
        {
            List<Bitmap> images = new List<Bitmap>();

            using (WebClient client = new WebClient())
            {
                byte[] data = client.DownloadData(url);
                using (var original = SKBitmap.Decode(data))
                {
                    using (var resized = original.Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3))
                    {
                        images.Add(resized.ToBitmap());
                    }
                    using (var resized = original.Resize(new SKImageInfo(iconWidth, iconHeight), SKBitmapResizeMethod.Lanczos3))
                    {
                        images.Add(resized.ToBitmap());
                    }
                }
            }

            return images;
        }

        public List<MediaSession.QueueItem> GetRandomQueue()
        {
            //List<string> months = this.Months;

            if (_playlists.Length <= 1)
                return new List<MediaSession.QueueItem>();

            //string month = months[0];
            IEnumerable<MediaMetadata> tracks = this.GetMusicsByPlaylist(_playlists[0].Id);

            return ConvertToQueue(tracks, HierarchyHelper.PodcastsByMonth, _playlists[0].Id.ToString());
        }

        private List<MediaSession.QueueItem> ConvertToQueue(IEnumerable<MediaMetadata> tracks, params string[] categories)
        {
            var queue = new List<MediaSession.QueueItem>();
            int count = 0;
            foreach (var track in tracks)
            {
                string hierarchyAwareMediaID = HierarchyHelper.EncodeMediaID(track.Description.MediaId, categories);
                MediaMetadata trackCopy = new MediaMetadata.Builder(track)
                    .PutString(MediaMetadata.MetadataKeyMediaId, hierarchyAwareMediaID)
                    .Build();

                var item = new MediaSession.QueueItem(trackCopy.Description, count++);
                queue.Add(item);
            }
            return queue;

        }

        public List<MediaSession.QueueItem> GetPlayingQueue(string mediaId)
        {
            string[] hierarchy = HierarchyHelper.GetHierarchy(mediaId);

            if (hierarchy.Length != 2)
                return null;

            string categoryType = hierarchy[0];
            string categoryValue = hierarchy[1];

            IEnumerable<MediaMetadata> tracks = null;
            if (categoryType == HierarchyHelper.PodcastsByMonth)
                tracks = this.GetMusicsByPlaylist(int.Parse(categoryValue));
            else if (categoryType == HierarchyHelper.PodcastsBySearch)
                tracks = this.SearchMusic(categoryValue);

            if (tracks == null)
                return null;

            return ConvertToQueue(tracks, hierarchy[0], hierarchy[1]);
        }

        public List<MediaSession.QueueItem> GetPlayingQueueFromSearch(string query)
        {
            return ConvertToQueue(this.SearchMusic(query), HierarchyHelper.PodcastsBySearch, query);
        }
    }
}