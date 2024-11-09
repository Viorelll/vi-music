import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddPlaylistComponent } from './add-playlist/add-playlist.component';
import { playlistDetailResolver } from './playlist-details/playlist-details-resolver';
import { PlaylistDetailsComponent } from './playlist-details/playlist-details.component';
import { PlaylistsComponent } from './playlists/playlists.component';

export const playlistRoutes: Routes = [
  {
    path: '',
    component: PlaylistsComponent,
  },
  {
    path: 'add',
    component: AddPlaylistComponent,
  },
  {
    path: ':id',
    component: PlaylistDetailsComponent,
    resolve: {
      playlistSongsBriefDto: playlistDetailResolver,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(playlistRoutes)],
  exports: [RouterModule],
})
export class PlaylistRoutingModule {}
