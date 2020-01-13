using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using vodenje_racunov.Dtos;
using vodenje_racunov.Models;

namespace vodenje_racunov.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
            Mapper.CreateMap<Manufacturer, ManufacturerDto>();
            Mapper.CreateMap<ManufacturerDto, Manufacturer>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();
            Mapper.CreateMap<Country, CountryDto>();
            Mapper.CreateMap<CountryDto, Country>();
            Mapper.CreateMap<ClientDto, Client>();
            Mapper.CreateMap<Client, ClientDto>();
            Mapper.CreateMap<Document, DocumentDto>();
            Mapper.CreateMap<DocumentDto, Document>();
            Mapper.CreateMap<Article, ArticleDto>();
            Mapper.CreateMap<ArticleDto, Article>();
        }
    }
}