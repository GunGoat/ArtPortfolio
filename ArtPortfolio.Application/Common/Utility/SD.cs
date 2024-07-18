using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Application.Common.Utility;

public static class SD {
    public const string Role_Admin = "Admin";
    public const string Role_Artist = "Artist";

    public const string Policy_Artwork_Update_Delete = "PolicyArtworkUpdateDelete";
    public const string Policy_Artwork_Create = "PolicyArtworkCreate";

	public const string TimeSpan_Week = "Week";
	public const string TimeSpan_Month = "Month";
	public const string TimeSpan_Year = "Year";
	public const string TimeSpan_All = "All";

    public const string SortBy_Title_Ascending = "Title";
    public const string SortBy_Title_Descending = "TitleDesc";
    public const string SortBy_Date_Ascending = "Date";
	public const string SortBy_Date_Descending = "DateDesc";
	public const string SortBy_Price_Ascending = "Price";
	public const string SortBy_Price_Descending = "PriceDesc";
}
