
let car = {
    brand: "BMW",
    Model: "who knows",

    start()
    {
        console.log(this.brand+ " is runing from <<Model>>");
    },
    
}
car.start();

class Car {
    
    brand;
    model;
    start()
    {
        console.log(this.brand+ " is runing from << Class object>>");
    }
}

let BMW = new Car();

BMW.brand="BMW";
BMW.model ="XMD";

BMW.start();

let Toyota =  new Car();
Toyota.brand = "Toyota";
Toyota.model = "XER";
Toyota.start();