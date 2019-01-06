import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-MySqlConnection',
  templateUrl: './MySqlConnection.component.html'
})
export class MySqlConnectionComponent {
  public names: Columns[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Columns[]>(baseUrl + 'api/MySqlConnection/NamesList').subscribe(result => {
      this.names = result;
    }, error => console.error(error));
  }
}

interface Columns {
  firstName: string;
  lastName: string;
}
