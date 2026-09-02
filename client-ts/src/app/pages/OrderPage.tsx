import { useSelector, useDispatch } from 'react-redux';
import type { RootState } from '../store';
import { clearCart } from '../features/cartSlice';
import { useState } from 'react';
import type { CartItem } from '../features/cartSlice';
import { Link } from 'react-router-dom';
import '../../styles.css';
import { API_ORDER } from '../config/config';
export default function OrderPage() {
    const { items, total } = useSelector((state: RootState) => state.cart);
    const dispatch = useDispatch();

    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [address, setAddress] = useState("");

    const sendOrder = async () => {
        console.log(`${API_ORDER}/orders`);

        const order = {
            firstName,
            lastName,
            email,
            address,
            items
        };

        const res = await fetch(`${API_ORDER}/orders`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(order)
        });

        const data = await res.json();
        alert("Order saved! ID: " + data.orderId);

        dispatch(clearCart());
    };

    return (
        <div style={{ padding: '40px' }}>
            <h2>סיכום ההזמנה</h2>
            <Link to="/">
                <button className="order-button">
                    חזרה
                </button>
            </Link>
            <h3>סך הכול: {total}₪</h3>

            <h3>מוצרים:</h3>
            {items.map((item: CartItem) => (
                <p key={item.productId}>
                    {item.name} x {item.quantity} — {item.price * item.quantity}₪
                </p>
            ))}

            <h3>פרטי הלקוח</h3>

            <div className="form-container">

                <label className="input-label">שם</label><br />
                <input
                    className="input-field"
                    value={firstName}
                    onChange={e => setFirstName(e.target.value)}
                />
                <br />
                <label className="input-label">שם משפחה</label><br />
                <input
                    className="input-field"
                    value={lastName}
                    onChange={e => setLastName(e.target.value)}
                />
                <br />
                <label className="input-label">מייל</label><br />
                <input
                    className="input-field"
                    value={email}
                    onChange={e => setEmail(e.target.value)}
                    type="email"
                />
                <br />
                <label className="input-label">כתובת</label><br />
                <input
                    className="input-field"
                    value={address}
                    onChange={e => setAddress(e.target.value)}
                />

            </div>

            <br /><br />
            <button className="order-button selected" onClick={sendOrder}>
                שלח
            </button>
        </div>
    );
}
