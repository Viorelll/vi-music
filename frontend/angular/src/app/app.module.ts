import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { LayoutPageModule } from './pages/layout-page/layout-page.module';
import { PlaylistPageModule } from './pages/playlist-page/playlist-page.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    CoreModule,
    SharedModule,
    LayoutPageModule,
    PlaylistPageModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
