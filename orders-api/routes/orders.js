const express = require('express');
const Order = require('../models/Order');
const mongoose = require('mongoose');   // <--- add this

const router = express.Router();

//  Show which DB you are connected to
mongoose.connection.on("connected", () => {
    console.log("Connected to DB:", mongoose.connection.name);
});

//  Show all MongoDB queries (insert, find, update)
mongoose.set("debug", true);

// Save order
router.post('/', async (req, res) => {
    console.log("Incoming order:", req.body);

    try {
        const order = new Order(req.body);

        //  Log before saving
        console.log("Attempting to save order...");

        const savedOrder = await order.save();

        //  Confirm save success
        console.log("Saved order:", savedOrder);

        res.status(201).json({ message: "Order saved", orderId: savedOrder._id });
    } catch (err) {
        console.error("Save error:", err);
        res.status(500).json({ error: "Failed to save order" });
    }
});

// Get order by ID
router.get('/:id', async (req, res) => {
    try {
        const order = await Order.findById(req.params.id);
        console.log("Fetched order:", order);   // <--- extra debug
        res.json(order);
    } catch (err) {
        console.error("Fetch error:", err);
        res.status(404).json({ error: "Order not found" });
    }
});

module.exports = router;
