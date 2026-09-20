const user = {
  name: "Ali",
  settings: {
    theme: "dark"
  }
};

console.log("original obj: ",user);

const shallow = {...user};
shallow.settings.theme = "light"
console.log("\n\nwith shallow copy: ",shallow);

console.log("\n\noriginal obj: ",user);

const deep = structuredClone(user);
deep.name = "chouaib";
deep.settings.theme = "default";

console.log("\n\ndeep copy obj: ",deep);
console.log("\n\noriginal obj: ",user);




