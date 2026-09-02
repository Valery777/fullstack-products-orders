import { useSelector,useDispatch } from 'react-redux';
import type { RootState, AppDispatch } from '../store';
import { addToCart } from '../features/cartSlice';
import '../../styles.css';
export default function ProductsList() {
    const dispatch = useDispatch<AppDispatch>();
    const { items, status, error } = useSelector((state: RootState) => state.products);

    if (status === 'loading') return <p>Loading products...</p>;
    if (status === 'failed') return <p>Error: {error}</p>;

    return (
        <div className="products-grid"> 
            {items.map(p => (
                <div
                    key={p.id}
                    className="product-card"
                    onMouseEnter={(e) => {
                        e.currentTarget.style.transform = 'scale(1.03)';
                        e.currentTarget.style.boxShadow = '0 4px 16px rgba(0,0,0,0.15)';
                    }}
                    onMouseLeave={(e) => {
                        e.currentTarget.style.transform = 'scale(1)';
                        e.currentTarget.style.boxShadow = '0 2px 10px rgba(0,0,0,0.1)';
                    }} >
                    <h3 className="product-name">{p.name}</h3>
                    <p className="product-price">{p.price}₪</p>
                    <button
                        className="category-button"
                        onClick={() => dispatch(addToCart({
                            productId: p.id,
                            name: p.name,
                            price: p.price
                        }))}
                    >
                        הוסף לעגלה
                    </button>
                </div>
            ))}
        </div>
    );
}
