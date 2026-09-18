
const user = {
    name : "chouaib",
    getUserName(saySomething)
    {
        console.log(saySomething,this.name);
    }
}

const getName1 = user.getUserName;
getName1("we lost this context");

getName1.call(user,"fixed version with call: ");
getName1.apply(user,["nigga i am fixed with apply"]);
const getName2 = user.getUserName.bind(user,"bind");

getName2();

