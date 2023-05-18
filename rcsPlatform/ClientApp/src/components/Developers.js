import React, { Component } from 'react';


export class Developers extends Component {
  static displayName = Developers.name;

  render() {
      const Developers = [
        { name: 'Developer 1', expertise: 'Frontend Development' },
        { name: 'Developer 2', expertise: 'Backend Development' },
        // Add more developers here
      ];
      return (
        <div>
        <h1>Developers</h1>
        {Developers.map((developer, index) => (
          <div key={index}>
            <h2>{developer.name}</h2>
            <p>{developer.expertise}</p>
          </div>
        ))}
      </div>
    );
  }
}
 
