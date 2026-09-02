

import { useSelector } from 'react-redux';
import type { RootState } from '../store';
import { Link } from 'react-router-dom';
import '../../styles.css';

export default function CartSummary() {
    const { total } = useSelector((state: RootState) => state.cart);

    return (
        <div style={{ marginTop: '20px' }}>
            <h3>סך הכול: {total}₪</h3>

            <Link to="/order">
                <button className="category-button selected">
                    המשך
                </button>
            </Link>
        </div>
    );
}
