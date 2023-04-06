import { Component, OnInit } from '@angular/core';
import { Player, PlayersService } from 'src/app/services/players.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css'],
})
export class PlayersComponent implements OnInit {
  players$!: Observable<Player[]>;

  constructor(private playersService: PlayersService) {}

  ngOnInit(): void {
    this.players$ = this.playersService.getPlayers();
  }
}
