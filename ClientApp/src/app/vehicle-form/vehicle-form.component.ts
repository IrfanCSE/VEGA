import { Component, OnInit } from "@angular/core";
import { MakeService } from "../Services/make.service";

@Component({
  selector: "vehicle-form",
  templateUrl: "./vehicle-form.component.html",
  styleUrls: ["./vehicle-form.component.css"],
})
export class VehicleFormComponent implements OnInit {
  makes: any;
  models: any;
  features: any;

  constructor(private service: MakeService) {}

  ngOnInit() {
    this.service.GetMakes().subscribe((res) => {
      this.makes = res;
    });

    this.service.GetFeatures().subscribe(res=>{
      this.features=res;
    });
  }

  onMakeChange(makeId) {
    if (makeId <= 0) this.models = [];
    else {
      this.service.GetModel(makeId).subscribe((res) => {
        this.models = res;
      });
    }
  }

  // OnSubmit(data){
  //   console.log(data);
  // }

}
