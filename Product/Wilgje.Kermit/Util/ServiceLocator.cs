namespace Willow.Kermit.Util
{
    public static class ServiceLocator
    {
        static Container _container;

        public static Container Current
        {
            get
            {
                if (ReferenceEquals(_container, null)) _container = new Container();
                return _container;
            }
        } 
    }
}