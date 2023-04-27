import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PlaylistPageComponent } from './pages/playlist-page/playlist-page.component';
import { AlbumComponent } from './pages/album-page/album/album.component';
import { HomeComponent } from './pages/home-page/home/home.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'playlists', component: PlaylistPageComponent },
  { path: 'albums', component: AlbumComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
