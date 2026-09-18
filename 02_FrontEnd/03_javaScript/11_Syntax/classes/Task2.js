
//not hiosted
//let p2 = new clsPerson("Karim Al Ahmadi",28);


class clsPerson {
    constructor(name,age)
    {
        this.name = name;
        this.age = age;
    }

    introduce()
    {
        console.log(`Hello my name ${this.name}, and i'am ${this.age} years old`);
    }
}

let p1 = new clsPerson("Chouaib Hadadi",23);
let p2 = new clsPerson("Karim Al Ahmadi",28);

p1.introduce();
p2.introduce();
