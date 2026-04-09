import './App.css'
import Current from "./Components/Current.jsx";
import Daily from "./Components/Daily.jsx";
import Hourly from "./Components/Hourly.jsx";
import {useEffect, useState} from "react";

function App() {

    const [current, setCurrent] = useState(null);
    const [hourly, setHourly] = useState(null);
    const [daily, setDaily] = useState(null);

    const [isError, setIsError] = useState(false);
    const [isLoading, setIsLoading] = useState(true);
    const [isReload, setIsReload] = useState(false);

    useEffect(()=>{
        setIsError(false);
        setIsLoading(true);
        setIsReload(false);
        fetch("https://localhost:32781/Forecast/common")
            .then(res => {
                return res.json()
            })
            .then(data => {
                console.log(data);
                setCurrent(data.current);
                setHourly(data.hourly);
                setDaily(data.daily);

            })
            .catch(err => {
                setIsError(true);
            })
            .finally(() => setIsLoading(false));
    }, [isReload]);

    if(isLoading)
    {
        return (
            <>
                <div>Loading data...</div>
            </>
        )
    }

    if(isError){
        return (
            <>
                <div>Error when data fetching</div>
                <button onClick={() => setIsReload(true)}>Reload</button>
            </>
        )
    }

  return (
      <>
          <div className="row"><Current {...current}/></div>
          <div className="row"><Hourly {...hourly}/></div>
          <div className="row"><Daily {...daily}/></div>
      </>
  )
}

export default App
