using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using YourApartment.Business;
using YourApartment.Domain;
using YourApartment.Persistence.EntityFramework;

namespace YourApartment.Infrastructure
{
    internal sealed class PaginationService<TEntity, TModel> : IPaginationService<TEntity, TModel>
        where TEntity : Entity
    {
        private readonly YourApartmentContext context;
        private readonly ISieveProcessor sieveProcessor;
        private readonly IMapper mapper;

        public PaginationService(YourApartmentContext context, ISieveProcessor sieveProcessor, IMapper mapper)
        {
            EnsureArg.IsNotNull(mapper);
            EnsureArg.IsNotNull(context);
            EnsureArg.IsNotNull(sieveProcessor);

            this.context = context;
            this.mapper = mapper;
            this.sieveProcessor = sieveProcessor;
        }

        private IQueryable<TEntity> RecordsQuery => context.Set<TEntity>().AsQueryable();
        public PageModel<TModel> GetPage(SieveModel sieveModel)
        {
            var records = RecordsQuery.AsNoTracking();

            records = FilterEntities(sieveModel, records);
            records = SortEntities(sieveModel, records);
            var number = records.Count();
            records = PaginateEntities(sieveModel, records);

            return new PageModel<TModel>()
            {
                TotalNumberOfRecords = number,
                Records = mapper.ProjectTo<TModel>(records),
            };
        }

        private IQueryable<TEntity> SortEntities(SieveModel sieveModel, IQueryable<TEntity> records)
            => sieveProcessor.Apply(sieveModel, records, applyPagination: false, applySorting: false);

        private IQueryable<TEntity> FilterEntities(SieveModel sieveModel, IQueryable<TEntity> records)
            => sieveProcessor.Apply(sieveModel, records, applyFiltering: false, applyPagination: false);

        private IQueryable<TEntity> PaginateEntities(SieveModel sieveModel, IQueryable<TEntity> records)
            => sieveProcessor.Apply(sieveModel, records, applyFiltering: false, applySorting: false);
    }
}
