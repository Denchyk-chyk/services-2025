function updateCartCount() {
    fetch('/cart/count')
        .then(r => r.json())
        .then(data => {
            const area = document.getElementById('cart-count-area');
            const counter = document.getElementById('cart-count');
            if (data.count > 0) {
                area.classList.remove('d-none');
                counter.textContent = data.count;
            } else {
                area.classList.add('d-none');
            }
        });
}

document.addEventListener('DOMContentLoaded', updateCartCount);

function addToCart(fruitId) {
    fetch('/cart/add', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
        },
        body: `fruit=${fruitId}`
    }).then(response => {
        if (response.ok) {
            updateCartCount();
        }
    });
};
