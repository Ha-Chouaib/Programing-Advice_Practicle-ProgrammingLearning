let btnSave = document.getElementById("btn-save");
let btnLogout = document.getElementById("btn-logout");
let btnLoadCookies = document.getElementById("btn-load-cookie");

let input = document.getElementById("user-name");

btnSave.addEventListener("click",SaveCookies);
btnLogout.addEventListener("click",Logout);
btnLoadCookies.addEventListener("click",displayCookie);

function SaveCookies()
{
    const userName = input.value;

    const expiration = new Date();
    expiration.setDate(expiration.getDate() + 7);

    document.cookie = "username=" + userName +"; expires=" + expiration.toUTCString()+"; path=/" ;

    alert(`Hello ${userName} you User name saved in cookies`);
}

function GetCookie(cookieName)
{
    const cookies = document.cookie.split(";");

    for(let c of cookies)
    {
        c = c.trim();

        if (c.startsWith(cookieName + "=")) {
            return c.substring(cookieName.length + 1);
          }
    }
    return null;
}

function displayCookie()
{
    let cookie = GetCookie("username");

    if(cookie === "")
    {
        alert(`No cookie found`)
    }
    else {
        alert(`Your cookie was store this value: [${cookie}]`);
    }
}

function Logout()
{
     document.cookie =
          "username=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/";
}