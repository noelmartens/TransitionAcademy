using System;
using Unity;
//using Unity;

namespace Cars
{
    public class BMW : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Ford : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Audi : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }

    }


    public class BMWKey : ICarKey
    {

    }

    public class AudiKey : ICarKey
    {

    }

    public class FordKey : ICarKey
    {

    }

    public class MyCar
    {
        private ICar _car = null;

        public MyCar(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }

    /*  public class Driver
    {        // register type mapping  - 
             //     container is registered to a type - (icar, bmw)
             //     resolve the container to class driver and run the car
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ",
               _car.GetType().Name, _car.Run());
        }

    }  --------  end of register type mapping  */

    /* public class Driver
    {        // register type mapping  - with a name
             //     container is registered to a type - <(icar, Audi)>("LuxuryCar")
             //     resolve the container to class driver and run the car
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ",
               _car.GetType().Name, _car.Run());
        }

    } --------  end of register type mapping - with a name "luxuryCar"  */


    /* public class Driver
    {        // Instance mapping  
             //     container is registered to an instance
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ",
               _car.GetType().Name, _car.Run());
        }

    }   --------  end of instance type mapping  */


    /*public class Driver
    {        // constructor mapping
             
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ",
               _car.GetType().Name, _car.Run());
        }

    }  --------  end of constructor injection*/


    /* public class Driver
     {        // constructor mapping - multiple parms

        private ICar _car = null;
        private ICarKey _key = null;

        public Driver(ICar car, ICarKey key)
        {
            _car = car;
            _key = key;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} with {1} - {2} mile ", _car.GetType().Name, _key.GetType().Name, _car.Run());
        }

    } --------  end of constructor injection - multiple parms*/




    /* public class Driver
    {        // constructor mapping - multiple parms [injectionConstructor]

        private ICar _car = null;
        private string _name = string.Empty;

        public Driver(ICar car, string driverName)
        {
            _car = car;
            _name = driverName;
        }

        public void RunCar()
        {
            Console.WriteLine("{0} is running {1} - {2} mile ",
                            _name, _car.GetType().Name, _car.Run());
        }

    }--------  end of constructor injection - multiple parms[injectionConstructor] */


    /* public class Driver
    {        // property injection
             //    creates car and indicates driver is dependent on car

        public Driver()
        {
        }

        [Dependency]
        public ICar Car { get; set; }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ",
                                this.Car.GetType().Name, this.Car.Run());
        }

    }--------  end of property injection - */



    /* public class Driver
    {// property injection - named mapping
     //    creates car and indicates driver is dependent on car
        public Driver()
        {
        }

        [Dependency("LuxuryCar")]
        public ICar Car { get; set; }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", this.Car.GetType().Name, this.Car.Run());
        }
    }--------  end of property injection - named mapping */


    /* public class Driver
    {// property injection - run time config
     //    driver is registered and car is injected
        public Driver()
        {
        }

        public ICar Car { get; set; }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", this.Car.GetType().Name, this.Car.Run());
        }
    }--------  end of property injection - run time config */


    /* public class Driver
    {   // method injection
        private ICar _car = null;

        public Driver()
        {
        }

        [InjectionMethod]
        public void UseCar(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }    --------  end of method injection */




    /* public class Driver
    {   // method injection - run time config
        private ICar _car = null;

        public Driver()
        {
        }

        public void UseCar(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }    //--------  end of method injection - run time config */



    /* public class Driver
    {   // overrides
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }    //--------  end of overrides */



    /* public class Driver
    {   // overrides - multiple parms
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }    //--------  end of overrides - multiple parms */



    /* public class Driver
    {   // property overrides
        public Driver()
        {
        }

        public ICar Car { get; set; }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", this.Car.GetType().Name, this.Car.Run());
        }

    }    //--------  end of property overrides */



    /* public class Driver
    {   // dependency overrides
        public Driver()
        {
        }

        [Dependency]
        public ICar Car { get; set; }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", this.Car.GetType().Name, this.Car.Run());
        }

    }    //--------  end of property overrides  */


    public class Driver
    {
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }

    /*
    public class Driver
    {
        private ICar _car = null;
        //private ICarKey _key = null;
        private string _name = string.Empty;

        //[Dependency("LuxuryCar")]
        //[Dependency("Car")]
        //[Dependency]
        //public ICar Car { get; set; }

        //-----------------------------------------------------------------
        //  used with register mapping
        public Driver(ICar car)
        {
            _car = car;
        }
        //-----------------------------------------------------------------


        //-----------------------------------------------------------------
        //  used with property injection
        //public Driver() 
        //{          
        //}
        //-----------------------------------------------------------------



        //    [InjectionConstructor]

        //public Driver(ICar car) //, ICarKey key)
        //public Driver() //, ICarKey key)
        //{
        //_car = car;
        //_key = key;
        //}
        /*
        public Driver(ICar car, string drivername)
        {
            _car = car;
            _name = drivername;
        }

        public Driver(string drivername)
        {
            _name = drivername;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", 
               _car.GetType().Name, _car.Run());
            //Console.WriteLine("{0} is running {1} - {2} mile ",
            //                _name, _car.GetType().Name, _car.Run());
            //           Console.WriteLine("Running {0} with {1} - {2} mile ", _car.GetType().Name, _key.GetType().Name, _car.Run());
        }

    }*/
}