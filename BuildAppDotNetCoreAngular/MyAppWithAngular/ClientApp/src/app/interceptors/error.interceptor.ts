import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HTTP_INTERCEPTORS, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { error } from 'protractor';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError(_httpErrorResponse => {

        if (_httpErrorResponse.status === 401) {
          return throwError(_httpErrorResponse.statusText);
        }
        if (_httpErrorResponse instanceof HttpErrorResponse) {
          const applicationError = _httpErrorResponse.headers.get('Application-Error');
          if (applicationError) {
            return throwError(applicationError);
          }

          const serverError = _httpErrorResponse.error;
          let modalStateError = '';
          if (serverError.errors && typeof serverError.errors === 'object') {
            for (const key in serverError.errors) {
              if (serverError.errors[key]) {
                modalStateError += serverError.errors[key] + '\n';
              }
            }
          }

          return throwError(modalStateError || serverError || 'Server Error');
        }
      })
    );
  }
}

export const ErrorInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: ErrorInterceptor,
  multi: true
}
