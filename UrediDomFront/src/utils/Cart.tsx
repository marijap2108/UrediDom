type Item = {
  [key: number]: number
}

export const AddToCart = (productID: number, quantity: number) => {
  const cart = localStorage.getItem("cart")
  if (cart) {
    const items: Item = JSON.parse(cart)
    if (items[productID]) {
      items[productID] += quantity
    } else {
      items[productID] = quantity
    }
    return localStorage.setItem("cart", JSON.stringify(items))
  }
  return localStorage.setItem("cart", JSON.stringify({[productID]: quantity}))
}

export const RemoveFromCart = (productID: number, quantity: number | undefined) => {
  const cart = localStorage.getItem("cart")
  if (cart) {
    const items: Item = JSON.parse(cart)

    if (quantity && items[productID] > quantity) {
      items[productID] -= quantity
    } else {
      delete items[productID]
    }
    return localStorage.setItem("cart", JSON.stringify(items))
  }
  return console.error("empty cart")
}

export const ClearCart = () => {
  return localStorage.removeItem("cart");
}

