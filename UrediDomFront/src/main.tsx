import React from 'react'
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

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      {
        path: "productList/",
        element: <>ProductList</>,
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
      }
    ],
  },
]);

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
