import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface ProductsExampleState {
    forecasts: Product[];
    loading: boolean;
}

export class Products extends React.Component<RouteComponentProps<{}>, ProductsExampleState> {
    constructor() {
        super();
        this.state = { forecasts: [], loading: true };

        fetch('api/Product/ProductsList')
            .then(response => response.json() as Promise<Product[]>)
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Products.renderForecastsTable(this.state.forecasts);

        return <div>
            <h1>Products list</h1>
            <p>This component demonstrates fetching data from the server.</p>
            { contents }
        </div>;
    }

    private static renderForecastsTable(products: Product[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Date created</th>
                    <th>Name</th> 
                    <th>Description</th>
                    <th>Measurable Value</th>                                    
                </tr>
            </thead>
            <tbody>
                    {products.map(forecast =>
                        <tr key={forecast.dateCreated}>
                        <td>{new Date(forecast.dateCreated).toLocaleDateString() }</td>
                        <td>{forecast.name }</td>   
                        <td>{forecast.description }</td>
                        <td>{forecast.measurableValue }</td>
                                      
                </tr>
            )}
            </tbody>
        </table>;
    }
}

interface Product {
    dateCreated: string;
    description: number;
    measurableValue: number;
    name: string;
}
