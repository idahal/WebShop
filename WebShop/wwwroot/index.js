const productsList = document.getElementById('products');

  fetch('https://localhost:44386/api/items')
  .then(response => response.json())
  .then(data => {
      // console.log(data) // Prints result from `response.json()` in getRequest
      data.forEach(item => {
        let output = `
        <strong><h1>${item.title}</h1></strong>
          <img src="./Image/${item.image}" alt="${item.title}" >
          <h3>${item.content}</h3>
          <strong><p>Price:</strong> ${item.price} : -</p>
          <strong><p>Left:</strong> ${item.quantity}</p>
          <button onClick="addToCart(${item.id}, ${item.price})" id="buyButton">Buy</button>
          `
          productsList.innerHTML += output;
      });
  })
    .catch(error => console.error(error))


const addToCart = (id, price) => {
    let guid = localStorage.getItem("guid");
    fetch(`https://localhost:44386/api/cart?id=${id}&price=${price}&guid=${guid}`, {
        method: "POST"
    })
        .then(response => response.json())
        .then(data => {
            if (data) {
                localStorage.guid = data;
            }
        });
};

