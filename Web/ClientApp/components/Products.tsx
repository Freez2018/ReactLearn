import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface ProductsExampleState {
    products: Product[];
    loading: boolean;
    substitutes: boolean;
}

export class Products extends React.Component<RouteComponentProps<{}>, ProductsExampleState> {
    constructor() {
        super();
        this.state = { products: [], loading: true, substitutes: false};

        fetch('api/Product/ProductsList')
            .then(response => response.json() as Promise<Product[]>)
            .then(data => {
                this.setState({ products: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Products.renderForecastsTable(this.state.products);

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
                    <th>Product view</th>
                    <th>Name</th>                   
                    <th>Measurable Value</th> 
                    <th>Get substitutes</th>    
                </tr>
            </thead>
            <tbody>
                    {products.map(prod =>
                    <tr key={prod.dateCreated}>
                        <td><img src={'./Media/Images/ProductImages/'+prod.id+'.png'}/></td>
                        <td>{prod.name }</td>                      
                        <td>{prod.measurableValue}</td>
                        <td><a href={'/substitutes?id=' +prod.id} onClick={() => { Products.getSubstitutes(prod.id) } }  >Get substitutes</a></td>
                                      
                   </tr>
            )}
            </tbody>
        </table>;
    }    

    private static getSubstitutes(id: string) {
        return fetch('api/Product/GetSubstitutes?id='+id)
           // .then(response => response.json() as Promise<Product[]>)
            
           ;
        //  return  alert('l');
     }
           
}

export interface Product {
    dateCreated: string;
    description: string;
    measurableValue: number;
    name: string;
    id: string;
}
