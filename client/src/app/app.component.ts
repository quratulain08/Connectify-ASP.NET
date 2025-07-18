import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']  // it should be 'styleUrls' not 'styleUrl'
})
export class AppComponent implements OnInit {
  title = 'Connectify';
  http = inject(HttpClient);
  users: any;

  ngOnInit(): void {
    this.http.get('https://localhost:5290/api/users').subscribe({
      next: (response) => {
        this.users = response;
        console.log(this.users);  // Check if users are fetched
      },
      error: (error) => console.error(error),
      complete: () => console.log('Request completed')
    });
  }
}
