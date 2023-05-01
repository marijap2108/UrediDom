import { ButtonHTMLAttributes} from "react"

export interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: string,
  size?: "small" | "medium" | "large"
}

const Button = ({
  variant = "primary",
  size = "medium",
  children,
  ...props
}: ButtonProps) => {
  return <button className={`button__${variant} button__${size}`} {...props}>
    {children}
  </button>
}

export default Button