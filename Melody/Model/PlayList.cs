﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melody.Model
{
    //Playlist model to define playlist collection (e.g. All Songs)
    public sealed class PlayList // : INotifyPropertyChanged (see TODO)
    {
        //Properties of playlist
        public string Name { get; set; }
        public string CoverFilePath { get; set; }
        //Playlistmodel type should be renamed to Song
        private readonly List<Song> songs;

        public PlayList(string name)
        {
            Name = name;
            CoverFilePath = "/Assets/PlaylistCoverPlaceholder.png";
            songs = new List<Song>();
        }

        // TODO: PlayList (or maybe a wrapper around it?)
        // must implement INotifyPropertyChanged in order for the UI to update
        // when PlayList objects inside it change state
        // https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8
    }
}
