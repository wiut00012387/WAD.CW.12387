import { Component, OnInit } from '@angular/core';
import { Player, PlayersService } from 'src/app/services/players.service';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css'],
})
export class PlayerComponent implements OnInit {
  player$!: Observable<Player>;

  constructor(
    private playersService: PlayersService,
    private router: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      this.player$ = this.playersService.getPlayer(params['id']);
    });
  }

  deletePlayer(playerId: number): void {
    this.playersService.deletePlayer(playerId).subscribe(() => {
      window.location.href = '/players';
    });
  }
}
