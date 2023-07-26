using TraderEngine.Common.DTOs.Request;
using TraderEngine.Common.DTOs.Response;

namespace TraderEngine.API.Services;

/// <summary>
/// Aggregates internal market cap data.
/// </summary>
public interface IMarketCapService
{
  /// <summary>
  /// Get historical market cap data for the specified market for each day within given amount of days ago.
  /// </summary>
  /// <param name="market"></param>
  /// <param name="days"></param>
  /// <returns></returns>
  Task<IEnumerable<MarketCapData>> ListHistorical(MarketDto market, int days = 21);

  /// <summary>
  /// Get historical market cap data of top ranked base currencies for the specified quote currency for each day within given amount of days ago.
  /// </summary>
  /// <param name="quoteSymbol"></param>
  /// <param name="days"></param>
  /// <returns></returns>
  IAsyncEnumerable<IEnumerable<MarketCapData>> ListHistoricalMany(string quoteSymbol, int days = 21);

  /// <summary>
  /// Get the latest market cap data of top ranked base currencies for the specified quote currency,
  /// smoothing out volatility using an Exponential Moving Average of given amount of smoothing days.
  /// </summary>
  /// <param name="quoteSymbol"></param>
  /// <param name="smoothing"></param>
  /// <returns></returns>
  Task<List<MarketCapData>> ListLatest(string quoteSymbol, int smoothing = 7);
}