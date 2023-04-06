import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { PlayersService } from 'src/app/services/players.service';
import { ClubService } from 'src/app/services/club.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html',
  styleUrls: ['./edit-player.component.css'],
})
export class EditPlayerComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private playersService: PlayersService,
    private router: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      this.playersService.getPlayer(params['id']).subscribe((player) => {
        this.form.patchValue({
          playerId: player.playerId,
          name: player.name,
          age: player.age,
          position: player.position,
          imageLink: player.imageLink,
          club: player.club.clubId,
        });
      });
    });
  }

  form = this.fb.group({
    playerId: [''],
    name: ['', Validators.required],
    age: [0, [Validators.required, Validators.min(18), Validators.max(40)]],
    position: ['', Validators.required],
    imageLink: ['', Validators.required],
    club: ['', Validators.required],
  });

  onSubmit(e: Event) {
    this.form.value.club = { clubId: Number(this.form.value.club) };

    if (this.form.valid) {
      this.playersService.updatePlayer(this.form.value).subscribe(() => {
        window.location.href = '/players';
      });
    }
  }
}
