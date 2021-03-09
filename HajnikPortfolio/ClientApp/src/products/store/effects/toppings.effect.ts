import { Injectable } from "@angular/core";

import { Effect, Actions, ofType } from "@ngrx/effects";
import { map, switchMap, catchError } from "rxjs/operators";

import * as toppingActions from "../actions/toppings.action";
import * as fromServices from "../../services";
import { of } from "rxjs";

@Injectable()
export class ToppingsEffects {
  constructor(
    private actions$: Actions,
    private toppingService: fromServices.ToppingsService
  ) {}

  @Effect()
  loadToppings$ = this.actions$.pipe(
    ofType(toppingActions.LOAD_TOPPINGS),
    switchMap(() => {
      return this.toppingService.getToppings().pipe(
        map((toppings) => new toppingActions.LoadToppingsSuccess(toppings)),
        catchError((error) => of(new toppingActions.LoadToppingsFail(error)))
      );
    })
  );
}
