const cartList = document.getElementById('orderrows');
const orderButton = document.getElementById('orderconfirmation');

orderButton.addEventListener('click', () => {
    localStorage.removeItem('guid');
    alert("Yey, we just send your order!");
    setTimeout(() => location = "./index.html",300);

});

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
            let output = `
             <strong><p>Name:</strong> ${data.name}</p>
             <strong><p>Lastname:</strong> ${data.lastname}</p>
             <strong><p>Address:</strong> ${data.address}</p>
             <strong><p>Zipcode:</strong> ${data.zipcode}</p>
             <strong><p>City:</strong> ${data.city}</p>
        
        `
            costumerList.innerHTML += output;
        })
    .catch(error => console.error(error))

