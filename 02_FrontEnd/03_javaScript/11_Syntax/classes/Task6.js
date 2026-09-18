class clsProduct
{
    constructor(name)
    {
        this._name = name;
        this._price;
    }

    get Price()
    {
        return this._price;
    }
    set Price(value)
    {
        if(value < 0) throw new Error("The Price always should be positive");

        this._price = value;
    }
}

let p = new clsProduct("phone");

p.Price = 90;
console.log(p.Price);
console.log(p._name);

p.Price = -90;
console.log(p.Price);