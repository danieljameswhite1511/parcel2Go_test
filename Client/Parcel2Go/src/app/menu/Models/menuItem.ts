import { Menu } from './menu';
export class MenuItem{
  id: number;
  linkText: string;
  url: string;
  sortOrder: number;
  menuId: number;
  parentId: number;
  menu: Menu;

}
