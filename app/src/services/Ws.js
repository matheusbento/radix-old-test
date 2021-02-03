
import { w3cwebsocket as W3CWebSocket } from "websocket";

const host = window.location.hostname;

const port = 5000;

const client = new W3CWebSocket(`ws://${host}:${port}/ws`);

client.onopen = () => {
    console.log('WebSocket Client Connected');
};
client.onclose = () => {
    console.log('WebSocket Client Closed');
};

export default client;