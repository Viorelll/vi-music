import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AlbumPageComponent } from './album-page/album-page.component';
import { AlbumComponent } from './album/album.component';



@NgModule({
  declarations: [
    AlbumPageComponent,
    AlbumComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AlbumPageModule { }
