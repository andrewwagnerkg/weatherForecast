export default function ErrorComponent({text, buttonText, onPress}) {
    return (
        <>
            <div>{text}</div>
            <button onClick={onPress}>{buttonText}</button>
        </>
    )
}