using System.Collections.Generic;

public static class Utilitaires
{
    public static IPrecieux TrouverPlusPrecieux(IEnumerable<IPrecieux> listePrecieux)
    {
        IPrecieux plusPrecieux = null;
        foreach (IPrecieux precieux in listePrecieux)
        {
            if (plusPrecieux == null || precieux.Valeur > plusPrecieux.Valeur)
            {
                plusPrecieux = precieux;
            }
        }
        return plusPrecieux;
    }
    public static IPrecieux TrouverMoinsPrecieux(IEnumerable<IPrecieux> listePrecieux)
    {
        IPrecieux moinsPrecieux = null;
        foreach (IPrecieux precieux in listePrecieux)
        {
            if (moinsPrecieux == null || precieux.Valeur < moinsPrecieux.Valeur)
            {
                moinsPrecieux = precieux;
            }
        }
        return moinsPrecieux;
    }
}
