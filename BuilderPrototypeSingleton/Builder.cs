using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPrototypeSingleton
{
    public interface ICarBuilder
    {
        ICarBuilder Reset();

        ICarBuilder SetSeats(byte count);

        ICarBuilder SetEngine();

        ICarBuilder SetTripComputer();

        ICarBuilder SetGps();

        Car GetResult();
    }

    public class CarAutoBuilder : ICarBuilder
    {
        private CarAuto Car { get; set; } = new();


        public ICarBuilder Reset()
        {
            Car = new CarAuto();
            return this;
        }

        public ICarBuilder SetEngine()
        {
            Car.HasEngine = true;
            return this;
        }

        public ICarBuilder SetGps()
        {
            Car.HasGPS = true;
            return this;
        }

        public ICarBuilder SetSeats(byte count)
        {
            Car.Seats = count;
            return this;
        }

        public ICarBuilder SetTripComputer()
        {
            Car.HasTripComputer = true;
            return this;
        }

        public Car GetResult()
        {
            var item = Car;
            Car = new();

            return item;
        }
    }

    public class CarManualBuilder : ICarBuilder
    {
        private CarManual Car { get; set; } = new();


        public ICarBuilder Reset()
        {
            Car = new CarManual();
            return this;
        }

        public ICarBuilder SetEngine()
        {
            Car.HasEngine = true;
            return this;
        }

        public ICarBuilder SetGps()
        {
            Car.HasGPS = true;
            return this;
        }

        public ICarBuilder SetSeats(byte count)
        {
            Car.Seats = count;
            return this;
        }

        public ICarBuilder SetTripComputer()
        {
            Car.HasTripComputer = true;
            return this;
        }

        public Car GetResult()
        {
            var item = Car;
            Car = new();

            return item;
        }
    }


    public abstract class Car
    {
        public int Seats { get; set; }

        public bool HasEngine { get; set; }
        public bool HasTripComputer { get; set; }
        public bool HasGPS { get; set; }

        public override string ToString()
            => string.Format("Seats: {0}, Engine: {1}, Computer: {2}, GPS: {3}", Seats, HasEngine, HasTripComputer, HasGPS);
    }

    public class CarAuto : Car { }

    public class CarManual : Car { }


    public abstract class CarDirector
    {
        protected ICarBuilder Builder { get; set; }


        public CarDirector(ICarBuilder builder) => Builder = builder;


        public abstract Car Make();
        public void ChangeBuilder(ICarBuilder newBuilder) => Builder = newBuilder ?? throw new ArgumentNullException(nameof(newBuilder));
    }

    public class ACategoryCarDirector : CarDirector
    {
        public ACategoryCarDirector(ICarBuilder builder) : base(builder) { }


        public override Car Make()
            => Builder.SetSeats(2).SetEngine().SetGps().GetResult();
    }

    public class BCategoryCarDirector : CarDirector
    {
        public BCategoryCarDirector(ICarBuilder builder) : base(builder) { }


        public override Car Make()
            => Builder.SetSeats(2).SetEngine().SetTripComputer().SetGps().GetResult();
    }
}
