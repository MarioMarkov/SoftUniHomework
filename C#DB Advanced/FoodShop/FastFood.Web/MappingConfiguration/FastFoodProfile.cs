﻿namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Web.ViewModels.Employees;
    using FastFood.Web.ViewModels.Orders;
    using Models;
    using ViewModels.Categories;
    using ViewModels.Items;

    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionName, y => y.MapFrom(p => p.Name));
            //.ForMember(x => x.PositionId, y => y.MapFrom(p => p.Id));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();
                

            this.CreateMap<Employee,EmployeesAllViewModel> ()
               .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                 .ForMember(x => x.Name, y => y.MapFrom(n => n.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>()
               .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));
            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(c => c.Id));

            this.CreateMap<CreateItemInputModel, Item>()
              .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Item, ItemsAllViewModels>()
              .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));
            //Orders
            this.CreateMap<CreateOrderInputModel,Order>();

            this.CreateMap<Order, OrderAllViewModel>()
               .ForMember(x => x.Employee, y => y.MapFrom(s => s.Employee.Name))
               .ForMember(x => x.OrderId, y => y.MapFrom(s => s.Id))
               .ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime.ToString("g")));

        }
    }
}
