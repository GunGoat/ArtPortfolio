using ArtPortfolio.Web.Components;

public class SearchBarVM {
	public string ControllerName { get; set; }
	public FilterOption[] SortByOptions { get; set; }
	public FilterOption[] TimeSpanOptions { get; set; }
	public string Query { get; set; }
}