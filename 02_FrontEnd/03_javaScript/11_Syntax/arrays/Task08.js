/*
    Use splice() to remove "3" from this array:

let data = [1, 2, 3, 4, 5];


*/

function main()
{
    let data = [1, 2, 3, 4, 5];
    console.log("original: "+data);

    data.splice(data.indexOf(3),1);
    console.log("after splice(data.indexOf(3),1): "+data);
}
main();