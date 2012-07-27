using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;

namespace Willow.Kermit.Util
{

    public class Container
    {
        private readonly ExportProvider _container = ContainerFactory.Create();

        public T GetInstance<T>()
        {
            return _container.GetExportedValue<T>();
        }

        public IEnumerable<T> GetInstances<T>()
        {
            return _container.GetExportedValues<T>();
        }

        public object GetInstance(string contract)
        {
            return _container.GetExportedValueOrDefault<object>(contract);
        }

        public IEnumerable GetInstances(string contract)
        {
            return _container.GetExportedValues<object>(contract);
        } 
    }
}