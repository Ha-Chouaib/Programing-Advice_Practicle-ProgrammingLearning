class clsCar{

    constructor(brand,speed)
    {
        this.brand = brand;
        this.speed = speed;
    }
    
    drive()
    {
        console.log("the "+this.brand+" drives with speed "+this.speed);
    }
    accelerate(amount)
    {
        this.speed += amount;
    }
}

let car1 = new clsCar("Toyota",60);
let car2 = new clsCar("dacia",40);

car1.drive();
car2.drive();

car1.accelerate(5);
car2.accelerate(15);

car1.drive();
car2.drive();

// let accelerateCar1 = car1.accelerate();
// accelerateCar1(); here this loses its context

let accelerateCar1 = (amount)=> car1.accelerate(amount);

accelerateCar1(5);
car1.drive();

let accelerateCar2 = car2.accelerate.bind(car2);

accelerateCar2(2);
car2.drive();