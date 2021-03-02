import {HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable} from 'rxjs';

export class ApiRequestHeaderInterceptor implements HttpInterceptor {
    constructor() {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const authReq = req.clone({
            headers: new HttpHeaders({
                'Content-Type':  'application/json; charset=UTF-8'
            })
        });

        console.log('Intercepted HTTP call', authReq);

        return next.handle(authReq);
    }
}
