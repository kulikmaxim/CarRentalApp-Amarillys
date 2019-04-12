import { User } from './user';
import { Car } from './car';

export class Order {
    id: number;
    comment: string;
    rentalBeginDate: Date;
    rentalEndDate: Date;
    userId: number;
    carId: number;
    
    user: User;
    car: Car;
}
