import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProgramComponent } from './program/program.component';

const routes: Routes = [
  { path: '', component: ProgramComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
