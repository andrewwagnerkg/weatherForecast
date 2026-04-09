function Current(props) {

    console.log(props);
    return (
            <section className="card" aria-label="Текущая погода">
                <div className="current-top">
                    <div>
                        <div className="city-name">{props.city}</div>
                        <div className="city-country">{props.lastUpdated}</div>
                    </div>
                    <img className="weather-icon-lg" src={props.conditionIconUrl} />
                </div>

                <div className="temp-row">
                    <span className="temp-main">{props.temperatureCelsius}</span>
                    <span className="temp-unit">°C</span>
                    <span className="feels-like">ощущается как {props.feelsLikeCelsius} &deg;C</span>
                </div>

                <div className="weather-desc">{props.conditionText}</div>

                {/*<div className="stats-row">*/}
                {/*    <div className="stat-item">*/}
                {/*        <div className="stat-label">Влажность</div>*/}
                {/*        <div className="stat-value">52%</div>*/}
                {/*    </div>*/}
                {/*    <div className="stat-item">*/}
                {/*        <div className="stat-label">Ветер</div>*/}
                {/*        <div className="stat-value">14 км/ч</div>*/}
                {/*    </div>*/}
                {/*    <div className="stat-item">*/}
                {/*        <div className="stat-label">УФ-индекс</div>*/}
                {/*        <div className="stat-value">5</div>*/}
                {/*    </div>*/}
                {/*</div>*/}
            </section>
    )
}

export default Current