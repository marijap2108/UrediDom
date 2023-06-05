import { useCallback } from "react"
import Button from "./Button"
import "./ProductCard.scss"
import { useNavigate } from "react-router-dom"

interface IProductCard {
  productID: number,
  productName: string,
  price: number,
  description: string,
  imgSrc: string
}

const ProductCard = ({productID, productName, price, imgSrc} : IProductCard) => {
  const navigate = useNavigate()

  const openProduct = useCallback(() => {
      navigate(`/product/${productID}`)
  }, [navigate, productID])

  return <div onClick={openProduct} className="productCard">
    <div className="productCard__top">
      <img src={imgSrc} />
    </div>
    <div className="productCard__bottom">
      <p>{productName}</p>
      <p>{price}</p>
      <Button>Vidi detalje</Button>
    </div>
  </div>
}

export default ProductCard