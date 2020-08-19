import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleService } from '../Services/vehicle.service';

@Component({
  selector: 'app-vehicle-view',
  templateUrl: './vehicle-view.component.html',
  styleUrls: ['./vehicle-view.component.css']
})
export class VehicleViewComponent implements OnInit {

  select: any;
  vehicle: any;
  vehicleId: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService
  ) {
    route.params.subscribe(p => {
      this.vehicleId = +p['id'];
    });
  }

  ngOnInit() {
    this.select = "vehicle";
    this.vehicleService.GetVehicle(this.vehicleId).subscribe(res => {
      this.vehicle = res;
      console.log(res);
    }, (error: Response) => {
      console.log(error);
      if(error.status == 404){
      this.router.navigateByUrl("vehicle");
      }
    });
  }

  OnTabClick(tabName){
    this.select = tabName;
  }

  OnClickDelete(){
    this.vehicleService.DeleteVehicle(this.vehicleId)
      .subscribe(res => {
        this.router.navigateByUrl("vehicle");
      });
  }

}
