import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import {About} from './components/About';
import {Developers} from './components/Developers';
import Customers from './components/Customers';
import Login from './components/Login';
import Signup from './components/Signup';
import Comments from './components/Comments';
const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  
  {
    path: '/about',
    element: <About />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/developers',
    element: <Developers />
  },
  {
    path: '/customers',
    element: <Customers />
  },
  {
    path: '/login',
    element: <Login />
  },
  {
    path: '/signup',
    element: <Signup />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/comments',
    element: <Comments />
  }
];
export default AppRoutes;
