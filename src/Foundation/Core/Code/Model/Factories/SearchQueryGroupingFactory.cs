﻿using Sitecore.Diagnostics;

namespace Conjunction.Foundation.Core.Model.Factories
{
  /// <summary>
  /// Represents the default factory for building instances of type <see cref="SearchQueryGrouping{T}"/>.
  /// </summary>
  public class SearchQueryGroupingFactory : ISearchQueryGroupingFactory
  {
    public SearchQueryGroupingFactory() 
      : this(Locator.Current.GetInstance<ILogicalOperatorFactory>())
    {
    }

    public SearchQueryGroupingFactory(ILogicalOperatorFactory logicalOperatorFactory)
    {
      Assert.ArgumentNotNull(logicalOperatorFactory, "logicalOperatorFactory");

      LogicalOperatorFactory = logicalOperatorFactory;
    }

    public ILogicalOperatorFactory LogicalOperatorFactory { get; }

    public SearchQueryGrouping<T> Create<T>(string configuredLogicalOperator) where T : IndexableEntity, new()
    {
      var logicalOperator = LogicalOperatorFactory.Create(configuredLogicalOperator);
      return new SearchQueryGrouping<T>(logicalOperator);
    }
  }
}