import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { type League } from './league.service';
import { type Player } from './players.service';

export type Club = {
  clubId: number;
  name: string;
  coachName: string;
  stadiumName: string;
  imageLink: string;
  foundedYear: Date;
  league: League;
  players: Player[];
};

@Injectable({
  providedIn: 'root',
})
export class ClubService {
  constructor(private http: HttpClient) {}

  getClubs() {
    return this.http.get<Club[]>(environment.apiUrl + 'club');
  }

  getClub(id: number) {
    return this.http.get<Club>(environment.apiUrl + 'club/' + id);
  }

  createClub(club: Club) {
    return this.http.post<null>(environment.apiUrl + 'club', club);
  }

  updateClub(club: Club) {
    return this.http.put<null>(
      environment.apiUrl + 'club/' + club.clubId,
      club
    );
  }

  deleteClub(id: number) {
    return this.http.delete<null>(environment.apiUrl + 'club/' + id);
  }
}
