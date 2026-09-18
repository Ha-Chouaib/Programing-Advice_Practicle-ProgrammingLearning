/*
    Use push() to add 30, then use pop() to remove the last element.
Print the final array.
*/

function main ()
{
    let nums = [1,2,3];
    console.log("original: "+nums);


    nums.push(30);
    console.log("after push(): "+nums);

    nums.pop();
    console.log("after pop(): "+nums);


}
main();