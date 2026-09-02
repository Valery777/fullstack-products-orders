import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { API_BASE } from '../config/config';

interface Product {
    id: number;
    name: string;
    price: number;
    categoryId: number;
}

interface ProductsState {
    items: Product[];
    status: 'idle' | 'loading' | 'succeeded' | 'failed';
    error: string | null;
}

const initialState: ProductsState = {
    items: [],
    status: 'idle',
    error: null
};

export const fetchProducts = createAsyncThunk<
    Product[],               // success type
    number | undefined,      // argument type
    { rejectValue: string }  // reject type
>(
    'products/fetchProducts',
    async (categoryId, { rejectWithValue }) => {
        try {
            const url = categoryId
                ? `${API_BASE}/products?categoryId=${categoryId}`
                : `${API_BASE}/products`;

            const response = await fetch(url);

            if (!response.ok) {
                return rejectWithValue("Server error");
            }

            const data = await response.json();
            return data;

        } catch {
            return rejectWithValue("Network error");
        }
    }
);

const productsSlice = createSlice({
    name: 'products',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(fetchProducts.pending, (state) => {
                state.status = 'loading';
                state.error = null;
            })
            .addCase(fetchProducts.fulfilled, (state, action) => {
                state.status = 'succeeded';
                state.items = action.payload;
            })
            .addCase(fetchProducts.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.payload ?? "Unknown error";
            });
    }
});

export default productsSlice.reducer;
