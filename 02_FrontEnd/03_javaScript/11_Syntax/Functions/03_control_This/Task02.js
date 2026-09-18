function calculatePrice(discount, tax) {
   return (this.price - discount) + tax;
}

const product = {
    name: "Laptop",
    price: 1000
};

const finalPrice = calculatePrice.call(product,3,5);
console.log(product.name,"final price:",finalPrice);

const phone = {
    name: "Phone",
    price: 500
};
const phonePrice = calculatePrice.apply(phone,[2,6]);
console.log("phone price: ",phonePrice);
