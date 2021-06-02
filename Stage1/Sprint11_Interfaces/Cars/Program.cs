using System;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Resolution;

namespace Cars
{
    class Program
    {

        static void Main(string[] args)
        {

            //----------------------------------------------------------
            // register type mapping
            //var container = new UnityContainer();
            //container.RegisterType<ICar, Audi> ();
            //Driver drv = container.Resolve<Driver>();
            //drv.RunCar();
            // end register type mapping
            //----------------------------------------------------------


            //----------------------------------------------------------
            // register type mapping with a name
            //var container = new UnityContainer();
            //container.RegisterType<ICar, BMW>();
            //container.RegisterType<ICar, Audi>("LuxuryCar");
            //ICar bmw = container.Resolve<ICar>();
            //ICar audi = container.Resolve<ICar>("LuxuryCar");
            //
            // ties driver "LuxuryCarDriver"  to Audi  "LuxuryCar"
            //container.RegisterType<Driver>("LuxuryCarDriver",
            //    new InjectionConstructor(container.Resolve<ICar>("LuxuryCar")));
            //Driver driver1 = container.Resolve<Driver>();// injects BMW
            //driver1.RunCar();

            //  resolves driver "luxurycarDriver" to audi
            //Driver driver2 = container.Resolve<Driver>("LuxuryCarDriver");// injects audi
            //driver2.RunCar();
            // end register type mapping
            //----------------------------------------------------------

            //----------------------------------------------------------
            // instance type mapping 
            //var container = new UnityContainer();
            //ICar audi = new Audi();
            //container.RegisterInstance<ICar>(audi);
            //Driver driver1 = container.Resolve<Driver>();
            //driver1.RunCar();
            //driver1.RunCar();
            //  driver2 does not create a new instance
            //Driver driver2 = container.Resolve<Driver>();
            //driver2.RunCar();
            // end instance type mapping
            //----------------------------------------------------------


            //----------------------------------------------------------
            // constructor injection  
            //     <ICar, BMW>  is injected into the container and 
            //                  container is resolved and injected into driver
            //var container = new UnityContainer();
            //container.RegisterType<ICar, BMW>();
            //
            //var driver = container.Resolve<Driver>();
            //driver.RunCar();
            // end of constructor injection
            //----------------------------------------------------------

            //----------------------------------------------------------
            // constructor injection  - multiple parms
            //var container = new UnityContainer();
            //
            //container.RegisterType<ICar, Audi>();
            //container.RegisterType<ICarKey, AudiKey>();
            //    
            //var driver = container.Resolve<Driver>();
            //driver.RunCar();
            // end of constructor injection - multiple parms
            //----------------------------------------------------------


            //----------------------------------------------------------
            // constructor injection  - multiple parms and [injection Constructor]
            //var container = new UnityContainer();
            //
            //container.RegisterType<Driver>(new InjectionConstructor(new object[] { new Audi(), "Steve" }));
            //
            //var driver = container.Resolve<Driver>(); // Injects Audi and Steve
            //driver.RunCar();
            // end of constructor injection - multiple parms and [injection Constructor]
            //----------------------------------------------------------


            //----------------------------------------------------------
            // Property injection  
            //var container = new UnityContainer();
            //container.RegisterType<ICar, BMW>();
            //var driver = container.Resolve<Driver>();
            //driver.RunCar();
            // end of property injection - 
            //----------------------------------------------------------



            //----------------------------------------------------------
            // Property injection   with named mapping
            //     bmw cant resolve to driver because of the named mapping
            //var container = new UnityContainer();
            //container.RegisterType<ICar, BMW>();
            //container.RegisterType<ICar, Audi>("LuxuryCar");
            //
            //var driver = container.Resolve<Driver>();
            //driver.RunCar();
            // end of property injection - 
            //----------------------------------------------------------



            //----------------------------------------------------------
            // run time configuration
            // injection property is sent in at run time
            //     driver is registered and car property is injected
            //var container = new UnityContainer();
            //
            //run-time configuration
            //container.RegisterType<Driver>(new InjectionProperty("Car", new BMW()));
            //
            //var driver = container.Resolve<Driver>();
            //driver.RunCar();
            // end of run time configuration
            //----------------------------------------------------------


            //----------------------------------------------------------
            // method injection
            //     For the method injection, we need to tell the Unity container
            //     which method should be used for dependency injection. So, we need
            //     to decorate a method with the [InjectionMethod] attribute as shown
            //     in the following Driver class.
            //
            //  var container = new UnityContainer();
            //container.RegisterType<ICar, BMW>();
            //
            //var driver = container.Resolve<Driver>();
            //driver.RunCar();
            // end of method injection
            //----------------------------------------------------------


            //----------------------------------------------------------
            // method injection - run time config
            //var container = new UnityContainer();
            //
            //run-time configuration
            //container.RegisterType<Driver>(new InjectionMethod("UseCar", new Audi()));
            //
            //to specify multiple parameters values
            //container.RegisterType<Driver>(new InjectionMethod("UseCar", new object[] { new Audi() }));
            //
            //var driver = container.Resolve<Driver>();
            //driver.RunCar();
            // end of method injection- run time config
            //----------------------------------------------------------

            //----------------------------------------------------------
            // overrides
            //     The ParameterOverride can be used to override
            //     registered construction parameter values.
            //     requires:   using Unity.Resolution;
            //     bmw is replaced by ford
            //
            //var container = new UnityContainer()
            //    .RegisterType<ICar, BMW>();
            //
            //var driver1 = container.Resolve<Driver>(); // Injects registered ICar type
            //driver1.RunCar();
            //
            // Overrides the registered ICar type 
            //var driver2 = container.Resolve<Driver>(new ParameterOverride("car", new Ford()));
            //driver2.RunCar();
            // end of overrides
            //----------------------------------------------------------

            //----------------------------------------------------------
            // overrides - multiple pars
            //var container = new UnityContainer()
            //    .RegisterType<ICar, BMW>();
            //
            //var driver1 = container.Resolve<Driver>();
            //driver1.RunCar();
            //
            //  creates a car1, car2 and car3 object
            //  nothing implements these cars
            //var driver2 = container.Resolve<Driver>(new ResolverOverride[] {
            //        new ParameterOverride("car1", new Ford()),
            //        new ParameterOverride("car2", new BMW()),
            //        new ParameterOverride("car3", new Audi())
            //});
            //driver2.RunCar();
            // end of overrides -  multiple parms
            //----------------------------------------------------------


            //----------------------------------------------------------
            // property override - similar to run time config
            //var container = new UnityContainer();
            //
            //Configure the default value of the Car property
            //container.RegisterType<Driver>(new InjectionProperty("Car", new BMW()));
            //
            //var driver1 = container.Resolve<Driver>();
            //driver1.RunCar();
            //
            //Override the default value of the Car property
            //var driver2 = container.Resolve<Driver>(
            //    new PropertyOverride("Car", new Audi()));
            //
            //driver2.RunCar();
            // end of property overrides -  
            //----------------------------------------------------------

            //----------------------------------------------------------
            // dependency override - 
            //var container = new UnityContainer()
            //    .RegisterType<ICar, BMW>();
            //
            //var driver1 = container.Resolve<Driver>();
            //driver1.RunCar();
            //
            //Override the dependency
            //var driver2 = container.Resolve<Driver>(new DependencyOverride<ICar>(new Audi()));
            //driver2.RunCar();
            // end of property overrides -  
            //----------------------------------------------------------



            //----------------------------------------------------------
            // transient lifetime manager (default)
            //    new object on every resolve
            //var container = new UnityContainer()
            //                  .RegisterType<ICar, BMW>(new TransientLifetimeManager());
            //
            //var driver1 = container.Resolve<Driver>();
            //driver1.RunCar();
            //
            //var driver2 = container.Resolve<Driver>();
            //driver2.RunCar();
            //
            // end of transient lifetime manager
            //----------------------------------------------------------



            //----------------------------------------------------------
            // ContainerControlledLifetimeManager  
            //      creates a singleton
            //var container = new UnityContainer()
            //       .RegisterType<ICar, BMW>(new ContainerControlledLifetimeManager());
            //
            //var driver1 = container.Resolve<Driver>();
            //driver1.RunCar();
            //
            //var driver2 = container.Resolve<Driver>();
            //driver2.RunCar();
            //// end of ContainerControlledLifetimeManager
            ////----------------------------------------------------------


            //----------------------------------------------------------
            // HierarchicalLifetimeManager  
            //      singleton for every child
            //var container = new UnityContainer()
            //.RegisterType<ICar, BMW>(new HierarchicalLifetimeManager());
            //
            //var childContainer = container.CreateChildContainer();
            //
            //var driver1 = container.Resolve<Driver>();         //parent
            //driver1.RunCar();
            //
            //var driver2 = container.Resolve<Driver>();         //parent
            //driver2.RunCar();
            //
            //var driver3 = childContainer.Resolve<Driver>();    //child
            //driver3.RunCar();
            //
            //var driver4 = childContainer.Resolve<Driver>();    //child
            //driver4.RunCar();
            /// end of HierarchicalLifetimeManager
            ///----------------------------------------------------------
            
            









            
            //container.RegisterType<Driver>("Steve");
            //container.RegisterType<Driver>(new InjectionConstructor(new object[] { new Audi(), "Steve" }));
            //container.RegisterType<ICar, BMW> ();
            //container.RegisterType<ICar, Audi>("LuxuryCar");
            //container.RegisterType<ICarKey, BMWKey>();
            // container.RegisterType<ICar, Audi>("LuxuryCar");
            // container.RegisterType<ICarKey, AudiKey>();
            // container.RegisterType<Driver>("LuxuryCarDriver", 
            //    new InjectionConstructor(container.Resolve<ICar>("LuxuryCar")));


            //ICar bmw = container.Resolve<ICar>();
            //ICar audi = container.Resolve<ICar>();

            //--------------------------------------------------------------------
            // property injection injects car into empty driver method
            // resolve figures out type bmw and runs the car
            //var container = new UnityContainer();
            //_ = container.RegisterType<Driver>(new InjectionProperty("Car", new BMW()));
            //var driver = container.Resolve<Driver>();
            //driver.RunCar();
            //--------------------------------------------------------------------

            //driver1.RunCar();

            //Driver driver2 = container.Resolve<Driver>();

            //Driver driver2 = container.Resolve<Driver>("LuxuryCarDriver");// injects Audi
            //driver2.RunCar();

            //Console.WriteLine("Hello World!");
        }
    }
}
