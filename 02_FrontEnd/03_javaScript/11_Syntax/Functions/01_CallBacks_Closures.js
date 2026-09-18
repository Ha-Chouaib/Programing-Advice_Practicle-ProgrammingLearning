
let sayHi = _ => console.log("Hello there!");

sayHi();

////
function process(num,callback)
{
    num*=2;
    callback(num);
}
process(3,(n)=> console.log("\nthe result is " + n ));

////
function makeCounter()
{
    let count = 0;

    return function increament(){
        count++;
        console.log(count);
    }
}

const counter = makeCounter();
counter();
counter();
counter();

////
function bankAccount()
{
    let balance = 100;
    return{
        deposit : (amount) => balance += amount,
        getBalance: _ => balance
    }
}
const myAccount = bankAccount();
myAccount.deposit(89);
console.log(myAccount.getBalance());

////
function setupMessage(text)
{
    return function()
    {
        console.log(`Message: ${text}`);
    }
}
const msg = setupMessage("My msg");
msg();
msg();
msg();




