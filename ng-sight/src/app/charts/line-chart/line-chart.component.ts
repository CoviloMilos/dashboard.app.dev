import { LINE_CHART_COLORS } from './../../shared/chart.color';
import { Component, OnInit } from '@angular/core';

const LINE_CHART_SAMPLE_DATA: any[] = [
  { data: [32, 14, 46, 23, 38, 56], label: 'Sentiment Analysis'},
  { data: [12, 18, 26, 13, 28, 26], label: 'Image Recognition'},
  { data: [52, 34, 49, 52, 68, 62], label: 'Forecasting'},
];

const LINE_CHART_LABLES: string[] = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'];

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {

  public lineChartData: any[] = LINE_CHART_SAMPLE_DATA;
  public lineChartLabels: string[] = LINE_CHART_LABLES;
  public lineChartType = 'line';
  public lineChartLegend  = LINE_CHART_COLORS;
  public lineChartOptions: any = {
    scaleShowVerticalLines: false,
    responsive: true
  };

  constructor() { }

  ngOnInit() {
  }

}
