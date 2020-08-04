import { Vehicle } from './../Models/Vehicle';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

constructor(private http: HttpClient) {}
  vehicleUrl = '/api/vehicle/';

  public AddVehicle(vehicle) {
    return this.http.post(this.vehicleUrl, vehicle);
  }

  public GetVehicle(id: number) {
    return this.http.get(this.vehicleUrl + id);
  }

  public UpdateVehicle(Vehicle) {
    return this.http.put(this.vehicleUrl+Vehicle.id,Vehicle);
  }

  public DeleteVehicle(id: number){
    return this.http.delete(this.vehicleUrl+id);
  }

}
