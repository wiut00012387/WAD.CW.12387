import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ClubService } from 'src/app/services/club.service';

@Component({
  selector: 'app-edit-club',
  templateUrl: './edit-club.component.html',
  styleUrls: ['./edit-club.component.css'],
})
export class EditClubComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private clubService: ClubService,
    private router: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      this.clubService.getClub(params['id']).subscribe((club) => {
        this.form.patchValue({
          clubId: club.clubId,
          name: club.name,
          coachName: club.coachName,
          stadiumName: club.stadiumName,
          imageLink: club.imageLink,
          foundedYear: new Date(club.foundedYear).toISOString().slice(0, 10),
          league: club.league.leagueId,
        });
      });
    });
  }

  form = this.fb.group({
    clubId: [''],
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
      this.clubService.updateClub(this.form.value).subscribe(() => {
        window.location.href = '/clubs';
      });
    }
  }
}
