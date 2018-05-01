using AutoMapper;
using iTest.Data.Models;
using iTest.DTO;
using iTest.Web.Areas.Admin.Models;

namespace iTest.Web.Infrastructure
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            this.CreateMap<TestDTO, AdminTestViewModel>()
                       .ForMember(x => x.Author, options => options.MapFrom(x => x.Author.UserName));

            this.CreateMap<CategoryDTO, AdminCategoryViewModel>()
                   .ForMember(x => x.Author, options => options.MapFrom(x => x.Author.UserName));

            this.CreateMap<AdminTestViewModel, TestDTO>(MemberList.Source);
            this.CreateMap<TestDTO, Test>(MemberList.Source);
        }
    }
}
