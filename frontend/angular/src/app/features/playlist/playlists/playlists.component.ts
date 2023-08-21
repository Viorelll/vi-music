import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { PaginatedListOfPlaylistBriefDto, PlaylistBriefDto, PlaylistsClient, SongBriefDto, SongsClient } from 'src/app/web-api-client';

@Component({
  selector: 'app-playlists',
  templateUrl: './playlists.component.html',
  styleUrls: ['./playlists.component.scss']
})
export class PlaylistsComponent {

  public playlistBriefDto?: PlaylistBriefDto[] = [];

  playlistBriefDto$?: Observable<PaginatedListOfPlaylistBriefDto>;
  // selectedId = 0;

  constructor(private route: ActivatedRoute, private client: PlaylistsClient) {
    client.getPlaylistsWithPagination(1, 10).subscribe(result => {
      this.playlistBriefDto = result.items;
    }, error => console.error(error));
  }

  // ngOnInit() {
  //   this.playlistBriefDto$ = this.route.firstChild?.paramMap.pipe(
  //     switchMap(params => {
  //       this.selectedId = parseInt(params.get('id')!, 10);
  //       return this.client.getPlaylistsWithPagination(1, 10);
  //     })
  //   );
  // }

}
