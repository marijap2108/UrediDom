import { useCallback } from "react"
import Button from "./Button"
import "./ProductCard.scss"
import { useNavigate } from "react-router-dom"

interface IProductCard {
  productID: number,
  productName: string,
  price: number,
  description: string
}

const ProductCard = ({productID, productName, price, description} : IProductCard) => {
  const navigate = useNavigate()

  const openProduct = useCallback(() => {
      navigate(`/product/${productID}`)
  }, [navigate, productID])

  return <div className="productCard" onClick={openProduct}>
    <div className="productCard__top">

    </div>
    <div className="productCard__bottom">
      <p>{productName}</p>
      <p>{description}</p>
      <p>{price}</p>
      <Button>Add to cart</Button>
    </div>
  </div>
}

export default ProductCard