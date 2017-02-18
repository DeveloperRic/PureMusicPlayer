#PureMusicPlayer
Enjoy your music wherever you are! (At least that's the plan)

PurePlayer is a project I've been working on in my spare time. It is built on VisualBasic and compiled in Visual Studio 2015 Community. If you would like to help contribute to PurePlayer, here is a detailed explanation of what each class does:

* **PurePlayer**:
This module holds usefull variables and functions that are called thoughout the PureMusicPlayer project. For example the queue is held here, so that any class that wants to know what music is currently playing would access PurePlayer.queue

* **MainPlayer**:
This form is where all the magic happens. Everything that the user sees is processed through this form. Each page that is displayed (Home, Queue, Album, Playlist etc.). It may seem a little complicated at first, but I am working on annotiating everything, I just wanted to get it working first.

* **Track**:
This class holds all information about a particular song, along with methods to play the track and shared functions for handling all tracks' data. All data is stored in the PurePlayer_Files/tracks folder without primary keys. However, once loaded its retrieved directory servs as the track's primary key.

* **TrackList**:
This class is used to add interactive and responsive collections of visual tracks to a specified "base" control (usually a panel). The process takes 5 parameters; the list of tracks, the base control, the initial location, initial size, and TrackListData used for idetifying what the tracklist is what what it does.

* **TrackListView**:
This is a user control I created to hold the visual container and its items that is placed on the TrackList's base contraol. In future this control will be used to filter and sort tracks in the TrackList.

* **TrackListItem**:
This as well is a user control. It is the visual container of a specific track in the TrackListView. A user can doubleclick to play, right click for options specific to the item's TrackList's data. It holds it's own events for responding to user actions.

* **ImportTracks**:
This form is used to adding tracks to PurePlayer. That's basically it, although it also downloads data from Last.fm (but that's technically done by the Tracks class.

* **Queue**:
This class is used to hold information about a list of tracks including from where, how and when they are playing.

* **TrackInfo**:
This form is used to allow the user to edit track info, download info from Last.fm, and set their own track album/single covers.

* **TileManager**:
This class is used to hold and manage a collection of Tiles.

* **Tile**:
This is a user control I created to allow the user to click within a rectangular area (that has a label) and get taken to the page compatible with the data supplied to it. It can also be used as headings for a group of other Tiles.

* **Playlist**:
This is a class that holds information about a playlist along with shared functions for managing all playlists.

* **PlaylistCover**:
This is a user control I created to display the cover(s) of a playlist in a table layout. If the playlist has 4 or more tracks the first 4 tracks' covers are shown in order, otherwise only the first track's cover is displayed.

* **PlaylistCard**:
This is a user control I created to display a playlist's name over a PlaylistCover. It also allows the user to click on it and play tracks in that playlist.

* **Animations**:
This is a module that holds classes I use to animate stuff or do stuff collectively (rarely used though).

_Note: This project is still in Beta_

I hope to add streaming capabilities from source such as Spotify, Soundcloud and GooglePlayMusic.
