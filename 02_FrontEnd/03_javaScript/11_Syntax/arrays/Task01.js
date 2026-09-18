/*
    Create an array named fruits with three items.
    Replace the second item with "mango" and print the updated array.
*/
function main ()
{
    let fruites = ["apple","orange","banana"];
    
    console.log(fruites);
    
    fruites.splice(1,1,"mango");

    console.log(fruites);
}
main();
