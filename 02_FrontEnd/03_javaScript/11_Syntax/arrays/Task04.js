/*
    Given:

let nums = [1, 2, 3, 4];

Remove the value 3 using splice().
Print the updated array.
*/

function main()
{
    let nums = [1, 2, 3, 4];
    console.log("original: "+nums);

    nums.splice(2,1);
    console.log("after splice(2,1) : "+nums);


}
main();