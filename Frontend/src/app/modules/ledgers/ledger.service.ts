import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class LedgerService {

  private url = 'ledger';
  constructor(private httpClient: HttpClient) { }

  getAllLedgerEntries(): Observable<LedgerEntry[]> {
    return this.httpClient.get<LedgerEntry[]>(`${this.url}`);
  }

  getLedgerEntryById(id: number): Observable<LedgerEntry[]> {
    return this.httpClient.get<LedgerEntry[]>(`${this.url}/${id}`);
  }

  addLedgerEntry(newLedger: Ledger): Observable<Ledger> {
    return this.httpClient.post<Ledger>(`${this.url}`, newLedger);
  }

  updateLedgerEntry(updatedLedger: Ledger): Observable<boolean> {
    return this.httpClient.put<boolean>(`${this.url}`, updatedLedger);
  }

  deleteLedgerEntry(deletedLedgerId: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.url}/${deletedLedgerId}`);
  }

}


export class LedgerEntry {
  description: string;
  createdOn: Date;
  credit: number;
  debit: number;
  accountId: number;
  accountName: string;
}


export class Ledger {
  description: string;
  createdOn: Date;
  jornal: Jornal[] = [];
}

export class Jornal {
  credit: number;
  debit: number;
  accountId: number;
  reference: number;
}
