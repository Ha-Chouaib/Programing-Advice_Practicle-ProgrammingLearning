//Using concat(), merge: [1, 2] and [3, 4, 5]

function main()
{
    let arr1 = [1, 2];
    let arr2 = [3,4,5];
    console.log("arr1: "+arr1)
    console.log("arr2: "+arr2)

    let conc = arr1.concat(arr2);
    console.log("after concat: "+conc)
}
main();