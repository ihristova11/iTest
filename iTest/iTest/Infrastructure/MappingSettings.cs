using AutoMapper;
using iTest.Data.Models;
using iTest.DTO;
using iTest.Web.Areas.Admin.Models.Categories;
using iTest.Web.Areas.Admin.Models.ManageTest;

namespace iTest.Web.Infrastructure
{
    public class MappingSettings : Profile
    {
        public MappingSettings()
        {
            this.ViewModelsAndDtosMappings();
            this.DtosAndDataModelsMappings();
        }

        private void ViewModelsAndDtosMappings()
        {
            //Test:
            //From ViewModel to Dto
            this.CreateMap<CreateTestViewModel, TestDTO>(MemberList.Source)
                .ForMember(t => t.Questions, o => o.MapFrom(t => t.Questions))
                .ForPath(t => t.CategoryName, o => o.MapFrom(t => t.CategoryName))
                .ReverseMap();

            this.CreateMap<CreateQuestionViewModel, QuestionDTO>()
                .ForMember(q => q.Description, o => o.MapFrom((q => q.Description)))
                .ForMember(q => q.Answers, o => o.MapFrom(q => q.Answers));

            this.CreateMap<CreateAnswerViewModel, AnswerDTO>()
                .ForMember(a => a.Description, o => o.MapFrom(a => a.Description));

            this.CreateMap<AdminCategoryViewModel, CategoryDTO>()
                .ForMember(a => a.Name, o => o.MapFrom(a => a.Name))
                .ReverseMap();
        }

        private void DtosAndDataModelsMappings()
        {
            //Test:
            //From ViewModel to Dto
            this.CreateMap<Category, CategoryDTO>(MemberList.Source)
                .ForMember(c => c.Name, o => o.MapFrom(t => t.Name))
                .ReverseMap();

            this.CreateMap<Test, TestDTO>(MemberList.Source)
                .ForMember(t => t.Questions, o => o.MapFrom(t => t.Questions));
            
            this.CreateMap<TestDTO, Test>()
                .ForMember(t => t.Questions, o => o.MapFrom(t => t.Questions));

            this.CreateMap<QuestionDTO, Question>(MemberList.Source)
                .ForMember(q => q.Description, o => o.MapFrom((q => q.Description)))
                .ForMember(q => q.Answers, o => o.MapFrom(q => q.Answers));
            
            this.CreateMap<AnswerDTO, Answer>(MemberList.Source);
            this.CreateMap<ResultDTO, Result>(MemberList.Source);
        }
    }
}