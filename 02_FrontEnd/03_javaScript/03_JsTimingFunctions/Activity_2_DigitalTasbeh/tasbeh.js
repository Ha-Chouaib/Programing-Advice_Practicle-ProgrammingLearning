let btnStart = document.getElementById("btn-start");

btnStart.addEventListener("click",StartTasbeh);


function StartTasbeh()
{
    let timer = document.getElementById("timer");
    let tasbeh = document.getElementById("tasbeh-content");

    

    let tasbehCount=0;
    let tasbehLevel =1;
    btnStart.disabled = true;
    btnStart.style.opacity = ".5";
    btnStart.style.cursor = "not-allowed";

    let timeout = setTimeout(()=>
        {
            
           
            let interval = setInterval(()=>{
                tasbehCount ++;

                if(tasbehCount === 33)
                {
                    tasbehLevel ++;
                    tasbehCount = 0;
                }
                
                tasbeh.textContent = "سبحان الله";
                tasbeh.style.color = "white";
                timer.textContent = `${tasbehCount}`;
                
                timer.style.border = "1px solid white";
               

                if(tasbehLevel >= 2)
                {
                    tasbeh.textContent = "الحمد لله";
                    tasbeh.style.color = "red";
                    timer.textContent = `${tasbehCount}`;
                    timer.style.border = "1px solid red";

                }
                if( tasbehLevel >= 3)
                {
                    tasbeh.textContent = "الله أكبر";
                    tasbeh.style.color = "gold";
                    timer.textContent = `${tasbehCount}`;
                    timer.style.border = "1px solid gold";

                   

                }
                if(tasbehLevel === 4)
                    {
                        tasbeh.textContent = "لا إله إلا الله وحده لا شريك له، له الملك وله الحمد وهو على كل شيء قدير";
                        tasbeh.style.color = "green";
                        timer.textContent = "0";
                        
                        timer.style.border = "1px solid green";
                        btnStart.disabled = false;
                        btnStart.style.opacity = "1";
                        btnStart.style.cursor = "pointer";
                        alert("في ميزان حسناتكم")

                        clearInterval(interval);

                    }

            }, 500)

        },300);
}