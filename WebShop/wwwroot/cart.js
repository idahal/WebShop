const cartList = document.getElementById('cart');
const cartGuid = localStorage.getItem("guid");
document.getElementById('CartGuid').value = cartGuid;
const form = document.forms[0];
form.addEventListener('submit', event => {
    event.preventDefault();
    const formData = new FormData(form);
    let data = {};

    for (let entry of formData.entries()) {
        data[entry[0]] = entry[1];
    }
    data = JSON.stringify(data)
    console.log(data);

    fetch('https://localhost:44386/api/placeorder', {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        method: 'POST',
        body: data
    })
        .then(location = '/checkout.html')
})
//skapa variabel av local storage



fetch('https://localhost:44386/api/cart/'+ cartGuid)
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

