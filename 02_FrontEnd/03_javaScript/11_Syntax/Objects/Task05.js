const std = {
  name: "Omar",
  age: 21,
  grade: "A"
}
console.log("----keys:");
for(let k in  std)
{
    console.log(k);
}

console.log("----values:")
for(let v of Object.values(std) )
{
    console.log(v);
}
console.log("----enries:")
for(let [k,v] of Object.entries(std) )
{
    console.log(k,v);
}

console.log("----enries to objects:")
const updatedStd = Object.fromEntries(
    Object.entries(std).map(([k,v]) => [k , typeof v === "string" ? v.toUpperCase() : v]  ));
console.log(updatedStd);