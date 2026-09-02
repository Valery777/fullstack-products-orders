const mongoose = require('mongoose');

const orderSchema = new mongoose.Schema({
    firstName: String,
    lastName: String,
    email: String,
    address: String,
    items: [
        {
            productId: Number,
            name: String,
            price: Number,
            quantity: Number
        }
    ],
    createdAt: {
        type: Date,
        default: Date.now
    }
});

module.exports = mongoose.model('Order', orderSchema);
