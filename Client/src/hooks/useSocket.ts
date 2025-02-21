import { useEffect, useState } from "react";

export const useSocket = () => {
  const [socket, setSocket] = useState<WebSocket | null>(null);
  useEffect(() => {
   const ws = new WebSocket(import.meta.env.VITE_SOCKET_URL);
   
  // const ws = new WebSocket("ws://localhost:6969/");
   
   setSocket(ws);

    ws.onopen = () => {
      console.log("WebSocket opened");
      setSocket(ws);
     
        // webSoc.send("Hello Server!");
        ws.send(
          JSON.stringify({ Type: "connect", Payload: { UserId: "some" } })
        );
     
    };

    ws.onerror = (e: any) => {
      console.error(e);
    };

    return () => {
      console.log("ws disconnected");
      ws.close();
    };
  }, []);
  return socket ? socket : null;
};
