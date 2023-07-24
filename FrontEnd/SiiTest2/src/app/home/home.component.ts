import { ApiService } from './../service/api.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{

    data: any = {};
    employees: any[] = [];
    searchId = "";
    constructor(private ApiService : ApiService, private router:Router){
     
    }
    ngOnInit(): void {
     
    }
    getData(){
      if(this.searchId == ""){
        this.getEmployees();
      }else{
        this.getEmployeesById();
      }
        
    }
    getEmployees(){
        this.ApiService.getData().subscribe( data => {
          this.data = data;
          if(this.data.status=="success"){
            this.employees = this.data.data;
          }else{
            alert(this.data.message);
          }
        });
    }
    getEmployeesById(){
          this.ApiService.getDataById(this.searchId).subscribe( data => {
          this.data = data;
          if(this.data.status=="success"){
            this.employees = this.data.data;
          }else{
            alert(this.data.message);
          }
        });
      }
    }

