import { AvailableExtras } from './availableExtras';
import { Service } from './service';

export class Quote {
  discount: string;
  service: Service;
  totalPrice: number;
  totalPriceExVat: number;
  totalVat: number;
  unitPrice: number;
  vatRate: number;
  collection: Date;
  cutOff: Date;
  estimatedDeliveryDate: Date;
  availableExtras: AvailableExtras[];
}
