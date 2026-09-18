/*
    Start with:

let items = [2, 3];

Use unshift() to add 1 at the beginning, then use shift() to remove the first element.
Print the result.
*/

function main ()
{
    let items = [2, 3];
    console.log("original: "+items);

    items.unshift(1);
    console.log("after unshift(): "+items);

    items.shift();
    console.log("after shift(): "+items);

}

main();