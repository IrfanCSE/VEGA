import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class MakeService {
  makeUrl = "/api/make";
  modelUrl = "/api/model";
  featureUrl = "/api/feature";
  constructor(private http: HttpClient) {}

  public GetMakes(){
    return this.http.get(this.makeUrl);
  }

  public GetModel(makeId: number){
    return this.http.get(this.modelUrl+"/"+makeId);
  }

  public GetFeatures(){
    return this.http.get(this.featureUrl);
  }

}
