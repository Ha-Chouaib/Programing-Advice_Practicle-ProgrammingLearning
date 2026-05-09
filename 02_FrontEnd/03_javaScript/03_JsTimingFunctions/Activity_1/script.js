    let btn = document.getElementById("btn");
    btn.addEventListener("click",startProcess);

function startProcess()
{
    let end = 0;
    let Timer = document.getElementById("timer");
    let label = document.getElementById("lable");

    label.textContent = "Starting Soon...";

    let Interval = setInterval(()=>
    {
        end ++;
        if(end >= 2)
        {
            label.textContent = "Running...";
            Timer.style.display = "flex";
            Timer.style.justifyContent = "center";
            Timer.style.alignItems = "center";
            Timer.innerHTML = `<span>Running...${end}</span>`;
        }
        if(end === 5)
        {
            label.innerHTML = "<p>Process complete";
            Timer.style.display = "none";
            clearInterval(Interval);
        }
    
    },1000)
}