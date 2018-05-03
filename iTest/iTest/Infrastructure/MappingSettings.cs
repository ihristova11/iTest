using AutoMapper;
using iTest.Data.Models;
using iTest.DTO;
using iTest.Web.Areas.Users.Models;

namespace iTest.Web.Infrastructure
{
    public class MappingSettings : Profile
    {
        public MappingSettings()
        {
            //this.CreateMap<TestDTO, AdminTestViewModel>()
            //       .ForMember(x => x.Author, options => options.MapFrom(x => x.Author.UserName));

            this.CreateMap<TestViewModel, TestDTO>(MemberList.Source);
            this.CreateMap<CategoryViewModel, CategoryDTO>(MemberList.Source);

            this.CreateMap<CategoryDTO, CategoryViewModel>(MemberList.Source)
                    .ReverseMap().MaxDepth(3); ;

            this.CreateMap<TestDTO, Test>(MemberList.Source);
            this.CreateMap<CategoryDTO, Category>(MemberList.Source);
            this.CreateMap<QuestionDTO, Question>(MemberList.Source);
            this.CreateMap<AnswerDTO, Answer>(MemberList.Source);
            this.CreateMap<ResultDTO, Result>(MemberList.Source);
        }
    }
}