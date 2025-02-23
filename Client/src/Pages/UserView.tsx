
import UserVid from '../Components/Streaming/UserVid'
import {useRef} from 'react'
export  const UserView =()=>{


    var videoSrc = 'http://localhost:8000/hls/stream.m3u8'


    const playerRef = useRef<any>(null);
  
    const videoJsOptions = {
      autoplay: true,
      controls: true,
      responsive: true,
      fluid: true,
      sources: [{
        src: videoSrc,
        type: 'application/x-mpegURL'
      }],
    };
  
    const handlePlayerReady = (player:any) => {
      playerRef.current = player;
  
      // You can handle player events here, for example:
      player.on('waiting', () => {
        console.log('player is waiting');
      });
  
      player.on('dispose', () => {
        console.log('player will dispose');
      });
    };
  
return (
    <>
        <div className="flex">
            <UserVid options={videoJsOptions} onReady={handlePlayerReady}/>

        </div>
    
    </>
)
}