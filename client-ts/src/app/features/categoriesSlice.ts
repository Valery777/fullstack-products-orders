import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { API_BASE } from '../config/config';

interface Category {
    id: number;
    name: string;
}

interface CategoriesState {
    items: Category[];
    status: 'idle' | 'loading' | 'succeeded' | 'failed';
    error: string | null;
}

const initialState: CategoriesState = {
    items: [],
    status: 'idle',
    error: null
};

export const fetchCategories = createAsyncThunk<
    Category[],          // success type
    void,                // argument type
    { rejectValue: string } // reject type
>(
    'categories/fetchCategories',
    async (_, { rejectWithValue }) => {
        try {
            const response = await fetch(`${API_BASE}/categories`);

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

const categoriesSlice = createSlice({
    name: 'categories',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(fetchCategories.pending, (state) => {
                state.status = 'loading';
                state.error = null;
            })
            .addCase(fetchCategories.fulfilled, (state, action) => {
                state.status = 'succeeded';
                state.items = action.payload;
            })
            .addCase(fetchCategories.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.payload ?? "Unknown error";
            });
    }
});

export default categoriesSlice.reducer;
