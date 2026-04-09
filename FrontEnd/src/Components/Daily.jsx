function Daily(props) {


    return (
        <>
            <section class="card">
                <div className="section-label">Прогноз на 3 дня</div>

                {props.data.map((item, index) => (
                    <div className="day-row">
                        <div className="day-name">{new Date(item.date).toLocaleDateString()}</div>
                        <img src={item.conditionIconUrl}/>
                        <div className="day-desc">{item.conditionText}</div>
                        <div className="day-temps">
                            <span className="day-low">{item.minTemperatureCelsius}°C</span>
                            <span className="day-high">{item.maxTemperatureCelsius}°C</span>
                        </div>
                    </div>
                ))}



            </section>
        </>
    )
}

export default Daily