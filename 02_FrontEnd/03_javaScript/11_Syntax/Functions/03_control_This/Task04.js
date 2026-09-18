function introduce(role, company) {
    console.log(
        `${this.name} is a ${role} at ${company}`
    );
}
const person = {
    name: "Chouaib"
};

const introPerson = introduce.bind(person,"CEO","My Company");
introPerson();