import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import './index.scss'
import SignIn from './pages/SignIn.tsx';
import SignUp from './pages/SignUp.tsx';
import Profile from './pages/Profile.tsx';
import Home from './pages/Home.tsx';
import About from './pages/About.tsx';
import ProductList from './pages/ProductList.tsx';
import Product from './pages/Product.tsx';
import Order from './pages/Order.tsx';

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      {
        path: "productList/",
        element: <ProductList />,
      },
      {
        path: "productList/:typeId",
        element: <ProductList />,
      },
      {
        path: "signIn/",
        element: <SignIn />
      },
      {
        path: "signUp/",
        element: <SignUp />
      },
      {
        path: "/profile",
        element: <Profile />
      },
      {
        path: "/home",
        element: <Home />
      },
      {
        path: "/aboutUs",
        element: <About />
      },
      {
        path: "/product/:productID",
        element: <Product />
      },
      {
        path: "/order",
        element: <Order />
      }
    ],
  },
]);

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
    <RouterProvider router={router} />
)
