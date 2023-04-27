import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlaylistPageComponent } from './playlist-page.component';
import { PlaylistModule } from 'src/app/features/playlist/playlist.module';


@NgModule({
  declarations: [
    PlaylistPageComponent
  ],
  imports: [
    CommonModule,
    PlaylistModule
  ]
})
export class PlaylistPageModule { }
