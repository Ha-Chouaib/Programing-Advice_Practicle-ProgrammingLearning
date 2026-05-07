var myvar = 10;
console.log(myvar);
console.log(window.myvar); // this will not work with Node.js beacause it does not have a window object, but in a browser, it will log 10