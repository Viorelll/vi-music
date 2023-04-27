import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPlaylistComponent } from './main-playlist/main-playlist.component';



@NgModule({
  declarations: [
    MainPlaylistComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [MainPlaylistComponent]
})
export class PlaylistModule { }
