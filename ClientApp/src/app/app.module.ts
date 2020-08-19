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
import { VehicleService } from './Services/vehicle.service';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { PaginationComponent } from './pagination/pagination.component';
import { VehicleViewComponent } from './vehicle-view/vehicle-view.component';

@NgModule({
   declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent,
      MakeComponent,
      VehicleFormComponent,
      VehicleListComponent,
      PaginationComponent,
      VehicleViewComponent
   ],
   imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'make', component: MakeComponent},
      { path: 'vehicle/new', component: VehicleFormComponent},
      { path: 'vehicle/edit/:id', component: VehicleFormComponent},
      { path: 'vehicle/:id', component: VehicleViewComponent},
      { path: 'vehicle', component: VehicleListComponent}
    ])
  ],
  providers: [MakeService, VehicleService],
  bootstrap: [AppComponent]
})
export class AppModule { }

// BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
