const express = require('express');
const mongoose = require('mongoose');
const cors = require('cors');
const ordersRouter = require('./routes/orders');

const app = express();

app.use(express.json());
app.use(cors());

// Connect to MongoDB
mongoose.connect('mongodb://localhost:27017/ordersdb')
    .then(() => console.log("MongoDB connected"))
    .catch(err => console.error("MongoDB error:", err));

// Routes
app.use('/orders', ordersRouter);

app.listen(4000, () => {
    console.log("Orders API running on port 4000");
});
