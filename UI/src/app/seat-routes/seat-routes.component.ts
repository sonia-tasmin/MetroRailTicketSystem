import { NestedTreeControl } from '@angular/cdk/tree';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { Route } from '../models/models';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'seat-routes',
  templateUrl: './seat-routes.component.html',
  styleUrls: ['./seat-routes.component.scss'],
})
export class SeatRoutesComponent {
  dataSource = new MatTreeNestedDataSource<Route>();
  treeControl = new NestedTreeControl<Route>((node) => node.children);

  constructor(private api: ApiService) {
    this.updateCategories();
  }

  hasChild = (_: number, node: Route) =>
    !!node.children && node.children.length > 0;

  updateCategories() {
    this.api.getTrains().subscribe({
      next: (res: any) => (this.dataSource.data = res),
    });
  }
}
