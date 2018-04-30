using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iTest.Infrastructure.Providers
{
    public interface IMappingProvider
    {
        TDestination MapTo<TDestination>(object source);

        TDestination InlineMapTo<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts);

        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable<object> source);

        IEnumerable<TDestination> ProjectTo<TDestination>(IEnumerable<object> source);
    }
}