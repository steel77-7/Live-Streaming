import React, { useState, useRef, useEffect } from "react";

interface VideoContainerProps {
  vid: any;
}
export const VideoContainer: React.FC<VideoContainerProps> = ({ vid }) => {
  const [dimensions,setDimensions] = useState({
    width: 800,
    height:600
  })
  const [video, setVideo] = useState();
  const VidRef = useRef<HTMLVideoElement | null>(null);
  useEffect(() => {
    if (VidRef.current) {
      VidRef.current.srcObject = vid;
    }
  }, [vid]);

  return (
    <>
      <div className={`flex w-[${dimensions.width}px] h-[${dimensions.height}px] bg-black rounded-lg border border-white`} >
        <video ref={VidRef} height={dimensions.height} width={dimensions.width} autoPlay muted className='scale-x-[-1]' />
      </div>
    </>
  );
};
