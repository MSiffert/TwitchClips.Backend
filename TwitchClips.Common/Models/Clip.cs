﻿namespace TwitchClips.Common.Models
{
    public class Clip
    {
        public string Id { get; set; }
        
        public string Url { get; set; }
        
        public string EmbedUrl { get; set; }
        
        public string BroadcasterId { get; set; }
        
        public string BroadcasterName { get; set; }
        
        public string CreatorId { get; set; }
        
        public string CreatorName { get; set; }
        
        public string VideoId { get; set; }
        
        public string GameId { get; set; }
        
        public string Language { get; set; }
        
        public string Title { get; set; }
        
        public int ViewCount { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public string ThumbnailUrl { get; set; }
    }
}