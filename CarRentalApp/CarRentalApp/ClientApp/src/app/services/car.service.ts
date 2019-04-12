import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  readonly url = 'https://localhost:44352/cars';
  constructor(private http: HttpClient) { }

  public getCars() {
    return this.http.get(this.url);
  }
}
