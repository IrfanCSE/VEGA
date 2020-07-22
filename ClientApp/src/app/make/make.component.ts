import { Component, OnInit } from '@angular/core';
import { MakeService } from '../Services/make.service';

@Component({
  selector: 'app-make',
  templateUrl: './make.component.html',
  styleUrls: ['./make.component.css']
})
export class MakeComponent implements OnInit {

  makes: {};
  models: {};

  constructor(private service: MakeService) { }

  ngOnInit() {
    this.service.GetMakes().subscribe(res => {
      this.makes=res;
    })
  }

  onMakeChange(makeId){
    if(makeId <= 0)
      this.models=[];

      else{
        this.service.GetModel(makeId)
        .subscribe(res=>{
          this.models=res;
        })
      }
  }

}
