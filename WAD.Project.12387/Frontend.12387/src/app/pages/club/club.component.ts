import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Club, ClubService } from 'src/app/services/club.service';

@Component({
  selector: 'app-club',
  templateUrl: './club.component.html',
  styleUrls: ['./club.component.css'],
})
export class ClubComponent implements OnInit {
  club$!: Observable<Club>;

  constructor(
    private router: ActivatedRoute,
    private clubService: ClubService
  ) {}

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      this.club$ = this.clubService.getClub(params['id']);
    });
  }

  deleteClub(clubId: number): void {
    this.clubService.deleteClub(clubId).subscribe(() => {
      window.location.href = '/clubs';
    });
  }
}
