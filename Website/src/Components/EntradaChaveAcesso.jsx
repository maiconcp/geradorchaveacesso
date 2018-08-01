'use strict'

import React from 'react'
import { Glyphicon, ButtonToolbar, ButtonGroup, Button, FormGroup, FormControl, ControlLabel, HelpBlock } from 'react-bootstrap';
import Api from '../api.config'

class EntradaChaveAcesso extends React.Component {
  constructor(props) {
    super(props);

    this.handleValidarClick = this.handleValidarClick.bind(this)
    this.handleChaveChange = this.handleChaveChange.bind(this);
    
    this.setState({value: currentValue, 
                    validationState: null,
                    help: '',
                    decomposicao: null});    
  }

  validarChave(chave)
  {
    console.log('validarChave: ' + chave)

    fetch(Api.API_URL + "ChaveAcesso/" + chave)
    .then(results =>{
      return results.json()
    })
    .then(data => {
      if (data.isValid) {
        this.setState({value: chave, 
          validationState: 'success', 
          help: '',
          decomposicao: data}); 
      }
      else {
        this.setState({value: chave, 
          validationState: 'error', 
          help: data.erros[0],
          decomposicao: data}); 
      }
    })   
  }

  handleValidarClick () {
    if ((this.state.decomposicao == null) || (!this.state.decomposicao.isValid))
      alert('A chave informada é Inválida.');
    else
    alert('A chave informada é Válida.');
  }

  setValidationState(currentValue) {
    console.log('getValidationState: ' + currentValue)
    const length = currentValue.length;
    if (length == 44) 
      this.validarChave(currentValue);
    else if (length > 0) 
      this.setState({value: currentValue, 
                     validationState: 'error', 
                     help: 'A chave deve conter 44 dígitos',
                     decomposicao: null});    
    else
      this.setState({value: currentValue, 
                     validationState: null,
                     help: '',
                     decomposicao: null});    

  }

  handleChaveChange = (e) => {
    console.log("change " + e.target.name + " to " + e.target.value + " with len " + e.target.value.length);

    this.setValidationState(e.target.value);
  }
    
  render() {
    return (
    <form className="card">
      <FormGroup controlId="formBasicText"
                 validationState={this.state.validationState}>
        <ControlLabel>Chave de Acesso</ControlLabel>
        <FormControl type="number"
                     value={this.state.value}
                     onChange={this.handleChaveChange}/>
        <FormControl.Feedback />
        <HelpBlock>{this.state.help}</HelpBlock>
      </FormGroup>
      <div className="form-group col-md-12">
            <ButtonToolbar>
                <ButtonGroup>
                    <Button bsStyle="primary" onClick={this.handleValidarClick}><Glyphicon glyph="ok" />&nbsp;Validar</Button>
                    <Button bsStyle="success"><Glyphicon glyph="search"/>&nbsp;Decodificar</Button>
                </ButtonGroup>
            </ButtonToolbar>
        </div>    
    </form>
  )}
}

export default EntradaChaveAcesso