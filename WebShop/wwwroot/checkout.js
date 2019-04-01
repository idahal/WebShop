const cartList = document.getElementById('orderrows');
const cartGuid = localStorage.getItem("guid");
fetch('https://localhost:44386/api/cart/' + cartGuid)
    .then(response => response.json())
    .then(data => {
        data.forEach(item => {
            let output = `
        <strong><p>${item.title}</p></strong>
        <img src="./Image/${item.image}" alt="${item.title}" >
        <p>${item.price}:-</p>
         
        `
            cartList.innerHTML += output;
        });
    })
    .catch(error => console.error(error))

const costumerList = document.getElementById('costumer');
fetch('https://localhost:44386/api/placeorder/' + cartGuid)
    .then(response => response.json())
    .then(data => {
        data.forEach(item => {
            let output = `
             <p>${item.name}</p>
             <p>${item.lastname}</p>
             <p>${item.address}</p>
             <p>${item.zipcode}</p>
             <p>${item.City}</p>
         
        `
            costumerList.innerHTML += output;
        });
    })
    .catch(error => console.error(error))