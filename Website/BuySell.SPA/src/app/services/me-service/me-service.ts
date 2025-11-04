import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MeService {
  private meSubject: BehaviorSubject<Me | undefined>;

  private apiUrl = 'https://localhost:7098/api/Me';

  constructor(private http: HttpClient) {
    this.meSubject = new BehaviorSubject<Me | undefined>(undefined);
  }

  public GetMe(): Observable<Me> {
    return this.http.get<Me>(this.apiUrl).pipe(
      tap((me: Me ) => this.meSubject.next(me))
    );
  }

  public getMeObservable(): Observable<any> {
      return this.meSubject.asObservable();
  }
}

export interface Me {
  email: string;
  isAdmin: boolean;
  isBuyer: boolean;
  isSeller: boolean;
}
