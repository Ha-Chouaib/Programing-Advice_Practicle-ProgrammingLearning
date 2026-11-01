const users = [
  { name: "Omar", age: 24 },
  { name: "Sara", age: 29 },
  { name: "Hadi", age: 31 }
];

const names = users.filter(u => u.age > 25).map(u => u.name);
console.log(names);