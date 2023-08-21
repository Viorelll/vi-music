import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { LayoutComponent } from './layout/layout.component';
import { RouterModule } from '@angular/router';
import { PlaylistPageModule } from '../playlist-page/playlist-page.module';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    LayoutComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    PlaylistPageModule
  ],
  exports: [
    LayoutComponent
  ]
})
export class LayoutPageModule { }
