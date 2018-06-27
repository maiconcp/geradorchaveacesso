import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Gerador extends React.Component<RouteComponentProps<{}>, {}> {

    render() {
        return (
          <form>
            <label>
              Name:
              <input type="text"  />
            </label>
            <input type="submit" value="Submit" />
          </form>
        );

}
