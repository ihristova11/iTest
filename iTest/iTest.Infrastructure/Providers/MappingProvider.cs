﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iTest.Infrastructure.Providers
{
    public class MappingProvider : IMappingProvider
    {
        private IMapper mapper;

        public MappingProvider(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination MapTo<TDestination>(object source)
        {
            return this.mapper.Map<TDestination>(MemberList.Source);
        }

        public TDestination InlineMapTo<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            return this.mapper.Map<TSource, TDestination>(source);
        }

        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable<object> source)
        {
            return source.ProjectTo<TDestination>();
        }

        public IEnumerable<TDestination> ProjectTo<TDestination>(IEnumerable<object> source)
        {
            return source.AsQueryable().ProjectTo<TDestination>();
        }
    }
}