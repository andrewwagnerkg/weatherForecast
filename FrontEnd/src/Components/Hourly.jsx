function Hourly(props) {


    return (
        <>
            <section className="card" aria-label="Почасовой прогноз">
                <div className="section-label">Почасовой прогноз</div>
                <div className="hourly-scroll">

                    {props.data.map((item, index) => (
                        <div className="hour-item">
                            <div className="hour-time">{new Date(item.date).toLocaleString()}</div>

                            <div className="hour-temp">{item.temperatureCelsius}°</div>
                            <img src={item.conditionIconUrl}/>
                            <div className="hour-pop">&nbsp;</div>
                            <div className="hour-time">{item.conditionText}</div>
                        </div>
                    ))}
                </div>
            </section>
        </>
    )
}

export default Hourly