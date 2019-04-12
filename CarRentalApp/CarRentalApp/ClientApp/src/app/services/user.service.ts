import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly url = 'https://localhost:44352/users';
  constructor(private http: HttpClient) { }

  public getUsers() {
    return this.http.get(this.url);
  }
}
