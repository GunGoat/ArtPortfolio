using ArtPortfolio.Application.Common.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace ArtPortfolio.Web.Components;

public record FilterOption(string Value, string DisplayText, bool IsSelected);

public class SearchBarComponent : ViewComponent {
	public IViewComponentResult Invoke(string controllerName, string sortBy, string timeSpan, string searchQuery) {

		// Helper function for case-insensitive comparison
		bool IsSelected(string str1, string str2) =>
			str2 != null && str2.Equals(str1, StringComparison.OrdinalIgnoreCase);

		var sortByOptions = new List<FilterOption> {
			new(SD.SortBy_Date_Ascending, "Date Ascending", IsSelected(SD.SortBy_Date_Ascending, sortBy)),
			new(SD.SortBy_Date_Descending, "Date Descending", IsSelected(SD.SortBy_Date_Descending, sortBy)),
		};
        if (controllerName == "Artwork") {
            sortByOptions.AddRange(new FilterOption[] {
                new(SD.SortBy_Price_Ascending, "Price Ascending", IsSelected(SD.SortBy_Price_Ascending, sortBy)),
                new(SD.SortBy_Price_Descending, "Price Descending", IsSelected(SD.SortBy_Price_Descending, sortBy)),
                new(SD.SortBy_Title_Ascending, "Title Ascending", IsSelected(SD.SortBy_Title_Ascending, sortBy)),
                new(SD.SortBy_Title_Descending, "Title Descending", IsSelected(SD.SortBy_Title_Descending, sortBy))
            });
        }
        else if (controllerName == "Artist") {
            sortByOptions.AddRange(new FilterOption[] {
                new(SD.SortBy_Name_Ascending, "Name Ascending", IsSelected(SD.SortBy_Name_Ascending, sortBy)),
                new(SD.SortBy_Name_Descending, "Name Descending", IsSelected(SD.SortBy_Name_Descending, sortBy))
            });
        }

        var timeSpanOptions = new FilterOption[] {
			new(SD.TimeSpan_All, "All Time", IsSelected(SD.TimeSpan_All, timeSpan)),
			new(SD.TimeSpan_Year, "Year", IsSelected(SD.TimeSpan_Year, timeSpan)),
			new(SD.TimeSpan_Month, "Month", IsSelected(SD.TimeSpan_Month, timeSpan)),
			new(SD.TimeSpan_Week, "Week", IsSelected(SD.TimeSpan_Week, timeSpan))
		};

		// Ensure at least one option is selected for sortByOptions
		if (!sortByOptions.Any(option => option.IsSelected)) {
			sortByOptions[0] = sortByOptions[0] with { IsSelected = true };
		}

		// Ensure at least one option is selected for timeSpanOptions
		if (!timeSpanOptions.Any(option => option.IsSelected)) {
			timeSpanOptions[0] = timeSpanOptions[0] with { IsSelected = true };
		}

		var model = new SearchBarVM {
			ControllerName = controllerName,
			SortByOptions = sortByOptions.ToArray(),
			TimeSpanOptions = timeSpanOptions,
			SearchQuery = searchQuery ?? string.Empty,
		};

		return View(model);
	}
}