namespace QuizExplain
{
    using System.Collections;
    using System.Text;

    internal class Program
    {
        internal static void Main(string[] args)
        {

        }
    }

    class HouseBoat : IBoat, IHouse
    {
        public void HouseMethod()
        {
            throw new NotImplementedException();
        }

        void IBoat.BoatMethod()
        {
            throw new NotImplementedException();
        }
    }

    interface IBoat
    {
        public void BoatMethod();
    }

    interface IHouse
    {
        public void HouseMethod();
    }
}