import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SongBriefDto } from 'src/app/web-api-client';
import { Song } from '../models/song.model';

@Component({
  selector: 'app-playlist-details',
  templateUrl: './playlist-details.component.html',
  styleUrls: ['./playlist-details.component.scss']
})
export class PlaylistDetailsComponent {
  public songs: Song[] = [];
  public playlistName: string = "";
  public playlistDescription: string = "";
  public playlistSongCount: number = 0;

  constructor(
    private route: ActivatedRoute
  ) {}


  ngOnInit() {
    this.route.data
      .subscribe(data => {
        const playlist = data['playlistBriefDto'];
        console.log(playlist);

        this.playlistName = playlist.name;
        playlist.songs.map((song: SongBriefDto)  => {
          this.songs.push(new Song('../../../../assets/songs/Dan Balan - Chica Bomb Official Video HD Hype Williams.mp3', song.title!, song.artistName!, song.coverImageUrl!, song.genreName!))
        });

        this.playlistSongCount = playlist.songs.length;
      });
  }
}
