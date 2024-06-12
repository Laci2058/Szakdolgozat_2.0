import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface GitData {
  id: number;
  title: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public data: GitData[] = [];
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getGitData();
  }
  
  getGitData() {
    this.http.get<GitData[]>("/api/gitdata").subscribe(
      (result) => {
        this.data = result;
      },
      (error) => {
        console.log(error);
      }
    );
  }


  title = 'szakdoga_re.client';
}
