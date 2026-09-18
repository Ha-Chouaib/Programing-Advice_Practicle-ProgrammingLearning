const usr = {
    name: "Chouaib",

    introduce() {
        console.log(`My name is ${this.name}`);
    }
};

const anotherUser = {
    name: "Ahmed"
};

const intro = usr.introduce.bind(anotherUser);
intro();
usr.introduce.call(anotherUser);
