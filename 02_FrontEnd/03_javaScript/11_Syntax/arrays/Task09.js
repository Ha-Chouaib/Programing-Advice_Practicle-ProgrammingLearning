/*
    Insert the numbers 100 and 200 between 2 and 3 using splice().
*/

function main()
{
    let arr = [1,2,3,4];
    console.log("original: "+arr);

    arr.splice(arr.indexOf(2),0,100,200);
    console.log("after: "+arr);


}
main();