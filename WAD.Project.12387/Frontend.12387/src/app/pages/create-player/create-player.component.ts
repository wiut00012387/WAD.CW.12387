import { Component, OnInit } from '@angular/core';
import { type Club, ClubService } from 'src/app/services/club.service';
import { Observable } from 'rxjs';
import { FormBuilder, Validators } from '@angular/forms';
import { PlayersService } from 'src/app/services/players.service';

@Component({
  selector: 'app-create-player',
  templateUrl: './create-player.component.html',
  styleUrls: ['./create-player.component.css'],
})
export class CreatePlayerComponent implements OnInit {
  clubs$!: Observable<Club[]>;

  constructor(
    private clubService: ClubService,
    private fb: FormBuilder,
    private playerService: PlayersService
  ) {}

  ngOnInit(): void {
    this.clubs$ = this.clubService.getClubs();
  }

  form = this.fb.group({
    name: ['', Validators.required],
    age: [0, [Validators.required, Validators.min(18), Validators.max(40)]],
    position: ['', Validators.required],
    imageLink: ['', Validators.required],
    club: ['', Validators.required],
  });

  onSubmit(e: Event) {
    this.form.value.club = { clubId: Number(this.form.value.club) };

    if (this.form.valid) {
      this.playerService.createPlayer(this.form.value).subscribe(() => {
        window.location.href = '/players';
      });
    }
  }
}
