import { Component } from '@angular/core';
import { Song } from '../models/song.model';
import { SongBriefDto, SongsClient } from 'src/app/web-api-client';

@Component({
  selector: 'app-main-playlist',
  templateUrl: './main-playlist.component.html',
  styleUrls: ['./main-playlist.component.scss']
})
export class MainPlaylistComponent {
  public songs: Song[] = [{
    artistName : 'test',
    imageUrl : '../../../../assets/img/playlist-cover.png',
    duration : '03:03:03',
    title : 'test'
  },{
    artistName : 'Armin van Buuren',
    imageUrl : '../../../../assets/img/playlist-cover.png',
    duration : '4:01:37',
    title : 'Blue Fear'
  }];

  public songBriefDtos?: SongBriefDto[] = [];


  constructor(private client: SongsClient) {
    client.getSongsWithPagination(1, 10).subscribe(result => {
      this.songBriefDtos = result.items;
      console.log(this.songBriefDtos?.length);
    }, error => console.error(error));
  }

}
