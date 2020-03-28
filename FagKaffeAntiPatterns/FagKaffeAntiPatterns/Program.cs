using System;

namespace Bouvet.Rogaland.Enigma.FagKaffe.AntiPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Fagkaffe!");
        }
    }

    #region Intro til patterns og anti patterns
    /* - Først beskrevet allerede i 1966 
      - Første bok i 1994: " Design Patterns: Elements of Reusable Object-Oriented Software"
      - Noen viktige pattern kan finnes her:
           - https://refactoring.guru/design-patterns/catalog
     */
    #endregion

    #region Intro til anti patterns
    /*  - Først beskrevet i 1995 
        - Første bok i 1998: "AntiPatterns"
        - Hva er et antipattern?
        - Anti patterns er noe vi gjør om igjen og om igjen (ikke bare i software) som er
           ueffektivt, og som fører til ustabil, buggy eller kode som er vanskelig å endre.
      
        - Noen eksempler:
           - God Class
           - Primitive obsession
           - Magic numbers
           - Singletons
           - Early optimization
      
        - Wikipedia: https://en.wikipedia.org/wiki/Anti-pattern
     */
    #endregion

    #region Primitive Obsession
    /*
       - Primitive obsession er å bruke primitives for mye, istedenfor innkapsle informasjon
           og behaviour i klasser.
       
       - C# value primitives:
           - bool, byte, sbyte, short, int, uint, long, ulong, IntPtr , UIntPtr, char,
               double, single
               
       - C# reference primitives:
           - string, object
     */
    #endregion

    #region Jaha, og hva så? Hva er problemet?
    /*
      - Bruk av primitives istedenfor sammensatte objekter...
            - mindre fleksibel kode,
            vanskeligere å legge til funksjonalitet
            - mer kode for validering av parameteres til methods
            - Mere kode øker antall bugs
            - 
     */

    #endregion

    #region Eksempler Primitve Obsession
    #endregion

    #region Forslåg til forbedringer
    #endregion



}
