let inputName = document.getElementById("name");
let inputEmail = document.getElementById("email");
let inputColor = document.getElementById("favorit-color");
let inputItemToDelete = document.getElementById("item-to-delete");

let btnSave = document.getElementById("btn-save");
let btnLoadData = document.getElementById("load-data");
let btnDeleteItem = document.getElementById("btn-delete-item");
let btnClearAll = document.getElementById("btn-clear-all");

let OutputName = document.getElementById("display-name");
let OutputEmail = document.getElementById("display-email");
let OutputColor = document.getElementById("display-color");
let OutputclearResult = document.getElementById("clear-result");

btnClearAll.addEventListener("click",ClearAll);
btnSave.addEventListener("click",SaveData);
btnLoadData.addEventListener("click",LoadData);
btnDeleteItem.addEventListener("click",DeleteItem);


const nameKey="name";
const emailKey="email";
const colorKey="color";

function SaveData()
{
    let name = inputName.value;
    let email = inputEmail.value;
    let color = inputColor.value;

    localStorage.setItem(nameKey,name);
    localStorage.setItem(emailKey,email);
    localStorage.setItem(colorKey,color);
    alert("added");

}

function DeleteItem()
{
    let item = inputItemToDelete.value;

   switch(item.toLowerCase())
   {
        case nameKey.toLowerCase():
            localStorage.removeItem(nameKey);
            OutputclearResult.textContent ="Name field removed from Local Storage";
            break;
        case emailKey.toLowerCase():
            localStorage.removeItem(emailKey);
            OutputclearResult.textContent ="email field removed from Local Storage";
            break;
        case colorKey.toLowerCase():
            localStorage.removeItem(colorKey);
            OutputclearResult.textContent ="color field removed from Local Storage";
            break;
   }
}
function ClearAll()
{
    localStorage.clear();
    OutputclearResult.textContent ="Local Storage is empty";

}

function LoadData()
{
    OutputName.textContent = localStorage.getItem(nameKey);
    OutputEmail.textContent = localStorage.getItem(emailKey);
    OutputColor.textContent = localStorage.getItem(colorKey);
}
window.onclose = function()
{
    localStorage.clear();
    btnClearAll.removeEventListener("click",ClearAll);
    btnSave.removeEventListener("click",SaveData);
    btnLoadData.removeEventListener("click",LoadData);
    btnClbtnDaearAll.removeEventListener("click",ClearAll);
}
