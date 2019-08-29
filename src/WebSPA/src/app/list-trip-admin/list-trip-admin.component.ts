import { Component, OnInit } from '@angular/core';
import { TripSummary } from '../models/trip-summary';
import { TripSummaryService } from '../services/trip-summary.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-trip-admin',
  templateUrl: './list-trip-admin.component.html',
  styleUrls: ['./list-trip-admin.component.css']
})
export class ListTripAdminComponent implements OnInit {

  tripSummary: TripSummary[];
  userid:number;

  constructor(private tripSummaryService: TripSummaryService, private router: Router, ) { 
    this.userid = parseInt(localStorage.getItem('username'));
  }

  ngOnInit() {
    this.tripSummaryService.getAllTrips()
      .subscribe((data: TripSummary[]) => {
        this.tripSummary = data;
      });
  }
}
