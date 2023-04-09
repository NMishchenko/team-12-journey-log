import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class PlaceService {

  constructor(private http: HttpClient) { }

  getPlacesByBbox(bbox: any): Observable<any>{
    return this.http.get(environment.apiUrl + 'places/' + 'bbox', {
      params: {
        lon_max: bbox.max_lon,
        lat_max: bbox.max_lat,
        lon_min: bbox.min_lon,
        lat_min: bbox.min_lat,
      }
    });
  }

  getPlaceInfoById(xid: string): Observable<any>{
    return this.http.get(environment.apiUrl + 'places/' + xid);
  }
}
