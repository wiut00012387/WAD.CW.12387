import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Club } from './club.service';

export type League = {
  leagueId: number;
  name: string;
  country: string;
};

export type LeagueTable = {
  leagueTableId: number;
  position: number;
  played: number;
  won: number;
  draw: number;
  lost: number;
  goalsFor: number;
  goalsAgainst: number;
  points: number;
  club: Club;
  league: League;
};

@Injectable({
  providedIn: 'root',
})
export class LeagueService {
  constructor(private http: HttpClient) {}

  getLeagues() {
    return this.http.get<League[]>(environment.apiUrl + 'league');
  }

  getLeague(id: number) {
    return this.http.get<League>(environment.apiUrl + 'league/' + id);
  }

  getLeagueTable(id: number) {
    return this.http.get<LeagueTable[]>(
      environment.apiUrl + 'leagueTable/' + id + '/league'
    );
  }

  createLeague(league: League) {
    return this.http.post<null>(environment.apiUrl + 'league', league);
  }

  updateLeague(league: League) {
    return this.http.put<null>(
      environment.apiUrl + 'league/' + league.leagueId,
      league
    );
  }

  deleteLeague(id: number) {
    return this.http.delete<null>(environment.apiUrl + 'league/' + id);
  }
}
