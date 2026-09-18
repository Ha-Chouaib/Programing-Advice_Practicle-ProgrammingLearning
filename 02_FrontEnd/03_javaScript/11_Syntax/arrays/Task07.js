/*
Given:

const items = ["a", "b", "c", "d", "e"];

Use slice() to get only ["b", "c", "d"].
*/

function main()
{
    const items = ["a", "b", "c", "d", "e"];

    console.log("original: "+items);
    

    let res = items.slice(items.length - 4,items.length -1);
    console.log("after sclice: "+res);

}

main();