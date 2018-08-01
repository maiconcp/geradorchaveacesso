import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import { Glyphicon, ButtonToolbar, ButtonGroup, Button, FormGroup, FormControl, ControlLabel, HelpBlock } from 'react-bootstrap';
import * as ChaveAcessoState from '../store/ChaveAcesso';

// At runtime, Redux will merge together...
type ChaveAcessoProps =
    ChaveAcessoState.ChaveAcessoState             // ... state we've requested from the Redux store
    & typeof ChaveAcessoState.actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{ chave: string }>;     // ... plus incoming routing parameters

class ChaveInput extends React.Component<any, any> 
{    
  componentWillMount() {
    console.log("componentWillMount");
    // This method runs when the component is first added to the page
    this.props.requestChaveValida(this.props.match.params.chave);
  }

  componentWillReceiveProps(nextProps: ChaveAcessoProps) {
      // This method runs when incoming props (e.g., route params) change
      this.props.requestChaveValida(nextProps.match.params.chave);
  }
/*
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
  */  
    public render() {
        return (
            <form className="card">
              <FormGroup
                controlId="formBasicText"
                //validationState={this.getValidationState()}
              >
                <ControlLabel>Chave de Acesso</ControlLabel>
                <FormControl
                  type="number"
                  value={this.state.value}
                  //onChange={this.handleChange}
                />
                <FormControl.Feedback />
                <HelpBlock>A chave deve conter 44 dígitos (numéricos)</HelpBlock>
              </FormGroup>
              <div className="form-group col-md-12">
                    <ButtonToolbar>
                        <ButtonGroup>
                            <Button bsStyle="primary" onClick={ () => { this.props.requestChaveValida() } }  ><Glyphicon glyph="ok" />&nbsp;Validar</Button>
                            <Button bsStyle="success"><Glyphicon glyph="search"/>&nbsp;Decodificar</Button>
                        </ButtonGroup>
                    </ButtonToolbar>
                </div>    
                { this.props.isLoading ? <span>Loading...</span> : [] }          
            </form>
          );
    }
}


export default connect(
  (state: ApplicationState) => state.chaveAcesso, // Selects which state properties are merged into the component's props
  ChaveAcessoState.actionCreators                 // Selects which action creators are merged into the component's props
)(ChaveInput) as typeof ChaveInput;
