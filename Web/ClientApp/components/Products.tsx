import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface ProductsExampleState {
    products: Product[];
    loading: boolean;
    substitutes: boolean;
    settings: string;
}

export class Products extends React.Component<RouteComponentProps<{}>, ProductsExampleState> {
    constructor() {
        super();
        this.state = { products: [], loading: true, substitutes: false, settings: "D:\\learning\\ReactLearn\\Web"};

        fetch('api/Product/GetPath').then(response => response.json() as Promise<string>)
            .then(data => {
                this.setState({ settings: data });
            });

        fetch('api/Product/ProductsList')
            .then(response => response.json() as Promise<Product[]>)
            .then(data => {
                this.setState({ products: data, loading: false });
            });
    }

    public render() {      
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Products.renderForecastsTable(this.state.products, this.state.settings);

        return <div>
            <h1>Products list</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
            <img src={require("../../Media/Images/ProductImages/156eec10-e6aa-4f00-a716-4c1d0d504b6d.png")} />
        </div>;
    }

    private static renderForecastsTable(products: Product[], path: string) {
       
        return <table className='table'>
            <thead>
                <tr>
                    <th>Product view</th>
                    <th>Name</th>                   
                    <th>Measurable Value</th> 
                    <th>Get substitutes</th>    
                </tr>
            </thead>
            <tbody>
                    {products.map(prod =>
                    <tr key={prod.dateCreated}>                      
                        <td><img src={require("../../Media/Images/ProductImages/1.png")} /></td>   
                        <td>{prod.name}</td>
                        <td>{prod.measurableValue}</td>
                        <td><a href={'/substitutes?id=' +prod.id} onClick={() => { Products.getSubstitutes(prod.id) } }  >Get substitutes</a></td>
                                      
                   </tr>
                     )}
            </tbody>
        </table>;
    }    

    private static getSubstitutes(id: string) {
        return fetch('api/Product/GetSubstitutes?id='+id); 
    }
    static getPath() {
        return fetch('api/Product/GetPath').then(response => response.json().then(x=> {return x}) ); 
    }
           
}

export interface Product {
    dateCreated: string;
    description: string;
    measurableValue: number;
    name: string;
    id: string;
}
