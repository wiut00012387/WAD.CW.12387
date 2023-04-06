import { Component, OnInit } from '@angular/core';
import { Player, PlayersService } from 'src/app/services/players.service';
import { Observable } from 'rxjs';
import { Club, ClubService } from 'src/app/services/club.service';
import { League, LeagueService } from 'src/app/services/league.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  players$!: Observable<Player[]>;
  clubs$!: Observable<Club[]>;
  leagues$!: Observable<League[]>;

  constructor(
    private playersService: PlayersService,
    private clubService: ClubService,
    private leagueService: LeagueService
  ) {}

  ngOnInit(): void {
    this.players$ = this.playersService.getPlayers();
    this.clubs$ = this.clubService.getClubs();
    this.leagues$ = this.leagueService.getLeagues();
  }
}
