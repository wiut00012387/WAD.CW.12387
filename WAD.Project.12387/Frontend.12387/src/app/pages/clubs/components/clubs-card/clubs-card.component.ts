import { Component, OnInit, Input } from '@angular/core';
import { Club } from 'src/app/services/club.service';

@Component({
  selector: 'app-clubs-card',
  templateUrl: './clubs-card.component.html',
  styleUrls: ['./clubs-card.component.css'],
})
export class ClubsCardComponent implements OnInit {
  @Input() club!: Club;

  constructor() {}

  ngOnInit(): void {}
}
