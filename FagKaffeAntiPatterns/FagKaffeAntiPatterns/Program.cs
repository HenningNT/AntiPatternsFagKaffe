using System;
using System.Net.Mail;

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
            - vanskeligere å legge til funksjonalitet
            - mer kode for validering av parameteres til methods
            - Mere kode øker antall bugs
     */

    #endregion

    #region Eksempler Primitve Obsession

    public class Examples
    {
        public void SendEmailToCustomer(string firstName, string lastName, string emailAddress, string email)
        {
            // What could possibly go wrong?
        }

        public void SendSmsToCustomer(string firstName, string lastName, int phoneNumber, string message)
        {
            // Mange muligheter for feil
            // Hva med utenlandske telefonnummer?
        }

        public void SendLetterToCustomer(string firstName, string lastName, string streetName, int houseNumber, int postCodeNumber, string postCodePlace, string message)
        {
            #region Hva kan gå galt?
            // Alle felter må valideres
            // Hva med utenlandske adresser med bokstaver i post i postnummer?
            // Hva med adresser med bokstaver i husnummer?
            #endregion
        }

        /*
         
         */


        #endregion

        #region Forslåg til forbedringer

        public void SendEmailToCustomer(Customer customer)
        {
            // What could possibly go wrong?
        }

        public void SendSmsToCustomer(Customer customer)
        {
            // Mange muligheter for feil
            // Hva med utenlandske telefonnummer?
        }

        public void SendLetterToCustomer(Customer customer)
        {
            #region Hva kan gå galt?
            // Alle felter må valideres
            // Hva med utenlandske adresser med bokstaver i post i postnummer?
            // Hva med adresser med bokstaver i husnummer?
            #endregion
        }
    }
    #endregion


    public class Customer
    {
        private Person _person;
        private Address _billingAddress;
        private Address _postAddress;
        private MailAddress _emailAddress;
        private PhoneNumber _MobilePhone;
        private PhoneNumber _LandLinePhone;
    }

    public class Address
    {

    }
    public class Person
    {

    }

    public class PhoneNumber
    {

    }
}
