import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PlaylistsClient, SongBriefDto } from 'src/app/web-api-client';
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
  public playlistCoverImage: string = "";
  public playlistSongCount: number = 0;


  constructor(
    private route: ActivatedRoute,
    private client: PlaylistsClient,
    private router: Router
  ) {}


  ngOnInit() {
    this.route.data
      .subscribe(data => {
        const playlist = data['playlistBriefDto'];
        console.log(playlist);

        this.playlistName = playlist.name;
        this.playlistCoverImage = playlist.coverImageUrl;

        playlist.songs.map((song: SongBriefDto)  => {
          this.songs.push(new Song(song.locationUrl!, song.title!, song.artistName!, song.coverImageUrl!, song.genreName!))
        });

        this.playlistSongCount = playlist.songs.length;
      });
  }

  onDeletePlaylist() {
    this.route.paramMap.subscribe(param => {
      const id = param.get('id')!;
      this.client.delete(+id).subscribe(_ => {
        (document.querySelector('dialog') as HTMLDialogElement).close();
         this.router.navigate(['/playlists']);
      }, error => console.error(error));
    });
  }
}
