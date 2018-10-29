import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-dashboard-card',
  templateUrl: './dashboard-card.component.html',
  styleUrls: ['./dashboard-card.component.css']
})
export class DashboardCardComponent implements OnInit {
  @Input('value')  value: String = '';
  @Input('header') header: String = '';
  @Input('subTitle') subTitle: String = '';
  @Input('actionText') actionText: String = '';

  constructor() { }

  ngOnInit() {
  }

}
