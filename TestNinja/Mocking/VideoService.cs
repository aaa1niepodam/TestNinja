using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;
        private IVideoRepository _repository;

        public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
        {
            _fileReader = fileReader ?? new FileReader();
            _repository = repository ?? new VideoRepository();
        }

        public string ReadVideoTitle()
        {
            //var str = File.ReadAllText("video.txt"); //external resource
            //var str = new FileReader().Read("video.txt"); //VideoService tightly-coupled with FileReader
            //var str = fileReader.Read("video.txt");
            var str = _fileReader.Read("video.txt");

            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        //[] => ""
        // [{},{},{},{}] => "1,2,3"
        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            
            using (var context = new VideoContext())
            {
                //external resources because is in context
                //var videos = 
                //    (from video in context.Videos
                //    where !video.IsProcessed
                //    select video).ToList();

                //var videos = new VideoRepository().GetUnprocessedVideos();

                //foreach (var v in videos)
                //    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
            }
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}