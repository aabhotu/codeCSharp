import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  public homeText: string;
  constructor(){}
  ngOnInit():void {
    this.homeText = "Welcome to the Home "
  }
}
