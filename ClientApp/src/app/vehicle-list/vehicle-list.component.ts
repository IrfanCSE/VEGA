import { Vehicle } from "./../Models/Vehicle";
import { VehicleService } from "./../Services/vehicle.service";
import { Component, OnInit } from "@angular/core";
import { MakeService } from "../Services/make.service";

@Component({
  selector: "app-vehicle-list",
  templateUrl: "./vehicle-list.component.html",
  styleUrls: ["./vehicle-list.component.css"],
})
export class VehicleListComponent implements OnInit {
  makes: any;
  models: any;
  vehicleList: any = [];
  filter: any = {
    pageSize: this.Page_Size
  };
  totalList: any;

  private readonly Page_Size = 10;

  constructor(
    private vehicleService: VehicleService,
    private makeService: MakeService
  ) {}

  ngOnInit() {
    this.makeService.GetMakes().subscribe((res) => {
      this.makes = res;
    });

    this.GetVehicles();
  }

  makeFilter() {
    this.makeService.GetModel(this.filter.makeId).subscribe((res) => {
      this.models = res;
    });

    this.filter.modelId = "";
    this.filter.page = 1;
    this.filter.pageSize = this.Page_Size;
    this.GetVehicles();
  }

  modelFilter() {
    this.filter.page = 1;
    this.filter.pageSize = this.Page_Size;
    this.GetVehicles();
  }

  GetVehicles() {
    this.vehicleService.GetVehicles(this.filter).subscribe(result => {
      this.vehicleList = result.items;
      this.totalList = result.totalItems;
    });
  }

  SortBy(columnName) {
    if (this.filter.sortBy === columnName && this.filter.isAscending != false) {
      this.filter.isAscending = false;
    } else {
      this.filter.sortBy = columnName;
      this.filter.isAscending = true;
    }
    this.GetVehicles();
  }

  OnReset() {
    this.filter = {
      page: 1,
      pageSize: this.Page_Size
    };
    this.GetVehicles();
  }

  OnPageChanged(page) {
    this.filter.page = page;
    this.GetVehicles();
  }
}
