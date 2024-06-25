import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { VioPlayerComponent } from 'vio-player';
import { ArtistFeatureModule } from '../artist-feature/artist-feature.module';
import { AddPlaylistComponent } from './add-playlist/add-playlist.component';
import { MainPlaylistComponent } from './main-playlist/main-playlist.component';
import { PlaylistDetailsComponent } from './playlist-details/playlist-details.component';
import { PlaylistRoutingModule } from './playlist-routing.module';
import { PlaylistsComponent } from './playlists/playlists.component';

@NgModule({
  declarations: [
    MainPlaylistComponent,
    PlaylistDetailsComponent,
    PlaylistsComponent,
    AddPlaylistComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PlaylistRoutingModule,
    ArtistFeatureModule,
    VioPlayerComponent
  ],
  exports: [MainPlaylistComponent]
})
export class PlaylistModule { }
