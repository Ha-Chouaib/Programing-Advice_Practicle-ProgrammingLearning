
function logArgumentsElements()
{
    console.log(arguments);
}

logArgumentsElements(1,2,3,4,5,6);

function logArgsElements(...args)
{
    console.log(args.map(n => n * 2));
}

logArgsElements(1,2,3,4,6);

