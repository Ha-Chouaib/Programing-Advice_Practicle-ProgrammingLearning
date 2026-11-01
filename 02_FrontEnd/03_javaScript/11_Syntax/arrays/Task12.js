const scores = [5, 10, 15];

const doubleScores = scores.map(s => s * 2);

console.log(doubleScores);

const cart = [20, 15, 30, 10];

const total = cart.reduce((tot,n) => tot += n ,0);
console.log(total);