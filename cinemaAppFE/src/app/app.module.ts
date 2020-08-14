import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProgramComponent } from './program/program.component';
import { HttpClientModule } from '@angular/common/http';
import { MovieComponent } from './movie/movie.component';
import { MatCardModule } from '@angular/material/card';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { FormsModule } from '@angular/forms';
import { TimeSlotComponent } from './timeSlot/timeSlot.component';

@NgModule({
  declarations: [
    AppComponent,
    ProgramComponent,
    MovieComponent,
    TimeSlotComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
    MatCardModule,
    FormsModule,
    ButtonsModule.forRoot()
  ],
  exports :[ MatCardModule ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
