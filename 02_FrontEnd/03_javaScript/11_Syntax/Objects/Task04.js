const car = {
    brand : "BMW",
    showBrand()
    {
        console.log("car: ",this.brand);
    }
}
car.showBrand();

function showStudentInfo()
{
    console.log(this.name + " has a grade of "+this.grade);
}

const student = {
    name:"chouaib",
    grade : 100
}
showStudentInfo.call(student);

const obj = {
    value: 10,
    print() {console.log(this.value)}
}
obj.print();
