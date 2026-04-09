export default function DailyRow (props) {
    return(
        <div className="day-row">
            <div className="day-name">{new Date(props.date).toLocaleDateString()}</div>
            <img src={props.conditionIconUrl}/>
            <div className="day-desc">{props.conditionText}</div>
            <div className="day-temps">
                <span className="day-low">{props.minTemperatureCelsius}°C</span>
                <span className="day-high">{props.maxTemperatureCelsius}°C</span>
            </div>
        </div>
    )
}