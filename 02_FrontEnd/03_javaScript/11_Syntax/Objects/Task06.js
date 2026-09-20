
const obj = Object.create(null);

obj.name = "chouaib";
obj.age = 23;

if("name" in obj) console.log("is name an obj key:",true);
else console.log("is name an obj key:",false);

if(Object.hasOwn(obj,"age")) console.log("is age an obj key:",true);
else console.log("is age an obj key:",false);