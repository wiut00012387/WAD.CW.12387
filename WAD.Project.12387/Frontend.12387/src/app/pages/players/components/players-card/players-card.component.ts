import { Component, OnInit, Input } from '@angular/core';
import { Player } from 'src/app/services/players.service';

@Component({
  selector: 'app-players-card',
  templateUrl: './players-card.component.html',
  styleUrls: ['./players-card.component.css'],
})
export class PlayersCardComponent implements OnInit {
  @Input() player!: Player;

  constructor() {}

  ngOnInit(): void {}
}
