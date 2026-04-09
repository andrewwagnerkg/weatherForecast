export default function HourForecastCard (props) {
    return(
        <div className="hour-item">
            <div className="hour-time">{new Date(props.date).toLocaleString()}</div>

            <div className="hour-temp">{props.temperatureCelsius}°</div>
            <img src={props.conditionIconUrl}/>
            <div className="hour-pop">&nbsp;</div>
            <div className="hour-time">{props.conditionText}</div>
        </div>
    )
}