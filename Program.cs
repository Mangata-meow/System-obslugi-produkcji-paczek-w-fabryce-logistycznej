using System;
using System_zarzadzania_produkcja_paczek_w_fabryce_logistycznej;

namespace System_zarzadzania_produkcja_paczek_w_fabryce_logistycznej
{
    public interface IPaczka
    {
        void Przygotuj();
    }


    class MalaPaczka : IPaczka
    {
        public void Przygotuj()
        {
            Console.WriteLine("Przygotowano małą paczkę.");
        }
    }

    class DuzaPaczka : IPaczka
    {
        public void Przygotuj()
        {
            Console.WriteLine("Przygotowano dużą paczkę.");
        }
    }

    public interface IFabrykaPaczek
    {
        IPaczka UtworzPaczke();
    }

    public class FabrykaMalychPaczek : IFabrykaPaczek
    {
        public IPaczka UtworzPaczke()
        {
            return new MalaPaczka();
        }
    }

    public class FabrykaDuzychPaczek : IFabrykaPaczek
    {
        public IPaczka UtworzPaczke()
        {
            return new DuzaPaczka();
        }
    }
    public class ZarzadzaniePaczkami
    {
        private IFabrykaPaczek fabrykaPaczek;
        private static ZarzadzaniePaczkami _instancja;
        private ZarzadzaniePaczkami() {}
        public static ZarzadzaniePaczkami Instancja
        {
            get
            {
                if (_instancja == null)
                {
                    _instancja = new ZarzadzaniePaczkami();
                }

                return _instancja;
            }
        }

        public void UstawFabryke(IFabrykaPaczek fabryka)
        {
            fabrykaPaczek = fabryka;
        }

        public void ZrealizujZamowienie()
        {
            var paczka = fabrykaPaczek.UtworzPaczke();
            paczka.Przygotuj();
        }
    }

    class Program
    {
        static void Main()
        {
            var manager = ZarzadzaniePaczkami.Instancja;
            manager.UstawFabryke(new FabrykaMalychPaczek());
            manager.ZrealizujZamowienie();
            manager.UstawFabryke(new FabrykaDuzychPaczek());
            manager.ZrealizujZamowienie();

            Console.ReadLine();
        }

    }
}
