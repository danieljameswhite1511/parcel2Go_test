import { Injectable, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Menu } from './Models/menu';
import { MenuItem } from './Models/menuItem';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  private apiController: string = 'menus';
  private apiUrl = environment.baseApiUrl + this.apiController;
  public menu: Menu;
  public menuItems: MenuItem[];


  constructor(private http: HttpClient) { }

  getMenuByName(menuName: string){

    return this.http.get<Menu>(this.apiUrl + '?name=' + menuName);

  }
}
