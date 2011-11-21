using Machine.Specifications;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.ViewModels;
using developwithpassion.specifications.rhino;

namespace Willow.Kermit.Specs.General
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
