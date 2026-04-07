import {useEffect, useState} from "react";

function Current() {

    var [weather, setWeather] = useState(null);
    var [lastUpdated, setLastUpdated] = useState(null);
    var [feelsLike, setFeelsLike] = useState(null);

    var [isError, setIsError] = useState(false);
    var [isLoading, setIsLoading] = useState(true);
    var [isReload, setIsReload] = useState(false);

    useEffect(()=>{
        setIsError(false);
        setIsLoading(true);
        setIsReload(false);
        fetch("https://localhost:7215/Forecast/current")
            .then(res => {
                return res.json()
            })
            .then(data => {
                console.log(data);
                setWeather(data.temperatureCelsius);
                setLastUpdated(data.lastUpdated);
                setFeelsLike(data.feelsLikeCelsius)
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
            <div>Current weather</div>

            <p>Updated date {lastUpdated}</p>
            <p>Moscow</p>
            <div>
                <h1>{weather} &deg;C</h1>
                <p>Feels like {feelsLike} &deg;C</p>
                <p><img src="//cdn.weatherapi.com/weather/64x64/day/116.png"/> Partly cloudy</p>
            </div>
        </>
    )
}

export default Current