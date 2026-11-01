const nums = [2, 4, 6];

nums.forEach(n => console.log(n));

const values = [40, 5, 90, 12];

values.sort((a,b) => a - b);
console.log(values);

const cities = ["Amman", "Zarqa", "Irbid"];

cities.sort();
console.log(cities);

const data = [3, 7, -2, 10];
console.log("contains negatives: ", data.some(n =>  n < 0));

const list = [2, 4, 6, 8];
console.log("are all even: ",list.every(n => n % 2 == 0));
