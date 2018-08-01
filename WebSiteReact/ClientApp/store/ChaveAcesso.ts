import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface ChavecdwAcessoState {
    chave: string;
    isLoading: boolean;
    isValid: boolean;
}
/*
export interface Estado {
    codigo: number;
    nome: string;
}

export interface Modelo {
    codigo: number;
    nome: string;
}

export interface FormaEmissao {
    codigo: number;
    nome: string;
}

export interface DecomposicaoChaveAcesso {
    estado: Estado;
    dataEmissao: Date;
    emitente?: any;
    modelo: Modelo;
    serie: number;
    numero: number;
    formaEmissao: FormaEmissao;
    codigoNumerico: number;
    digito: number;
    erros: string[];
    isValid: boolean;
}


// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestDecomposicaoChaveAction {
    type: 'REQUEST_DECOMPOSICAO';
    chave: string;
}

interface ReceiveDecomposicaoChaveAction {
    type: 'RECEIVE_DECOMPOSICAO';
    result: DecomposicaoChaveAcesso;
}
*/
interface RequestChaveValidaAction {
    type: 'REQUEST_CHAVEVALIDA';
    chave: string;
}

interface ReceiveChaveValidaAction {
    type: 'RECEIVE_CHAVEVALIDA';
    isValid: boolean;
}
// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestChaveValidaAction | ReceiveChaveValidaAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestChaveValida: (chave: string): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        console.log("Passei");
        console.log("Chave: " + chave);
        if (chave !== getState().chaveAcesso.chave) {
            let fetchTask = fetch(`api/ChaveAcesso/EhValida?chave=1233=${ chave }`)
                .then(response => response.json() as Promise<boolean>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_CHAVEVALIDA', isValid: data });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_CHAVEVALIDA', chave: chave });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: ChaveAcessoState = { chave: "", isLoading: false, isValid: false};

export const reducer: Reducer<ChaveAcessoState> = (state: ChaveAcessoState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_CHAVEVALIDA':
            return {
                chave: action.chave,
                isValid: false,
                isLoading: true
            };
        case 'RECEIVE_CHAVEVALIDA':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
                return {
                    isValid: action.isValid,
                    chave: state.chave,
                    isLoading: false
                };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
