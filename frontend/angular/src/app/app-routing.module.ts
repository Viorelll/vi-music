import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PlaylistPageComponent } from './pages/playlist-page/playlist-page.component';
import { AlbumComponent } from './pages/album-page/album/album.component';
import { HomeComponent } from './pages/home-page/home/home.component';

export const routes: Routes = [
  {
    path: 'playlists',
    component: PlaylistPageComponent,
    loadChildren: () => import('./features/playlist/playlist.module').then(m => m.PlaylistModule),
    data: { preload: true }
  },
  { path: 'albums', component: AlbumComponent },
  { path: '', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
