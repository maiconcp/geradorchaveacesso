'use strict'

import React from 'react'

class Lista extends React.Component {
  render() {
    console.log(this.props.itens);
    return <ul>       
    {this.props.itens.length >= 1 &&
        this.props.itens.map(function (item) {
            return (
                <li>
                    <span>{item}</span>
                </li>
            );
        })
    }
    </ul>
  }
}

export default Lista