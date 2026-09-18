/*
    Insert "blue" at index 1 inside this array:

let colors = ["red", "green"];

Print the new array.
*/

function main()
{
    let colors = ["red", "green"];
    console.log("original: "+colors);

    colors.splice(1,0,"blue");
    console.log("after splice(1,0,\"blue\") : "+colors);
    
}
main();
