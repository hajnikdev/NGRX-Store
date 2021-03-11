import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable, of, throwError } from "rxjs";
import { catchError } from "rxjs/operators";

import { Pizza } from "../models/pizza.model";

@Injectable()
export class PizzasService {
  constructor(private http: HttpClient) {}

  getPizzas(): Observable<Pizza[]> {
    // return of([
    //   {
    //     name: "a",
    //     toppings: [
    //       {
    //         id: 1,
    //         name: "anchovy",
    //       },
    //       {
    //         id: 2,
    //         name: "bacon",
    //       },
    //     ],
    //     id: 1,
    //   },
    //   {
    //     name: "b",
    //     toppings: [
    //       {
    //         id: 1,
    //         name: "anchovy",
    //       },
    //       {
    //         id: 2,
    //         name: "bacon",
    //       },
    //     ],
    //     id: 1,
    //   },
    // ]);
    return this.http
      .get<Pizza[]>(`/api/pizzas`)
      .pipe(catchError((error: any) => throwError(error)));
  }

  createPizza(payload: Pizza): Observable<Pizza> {
    return this.http
      .post<Pizza>(`/api/pizzas`, payload)
      .pipe(catchError((error: any) => throwError(error)));
  }

  updatePizza(payload: Pizza): Observable<Pizza> {
    return this.http
      .put<Pizza>(`/api/pizzas/${payload.id}`, payload)
      .pipe(catchError((error: any) => throwError(error)));
  }

  removePizza(payload: Pizza): Observable<Pizza> {
    return this.http
      .delete<any>(`/api/pizzas/${payload.id}`)
      .pipe(catchError((error: any) => throwError(error)));
  }
}
