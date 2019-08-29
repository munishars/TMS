import { Component, OnInit } from '@angular/core';
import { TripSummary } from '../models/trip-summary';
import { TripSummaryService } from '../services/trip-summary.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-trip-employee',
  templateUrl: './list-trip-employee.component.html',
  styleUrls: ['./list-trip-employee.component.css']
})
export class ListTripEmployeeComponent implements OnInit {

  tripSummary: TripSummary[];
  userid:number;

  constructor(private tripSummaryService: TripSummaryService, private router: Router, ) { 
    this.userid = parseInt(localStorage.getItem('username'));
  }

  ngOnInit() {
    this.tripSummaryService.getTripByEmployeeId(this.userid)
      .subscribe((data: TripSummary[]) => {
        this.tripSummary = data;
      });
  }
}
