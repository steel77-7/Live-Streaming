import { useEffect, useState } from "react";

export const useSocket = () => {
  const [socket, setSocket] = useState<WebSocket | null>(null);
  useEffect(() => {
    const ws = new WebSocket(import.meta.env.VITE_SOCKET_URL);
    setSocket(ws);

    ws.send(
      JSON.stringify({
        Type: "connect",
        Payload: {},
      })
    );

    ws.onerror = (e: any) => {
      console.error(e);
    };

    return () => {
      console.log("ws disconnected");
      ws.close();
    };
  });
  return socket ? socket : null;
};
