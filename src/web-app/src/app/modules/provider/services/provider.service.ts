import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ApiPathService} from '../../../shared/services/api-path.service';
import {Observable} from 'rxjs';
import {ProviderModel} from '../models/provider.model';
import {List} from 'immutable';
import {map} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class ProviderService {
    constructor(private readonly http: HttpClient,
                private readonly apiPathService: ApiPathService) {}

    getProviders(): Observable<List<ProviderModel>> {
        return this.http.get<List<ProviderModel>>(`${this.apiPathService.getProviderPath()}`).pipe(
            map(providers => List(providers).map(json => ProviderModel.fromJson(json)))
        );
    }

    getProviderById(id: number): Observable<ProviderModel> {
        return this.http.get<ProviderModel>(`${this.apiPathService.getProviderPath()}/${id}`);
    }

    createProvider(provider: ProviderModel): Observable<ProviderModel> {
        return this.http.post<ProviderModel>(`${this.apiPathService.getProviderPath()}`, provider).pipe(
            map(createdProvider => ProviderModel.fromJson(createdProvider))
        );
    }

    updateProvider(provider: ProviderModel): Observable<ProviderModel> {
        return this.http.put<ProviderModel>(`${this.apiPathService.getProviderPath()}/${provider.id}`, provider).pipe(
            map(updatedProvider => ProviderModel.fromJson(updatedProvider))
        );
    }

    deleteProvider(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiPathService.getProviderPath()}/${id}`);
    }
}
