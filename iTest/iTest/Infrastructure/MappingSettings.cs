using AutoMapper;
using iTest.Data.Models;
using iTest.DTO;
using iTest.Web.Areas.Admin.Models;
using iTest.Web.Areas.Admin.Models.Categories;
using iTest.Web.Areas.Admin.Models.Tests;
using iTest.Web.Areas.Users.Models;

namespace iTest.Web.Infrastructure
{
    public class MappingSettings : Profile
    {
        public MappingSettings()
        {
            // Admin View
            this.CreateMap<TestViewModel, TestDTO>(MemberList.Source)
                .ForMember(t => t.Questions, o => o.MapFrom(t => t.Questions))
                .ForPath(t => t.Category.Name, o => o.MapFrom(t => t.Category))
                .ReverseMap();

            this.CreateMap<CreateQuestionViewModel, QuestionDTO>()
                .ForMember(q => q.Description, o => o.MapFrom((q => q.Description)))
                .ForMember(q => q.Answers, o => o.MapFrom(q => q.Answers));

            this.CreateMap<QuestionViewModel, QuestionDTO>()
                .ForMember(q => q.Description, o => o.MapFrom((q => q.Description)))
                .ForMember(q => q.Answers, o => o.MapFrom(q => q.Answers))
                .ForMember(q => q.IsCorrect, o => o.MapFrom(q => q.IsCorrect));

            this.CreateMap<CreateAnswerViewModel, AnswerDTO>()
                .ForMember(a => a.Description, o => o.MapFrom(a => a.Description));

            //this.CreateMap<CreateTestViewModel, TestDTO>(MemberList.Source);
            //this.CreateMap<TestViewModel, TestDTO>(MemberList.Source);
            this.CreateMap<AdminCategoryViewModel, CategoryDTO>(MemberList.Source);

            // User View
            this.CreateMap<UserTestViewModel, TestDTO>(MemberList.Source);
            this.CreateMap<UserCategoryViewModel, CategoryDTO>(MemberList.Source);
            this.CreateMap<UserTestDetailsViewModel, CategoryDTO>(MemberList.Source);


            // DTO
            this.CreateMap<TestDTO, Test>(MemberList.Source);
            this.CreateMap<CategoryDTO, Category>(MemberList.Source);
            this.CreateMap<QuestionDTO, Question>(MemberList.Source);
            this.CreateMap<AnswerDTO, Answer>(MemberList.Source);
            this.CreateMap<ResultDTO, Result>(MemberList.Source);
        }
    }
}