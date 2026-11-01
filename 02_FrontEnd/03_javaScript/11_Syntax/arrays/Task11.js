const people = [
  { name: "Ali", age: 22 },
  { name: "Lina", age: 30 },
  { name: "Ali", age: 28 }
];

const person = people.find(p => p.name.toLocaleLowerCase() === "ali");
console.log(person);

const filtered = people.filter( p => p.age > 25);
console.log(filtered);