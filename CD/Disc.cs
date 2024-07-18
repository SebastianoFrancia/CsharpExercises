using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD
{
    internal class Disc
    {
        private string _title;
        private string _artist;
        private List<Track> _tracks;
        public string Title
        {
            get { return _title; }
            private set
            {
                if (value == null) throw new ArgumentException("the title is void");
                _title = value;
            }
        }

        public string Artist
        {
            get { return _artist; }
            private set
            {
                if (value == null) throw new ArgumentException("the artist name is void");
                _artist = value;
            }
        }

        public List<Track> Tracks
        { 
            get { return _tracks; } 
        }
        
        public Disc(string title, string artistName)
        {
            Title = title;
            Artist = artistName;
            _tracks = new List<Track>();
        }

        public void AddTrack(Track track)
        { 
            _tracks.Add(track); 
        }

        public int DurationSeconds()
        {
            int duration = 0;
            foreach (Track track in _tracks)
            {
                duration += track.Time;
            }
            return duration;
        }

    }
}
