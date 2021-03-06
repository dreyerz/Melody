﻿using Melody.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melody.ViewModel
{
    // Right now PlayListManager is managing both playlists and songs
    // QUESTION: Is it appropriate for there to be another ViewModel class
    // called SongManager?
    public static class PlayListManager
    {
        // Guaranteed to be static because it is const, correct?
        private const int DUMMY_SONGS_COUNT = 4;

        private static PlayList allSongsPlayList;
        private static List<PlayList> allPlayLists;
        private static JsonHelper.RootObject dataRoot;

        //private static readonly List<Song> allSongs = new List<Song>();


        /// <summary>
        /// Fills out the caller's ObservableCollection<PlayList> with all playlists
        /// </summary>
        /// <param name="displayedPlayLists"></param>
        public static void GetAllPlayLists(
                                    ObservableCollection<PlayList> ocPlayLists)
        {
            // Observer pattern specifies to clear the ObservableCollection 
            ocPlayLists.Clear();

            foreach (var playList in allPlayLists)
            {
                ocPlayLists.Add(playList);
            }
        }

        public static void GetSongsByPlayList(
                                        ObservableCollection<Song> ocSongs,
                                        PlayList playList)
        {
            // Observer pattern specifies to clear the ObservableCollection 
            ocSongs.Clear();

            foreach(var song in playList.Songs)
            {
                ocSongs.Add(song);
            }
        }

        public static void GetAllSongs(ObservableCollection<Song> ocSongs)
        {
            // Observer pattern specifies to clear the ObservableCollection 
            ocSongs.Clear();
            foreach (var song in allSongsPlayList.Songs)
            {
                ocSongs.Add(song); 
            }
        }

        public static PlayList CreateNewPlayList(
                                        string name, IEnumerable<Song> songs)
        {
            var newPlaylist = new PlayList(name);
            songs.ToList().ForEach( song => newPlaylist.Songs.Add(song) );
            allPlayLists.Add(newPlaylist);


            // Update the external data store with the new playlist
            dataRoot.playlists.Add(newPlaylist);
            //JsonHelper.WriteData(dataRoot);
            
            return newPlaylist;
        }

        public static void Setup()
        {
            dataRoot = JsonHelper.GetData();
            allPlayLists = JsonHelper.GetData().playlists;
            allSongsPlayList = allPlayLists[0];


            //CreateDummyAllSongsPlayList();
            //JSONHelper.GetAllPlayLists(allPlayLists);
        }

        //private static void CreateDummyAllSongsPlayList()
        //{
        //    // Populate with dummy songs
        //    // (Represents the entire library of songs)
        //    for (var num = 1; num <= DUMMY_SONGS_COUNT; ++num)
        //    {
        //        var dummysong = new Song($"Placeholder Song Name {num}", "Placeholder Song Artist", "Placeholder Song Genre");
        //        allSongsPlayList.Songs.Add(dummysong);

        //    }

        //    // First PlayList in the collection will be All Songs
        //    // Or not? Maybe need to special-case this?
        //    allPlayLists.Add(allSongsPlayList);

        //}


        public static Song AddNewSong(string name, string artist, string genre)
        {
            var newSong = new Song (name, artist, genre);
            allSongsPlayList.Songs.Add(newSong);

            // Update the external data store with the new song
            dataRoot.playlists[0].Songs.Add(newSong);
            //JsonHelper.WriteData(dataRoot);

            return newSong;

        }

    }
}
