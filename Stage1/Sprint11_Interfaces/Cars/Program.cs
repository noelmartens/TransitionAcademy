using System;
using Unity;


namespace Cars
{
    class Program
    {
     
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<ICar, BMW>();
            container.RegisterType<ICar, Audi>("LuxuryCar");
            ICar bmw = container.Resolve<ICar>();
            ICar audi = container.Resolve<ICar>();

            Driver driver1 = container.Resolve<Driver>();
            driver1.RunCar();
            driver1.RunCar();

            //Driver driver2 = container.Resolve<Driver>();
            // Registers Driver type            
            container.RegisterType<Driver>("LuxuryCarDriver",
                            new InjectionConstructor(container.Resolve<ICar>("LuxuryCar")));
            driver2.RunCar();

            //Console.WriteLine("Hello World!");
        }
    }
}
