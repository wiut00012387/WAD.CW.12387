import { Component, OnInit } from '@angular/core';
import { League, LeagueService } from 'src/app/services/league.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-leagues',
  templateUrl: './leagues.component.html',
  styleUrls: ['./leagues.component.css'],
})
export class LeaguesComponent implements OnInit {
  leagues$!: Observable<League[]>;

  constructor(private leagueService: LeagueService) {}

  ngOnInit(): void {
    this.leagues$ = this.leagueService.getLeagues();
  }
}
