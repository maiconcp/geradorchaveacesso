'use strict'

import React from 'react'
import { Form, FormFeedback, ButtonToolbar, ButtonGroup, Button, FormGroup, Label, Input, InputGroup, InputGroupAddon } from 'reactstrap';
import {Icon} from 'react-fa'
import Lista from './Lista'
import Api from '../api.config'
import styles from './EntradaChaveAcesso.css';

class EntradaChaveAcesso extends React.Component {
  constructor(props) {
    super(props);

    this.handleValidarClick = this.handleValidarClick.bind(this)
    this.handleChaveChange = this.handleChaveChange.bind(this)

    this.state = {chave: '', 
                  chaveValida: false,
                  notification: [],
                  decomposicao: null};    

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
        this.setState({chave: chave, 
          chaveValida: true, 
          notification: ['A chave informada é Válida'],
          decomposicao: data}); 
      }
      else {
        
        this.setState({chave: chave, 
          chaveValida: false, 
          notification: data.erros,
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
      this.setState({chave: currentValue, 
                     chaveValida: false, 
                     notification: ['A chave deve conter 44 dígitos'],
                     decomposicao: null});    
    else
      this.setState({chave: currentValue, 
                     chaveValida: false,
                     notification: [],
                     decomposicao: null});
  }

  handleChaveChange = (e) => {
    console.log("change " + e.target.name + " to " + e.target.value + " with len " + e.target.value.length);

    this.setValidationState(e.target.value);
  }
    
  render() {
    return (
    <Form className="card">
      <FormGroup>
        <Label for="inputChaveAcesso">Chave de Acesso:</Label>
        <InputGroup>
          <Input type="number" 
                  name="inputChaveAcesso" 
                  id="inputChaveAcesso"
                  value={this.state.chave}
                  onChange={this.handleChaveChange}
                  invalid={!this.state.chaveValida && this.state.chave.length > 0}
                  valid={this.state.chaveValida }
                  />
          {
            !this.state.chaveValida && this.state.chave.length > 0 &&
              <InputGroupAddon addonType="append" className="icon-addon"><Icon name="close" className={styles.iconwarning}/></InputGroupAddon>
          }
          {
            this.state.chaveValida &&
            <InputGroupAddon addonType="append" className="icon-addon"><Icon name="check" className={styles.iconsuccess}/></InputGroupAddon>
          }                
          <FormFeedback valid={this.state.chaveValida}><Lista itens={this.state.notification}/></FormFeedback>
        </InputGroup>
      </FormGroup>
      <div className="form-group col-md-12">
            <ButtonToolbar>
                <ButtonGroup>
                    <Button color="primary" onClick={this.handleValidarClick}><Icon name="check"/>&nbsp;Validar</Button>
                    <Button color="success"><Icon name="search"/>&nbsp;Decodificar</Button>
                </ButtonGroup>
            </ButtonToolbar>
        </div>    
    </Form>
  )}
}

export default EntradaChaveAcesso