using AutoMapper;
using iTest.Data.Models;
using iTest.DTO;
using iTest.Web.Areas.Admin.Models.Categories;
using iTest.Web.Areas.Admin.Models.Tests;
using iTest.Web.Areas.Users.Models;

namespace iTest.Web.Infrastructure
{
    public class MappingSettings : Profile
    {
        public MappingSettings()
        {
            //this.CreateMap<TestDTO, AdminTestViewModel>()
            //       .ForMember(x => x.Author, options => options.MapFrom(x => x.Author.UserName));

            // Admin
            this.CreateMap<CreateTestViewModel, TestDTO>(MemberList.Source);
            this.CreateMap<AdminCategoryViewModel, CategoryDTO>(MemberList.Source);

            //User
            this.CreateMap<UserTestViewModel, TestDTO>(MemberList.Source);
            this.CreateMap<UserCategoryViewModel, CategoryDTO>(MemberList.Source);

            this.CreateMap<TestDTO, Test>(MemberList.Source);
            this.CreateMap<CategoryDTO, Category>(MemberList.Source);
            this.CreateMap<QuestionDTO, Question>(MemberList.Source);
            this.CreateMap<AnswerDTO, Answer>(MemberList.Source);
            this.CreateMap<ResultDTO, Result>(MemberList.Source);
        }
    }
}