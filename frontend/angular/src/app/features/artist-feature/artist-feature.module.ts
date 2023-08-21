import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArtistFeatureComponent } from './artist-feature.component';

@NgModule({
  declarations: [
    ArtistFeatureComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ArtistFeatureComponent
  ]
})
export class ArtistFeatureModule { }
