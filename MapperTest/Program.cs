using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MapperTest
{
   
    public class parentPoipo
    {
        public string parent {get; set;}
    }

    public class parentHisoka
    {
        public string parent { get; set; }
    }

    /************************************************************************************************************************/

    public class innerPoipo
    {
        public string taijutsu;
        public int rate;
    }
    
    public class Poipo : parentPoipo
    {
        public string Name { get; set; }
        public string Clan { get; set; }
        public string Jutsu { get; set; }

        public string something { get; set; }
        public string[] poipoArray { get; set; }

        public innerPoipo[] iPoipo { get; set; }
    }

    public class innerHisoka
    {
        public string taijutsu;
        public int rate;
    }
    public class Hisoka : parentHisoka
    {
    public string Name {get; set;}
    public string Clan { get; set; }
    public string Jutsu { get; set; }
    public string justSomething { get; set; }
    public string[] hisokaArray { get; set; }
    public innerHisoka[] iHisoka { get; set; }
    }


    class Program
    {        
        static void Main(string[] args)
        {            
            innerPoipo[] initPoipo = { 
                                         new innerPoipo(){rate = 98, taijutsu = "innergate lvl 5"},
                                         new innerPoipo(){rate = 97, taijutsu = "innergate lvl 6"},
                                         new innerPoipo(){rate = 99, taijutsu = "innergate lvl 7"}
        
                                     };

            string[] myString = { "null","satu", "dua"};

            Poipo mPoipo = new Poipo
            {
                Name = "Hisoka Poipo",
                Clan = "Hunter x Hunter",
                Jutsu = "Undefined",
                something="something of Poipo",
                poipoArray = myString,
                iPoipo = initPoipo
            };

            Mapper.CreateMap<innerPoipo, innerHisoka>();//mapper array

            Mapper.CreateMap<Poipo, Hisoka>()
                .ForMember(dest=>dest.justSomething, sour=>sour.MapFrom(poip=>poip.something))
                .ForMember(dest=>dest.hisokaArray, sour=>sour.MapFrom(poip=>poip.poipoArray))
                .ForMember(dest => dest.iHisoka, sour => sour.MapFrom(poip => poip.iPoipo))
                ;
            

            Hisoka mHisoka = Mapper.Map<Poipo, Hisoka>(mPoipo);

            Console.WriteLine("Isi Variabel Kelas Hisoka :");
            Console.WriteLine("Name : " + mHisoka.Name);
            Console.WriteLine("Clan : " + mHisoka.Clan);
            Console.WriteLine("Jutsu : " + mHisoka.Jutsu);
            Console.WriteLine("justSomething : " + mHisoka.justSomething);
            Console.WriteLine("Nampilin isi array : ");
            foreach (string temp in mHisoka.hisokaArray)
            {
                Console.WriteLine(temp);
            }

            Console.WriteLine("\nIsi Kelas array iHisoka : ");
            foreach (innerHisoka temp in mHisoka.iHisoka)
            {
                Console.WriteLine("Rate : " + temp.rate);
                Console.WriteLine("Taijutsu : " + temp.taijutsu);                
            }



            Console.WriteLine("=========Part IV=======");
            Console.WriteLine("Parent Class Hisoka : " + mHisoka.parent);


            Console.ReadLine();
        }
    }
}
