
let obj ={

    location: "from the outer object",
    where()
    {
        console.log(this.location);
    },
    InnerObj : {
        location : "from the inner object",
        where()
        {
            console.log(this.location);
        }
    }

}

obj.where();
obj.InnerObj.where();