using Machine.Specifications;
using Willow.Kermit.ViewModels;
using Willow.Kermit.ViewModels.Interfaces;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;

namespace Willow.Kermit.Specs.ViewModels
{   
    public class SearchViewModelSpecs
    {
        public abstract class concern : Observes<ISearchViewModel, SearchViewModel>
        {
        
        }

        [Subject(typeof(SearchViewModel))]
        public class when_using_the_view : concern
        {

            It should_have_a_search_button = () => { sut.Search.ShouldNotBeNull(); };
            It should_have_the_search_text_empty = () => { string.IsNullOrWhiteSpace(sut.SearchText).ShouldBeTrue(); };
        }
    }
}
