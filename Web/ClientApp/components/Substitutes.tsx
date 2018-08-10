import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { Product } from './Products';

interface ProductsExampleState {
    products: RankedProduct[];
    baseproduct: Product;
    loading: boolean;
    substitutes: boolean;
}

export class Substitutes extends React.Component<RouteComponentProps<{}>, ProductsExampleState> {
    constructor() {
        super();
        this.state = {
            products: [], loading: true, substitutes: false, baseproduct:   {
                                                                            dateCreated: "Hello",
                                                                            description: "",
                                                                            measurableValue: 1, name :"", id :""  
                                                                             }        
                    };

        var url = new URL(window.location.href);
        var baseId = url.searchParams.get("id");

        fetch('api/Product/GetProduct?id=' + baseId)
            .then(response => response.json() as Promise<Product>)
            .then(data => {
                this.setState({ baseproduct: data, loading: false });
            });

        fetch('api/Product/GetSubstitutes?id=' + baseId)
            .then(response => response.json() as Promise<RankedProduct[]>)
            .then(data => {
                this.setState({ products: data, loading: false });
            });
    }

    public render() {

            let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Substitutes.renderSubstitutes(this.state.products);
       
        return <div>
            <h1>Products list</h1>
            <p>This component demonstrates list of substitute products for product: {this.state.baseproduct.name} </p>
            { contents }
        </div>;
    }

    private static renderSubstitutes(products: RankedProduct[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Sugar value</th>                   
                    <th>Taste</th> 
                    <th>Consumtion convinience</th>
                    <th>Price</th>
                    <th>Total rating</th>
                    <th>Rate this</th>
                </tr>
            </thead>
            <tbody>
                    {products.map(prod =>
                    <tr key={prod.id}>                       
                        <td>{prod.name }</td>                      
                        <td>{prod.measurableValue}</td>
                        <td>{prod.rate1}</td>  
                        <td>{prod.rate2}</td>  
                        <td>{prod.rate3}</td>  
                        <td>{prod.totalRate}</td> 
                        <td><a href='#'>Rate this substitute</a></td>
                   </tr>
            )}
            </tbody>
        </table>;
    }  
           
}

interface RankedProduct {
    id: string;
    name: string;
    description: string;
    measurableValue: number;
    category: string;
    baseProd: string;
    rate1: number;
    rate2: number;
    rate3: number;
    totalRate: number;
}
