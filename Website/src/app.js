'use strict'

import './css/app.css'
import React from 'react'
import Title from './Components/Title';
import EntradaChaveAcesso from './Components/EntradaChaveAcesso.jsx';

class App extends React.Component {
  render() {
    return <div>
      <h1>Aplicação 2</h1>
      <div>
        <EntradaChaveAcesso/>
        <Title value="maicon"/>
      </div>
    </div>
  }
}

export default App