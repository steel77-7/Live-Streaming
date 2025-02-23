import React, { useEffect, useRef, useState } from "react";
import { VideoContainer } from "../Components/Streaming/VideoContainer";
import { useSocket } from "../hooks/useSocket";
export const StreamerView: React.FC = () => {
  const [vid, setVid] = useState<MediaStream | null>(null);
  const [isStreaming, setIsStreaming] = useState<boolean>(false);
  4;
  const [recorder, setRecorder] = useState<MediaRecorder | null>(null);
  const socket = useSocket();

  const playVidFromCamera = async () => {
    try {
      const stream = await navigator.mediaDevices.getUserMedia({
        audio: true,
        video: {
          width: { ideal: 1920 },
          height: { ideal: 1080 },
          frameRate: { ideal: 30 },
        },
      });
      setVid(stream);
    } catch (e) {
      console.error(e);
    }
    return;
  };
  function handleStream() {
    if (!vid) return;
    setIsStreaming((prev: boolean) => !prev);
    console.log("pressed");
    const mediaRecorder = new MediaRecorder(vid, {
      audioBitsPerSecond: 128000,
      videoBitsPerSecond: 2500000,
    });

    mediaRecorder.ondataavailable = (event) => {
      if (!isStreaming || !socket) return;
      console.log("data:", event.data);
      socket.send(event.data);
    };

    mediaRecorder.onstart = () => {
      if (isStreaming) console.log("started");
    };

    mediaRecorder.onstop = () => {
      console.log("stopped");
      setIsStreaming(false);
    };

    mediaRecorder.start(1000);
    setRecorder(mediaRecorder);
  }

  function handleStopStream() {
    if (!recorder) return;
    recorder.stop();
    setRecorder(null);
  }
  useEffect(() => {
    playVidFromCamera();

    return () => {
      handleStopStream();
    };
  }, []);

  return (
    <>
      <div className="fixed w-screen h-screen  text-white font-mono ">
        <h1 className="text-4xl">Stream :</h1>
        <VideoContainer vid={vid} />

        <button
          className="bg-white p-2 border border-black text-black rounded-lg"
          onClick={handleStream}
        >
          stream
        </button>
        <button
          className="bg-white p-2 border border-black text-black rounded-lg"
          onClick={handleStopStream}
        >
          Stop stream
        </button>
      </div>
    </>
  );
};
