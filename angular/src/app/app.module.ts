import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { LayoutPageModule } from './pages/layout-page/layout-page.module';
import { SharedModule } from './shared/shared.module';
import { API_BASE_URL } from './web-api-client';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [AppComponent],
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
  providers: [
    {
      provide: API_BASE_URL,
      useValue: environment.apiRoot,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
