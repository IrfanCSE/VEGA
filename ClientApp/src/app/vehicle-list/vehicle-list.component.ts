import { Vehicle } from './../Models/Vehicle';
import { VehicleService } from './../Services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { MakeService } from '../Services/make.service';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {

  makes: any;
  models: any;
  vehicleList: Vehicle[];
  filter: any = {};
  constructor(private vehicleService: VehicleService, private makeService: MakeService) { }

  ngOnInit() {
    this.makeService.GetMakes().subscribe(res => {
      this.makes=res;
    });

    this.GetVehicles();
  }

  makeFilter() {
        this.makeService.GetModel(this.filter.makeId).subscribe(res => {
          this.models = res;
        });

        this.filter.modelId = "";

        this.GetVehicles();
  }

  modelFilter() {
    this.GetVehicles();
}

  GetVehicles(){
    this.vehicleService.GetVehicles(this.filter).subscribe(res => {
      this.vehicleList=res;
  });
}

  OnReset(){
    this.filter.makeId = "";
    this.filter.modelId = "";
    this.models = [];
  }

}
