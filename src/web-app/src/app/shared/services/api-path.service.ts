import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {ApiPathConstants} from '../const/apis/api-path.constants';

@Injectable({
  providedIn: 'root'
})

export class ApiPathService {

  constructor(){}

  getMemShopEndPointUrl(): string {
    return environment.memShopApiService;
  }

  getCategoryPath(): string {
    return `${this.getMemShopEndPointUrl()}/${ApiPathConstants.CATEGORY}`;
  }

  getProductPath(): string {
    return `${this.getMemShopEndPointUrl()}/${ApiPathConstants.PRODUCT}`;
  }

  getProviderPath(): string {
    return `${this.getMemShopEndPointUrl()}/${ApiPathConstants.PROVIDER}`;
  }

}
