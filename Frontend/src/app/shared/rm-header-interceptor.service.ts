/*
 * @CreateTime: Sep 6, 2018 4:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 6, 2018 4:57 PM
 * @Description: Http Intercepter to modify passing http request
 */
import { Injectable } from '@angular/core';
import { HttpRequest, HttpInterceptor, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class RmHeaderInterceptorService  implements HttpInterceptor {

    intercept(request: HttpRequest<any>, next: HttpHandler ): Observable<HttpEvent<any>> {

      // get the requested url eg:// /api/something
      const requestUrl = request.url;
      // modify request content-type header to application/json
      const modifiedRequest: HttpRequest<any> =  request.clone({

        url: `http://localhost:53267/api/${requestUrl}`
      });
      // check the request method used
        if (request.method === 'GET') {
          return next.handle(modifiedRequest);
        } else {
          return next.handle(modifiedRequest);
        }
    }

}
