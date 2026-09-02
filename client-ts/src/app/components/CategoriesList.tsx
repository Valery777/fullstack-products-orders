

import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchCategories } from '../features/categoriesSlice';
import { fetchProducts } from '../features/productsSlice';
import type { RootState, AppDispatch } from '../store';
import '../../styles.css';
export default function CategoriesList() {
    const dispatch = useDispatch<AppDispatch>();
    const { items, status, error } = useSelector((state: RootState) => state.categories);

    const [selectedCategory, setSelectedCategory] = useState<number | null>(null);

    useEffect(() => {
        dispatch(fetchCategories());
    }, [dispatch]);

    if (status === 'loading') return <p>Loading categories...</p>;
    if (status === 'failed') return <p>Error: {error}</p>;

    return (
        <div className="categories-container">
            {items.map(cat => (
                <button
                    key={cat.id}
                    className={
                        selectedCategory === cat.id
                            ? "category-button selected"
                            : "category-button"
                    }
                    onClick={() => {
                        setSelectedCategory(cat.id);
                        dispatch(fetchProducts(cat.id));
                    }}
                >
                    {cat.name}
                </button>
            ))}
        </div>
    );
}