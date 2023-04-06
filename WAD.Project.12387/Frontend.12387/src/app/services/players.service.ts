import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Club } from './club.service';

export type Player = {
  playerId: number;
  name: string;
  age: number;
  position: string;
  imageLink: string;
  club: Club;
};

@Injectable({
  providedIn: 'root',
})
export class PlayersService {
  constructor(private http: HttpClient) {}

  getPlayers() {
    return this.http.get<Player[]>(environment.apiUrl + 'player');
  }

  getPlayer(id: number) {
    return this.http.get<Player>(environment.apiUrl + 'player/' + id);
  }

  createPlayer(player: Player) {
    return this.http.post<null>(environment.apiUrl + 'player', player);
  }

  updatePlayer(player: Player) {
    return this.http.put<null>(
      environment.apiUrl + 'player/' + player.playerId,
      player
    );
  }

  deletePlayer(id: number) {
    return this.http.delete<null>(environment.apiUrl + 'player/' + id);
  }
}
