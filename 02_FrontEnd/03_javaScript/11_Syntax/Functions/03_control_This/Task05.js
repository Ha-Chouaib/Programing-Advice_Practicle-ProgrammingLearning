function deposit(amount) {
    this.balance += amount;
}

function withdraw(amount) {
    this.balance -= amount;
    
}

function showBalance() {
    console.log(this.balance);
}

const account1 = {
    owner: "Chouaib",
    balance: 1000
};

const account2 = {
    owner: "Ahmed",
    balance: 500
};

deposit.call(account1,900);
withdraw.apply(account2,[10]);

const acc1Balance = showBalance.bind(account1);
const acc2Balance = showBalance.bind(account2);

acc1Balance();
acc2Balance();
