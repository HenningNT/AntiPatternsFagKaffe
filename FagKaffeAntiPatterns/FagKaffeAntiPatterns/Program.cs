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
    /*
      - Først beskrevet allerede i 1966 
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
            - Mer kode betyr mer unit tester (som alle skriver masse av ? )
     */

    #endregion



    #region Eksempler Primitive Obsession

    public class Examples
    {
        public void SendEmailToCustomer(string firstName, string lastName, string emailAddress, string email)
        {
            // What could possibly go wrong?
            #region
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentException();
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentException();
            if (string.IsNullOrEmpty(emailAddress)) throw new ArgumentException();
            if (string.IsNullOrEmpty(email)) throw new ArgumentException();

            // do stuff...
            #endregion
        }

        public void SendSmsToCustomer(string firstName, string lastName, int phoneNumber, string message)
        {
            // Mange muligheter for feil
            // Hva med utenlandske telefonnummer?

            #region
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentException();
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentException();
            if (!IsValidMobileNumber(phoneNumber)) throw new ArgumentException();
            if (string.IsNullOrEmpty(message)) throw new ArgumentException();

            // do stuff...
            #endregion
        }

        public void SendLetterToCustomer(string firstName, string lastName, string streetName, int houseNumber, int postCodeNumber, string postCodePlace, string message)
        {
            // Alle felter må valideres
            // Hva med utenlandske adresser med bokstaver i post i postnummer?
            // Hva med adresser med bokstaver i husnummer?

            #region 
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentException();
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentException();
            if (string.IsNullOrEmpty(streetName)) throw new ArgumentException();
            if (string.IsNullOrEmpty(postCodePlace)) throw new ArgumentException();
            if (string.IsNullOrEmpty(message)) throw new ArgumentException();

            // do stuff...
            #endregion
        }

        private bool IsValidMobileNumber(int phoneNumber)
        {
            throw new NotImplementedException();
        }


    #endregion



    #region Forslag til forbedringer

        public void SendEmailToCustomer(Customer customer)
        {
            // Customer er allerede sjekket i contructoren, alle felt skal være gyldige.

            // Do stuff
        }

        public void SendSmsToCustomer(Customer customer)
        {
            // customer er allerede sjekket i contructoren, alle felt skal være gyldige.
            // Do stuff
        }

        public void SendLetterToCustomer(Customer customer)
        {
            // customer er allerede sjekket i contructoren, alle felt skal være gyldige.
            // Do stuff confidently ;-) 
        }

        private readonly bool stuffIsOk;

        // Kanskje enda bedre:
        public Result SendEmailToCustomer_v2(Customer customer)
        {
            // Do stuff
            if (stuffIsOk)
                return new Ok();
            else
                return new Error();
        }
    }


    #endregion



    #region Avslutningsvis

    // Bruk klasser (eller struct) isteden for primitives
    // Returner et object istedenfor bool

    #endregion



    #region support classes

    public class Customer
    {
        private readonly Person _person;
        private readonly Address _billingAddress;
        private readonly Address _postAddress;
        private readonly MailAddress _emailAddress;
        private readonly PhoneNumber _MobilePhone;
        private readonly PhoneNumber _LandLinePhone;
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

    public class Result    {    }
    public class Ok : Result    { }
    public class Error : Result { }

    #endregion

}
