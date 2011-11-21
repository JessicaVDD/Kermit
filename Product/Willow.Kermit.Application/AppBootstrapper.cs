using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Caliburn.Micro;
using Willow.Kermit.Shell.Interfaces;

namespace Willow.Kermit.Application
{
    public class AppBootstrapper : Bootstrapper<IShell>
	{
		CompositionContainer container;

		/// <summary>
		/// By default, we are configured to use MEF
		/// </summary>
		protected override void Configure() {
            AssemblySource.Instance.Add(typeof(IShell).Assembly);
            var catalog = new AggregateCatalog(
		        AssemblySource.Instance.Select(x => new AssemblyCatalog(x))
		        );

			container = new CompositionContainer(catalog);

			var batch = new CompositionBatch();

			batch.AddExportedValue<IWindowManager>(new WindowManager());
			batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(container);
		    batch.AddExportedValue(catalog);

			container.Compose(batch);
		}

		protected override object GetInstance(Type serviceType, string key)
		{
			string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
			var exports = container.GetExportedValues<object>(contract);

		    var result = exports.FirstOrDefault();
            if (result != null) return result;

			throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
		}

		protected override IEnumerable<object> GetAllInstances(Type serviceType)
		{
			return container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
		}

		protected override void BuildUp(object instance)
		{
			container.SatisfyImportsOnce(instance);
		}
	}
}
