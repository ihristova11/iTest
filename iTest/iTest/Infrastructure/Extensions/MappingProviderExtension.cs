using AutoMapper;

namespace iTest.Web.Infrastructure.Extensions
{
    public static class MappingProviderExtension
    {
        public static IMappingExpression<TSource, TDest> IgnoreAll<TSource, TDest>(this IMappingExpression<TSource, TDest> e)
        {
            e.ForAllMembers(x => x.Ignore());
            return e;
        }
    }
}
