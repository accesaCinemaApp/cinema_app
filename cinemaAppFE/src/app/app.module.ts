import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProgramComponent } from './program/program.component';
import { HttpClientModule } from '@angular/common/http';
import { TimeSlotComponent } from './timeSlot/timeSlot.component';
import { MatCardModule } from '@angular/material/card';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ProgramComponent,
    TimeSlotComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatCardModule,
    FormsModule,
    ButtonsModule.forRoot()
  ],
  exports :[ MatCardModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
