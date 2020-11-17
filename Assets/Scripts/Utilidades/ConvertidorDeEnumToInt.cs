public class ConvertidorDeEnumToInt : IConvertidorDeEnumToInt
{
    public int ConvertEnumToInt(EscenasDelJuego escenaEnum)
    {
        return (int)escenaEnum;
    }
}
