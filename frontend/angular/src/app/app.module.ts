import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { LayoutPageModule } from './pages/layout-page/layout-page.module';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,

    FormsModule,
    ReactiveFormsModule,

    HttpClientModule,
    AppRoutingModule,

    CoreModule,
    SharedModule,
    LayoutPageModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
