import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProgramComponent } from './program/program.component';
import { TimeSlotComponent } from './timeSlot/timeSlot.component';

const routes: Routes = [
  { path: '', component: ProgramComponent },
  { path: 'time/:id', component: TimeSlotComponent },
  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
