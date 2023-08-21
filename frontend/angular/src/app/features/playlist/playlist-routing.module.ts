import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PlaylistDetailsComponent } from './playlist-details/playlist-details.component';
import { PlaylistsComponent } from './playlists/playlists.component';
import { playlistDetailResolver } from './playlist-details/playlist-details-resolver';

export const playlistRoutes: Routes = [
  {
    path: '',
    component: PlaylistsComponent,
  },
  {
    path: ':id',
    component: PlaylistDetailsComponent,
    resolve: {
      playlistBriefDto: playlistDetailResolver
    }
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(playlistRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class PlaylistRoutingModule { }
