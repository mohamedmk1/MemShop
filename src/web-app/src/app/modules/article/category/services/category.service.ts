import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ApiPathService} from '../../../../shared/services/api-path.service';
import {Category} from '../models/category.model';
import {Observable} from 'rxjs';
import {List} from 'immutable';
import {map} from 'rxjs/operators';


@Injectable({
    providedIn: 'root'
})
export class CategoryService {
    constructor(private readonly http: HttpClient,
                private readonly apiPathService: ApiPathService) {}

    getCategories(): Observable<List<Category>> {
        return this.http.get<List<Category>>(`${this.apiPathService.getCategoryPath()}`).pipe(
            map(categories => List(categories).map(json => Category.fromJson(json)))
        );
    }

    getCategoryById(id: number): Observable<Category> {
        return this.http.get<Category>(`${this.apiPathService.getCategoryPath()}/${id}`);
    }

    createCategory(category: Category): Observable<Category> {
        return this.http.post<Category>(`${this.apiPathService.getCategoryPath()}`, JSON.stringify(category)).pipe(
            map(createdCategory => Category.fromJson(createdCategory))
        );
    }

    updateCategory(category: Category): Observable<Category> {
        return this.http.put<Category>(`${this.apiPathService.getCategoryPath()}/${category.id}`, JSON.stringify(category)).pipe(
            map(updatedCategory => Category.fromJson(updatedCategory))
        );
    }

    deleteCategory(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiPathService.getCategoryPath()}/${id}`);
    }

}
