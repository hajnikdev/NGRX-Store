import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable, of, throwError } from "rxjs";
import { catchError } from "rxjs/operators";

import { Topping } from "../models/topping.model";

@Injectable()
export class ToppingsService {
  constructor(private http: HttpClient) {}

  getToppings(): Observable<Topping[]> {
    // return of([
    //   {
    //     id: 1,
    //     name: "anchovy",
    //   },
    //   {
    //     id: 2,
    //     name: "bacon",
    //   },
    //   {
    //     id: 3,
    //     name: "basil",
    //   },
    //   {
    //     id: 4,
    //     name: "chili",
    //   },
    //   {
    //     id: 5,
    //     name: "mozzarella",
    //   },
    //   {
    //     id: 6,
    //     name: "mushroom",
    //   },
    //   {
    //     id: 7,
    //     name: "olive",
    //   },
    //   {
    //     id: 8,
    //     name: "onion",
    //   },
    //   {
    //     id: 9,
    //     name: "pepper",
    //   },
    //   {
    //     id: 10,
    //     name: "pepperoni",
    //   },
    //   {
    //     id: 11,
    //     name: "sweetcorn",
    //   },
    //   {
    //     id: 12,
    //     name: "tomato",
    //   },
    // ]);
    return this.http
      .get<Topping[]>(`/api/toppings`)
      .pipe(catchError((error: any) => throwError(error)));
  }
}
