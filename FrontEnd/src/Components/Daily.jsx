import DailyRow from "./DailyRow.jsx";

function Daily(props) {


    return (
      <section class="card">
          <div className="section-label">Прогноз на 3 дня</div>
          {props.data.map((item, index) => (
              <DailyRow key={index} {...item} />
          ))}
      </section>
    )
}

export default Daily