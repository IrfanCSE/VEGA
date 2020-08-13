import { VehicleService } from "./../Services/vehicle.service";
import { Component, OnInit } from "@angular/core";
import { MakeService } from "../Services/make.service";
import { SaveVehicle } from "../Models/SaveVehicle";
import { Router, ActivatedRoute } from "@angular/router";
import { Vehicle } from "../Models/Vehicle";
import { forkJoin } from "rxjs";

@Component({
  selector: "vehicle-form",
  templateUrl: "./vehicle-form.component.html",
  styleUrls: ["./vehicle-form.component.css"],
})
export class VehicleFormComponent implements OnInit {
  makes: any;
  models: any;
  features: any;
  vehicle: SaveVehicle = {
    id: 0,
    makeId: null,
    modelId: null,
    isRegisterd: false,
    features: [],
    contact: {
      name: '',
      phone: '',
      email: '',
    },
  };

  editMode = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private makeService: MakeService,
    private vehicleService: VehicleService
  ) {
    route.params.subscribe(p => {
      this.vehicle.id = +p['id'];
    });
  }

  ngOnInit() {
    var source = [
      this.makeService.GetMakes(),
      this.makeService.GetFeatures()
    ];

    if (this.vehicle.id) {
      source.push(this.vehicleService.GetVehicle(this.vehicle.id));
      this.editMode = true;
    }

    forkJoin(source).subscribe(data => {
      this.makes = data[0];
      this.features = data[1];
      if(this.vehicle.id) {
       this.SetVehicle(data[2]);
       this.OnGetMake();
      }
    });
  }

  onMakeChange() {
    if (this.vehicle.makeId <= 0) {
      this.models = [];
    } else {
      this.makeService.GetModel(this.vehicle.makeId).subscribe((res) => {
        this.models = res;
      });
    }

    delete this.vehicle.modelId;
  }

  OnGetMake(){
    this.makeService.GetModel(this.vehicle.makeId).subscribe((res) => {
      this.models = res;
    });
  }

  OnFeatureToggle(featureId, $event) {
    if ($event.target.checked) {
      this.vehicle.features.push(featureId);
    } else {
      let index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  OnSubmit(f) {
    if(this.vehicle.id) {
      this.vehicleService.UpdateVehicle(this.vehicle)
        .subscribe(res => {
          console.log(res);
        });
    }
    else{
      delete this.vehicle.id;
      this.vehicleService.AddVehicle(this.vehicle).subscribe((res) => {
        console.log(res);
      });
    }
  }

  SetVehicle(v: any) {
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.isRegisterd = v.isRegisterd;
    this.vehicle.contact = v.contact;
    v.features.forEach(element => {
      this.vehicle.features.push(element.id);
    });
  }

  OnClickDelete(){
    this.vehicleService.DeleteVehicle(this.vehicle.id)
      .subscribe(res => {
        console.log(res);
      });
  }
}
