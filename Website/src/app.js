'use strict'

import './css/app.css'
import React from 'react'
import Title from './Components/Title';
import EntradaChaveAcesso from './Components/EntradaChaveAcesso.jsx';

class App extends React.Component {
  render() {
    return <div><br/>
        <EntradaChaveAcesso/>
      </div>
  }
}

export default App