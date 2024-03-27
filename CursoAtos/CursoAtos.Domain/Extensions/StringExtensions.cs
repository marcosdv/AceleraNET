namespace CursoAtos.Domain.Extensions;

public static class StringExtensions
{
    public static int ToInt(this string texto)
    {
        return int.Parse(texto);
    }

    public static int ToInt(this string texto, int vlrPadrao)
    {
        try
        {
            return int.Parse(texto);
        }
        catch
        {
            return vlrPadrao;
        }
    }

    public static bool IsNullOrEmpty(this string texto)
    {
        return string.IsNullOrEmpty(texto);
    }
}