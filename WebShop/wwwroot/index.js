const productsList = document.getElementById('products');

  fetch('https://localhost:44386/api/items')
  .then(response => response.json())
  .then(data => {
      // console.log(data) // Prints result from `response.json()` in getRequest
      data.forEach(item => {
        let output = `
        <strong><h2>${item.title}</h2></strong>
          <img src="./Image/${item.image}" alt="${item.title}">
          <h3>${item.content}</h3>
          <p>${item.price}</p>
          <p>${item.quantity}</p>
          <button onClick="addToCart(${item.id})" id="buyButton">Buy</button>
          `
          productsList.innerHTML += output;
      });
  })
    .catch(error => console.error(error))


const addToCart = (id) => {
    let guid = localStorage.getItem("guid");
    fetch(`https://localhost:44386/api/cart?id=${id}&guid=${guid}`, {
        method: "POST"
    })
        .then(response => response.json())
        .then(data => {
            if (data) {
                localStorage.guid = data;
            }
        });
};

