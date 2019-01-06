import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod} from '@angular/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  //public currentCount = 0;
  public Msg: any;
  public Names: any;
  public _http: any;
  public _baseUrl: any;
  public headers = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  
  public constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
    this.Names = {
      "firstName": "",
      "lastName": ""
    }
  }
  
  @Injectable()
  public SaveData() {
    //this.currentCount++;
    this.Msg = "";
    this._http
      .post(this._baseUrl + 'api/MySqlConnection/SaveNamesList', this.Names, this.headers)
      .subscribe(data => {
        if (data == 1) {
          this.Names = "";
          this.Msg = "Data Successfully Saved";
        }
        else {
          this.Msg = "Some Error Occurred";
        }
      });
  }
}

interface People {
  firstName: string;
  lastName: string;
}
