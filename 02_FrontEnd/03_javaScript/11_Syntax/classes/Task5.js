
class clsStudent{

    name = "Unknown";
    grade = 0;

    introduce()
    {
        console.log("Student Name: "+this.name+"/ grade: "+this.grade)
    }

    prompt(lvl)
    {
        this.level = "In level "+ lvl;
    }
}

let s1 = new clsStudent();
let s2 = new clsStudent();

s1.name = "chouaib hadadi";
s1.grade= 100;

s2.name = "ali";
s2.grade = 95;

s1.introduce();
s2.introduce();

s1.prompt("A+");

console.log("S1",s1.level);
console.log("S2",s2.level);
