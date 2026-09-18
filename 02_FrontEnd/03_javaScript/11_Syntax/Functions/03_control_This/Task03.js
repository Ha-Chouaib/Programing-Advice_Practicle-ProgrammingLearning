const user = {
    name: "Chouaib",

    showName() {
        console.log(this.name);
    }
};

const callback = user.showName.bind(user);
callback();

const x = callback;
x();