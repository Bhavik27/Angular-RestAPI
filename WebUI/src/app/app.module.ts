import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainComponent } from './main/main.component';
import { MaterialModule } from './shared/material.module';
import { UserComponent } from './user/user.component';
import { HttpClientModule } from '@angular/common/http';
import { EditUserComponent } from './user/edit-user/edit-user.component';
import { ConfirmBoxComponent } from './main/confirm-box/confirm-box.component';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    UserComponent,
    EditUserComponent,
    ConfirmBoxComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
