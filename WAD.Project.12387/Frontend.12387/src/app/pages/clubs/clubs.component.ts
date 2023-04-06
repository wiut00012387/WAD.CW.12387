import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Club, ClubService } from 'src/app/services/club.service';
import { League, LeagueService } from 'src/app/services/league.service';

@Component({
  selector: 'app-clubs',
  templateUrl: './clubs.component.html',
  styleUrls: ['./clubs.component.css'],
})
export class ClubsComponent implements OnInit {
  clubs$!: Observable<Club[]>;
  leagues$!: Observable<League[]>;
  selectedLeague: string = '';

  constructor(
    private clubService: ClubService,
    private leagueService: LeagueService
  ) {}

  ngOnInit(): void {
    this.clubs$ = this.clubService.getClubs();
    this.leagues$ = this.leagueService.getLeagues();
  }
}
