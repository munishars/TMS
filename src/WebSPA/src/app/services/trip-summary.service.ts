import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TripSummary } from '../models/trip-summary';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class TripSummaryService {
  private bearerToken: string;
  constructor(private http: HttpClient, public authService: AuthenticationService) {
    this.bearerToken = this.authService.getBearerToken();
  }
  baseUrl: string = 'http://localhost:8082/api/Trip/';  
  getAllTrips() {
    return this.http.get<TripSummary[]>(this.baseUrl, { headers: new HttpHeaders().set('Authorization', `Bearer ${this.bearerToken}`)});
  }
  getTripByEmployeeId(id: number ) {
    return this.http.get<TripSummary[]>(this.baseUrl + id, { headers: new HttpHeaders().set('Authorization', `Bearer ${this.bearerToken}`)});
  }
  deleteTrip(id: number) {
    return this.http.delete<TripSummary[]>(this.baseUrl + id , { headers: new HttpHeaders().set('Authorization', `Bearer ${this.bearerToken}`)});
  }
  bookTrip(trip: TripSummary) {
    return this.http.post(this.baseUrl, trip, { headers: new HttpHeaders().set('Authorization', `Bearer ${this.bearerToken}`)});
  }
  confirmTrip(trip: TripSummary) {
    return this.http.put(this.baseUrl + trip.TripId, trip,  { headers: new HttpHeaders().set('Authorization', `Bearer ${this.bearerToken}`)});
  }

}
