import HourForecastCard from "./HourForecastCard.jsx";

function Hourly(props) {


    return (
     <section className="card" aria-label="Почасовой прогноз">
         <div className="section-label">Почасовой прогноз</div>
         <div className="hourly-scroll">
             {props.data.map((item, index) => (
                 <HourForecastCard key={index} {...item} />
             ))}
         </div>
     </section>
    )
}

export default Hourly