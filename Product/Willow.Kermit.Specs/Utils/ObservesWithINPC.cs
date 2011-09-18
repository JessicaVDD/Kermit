using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Machine.Specifications;
using developwithpassion.specifications.rhino;

namespace Willow.Kermit.Specs.Utils
{
    public class ObservesWithINPC<TContract, TClassUnderTest> : Observes<TContract, TClassUnderTest>
        where TContract : class
        where TClassUnderTest : class, TContract, INotifyPropertyChanged
    {
        Establish e = () =>
        {
            add_pipeline_behaviour_against_sut(x => property_helper = new PropertyChangedHelper<TClassUnderTest>(x));
        };

        protected static  IPropertyChangedHelper<TClassUnderTest> property_helper;
    }
}
