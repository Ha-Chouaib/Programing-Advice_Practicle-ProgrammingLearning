
(function(){
    console.log("App Loaded");
})();

////

(
    function(num)
    {
        num *= 2;
        console.log(num);
    }
)(5);

////

const Increament = (function(){
    var count =0 ;//even var becomes local scope here
    return function ()
    {
        count ++;
        console.log(count);
    }
})();
Increament();
Increament();
Increament();