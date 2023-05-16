import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Routes>
        
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
        </Routes>
      </Layout>
    );
  }
}

// export default AppRoutes;
// import React from 'react';
// import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
// import { Home } from './components/Home';
// import { NavMenu } from './components/NavMenu';
// import About from './components/About';
// import Developers from './components/Developers';
// import Customers from './components/Customers';
// import Login from './components/Login';
// import Signup from './components/Signup';

// function App() {
//   return (
//     <Router>
//       <NavMenu />
//         <Routes>
//           <Route path="/" element={<Home />} />
//           <Route path="/about" element={<About />} />
//           <Route path="/developers" element={<Developers />} />
//           <Route path="/customers" element={<Customers />} />
//           <Route path="/login" element={<Login />} />
//           <Route path="/signup" element={<Signup />} />
//           <Route path="/signup" element={<NavMenu />} />
//         </Routes>
//     </Router>
//   );
// }

// export default App;