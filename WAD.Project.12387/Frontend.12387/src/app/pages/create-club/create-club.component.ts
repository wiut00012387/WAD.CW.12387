import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ClubService } from 'src/app/services/club.service';
import { League, LeagueService } from 'src/app/services/league.service';

@Component({
  selector: 'app-create-club',
  templateUrl: './create-club.component.html',
  styleUrls: ['./create-club.component.css'],
})
export class CreateClubComponent implements OnInit {
  leagues$!: Observable<League[]>;

  constructor(
    private leagueService: LeagueService,
    private fb: FormBuilder,
    private clubService: ClubService
  ) {}

  ngOnInit(): void {
    this.leagues$ = this.leagueService.getLeagues();
  }

  form = this.fb.group({
    name: ['', Validators.required],
    coachName: ['', Validators.required],
    stadiumName: ['', Validators.required],
    imageLink: ['', Validators.required],
    foundedYear: ['', Validators.required],
    league: ['', Validators.required],
  });

  onSubmit(e: Event) {
    this.form.value.league = { leagueId: Number(this.form.value.league) };

    if (this.form.valid) {
      this.clubService.createClub(this.form.value).subscribe(() => {
        window.location.href = '/clubs';
      });
    }
  }
}
