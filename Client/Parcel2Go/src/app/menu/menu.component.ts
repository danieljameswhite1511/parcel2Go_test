import { Component, Input, OnInit } from '@angular/core';
import { Menu } from './Models/menu';
import { MenuItem } from './Models/menuItem';
import { MenuService } from './menu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})

export class MenuComponent implements OnInit {

  @Input() menuName: string;
  public menu: Menu;
  public menuItems: MenuItem[];

  constructor(private menuService: MenuService) { }

  ngOnInit(): void {
    this.menuService.getMenuByName(this.menuName).subscribe((menu: Menu)=> {

      this.menu=menu;
      this.menuItems = menu.menuItems;
      this.menu.menuItems=this.menuItems;

     console.log(this.menuItems);

    },error => {
      console.log(error)
    });
  }
}
