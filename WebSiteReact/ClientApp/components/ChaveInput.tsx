import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import { Glyphicon, ButtonToolbar, ButtonGroup, Button, FormGroup, FormControl, ControlLabel, HelpBlock } from 'react-bootstrap';

export class ChaveInput extends React.Component<any, any> 
{    
    constructor(props : any, context : any) {
        super(props, context);
    
        this.handleChange = this.handleChange.bind(this);
    
        this.state = {
          value: ''
        };
      }
    
      getValidationState() {
        const length = this.state.value.length;
        if (length == 44) return 'success';
        else if (length > 0) return 'error';
        return null;
      }
    
      handleChange(e : any) {
        this.setState({ value: e.target.value });
      }

    public render() {
        return (
            <form className="card">
              <FormGroup
                controlId="formBasicText"
                validationState={this.getValidationState()}
              >
                <ControlLabel>Chave de Acesso</ControlLabel>
                <FormControl
                  type="number"
                  value={this.state.value}
                  onChange={this.handleChange}
                />
                <FormControl.Feedback />
                <HelpBlock>A chave deve conter 44 dígitos (numéricos)</HelpBlock>
              </FormGroup>
              <div className="form-group col-md-12">
                    <ButtonToolbar>
                        <ButtonGroup>
                            <Button bsStyle="primary"><Glyphicon glyph="ok" />&nbsp;Validar</Button>
                            <Button bsStyle="success"><Glyphicon glyph="search"/>&nbsp;Decodificar</Button>
                        </ButtonGroup>
                    </ButtonToolbar>
                </div>              
            </form>
          );
    }
}
