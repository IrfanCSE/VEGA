import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MakeComponent } from './make/make.component';
import { HomeComponent } from './home/home.component';
import { MakeService } from './Services/make.service';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';

@NgModule({
   declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent,
      MakeComponent,
      VehicleFormComponent
   ],
   imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'make', component: MakeComponent},
      { path: 'new/vehicle', component: VehicleFormComponent}
    ])
  ],
  providers: [MakeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
