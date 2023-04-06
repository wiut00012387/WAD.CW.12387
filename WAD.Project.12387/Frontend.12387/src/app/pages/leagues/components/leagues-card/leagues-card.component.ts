import { Component, OnInit, Input } from '@angular/core';
import { League } from 'src/app/services/league.service';

@Component({
  selector: 'app-leagues-card',
  templateUrl: './leagues-card.component.html',
  styleUrls: ['./leagues-card.component.css'],
})
export class LeaguesCardComponent implements OnInit {
  @Input() league!: League;
  constructor() {}

  ngOnInit(): void {}
}
