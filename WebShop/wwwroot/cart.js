const cartList = document.getElementById('cart');
//skapa variabel av local storage

fetch('https://localhost:44386/api/cart/49780816-7984-493E-A152-111776C4DCCE')
    .then(response => response.json())
    .then(data => {
          data.forEach(item => {
            let output = `
        <strong><p>${item.title}</p></strong>
        <img src="./Image/${item.image}" alt="${item.title}" >
        <p>${item.price}</p>
         
        `
            cartList.innerHTML += output;
        });
    })
    .catch(error => console.error(error))

//user info
var user = {
    name: 'name',
    lastname: 'lastname',
    address: 'gatan',
    zipcode: 'number',
    city: 'city',
    cartguid: '49780816 - 7984 - 493E-A152-111776C4DCCE'
};


var data = new FormData();
data.append("json", JSON.stringify(user));


const addCustumerInfo = () => {
   
    fetch(`https://localhost:44386/api/placeorder`, {
        method: "POST",
        body: data
    })
        .then(response => response.json())
        .then(data => {
            if (data) {
                return data;
            }
        });
};