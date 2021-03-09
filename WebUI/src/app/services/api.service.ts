import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CoreService } from './core.service';


let headers = new HttpHeaders()
  .set('Content-Type', 'application/json')
  .set('Accept', 'application/json');

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient,
    private coreService: CoreService) { }

  get(url: string): Observable<any> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', 'application/json')
      .set('Authorization', 'bearer ' + this.coreService.Token);
    return this.httpClient.get(environment.url + url, { headers: headers })
  }

  post(url: string, model: any): Observable<any> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', 'application/json')
      .set('Authorization', 'bearer ' + this.coreService.Token);
    return this.httpClient.post(environment.url + url, model, { headers: headers })
  }

  delete(url: string): Observable<any> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', 'application/json')
      .set('Authorization', 'bearer ' + this.coreService.Token);
    return this.httpClient.delete(environment.url + url, { headers: headers })
  }


}
