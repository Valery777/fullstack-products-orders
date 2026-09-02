import { BrowserRouter, Routes, Route } from 'react-router-dom';
import CategoriesList from './app/components/CategoriesList';
import ProductsList from './app/components/ProductsList';
import CartSummary from './app/components/CartSummary';
import OrderPage from './app/pages/OrderPage';
import './styles.css';
export default function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={
                    <div className="app-container">
                        <div>
                            <h2>Categories</h2>
                            <CategoriesList />
                            <CartSummary />
                        </div>

                        <div style={{ flex: 1 }}>
                            <h2>Products</h2>
                            <ProductsList />
                        </div>
                    </div>
                } />

                <Route path="/order" element={<OrderPage />} />
            </Routes>
        </BrowserRouter>
    );
}