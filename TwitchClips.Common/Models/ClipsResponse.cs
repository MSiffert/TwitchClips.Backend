﻿namespace TwitchClips.Common.Models
{
    public class ClipsResponse
    {
        public List<Clip> Data { get; set; }
        public Pagination Pagination { get; set; }

        public ClipsResponse()
        {
            Data = new List<Clip>();
        }
    }
}
